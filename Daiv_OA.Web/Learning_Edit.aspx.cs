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
    public partial class Learning_Edit : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("learning-edit");
            if (!this.Page.IsPostBack)
            {
                Bind();
                MyValidate();
            }

        }
        //判断是否是发布任务的本人
        void MyValidate()
        {
            Daiv_OA.Entity.LearningEntity learningEntity = new Daiv_OA.Entity.LearningEntity();
            learningEntity = new Daiv_OA.BLL.LearningBLL().GetEntity(Str2Int(q("id")));
            if (UserName != learningEntity.Sauthor)
            {
                FinalMessage("该学习资料你无权修改", "", 1);
            }
        }

        //信息绑定
        void Bind()
        {
            Daiv_OA.Entity.LearningEntity model = new Daiv_OA.Entity.LearningEntity();
            model = new BLL.LearningBLL().GetEntity(Str2Int(q("id")));
            this.txtTitle.Text = model.Stitle;
            this.kindeditor.Value = model.Spath;
        }
        //修改信息
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.LearningEntity model = new Entity.LearningEntity();
            model.Sid = Str2Int(q("id"));
            model.Sauthor = UserName;
            model.Stitle = this.txtTitle.Text;
            model.Sdate = DateTime.Now;
            model.Spath = this.kindeditor.Value;
            model.Did = UserDepartmentId;
            new Daiv_OA.BLL.LearningBLL().Update(model);
            string addtype = "修改学习资料";
            Addlog(addtype);
        }

        //往操作日志添加信息
        void Addlog(string type)
        {
            Entity.OperatelogEntity model = new Entity.OperatelogEntity();
            model.Uid = UserId;
            model.Eupdatetitle = this.txtTitle.Text;
            model.Eupdatetype = type;
            model.Eupadatetime = DateTime.Now;
            int i = new Daiv_OA.BLL.OperatelogBLL().Add(model);
            if (i > 0)
                FinalMessage("修改成功", "Learning_List.aspx", 0);
            else
                FinalMessage("修改失败", "Learning_List.aspx", 0);
        }
    }
}
