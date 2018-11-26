using Daiv_OA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class ParentMessage_Edit : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("pm-edit");
            if (!this.Page.IsPostBack)
            {
                Bind();
            }
        }


        //数据绑定
        void Bind()
        {
            int gid = Str2Int(q("id"), 0);
            Daiv_OA.Entity.ParentMessageEntity model = new Daiv_OA.Entity.ParentMessageEntity();
            model = new Daiv_OA.BLL.ParentMessageBLL().GetEntity(gid);
            this.Mtitle.Text = model.Mtitle;
            this.Content.Text = model.Content;
        }


        //更新
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.ParentMessageEntity model = new Entity.ParentMessageEntity();
            model = new Daiv_OA.BLL.ParentMessageBLL().GetEntity(Str2Int(q("id"), 0));
            model.Mtitle = this.Mtitle.Text;
            model.Content = this.Content.Text;
            new Daiv_OA.BLL.ParentMessageBLL().Update(model);
            logHelper.logInfo("修改班级成功！操作人：" + UserId);
            FinalMessage("操作成功", "ParentMessage_List.aspx", 0);
        }
    }
}