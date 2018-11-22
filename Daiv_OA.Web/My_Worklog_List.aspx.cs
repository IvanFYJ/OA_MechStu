using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Daiv_OA.Web
{
    public partial class My_Worklog_List : Daiv_OA.UI.BasicPage
    {
        public string where = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            where = " and uid = " + UserId + " ";
            if (!this.Page.IsPostBack)
            {
                Selectinfo(where);
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        public void Selectinfo(string str)
        {

            int count;
            BLL.WorklogBLL bll = new Daiv_OA.BLL.WorklogBLL();
            this.Repeater_Worklog.DataSource = bll.getpage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count, str);
            this.Repeater_Worklog.DataBind();
            AspNetPager1.RecordCount = count;
        }

        /// <summary>
        /// 分页
        /// </summary>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Selectinfo(where);
        }
    }
}
