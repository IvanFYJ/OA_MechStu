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
    public partial class My_Callinfo_List : Daiv_OA.UI.BasicPage
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
            BLL.CallinfoBLL bll = new Daiv_OA.BLL.CallinfoBLL();
            this.Repeater_Callinfo.DataSource = bll.getpage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count, str);
            this.Repeater_Callinfo.DataBind();
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
