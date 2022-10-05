using Entity.RequestEntity;
using Entity.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DALInterfaces
{
    public interface ISecurity
    {
        ValidateUserModel ValidateUser(string user_name, string encPassword);
        long SaveLoginInfo(UserLoginAttempts attempts);
        long SaveEmployee(RegistrationModel model);
        int ValidateSessionToken(TokenValidationRequest model);
    }
}
