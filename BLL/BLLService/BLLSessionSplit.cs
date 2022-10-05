using BLL.BLLInterfaces;
using BLL.BLLUtility;
using BLL.Common;
using DAL.DALInterfaces;
using Entity.RequestEntity;
using Entity.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.BLLService
{
    public class BLLSessionSplit : ISessionSplit
    {
        private ISecurity _sessionSplit;
        public BLLSessionSplit(ISecurity sessionSplit)
        { 
            _sessionSplit = sessionSplit;
        }
        public SequrityValue ValidateSessionToken(string sessionToken) 
        {
            int tokenValue = 0;
            TokenValidationRequest model = new TokenValidationRequest();
            SequrityValue sequrityValue = new SequrityValue();

            try
            {

                string decryptToken = AESCriptography.Decrypt(sessionToken);
                sequrityValue = GetDataFromSecurityToken(decryptToken);

                model.tokenProviderId = sequrityValue.loginProvider;
                model.userId = sequrityValue.userId;
                sequrityValue.userId = sequrityValue.userId;

                tokenValue = _sessionSplit.ValidateSessionToken(model);

                if (tokenValue == 1)
                {
                    sequrityValue.isSessionValid = tokenValue;
                }
                else
                {
                    sequrityValue.isSessionValid= 0;
                }
                return sequrityValue;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public SequrityValue GetDataFromSecurityToken(string decryptedSessiontoken)
        {
            SequrityValue data = new SequrityValue();
            try
            {
                string[] tokenProperties = StringFormatCollection.AccessTokenPropertyArray;
                var splitedDataList = decryptedSessiontoken.Split(tokenProperties, StringSplitOptions.None);

                if (tokenProperties.Length <= splitedDataList.Count())
                {
                    for (int i = 0; i < splitedDataList.Count(); i++)
                    {
                        if (i == 0)
                            data.loginProvider = splitedDataList[i].ToString();
                        if (i == 1)
                            data.userId = Convert.ToInt32(splitedDataList[i]);
                        if (i == 2)
                            data.userName = splitedDataList[i].ToString();
                        if (i == 3)
                            data.rightId = Convert.ToInt32(splitedDataList[i]);
                        if (i == 4)
                            data.role = splitedDataList[i].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

    }
}
