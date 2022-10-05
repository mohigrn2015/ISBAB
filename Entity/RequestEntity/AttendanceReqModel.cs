using Entity.CommonEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.RequestEntity
{
    public class AttendanceReqModel : CommonReqModel
    {
        public DateTime checkinTime { get; set; }
        public DateTime checkoutTime { get; set; }
        public int userId { get; set; }
        public string loginProvider { get; set; }
    }
}
