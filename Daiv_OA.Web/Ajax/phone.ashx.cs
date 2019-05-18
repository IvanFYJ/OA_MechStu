using Daiv_OA.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Daiv_OA.Web.Ajax
{
    /// <summary>
    /// phone 的摘要说明
    /// </summary>
    public class phone : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string schoolnumber = HttpContext.Current.Request.QueryString["schoolnumber"];
            string phonenum = HttpContext.Current.Request.QueryString["phonenum"];

            if (string.IsNullOrEmpty(schoolnumber) && string.IsNullOrEmpty(phonenum))
            {
                try
                {
                    JObject ob = StreamToString(HttpContext.Current.Request.InputStream);
                    if (ob["schoolnumber"] != null && ob["phonenum"] != null)
                    {
                        schoolnumber = ob["schoolnumber"].ToString();
                        phonenum = ob["phonenum"].ToString();
                    }
                }
                catch (Exception ex)
                {

                }
            }
            logHelper.logInfo(" phonelist params：schoolnumber：" + schoolnumber + " phonenum:" + phonenum);
            //获取情亲号
            BLL.ContactBLL cbll = new BLL.ContactBLL();
            Hashtable list = cbll.GetPhoneListBySchoolAndPhonenum(schoolnumber, phonenum);
            List<string> resultList = new List<string>();
            if (list != null && !string.IsNullOrEmpty(list["Cphone"].ToString()))
            {
                resultList.Add("Result:True");
            }
            else
            {
                resultList.Add("Result:False");
            }
            context.Response.Write(string.Join(",", resultList));
        }

        /// <summary>
        /// 字符流转换成Jsno对象
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static JObject StreamToString(Stream s)
        {
            return RequestHelper.StreamToString(s);
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