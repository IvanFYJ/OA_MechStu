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
    public partial class My_Worklog_Show : Daiv_OA.UI.BasicPage
    {
        public string text;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            if (!this.Page.IsPostBack)
            {
                Bind_Worklog();
            }
        }

        void Bind_Worklog()
        {
            int id = Str2Int(q("id"), 0);
            Entity.WorklogEntity model = new Entity.WorklogEntity();
            model = new Daiv_OA.BLL.WorklogBLL().GetEntity(id);
            if (model.Uid != UserId)
            {
                FinalMessage("请勿违规操作", "", 100);
            }
            this.lblTitle.Text = model.Title;
            this.lblBegintime.Text = model.Begintime.ToString();
            this.lblEndtime.Text = model.Endtime.ToString();
            this.lblContent.Text = model.Content;
            this.lblManager.Text = model.Manager;
            this.lblProblem.Text = model.Problem;
            text = model.Remark;
        }
    }
}
