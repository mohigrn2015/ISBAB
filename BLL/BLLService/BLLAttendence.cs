using BLL.BLLInterfaces;
using Entity.RequestEntity;
using Entity.ResponseEntity;
using DAL.DALInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BLLService
{
    public class BLLAttendence : IBLLAttendence
    {
        private IAttendence _attendence;
        public BLLAttendence(IAttendence attendence)
        {
            _attendence = attendence;
        }
        public List<CheckinResponseModel> CheckInSubmit(AttendanceReqModel attendance)
        {
            List < CheckinResponseModel > checkinResponses = new List < CheckinResponseModel >();
            checkinResponses = _attendence.CheckIn(attendance);
            return checkinResponses;
        }

        public List<CheckinResponseModel> CheckOutSubmit(AttendanceReqModel attendance)
        {
            List<CheckinResponseModel> checkinResponses = new List<CheckinResponseModel>();
            checkinResponses = _attendence.CheckOut(attendance);
            return checkinResponses;
        }

        public List<CheckinResponseModel> GetAttendanceData(int userId)
        {
            List<CheckinResponseModel> checkinResponses = new List<CheckinResponseModel>();
            checkinResponses = _attendence.GetAttendance(userId);
            return checkinResponses;
        }
    }
}
