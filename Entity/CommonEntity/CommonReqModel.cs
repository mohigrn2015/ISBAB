using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.CommonEntity
{
    public class CommonReqModel
    {
        [Required]
        public string sessionToken { get; set; }
    }
}
