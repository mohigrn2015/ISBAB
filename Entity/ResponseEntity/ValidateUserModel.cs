using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ResponseEntity
{
    public class ValidateUserModel
    {
        public int userId { get; set; }
        public string session_token { get; set; }
        public int right_id { get; set; }
        public string accessed_role { get; set; }
        public string userName { get; set; }
        public string device_Id { get; set; }
        public int is_success { get; set; }
    }
}
