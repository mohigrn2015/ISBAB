using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ResponseEntity
{
    public class LoginResponseModel
    {
        public bool is_Authenticated { get; set; }
        public string auth_essage { get; set; }
        public bool hasUpdate { get; set; }
        public string session_token { get; set; }
        public int right_id { get; set; }
        public string accessed_role { get; set; }
        public int userId { get; set; }
    }
}
