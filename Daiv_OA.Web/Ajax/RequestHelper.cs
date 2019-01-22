using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Daiv_OA.Web.Ajax
{
    public class RequestHelper
    {
        /// <summary>
        /// 字符流转换成Jsno对象
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static JObject StreamToString(Stream s)
        {
            //创建流的对象
            var sr = new StreamReader(s);
            //读取request的流：Json字符
            var stream = sr.ReadToEnd().ToString();
            //讲读取到的字符用字典存储
            Dictionary<string, object> str = (Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(stream);

            JObject jo = new JObject();

            foreach (var item in str)
            {
                //把字典转换成Json对象
                jo.Add(item.Key, item.Value.ToString());

            }
            return jo;
        }
    }
}