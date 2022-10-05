using Entity.RequestEntity;
using Entity.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BLLInterfaces
{
    public interface IBLLAttendence 
    {
        List<CheckinResponseModel> CheckInSubmit(AttendanceReqModel attendance);
        List<CheckinResponseModel> GetAttendanceData(int userId);
        List<CheckinResponseModel> CheckOutSubmit(AttendanceReqModel attendance);
    }
}
