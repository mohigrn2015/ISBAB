using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Common
{
    public static class MessageCollection
    {
        public static string ValidUser { get { return "User is Valid!"; } }
        public static string InvalidUser { get { return "Invalid User"; } }
        public static string SuccessFullyReg { get { return "Successfully Registered!"; } }
    }
}
