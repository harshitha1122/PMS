using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Helper
{
    public class StringHelper
    {
        public static Boolean GetTrueOrFalse(string value)
        {
            if (value.Equals("0"))
            {
                return true;
            }
            else if(value.Equals("1"))
            {
                return false;
            }
            return false;
        }
    }
}
