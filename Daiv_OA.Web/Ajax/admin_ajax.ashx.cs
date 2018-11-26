using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;
using Daiv_OA.DBUtility;


namespace DTcms.Web.tools
{
    /// <summary>
    /// 管理后台AJAX处理页
    /// </summary>
    public class admin_ajax : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = HttpContext.Current.Request.QueryString["action"];  // .QueryString("action");

            switch (action)
            {
                case "sys_channel_load": //加载频道管理菜单
                    sys_channel_load(context);
                    break;
               
            }

        }

        //#region 加载频道管理菜单================================
        private void sys_channel_load(HttpContext context)
        {
            string user =Convert.ToString(context.Session["UserName"]);
            StringBuilder strTxt = new StringBuilder();
          
            strTxt.Append("[");
            int i = 1;
            
                strTxt.Append("{");
                strTxt.Append("\"text\":\"" + "菜单展示"+ "\",");
                strTxt.Append("\"isexpand\":\"false\",");
                strTxt.Append("\"children\":[");
              
                  int j = 1;
                  string SQL = null;
                  if (!string.IsNullOrEmpty(user))  {
                      SQL = "SELECT Setting FROM dbo.OA_User WHERE Uname='"+user+"'";
                      DataSet ds = DbHelperSQL.Query(SQL);
                      string[] rols = (ds.Tables[0].Rows[0]["Setting"].ToString()).Split(',') ;
                         foreach (string rol in rols ){
                             if (!string.IsNullOrEmpty(rol))
                             {
                                 string sqltitle = "SELECT title,url FROM  OA_Url WHERE rol LIKE '%" + rol + "%' and Rol NOT IN ('learning-edit','placard-edit','task-edit','user-edit','user-edit','grade-edit','grade-add','student-add','student-edit','pm-add','pm-edit') ";
                                 DataSet dstitle = DbHelperSQL.Query(sqltitle);
                                 if (dstitle.Tables[0].Rows.Count>0) { 
                                 string title = dstitle.Tables[0].Rows[0]["title"].ToString().Trim();
                                 string url = dstitle.Tables[0].Rows[0]["url"].ToString().Trim();
                                 strTxt.Append("{");
                                 strTxt.Append("\"text\":\"" + title + "\",");
                                 strTxt.Append("\"url\":\"" + url + "\""); //此处要优化，加上nav.nav_url网站目录标签替换
                                 strTxt.Append("},");
                                 //if (j < model2.sys_model_navs.Count)
                                 //{
                                 //    strTxt.Append(",");
                                 //}
                                 j++;
                                 }
                             }
                         }
                  }
                strTxt.Append("]");
                strTxt.Append("}");
                strTxt.Append(",");
                i++;
           
            string newTxt = DelLastChar(strTxt.ToString(), ",") + "]";
            context.Response.Write(newTxt);
            return;
        }
        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        public static string DelLastChar(string str, string strchar)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            if (str.LastIndexOf(strchar) >= 0 && str.LastIndexOf(strchar) == str.Length - 1)
            {
                return str.Substring(0, str.LastIndexOf(strchar));
            }
            return str;
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