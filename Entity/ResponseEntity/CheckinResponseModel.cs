﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ResponseEntity
{
    public class CheckinResponseModel
    {
        public int userId { get; set; }
        public string checkinDate { get; set; }
        public string checkinTime { get; set; }
        public string checkoutTime { get; set; }
        public string overTime { get; set; }
        public int leaveDaysCount { get; set; }
        public int absentDaysCount { get; set; }
        public int holidaysCount { get; set; }
        public int weekendDaysCount { get; set; }
        public int lateDaysCount { get; set; }
        public string attendenceStatus { get; set; }
    }
}
