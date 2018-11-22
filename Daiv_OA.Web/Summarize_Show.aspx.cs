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
    public partial class Summarize_Show : Daiv_OA.UI.BasicPage
    {
        public string text;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("summarize-show");
            if (!this.Page.IsPostBack)
            {
                int id = Str2Int(q("id"), 0);
                BindSummarize(id);
            }
        }

        //工作总结的绑定
        void BindSummarize(int suid)
        {
            Entity.SummarizeEntity model = new Entity.SummarizeEntity();
            model = new Daiv_OA.BLL.SummarizeBLL().GetEntity(suid);
            this.lblTitle.Text = model.Sutitle;
            text = model.Sutext;
        }
    }
}
