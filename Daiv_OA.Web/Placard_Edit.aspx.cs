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
    public partial class Placard_Edit : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("placard-edit");
            if (!this.Page.IsPostBack)
            {
                Bind();
                MyValidate();
            }
        }
        //判断是否是发布任务的本人
        void MyValidate()
        {
            Daiv_OA.Entity.PlacardEntity placardEntity = new Daiv_OA.Entity.PlacardEntity();
            placardEntity = new Daiv_OA.BLL.PlacardBLL().GetEntity(Str2Int(q("id")));
            if (UserName != placardEntity.Pauthor)
            {
                FinalMessage("该通知公告你无权修改", "", 1);
            }
        }

        //信息绑定
        void Bind()
        {
            Daiv_OA.Entity.PlacardEntity model = new Daiv_OA.Entity.PlacardEntity();
            model = new BLL.PlacardBLL().GetEntity(Str2Int(q("id")));
            this.txtTitle.Text = model.Ptitle;
            this.kindeditor.Value = model.Ptext;
        }
        //修改信息
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.PlacardEntity model = new Entity.PlacardEntity();
            model.Pid = Str2Int(q("id"));
            model.Pauthor = UserName;
            model.Ptitle = this.txtTitle.Text;
            model.Pdate = DateTime.Now;
            model.Ptext = this.kindeditor.Value;
            new Daiv_OA.BLL.PlacardBLL().Update(model);
            string addtype = "修改通知公告";
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
                FinalMessage("修改成功", "Placard_List.aspx", 0);
            else
                FinalMessage("修改失败", "Placard_List.aspx", 0);
        }
    }
}
