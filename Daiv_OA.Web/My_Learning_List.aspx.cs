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
    public partial class My_Learning_List : Daiv_OA.UI.BasicPage
    {
        protected string wherestr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("my_learning-show");
            wherestr = " and [OA_Learning].Did in (" + UserDepartmentId + ",0)";
            if (!this.Page.IsPostBack)
            {
                Selectinfo(wherestr);
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        public void Selectinfo(string str)
        {

            int count;
            BLL.LearningBLL bll = new Daiv_OA.BLL.LearningBLL();
            this.Sinfo_repeater.DataSource = bll.getpage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count, str);
            this.Sinfo_repeater.DataBind();
            AspNetPager1.RecordCount = count;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Selectinfo(wherestr);
            }
        }
    }
}
