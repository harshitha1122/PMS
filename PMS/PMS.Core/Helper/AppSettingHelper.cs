using PMS.Core.Constants;
using PMS.Core.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Helper
{
    public class AppSettingHelper
    {
        public static string GetConnectionString()
        {

            return ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString;
        }

        public static string GetConnectionString(string dbName)
        {
            return ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
        }

        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static Boolean IsSqlLoggingEnable
        {
            get
            {
                return StringHelper.GetTrueOrFalse(GetValue(AppConfigConstants.IsSqlLoggingEnable));
            }
        }

        public static Boolean IsSendEmailEnable
        {
            get
            {
                return StringHelper.GetTrueOrFalse(GetValue(AppConfigConstants.IsSendEmailEnable));
            }
        }


    }
}
