using Daiv_OA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class School_Edit : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("sch-list");
            if (!this.Page.IsPostBack)
            {
                Bind();
            }
        }



        //数据绑定
        void Bind()
        {
            int gid = Str2Int(q("id"), 0);
            Daiv_OA.Entity.SchoolEntity model = new Daiv_OA.Entity.SchoolEntity();
            model = new Daiv_OA.BLL.SchoolBLL().GetEntity(gid);
            this.Name.Text = model.Name;
            this.Address.Text = model.Address;
            
        }


        //更新
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.SchoolEntity model = new Entity.SchoolEntity();
            Daiv_OA.BLL.ContactBLL contactBll = new Daiv_OA.BLL.ContactBLL();
            Daiv_OA.BLL.SchoolBLL SchoolBll = new Daiv_OA.BLL.SchoolBLL();
            model = SchoolBll.GetEntity(Str2Int(q("id"), 0));
            model.Name = this.Name.Text;
            model.Address = this.Address.Text;
            SchoolBll.Update(model);
            logHelper.logInfo("修改学校成功！操作人：" + UserId);
            FinalMessage("操作成功", "School_List.aspx", 0);
        }
    }
}