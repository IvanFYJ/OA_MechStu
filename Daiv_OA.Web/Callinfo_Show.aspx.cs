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
    public partial class Callinfo_Show : Daiv_OA.UI.BasicPage
    {
        public string text;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("callinfo-show");
            if (!this.Page.IsPostBack)
            {
                Bind_Callinfo();
            }
        }

        void Bind_Callinfo()
        {
            int id = Str2Int(q("id"), 0);
            Entity.CallinfoEntity model = new Entity.CallinfoEntity();
            model = new Daiv_OA.BLL.CallinfoBLL().GetEntity(id);

            this.lblTitle.Text = model.Title;
            this.lblAddtime.Text = model.Addtime.ToString();
            this.lblUnit.Text = model.Unit;
            this.lblUserinfo.Text = model.Userinfo;
            this.lblReply.Text = model.Reply;
            text = model.Remark;
        }
    }
}
