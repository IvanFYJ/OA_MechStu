using System;
using System.Collections.Generic;
using System.Text;

namespace Daiv_OA.Utils
{
    public class logHelper
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("logHelper");

        /// <summary>
        /// 打印信息
        /// </summary>
        /// <param name="msg"></param>
        public static void logInfo(string msg)
        {
            log.Info(msg);
        }
    }
}
