using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class Index : Daiv_OA.UI.BasicPage
    {
        //public string user = "admin";

        protected string urls = string.Empty;
        protected string time = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            time = "今天是" + DateTime.Now.ToString("yyyy年MM月dd日") + Day[Convert.ToInt16(DateTime.Now.DayOfWeek)];
            User_Load("", "/Index.aspx", 0);
            string us = Convert.ToString(Session["UserName"]);
            if (string.IsNullOrEmpty(us))
            {
                Response.Redirect("Login.aspx");

            }
            else
            {
                if (!IsPostBack)
                {
                  
                    if (UserPowerId != 1)
                    {
                      
                        urls = "DeskTop" + UserPowerId + ".aspx";
                    }
                }
            }
          
        }
    }
}