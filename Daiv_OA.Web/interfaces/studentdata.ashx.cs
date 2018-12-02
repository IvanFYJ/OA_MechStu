using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Daiv_OA.Web.interfaces
{
    /// <summary>
    /// studentdata 的摘要说明
    /// </summary>
    public class studentdata : IHttpHandler
    {
        /// <summary>
        /// 获取学生数据
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            string user = Convert.ToString(context.Session["UserName"]);
            string pagesize = HttpContext.Current.Request.QueryString["pagesize"];
            string pageindex = HttpContext.Current.Request.QueryString["pageindex"];
            string mPhone = HttpContext.Current.Request.QueryString["mPhone"];

            context.Response.ContentType = "text/plain";

            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}