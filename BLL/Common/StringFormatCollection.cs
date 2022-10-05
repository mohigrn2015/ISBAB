﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Common
{
    public static class StringFormatCollection
    {
        public static string AccessTokenFormat
        {
            get
            {
                return "{0},uid:{1},uname:{2},rightId:{3},role:{4}";
            }
        }

        public static string[] AccessTokenPropertyArray
        {
            get
            {
                return new string[] { ",uid:", ",uname:", ",rightId:", ",role:" };
            }
        }
    }
}
