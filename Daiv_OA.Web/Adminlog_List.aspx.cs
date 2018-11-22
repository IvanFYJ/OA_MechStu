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
//下载于51aspx.com
namespace Daiv_OA.Web
{
    public partial class Adminlog_List : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("adminlog-show");
            if (!this.Page.IsPostBack)
            {
                Select_log("");
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Select_log("");
            }
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        public void Select_log(string str)
        {

            int count;
            BLL.AdminlogBLL bll = new Daiv_OA.BLL.AdminlogBLL();
            this.pro_repeater.DataSource = bll.getpage(20, AspNetPager1.CurrentPageIndex, out count, str);
            this.pro_repeater.DataBind();
            AspNetPager1.RecordCount = count;
        }
    }
}
