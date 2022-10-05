using BLL.BLLInterfaces;
using BLL.BLLUtility;
using Entity.ResponseEntity;
using ISBAB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ISBAB.Controllers
{    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ISessionSplit _sessionValue;
        private IBLLAttendence _attendence;
        public HomeController(ILogger<HomeController> logger, ISessionSplit session, IBLLAttendence attendence)
        {
            _logger = logger;
            _sessionValue = session;
            _attendence = attendence;
        }

        public IActionResult Index()
        {
            SequrityValue sequrityValue = new SequrityValue();
            List<CheckinResponseModel> listOfAttendence = new List<CheckinResponseModel>();
            try
            {
                var sessionValue = this.HttpContext.Session.GetString("sessionToken");

                if (!string.IsNullOrEmpty(sessionValue))
                {
                    ViewBag.RightId = this.HttpContext.Session.GetString("right"); 

                    return View();
                }
                else
                {
                    ViewBag.message = "Invalid Session!";
                    return RedirectToAction("Index", "Security");
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = "Invalid Session!";
                return RedirectToAction("Index", "Security");
            }

            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
