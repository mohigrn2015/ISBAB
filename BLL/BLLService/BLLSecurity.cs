using BLL.BLLInterfaces;
using DAL.DALInterfaces;
using Entity.RequestEntity;
using Entity.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BLLService
{
    public class BLLSecurity : IBLLSecurity
    {
        private ISecurity _security;
        public BLLSecurity(ISecurity security)
        {
            _security = security;
        }
        public long Register(RegistrationModel model)
        {
            long insertedId = 0; 
            insertedId = _security.SaveEmployee(model);
            return insertedId;
        }
        public long SaveLoginAttempts(UserLoginAttempts attempts)
        {
            long insertedId = 0;
            insertedId = _security.SaveLoginInfo(attempts);
            return insertedId;  
        }
        public ValidateUserModel ValidateUsers(string user_name, string encPassword)
        {
            ValidateUserModel users = new ValidateUserModel();
            users = _security.ValidateUser(user_name, encPassword);
            return users;
        }
    }
}
