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
    public partial class User_List : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("user-show");
            if (!this.Page.IsPostBack)
            {
                Bind();
            }
        }
        //数据绑定
        void Bind()
        {
            string sql = "select [OA_User].uid,[OA_User].uname,[OA_User].upwd,[OA_User].PID,Position,IsNull((select DName from [OA_Department] where [OA_Department].Did=[OA_User].did),'管理部') as Dname,[OA_Power].pname FROM [OA_User] left join [OA_Power] on [OA_User].pid = [OA_Power].pid where [OA_User].uid <> 1 ";
            this.user_repeater.DataSource = new Daiv_OA.BLL.UserBLL().Getall(sql);
            this.user_repeater.DataBind();
        }

        //删除数据
        protected void lbDel_Click(object sender, CommandEventArgs e)
        {
            User_Load("user-del");
            string oname = Getoname(Convert.ToInt32(e.CommandArgument));
            new Daiv_OA.BLL.UserBLL().Delete(Convert.ToInt32(e.CommandArgument));
            Adminlogadd(oname);
            Bind();
        }

        //通过参数获取被更改的用户名
        string Getoname(int id)
        {
            Entity.UserEntity model = new Entity.UserEntity();
            model = new Daiv_OA.BLL.UserBLL().GetEntity(id);
            return model.Uname;
        }

        //添加到管理员操作日志
        void Adminlogadd(string name)
        {
            Entity.AdminlogEntity model = new Entity.AdminlogEntity();
            model.Uid = UserId;
            model.Updatetitle = name;
            model.Updatetime = DateTime.Now;
            model.Updatetype = "删除用户";
            int i = new Daiv_OA.BLL.AdminlogBLL().Add(model);
            if (i > 0)
                FinalMessage("用户删除成功", "User_List.aspx", 0);
            else
                FinalMessage("用户删除失败", "User_List.aspx", 0);
        }
    }
}
