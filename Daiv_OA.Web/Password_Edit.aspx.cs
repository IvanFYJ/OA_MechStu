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
    public partial class Password_Edit : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("password-edit");
            if (!this.Page.IsPostBack)
            {
                Bind();
            }
        }

        //绑定
        void Bind()
        {
            Entity.UserEntity model = new Entity.UserEntity();
            model = new Daiv_OA.BLL.UserBLL().GetEntity(UserId);
            this.txtUname.Text = model.Uname;
            ViewState["pid"] = model.Pid.ToString();
            this.txtUname.ReadOnly = true;
        }

        //个人密码修改
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.UserEntity model = new Entity.UserEntity();
            model = new Daiv_OA.BLL.UserBLL().GetEntity(UserId);
            model.Upwd = Daiv_OA.Utils.MD5.Lower32(this.txtAgainpwd.Text.Trim());
            new Daiv_OA.BLL.UserBLL().Update(model);
            FinalMessage("操作成功", "Password_Edit.aspx", 0);
        }

    }
}
