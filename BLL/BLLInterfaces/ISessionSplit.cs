using Entity.RequestEntity;
using Entity.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BLLInterfaces
{
    public interface ISessionSplit
    {
        SequrityValue ValidateSessionToken(string sessionToken); 
        SequrityValue GetDataFromSecurityToken(string decryptedSessiontoken);
    }
}
