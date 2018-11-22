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
    public partial class Learning_Show : Daiv_OA.UI.BasicPage
    {
        public string text;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("learning-show");
            if (!this.Page.IsPostBack)
            {
                Bind();
            }
        }

        void Bind()
        {
            int id = Str2Int(q("id"), 0);
            Entity.LearningEntity model = new Entity.LearningEntity();
            model = new Daiv_OA.BLL.LearningBLL().GetEntity(id);
            if (UserPowerId > 2)
            {
                if (UserDepartmentId != model.Did && model.Did > 0)
                {
                    FinalMessage("请勿越权", "Learning_List.aspx", 0);
                }
            }
            this.lblTitle.Text = model.Stitle;
            text = model.Spath;
        }
    }
}
