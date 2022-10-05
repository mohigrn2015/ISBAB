using System;
using System.Collections.Generic;
using System.Text;
using Entity.CommonEntity;

namespace Entity.RequestEntity
{
    public class TokenValidationRequest : CommonReqModel 
    {
        public string tokenProviderId { get; set; }
        public int userId { get; set; }
    }
}
