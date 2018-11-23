using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Timers;

namespace Daiv_OA.Web
{
    public class Global : System.Web.HttpApplication
    {
        public static HttpContext myContext = HttpContext.Current;

        protected void Application_Start(object sender, EventArgs e)
        {
            //项目启动加载
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/Web.config")));

            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(TimeEvent);
            aTimer.Interval = 10000;// 设置引发时间的时间间隔　此处设置为１0秒
            aTimer.Enabled = true;
        }
        private void TimeEvent(object source, ElapsedEventArgs e)
        { 
           

        }
        private string ServerUrl()
        {
            if (myContext.Request.Url.Port == 80)
                return "http://" + myContext.Request.Url.Host;
            else
                return "http://" + myContext.Request.Url.Host + ":" + myContext.Request.Url.Port;
        }
        private string AppPath()
        {
            string _ApplicationPath = myContext.Request.ApplicationPath;
            if (_ApplicationPath != "/")
                _ApplicationPath += "/";
            return _ApplicationPath;
        }
        private string GetHttpPage(string url)
        {
            string strResult = string.Empty;
            try
            {
                System.Net.WebClient MyWebClient = new System.Net.WebClient();
                MyWebClient.Credentials = System.Net.CredentialCache.DefaultCredentials;
                MyWebClient.Encoding = System.Text.Encoding.UTF8;
                strResult = MyWebClient.DownloadString(url);
            }
            catch (Exception)
            {
                strResult = "页面获取失败";
            }
            return strResult;
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}