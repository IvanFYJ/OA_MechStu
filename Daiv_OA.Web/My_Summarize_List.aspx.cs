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
    public partial class My_Summarize_List : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            if (!this.Page.IsPostBack)
            {
                Selectplan(" and uid = " + UserId + " ");
            }
        }

        /// <summary>
        /// 工作总结
        /// </summary>
        public void Selectplan(string str)
        {

            int count;
            BLL.SummarizeBLL bll = new Daiv_OA.BLL.SummarizeBLL();
            this.Plan_repeater.DataSource = bll.getpage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count, str);
            this.Plan_repeater.DataBind();
            AspNetPager1.RecordCount = count;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Selectplan(" and uid = " + UserId + " ");
            }
        }
        public string ShowEditLink(string id, string locked)
        {
            if (locked == "0")
                return "<a href=\"My_Summarize_Edit.aspx?id=" + id + "\">编辑</a>";
            else
                return "<span style=\"color:#eee\">编辑</a>";
        }
    }
}
