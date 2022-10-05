using Entity.ResponseEntity;
using Entity.RequestEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DALInterfaces
{
    public interface IAttendence
    {
        List<CheckinResponseModel> CheckIn(AttendanceReqModel attendance);
        List<CheckinResponseModel> GetAttendance(int userId);
        List<CheckinResponseModel> CheckOut(AttendanceReqModel attendance); 
    }
}
