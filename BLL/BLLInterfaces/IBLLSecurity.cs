using Entity.RequestEntity;
using Entity.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BLLInterfaces
{
    public interface IBLLSecurity
    {
        ValidateUserModel ValidateUsers(string user_name, string encPassword);
        long SaveLoginAttempts(UserLoginAttempts attempts);
        long Register(RegistrationModel model); 
         
    }
}
