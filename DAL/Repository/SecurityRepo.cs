using DAL.DALInterfaces;
using DAL.FacadeBiz;
using DAL.Utility;
using Dapper;
using Entity;
using Entity.RequestEntity;
using Entity.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class SecurityRepo : ISecurity
    {
        LogsHandler _logsHandler = new LogsHandler();
        DynamicParams _dynamic = new DynamicParams();
        public ValidateUserModel ValidateUser(string user_name, string encPassword)
        {
            ValidateUserModel userModel = new ValidateUserModel();
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(Context.ConnectionString))
                {
                    if (constr.State == ConnectionState.Closed)
                        constr.Open();

                    var validateData = constr.Query<ValidateUserModel>("UG_VALIDATE_USER", _dynamic.ValidateUserCredential(user_name, encPassword), commandType: CommandType.StoredProcedure);

                    if (validateData != null && validateData.Count() > 0)
                    {
                        userModel = validateData.SingleOrDefault();
                        userModel.is_success = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler = new LogsHandler();
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }

            return userModel;
        }
        public long SaveEmployee(RegistrationModel model)
        {
            long inserted = 0;
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(Context.ConnectionString))
                {
                    if (constr.State == ConnectionState.Closed)
                        try { constr.Open(); } catch (Exception ex) { throw new Exception(ex.Message.ToString()); }

                    var attemp = constr.Query<RegistrationModel>("US_ADD_EMPLOYEES", _dynamic.SetParametersInsertEmployee(model), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        inserted = Convert.ToInt32(attemp.SingleOrDefault());
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return inserted;
        }

        public long SaveLoginInfo(UserLoginAttempts attempts)
        {
            long inserted = 0;
            _dynamic = new DynamicParams();
            try
            {
                using (IDbConnection constr = new SqlConnection(Context.ConnectionString))
                {
                    if (constr.State == ConnectionState.Closed)
                        constr.Open();

                    var attemp = constr.Query<UserLoginAttempts>("US_ADD_LOGIN_ATTEMPTS", _dynamic.SetParametersInsert(attempts), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        inserted = Convert.ToInt32(attemp.SingleOrDefault());
                    }
                }
            }
            catch (Exception ex)
            {
                _logsHandler.Log("[Exception] " + ex.Message + " Stace Trace: " + ex.StackTrace.ToString());
            }
            return inserted;
        }
         
        public int ValidateSessionToken(TokenValidationRequest model)
        {
            DynamicParams _dynamic = new DynamicParams();
            int isValidToken = 0;
            try
            {              
                using (IDbConnection constr = new SqlConnection(Context.ConnectionString))
                {
                    if (constr.State == ConnectionState.Closed)
                        constr.Open();

                    var attemp = constr.Query<SequrityValue>("UG_VALIDATE_SESSIONTOKEN", _dynamic.TokenValidate(model.tokenProviderId, model.userId), commandType: CommandType.StoredProcedure);

                    if (attemp != null && attemp.Count() > 0)
                    {
                        foreach (var item in attemp)
                        {
                            isValidToken = Convert.ToInt16(item.isSessionValid);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return isValidToken;
        }
    }
}
