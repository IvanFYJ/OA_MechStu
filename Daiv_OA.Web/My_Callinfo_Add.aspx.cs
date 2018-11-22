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
using Layers.Common;

namespace Daiv_OA.Web
{
    public partial class My_Callinfo_Add : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            if (!this.Page.IsPostBack)
            {
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.CallinfoEntity callinfo = new Entity.CallinfoEntity();
            callinfo.Uid = UserId;
            callinfo.Addtime = Convert.ToDateTime(this.txtAddtime.Text);
            callinfo.Title = this.txtTitle.Text;
            callinfo.Unit = this.txtUnit.Text;
            callinfo.Reply = this.txtReply.Text;
            callinfo.Userinfo = this.txtUserinfo.Text;
            callinfo.Remark = this.kindeditor.Value;
            int i = new Daiv_OA.BLL.CallinfoBLL().Add(callinfo);
            if (i > 0)
            {
                FinalMessage("操作成功", "My_Callinfo_List.aspx", 0);
            }
            else
            {
                FinalMessage("操作失败", "My_Callinfo_List.aspx", 0);
            }
        }
    }
}
