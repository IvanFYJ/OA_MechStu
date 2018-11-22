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
    public partial class Placard_List : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("placard-show");
            if (!this.Page.IsPostBack)
            {
                Selectinfo("");
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        public void Selectinfo(string str)
        {

            int count;
            BLL.PlacardBLL bll = new Daiv_OA.BLL.PlacardBLL();
            this.Repeater_Placard.DataSource = bll.getpage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count, str);
            this.Repeater_Placard.DataBind();
            AspNetPager1.RecordCount = count;
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Selectinfo("");
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbEdit_Click(object sender, CommandEventArgs e)
        {
            User_Load("placard-edit");
            if (new Daiv_OA.BLL.PlacardBLL().GetEntity(Convert.ToInt32(e.CommandArgument)).Pauthor != UserName)
            {
                FinalMessage("无权修改别人发布的公告通知", "", 1);
            }
            Response.Redirect("Placard_Edit.aspx?id=" + e.CommandArgument);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbDel_Click(object sender, CommandEventArgs e)
        {
            User_Load("placard-del");
            if (new Daiv_OA.BLL.PlacardBLL().GetEntity(Convert.ToInt32(e.CommandArgument)).Pauthor != UserName)
            {
                FinalMessage("无权删除别人发布的公告通知", "", 1);
            }
            new Daiv_OA.BLL.PlacardBLL().Delete(Convert.ToInt32(e.CommandArgument));
            Selectinfo("");
        }
    }
}
