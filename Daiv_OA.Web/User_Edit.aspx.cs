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
    public partial class User_Edit : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("user-edit");
            if (!this.Page.IsPostBack)
            {
                Bind();
                this.txtUname.ReadOnly = true;
            }
        }
        //数据绑定
        void Bind()
        {
            int uid = Str2Int(q("id"), 0);
            Daiv_OA.Entity.UserEntity model = new Daiv_OA.Entity.UserEntity();
            model = new Daiv_OA.BLL.UserBLL().GetEntity(uid);
            this.txtUname.Text = model.Uname;
        }

        //更新
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.UserEntity model = new Entity.UserEntity();
            model = new Daiv_OA.BLL.UserBLL().GetEntity(Str2Int(q("id"), 0));
            model.Upwd = Daiv_OA.Utils.MD5.Lower32(this.txtAgainpwd.Text.Trim());
            new Daiv_OA.BLL.UserBLL().Update(model);
            Addadminlog("修改用户密码");
        }

        //往管理员日志插入数据
        void Addadminlog(string type)
        {
            Entity.AdminlogEntity model = new Entity.AdminlogEntity();
            model.Uid = UserId;
            model.Updatetime = DateTime.Now;
            model.Updatetitle = this.txtUname.Text;
            model.Updatetype = type;
            int i = new Daiv_OA.BLL.AdminlogBLL().Add(model);
            if (i > 0)
            {
                FinalMessage("操作成功", "User_List.aspx", 0);
            }
        }
    }
}
