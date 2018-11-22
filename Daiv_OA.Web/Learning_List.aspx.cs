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
    public partial class Learning_List : Daiv_OA.UI.BasicPage
    {
        protected string wherestr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("learning-show");
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
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbEdit_Click(object sender, CommandEventArgs e)
        {
            User_Load("learning-edit");
            if (new Daiv_OA.BLL.LearningBLL().GetEntity(Convert.ToInt32(e.CommandArgument)).Sauthor != UserName)
            {
                FinalMessage("无权修改别人发布的学习资料", "", 1);
            }
            Response.Redirect("Learning_Edit.aspx?id=" + e.CommandArgument);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbDel_Click(object sender, CommandEventArgs e)
        {
            User_Load("learning-del");
            if (new Daiv_OA.BLL.LearningBLL().GetEntity(Convert.ToInt32(e.CommandArgument)).Sauthor != UserName)
            {
                FinalMessage("无权删除别人发布的学习资料", "", 1);
            }
            new Daiv_OA.BLL.LearningBLL().Delete(Convert.ToInt32(e.CommandArgument));
            Selectinfo(wherestr);
        }
    }
}
