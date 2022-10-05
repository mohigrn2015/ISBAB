using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.RequestEntity
{
    public class UserLoginAttempts
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string loginProvider { get; set; }
        public string deviceId { get; set; }
        public string ip_address { get; set; }
        public string version { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
