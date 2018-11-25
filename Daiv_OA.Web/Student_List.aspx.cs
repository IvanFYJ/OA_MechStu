using Daiv_OA.Utils;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class Student_List : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("student-list");
            if (!this.Page.IsPostBack)
            {
                Bind();
            }
        }


        //删除数据
        protected void lbDel_Click(object sender, CommandEventArgs e)
        {
            User_Load("student-list");
            string oname = Getoname();
            Daiv_OA.BLL.StudentBLL studentBll = new Daiv_OA.BLL.StudentBLL();
            Daiv_OA.BLL.UserBLL userBll = new BLL.UserBLL();
            int sid = Convert.ToInt32(e.CommandArgument);
            Entity.StudentEntity studentEntity = studentBll.GetEntity(sid);
            studentBll.Delete(sid);
            Entity.UserEntity userEntity = userBll.GetEntity(studentEntity.Uid);
            userBll.Delete(studentEntity.Uid);//连同家长的账号也一起删除
            logHelper.logInfo("删除学生成功！操作人：" + oname);
            string stuStr = Newtonsoft.Json.JsonConvert.SerializeObject(studentEntity);
            string userStr = Newtonsoft.Json.JsonConvert.SerializeObject(studentEntity);
            logHelper.logInfo("删除学生：" + stuStr);
            logHelper.logInfo("删除家长：" + userStr);
            Adminlogadd(oname);
            Bind();
        }

        //数据绑定
        void Bind()
        {
            string sql = string.Format(@"SELECT 
st.Sid,st.Snumber,st.Gid,st.Uid,st.Sbirthday,st.Gname,st.Sname,st.MechID,st.IsDeleted,
g.Gdescription,g.GgradeName,g.Gname,
cat.Cphone,cat.Cphone2,cat.Cphone3,cat.Cphone4
FROM Daiv_OA..OA_Student(NOLOCK) st 
JOIN Daiv_OA..OA_Grade(NOLOCK) g ON g.Gid = st.Gid
LEFT JOIN Daiv_OA..OA_Contact(NOLOCK) cat ON cat.Sid = st.Sid
WHERE st.IsDeleted = 0 AND g.IsDeleted = 0  AND st.MechID ={0}", UserId);
            this.user_repeater.DataSource = new Daiv_OA.BLL.GradeBLL().Getall(sql);
            this.user_repeater.DataBind();
        }

        void Adminlogadd(string name)
        {
            Entity.AdminlogEntity model = new Entity.AdminlogEntity();
            model.Uid = UserId;
            model.Updatetitle = name;
            model.Updatetime = DateTime.Now;
            model.Updatetype = "删除学生";
            int i = new Daiv_OA.BLL.AdminlogBLL().Add(model);
            if (i > 0)
                FinalMessage("学生删除成功", "Student_List.aspx", 0);
            else
                FinalMessage("学生删除失败", "Student_List.aspx", 0);
        }

        //通过参数获取被更改的用户名
        string Getoname()
        {
            Entity.UserEntity model = new Entity.UserEntity();
            model = new Daiv_OA.BLL.UserBLL().GetEntity(UserId);
            return model.Uname;
        }
    }
}