using Daiv_OA.Utils;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class Grade_List : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("grade-list");
            if (!this.Page.IsPostBack)
            {
                Bind();
            }
        }

        //删除数据
        protected void lbDel_Click(object sender, CommandEventArgs e)
        {
            User_Load("grade-list");
            string oname = Getoname();
            new Daiv_OA.BLL.GradeBLL().Delete(Convert.ToInt32(e.CommandArgument));
            logHelper.logInfo("删除班级成功！操作人："+oname);
            Adminlogadd(oname);
            Bind();
        }

        //通过参数获取被更改的用户名
        string Getoname()
        {
            Entity.UserEntity model = new Entity.UserEntity();
            model = new Daiv_OA.BLL.UserBLL().GetEntity(UserId);
            return model.Uname;
        }

        //数据绑定
        void Bind()
        {
            
            string sql = "SELECT Gid ,Gname ,Gsnumber ,Gdescription ,IsDeleted FROM Daiv_OA..OA_Grade(NOLOCK) WHERE IsDeleted = 0 ";
            this.user_repeater.DataSource = new Daiv_OA.BLL.UserBLL().Getall(sql);
            this.user_repeater.DataBind();
        }
        void Adminlogadd(string name)
        {
            Entity.AdminlogEntity model = new Entity.AdminlogEntity();
            model.Uid = UserId;
            model.Updatetitle = name;
            model.Updatetime = DateTime.Now;
            model.Updatetype = "删除班级";
            int i = new Daiv_OA.BLL.AdminlogBLL().Add(model);
            if (i > 0)
                FinalMessage("班级删除成功", "Grade_List.aspx", 0);
            else
                FinalMessage("班级删除失败", "Grade_List.aspx", 0);
        }
    }
}