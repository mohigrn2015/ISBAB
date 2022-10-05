using BLL.BLLInterfaces;
using Entity.RequestEntity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BLL.BLLUtility;
using BLL.Common;
using System;
using Entity.ResponseEntity;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Entity.CommonEntity;

namespace ISBAB.Controllers
{
    
    public class SecurityController : Controller
    {
        private IBLLSecurity _security;
        public SecurityController(IBLLSecurity security)
        {
            _security = security;   
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[Route("Login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            try
            {
                UserLoginAttempts attempts = new UserLoginAttempts();
                string passWord = AESCriptography.Encrypt(login.password);
                string loginProvider = Guid.NewGuid().ToString();

                ValidateUserModel userModel = _security.ValidateUsers(login.user_name, passWord);

                if (userModel.is_success == 0)
                {
                    return Ok(new LoginResponseModel()
                    {
                        is_Authenticated = false,
                        auth_essage = MessageCollection.InvalidUser,
                        hasUpdate = false,
                        session_token = "",
                        right_id = 0,
                        accessed_role = ""
                    });
                }

                attempts = new UserLoginAttempts()
                {
                    userId = userModel.userId,
                    userName = login.user_name,
                    loginProvider = loginProvider,
                    deviceId = login.device_id,
                    ip_address = "",
                    latitude = login.latitude,
                    longitude = login.longitude
                };

                Thread saveThread = new Thread(() => _security.SaveLoginAttempts(attempts));
                saveThread.Start();
                string accessToken = AESCriptography.Encrypt(String.Format(StringFormatCollection.AccessTokenFormat, loginProvider, userModel.userId, userModel.userName, userModel.right_id, userModel.accessed_role,Guid.NewGuid()));
                HttpContext.Session.SetString("sessionToken",accessToken);
                HttpContext.Session.SetString("right", userModel.right_id.ToString());
                return Ok(new LoginResponseModel()
                {
                    is_Authenticated = true,
                    auth_essage = MessageCollection.ValidUser,
                    hasUpdate = false,
                    session_token = accessToken,
                    right_id = userModel.right_id,
                    accessed_role = userModel.accessed_role,
                    userId = userModel.userId
                });

            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.RightId = this.HttpContext.Session.GetString("right");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationModel registration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string encPassword = AESCriptography.Encrypt(registration.password);
                    registration.password = encPassword;
                    long saveUser = _security.Register(registration);
                }
                else
                {
                    return RedirectToAction("Register");
                }
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
