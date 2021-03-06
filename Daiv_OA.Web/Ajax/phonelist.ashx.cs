﻿using Daiv_OA.Utils;
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
    /// phonelist 的摘要说明
    /// </summary>
    public class phonelist : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string schoolnumber = HttpContext.Current.Request.QueryString["schoolnumber"];
            string datetime = HttpContext.Current.Request.QueryString["datetime"];
            string pageindex = HttpContext.Current.Request.QueryString["pageindex"];
            string pagesize = HttpContext.Current.Request.QueryString["pagesize"];

            if (string.IsNullOrEmpty(schoolnumber) && string.IsNullOrEmpty(datetime))
            {
                try
                {
                    JObject ob = StreamToString(HttpContext.Current.Request.InputStream);
                    if (ob["schoolnumber"] != null && ob["datetime"] != null)
                    {
                        schoolnumber = ob["schoolnumber"].ToString();
                        datetime = ob["datetime"].ToString();
                    }
                }
                catch (Exception ex)
                {

                }
            }
            logHelper.logInfo(" phonelist params：schoolnumber：" + schoolnumber + " datetime:" + datetime );
            //获取情亲号
            BLL.ContactBLL cbll = new BLL.ContactBLL();
            IList<Hashtable> list=  cbll.GetPhoneListBySchoolAndDate(schoolnumber, datetime,pageindex,pagesize);
            List<string> resultList = new List<string>();
            if(list != null && list.Count > 0)
            {
                resultList.Add("[" + list[0]["Total"] + "]");
                resultList.Add("[" + list[0]["MaxDate"] + "]");
                foreach (var item in list)
                {
                    resultList.Add("["+item["Cphone"].ToString()+"]");
                }
                resultList.Add("[END]");
            }else
            {
                //如果没查询结果，则查询情亲号最大的修改时间。
                Hashtable ht = cbll.GetMaxCreatTime();
                if(ht != null && ht["CreatDate"] != null)
                {
                    resultList.Add("[" + ht["CreatDate"].ToString() + "]");
                }
                resultList.Add("[NO RECORD]");
            }
            context.Response.Write(string.Join(",",resultList));
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