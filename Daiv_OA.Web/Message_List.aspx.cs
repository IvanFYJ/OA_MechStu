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
    public partial class Message_List : Daiv_OA.UI.BasicPage
    {
        protected string wherestr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("message-show");
            wherestr = " and [OA_Message].ToUid=" + UserId;
            if (!this.Page.IsPostBack)
            {
                Selectinfo(wherestr);
            }
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        public void Selectinfo(string str)
        {
            int count;
            Daiv_OA.BLL.MessageBLL bll = new Daiv_OA.BLL.MessageBLL();
            this.Repeater_Message.DataSource = bll.getpage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count, str);
            this.Repeater_Message.DataBind();
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
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbDel_Click(object sender, CommandEventArgs e)
        {
            User_Load("message-del");
            new Daiv_OA.BLL.MessageBLL().Delete(Convert.ToInt32(e.CommandArgument));
            Selectinfo(wherestr);
        }
    }
}
