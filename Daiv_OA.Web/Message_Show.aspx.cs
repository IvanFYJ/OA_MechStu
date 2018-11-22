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
    public partial class Message_Show : Daiv_OA.UI.BasicPage
    {
        public string text;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("message-show");
            if (!this.Page.IsPostBack)
            {
                Bind_Work();
            }
        }

        void Bind_Work()
        {
            int id = Str2Int(q("id"), 0);
            Entity.MessageEntity model = new Entity.MessageEntity();
            model = new Daiv_OA.BLL.MessageBLL().GetEntity(id);
            this.lblTitle.Text = model.Mtitle;
            text = model.Content;
            if (UserId == model.ToUid)
                new Daiv_OA.BLL.MessageBLL().SetReadById(id);

        }
    }
}
