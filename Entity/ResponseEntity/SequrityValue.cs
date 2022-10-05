using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ResponseEntity
{
    public class SequrityValue
    {
        public string loginProvider { get; set; }
        public int userId { get; set; }
        public int rightId { get; set; }
        public string userName { get; set; }
        public string role { get; set; }
        public int isSessionValid { get; set; }
    }
}
