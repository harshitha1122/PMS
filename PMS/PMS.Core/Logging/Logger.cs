using PMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Core.Logging
{
    public class Logger
    {
        ILogger logger = null;
        private Logger()
        {
            logger = new FileLogger();
        }

        public Logger(LoggerEnum loggerEnum)
        {
            //Factory Design Pattern
            if(loggerEnum == LoggerEnum.DataBase)
            {
                logger = new DbLogger();
            }
            else if(loggerEnum == LoggerEnum.File)
            {
                logger = new FileLogger();
            }
            else
            {
                logger = new  EmailLogger();
            }
        }

        public void Log()
        {
            logger.Log();
        }
    }
}
