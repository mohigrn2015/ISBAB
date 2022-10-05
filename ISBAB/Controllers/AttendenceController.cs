using Microsoft.AspNetCore.Mvc;
using BLL.BLLInterfaces;
using Entity.ResponseEntity;
using System.Collections.Generic;
using Entity.RequestEntity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ISBAB.Controllers
{
    public class AttendenceController : Controller
    {
        private IBLLAttendence _attendence;
        private ISessionSplit _sessionSplit;
        public AttendenceController(ISessionSplit sessionSplit, IBLLAttendence attendence)
        {
            _sessionSplit = sessionSplit;
            _attendence = attendence;
        }
        public IActionResult Index()
        {
            ViewBag.RightId = this.HttpContext.Session.GetString("right");
            return View();
        }

        [HttpPost]
        public JsonResult CheckIn(AttendanceReqModel checkin)
        {
            SequrityValue sequrityValue = new SequrityValue();
            List<CheckinResponseModel> data = new List<CheckinResponseModel>();
            try
            {
                sequrityValue = _sessionSplit.ValidateSessionToken(checkin.sessionToken);
                if (sequrityValue.isSessionValid == 0)
                {
                    ViewBag.Message = "Invalid Session!";
                }
                checkin.userId = sequrityValue.userId;
                checkin.checkinTime = System.DateTime.Now;
                _attendence.CheckInSubmit(checkin);

                data = _attendence.GetAttendanceData(sequrityValue.userId);
            }
            catch (System.Exception)
            {
                throw;
            }
            return Json(data);
        }
         
        [HttpPost]
        public JsonResult CheckOut(AttendanceReqModel checkout)
        {
            SequrityValue sequrityValue = new SequrityValue();
            List<CheckinResponseModel> data = new List<CheckinResponseModel>();
            try
            {
                sequrityValue = _sessionSplit.ValidateSessionToken(checkout.sessionToken);
                if (sequrityValue.isSessionValid == 0)
                {    
                    ViewBag.Message = "Invalid Session!";
                }
                checkout.userId = sequrityValue.userId;
                checkout.checkoutTime = System.DateTime.Now;
                _attendence.CheckOutSubmit(checkout);

                data = _attendence.GetAttendanceData(sequrityValue.userId);
            }
            catch (System.Exception)
            {
                throw;
            }
            return Json(data);
        } 

        [HttpPost]
        public JsonResult GetAttendence(AttendanceReqModel model)
        {
            SequrityValue sequrityValue = new SequrityValue();
            List<CheckinResponseModel> data = new List<CheckinResponseModel>();
            try
            {
                if(model.sessionToken != null)
                {
                    sequrityValue = _sessionSplit.ValidateSessionToken(model.sessionToken);
                    if (sequrityValue.isSessionValid == 0)
                    {
                        ViewBag.Message = "Invalid Session!";
                    }
                    data = _attendence.GetAttendanceData(sequrityValue.userId);
                }               
            }
            catch (System.Exception)
            {
                throw;
            }
            return Json(data);
        }
    }
}
