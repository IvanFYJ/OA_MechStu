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
    public partial class My_Placard_Show : Daiv_OA.UI.BasicPage
    {
        public string text;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("my_placard-show");
            if (!this.Page.IsPostBack)
            {
                Msgbind();
            }
        }

        void Msgbind()
        {
            int id = Str2Int(q("id"), 0);
            Entity.PlacardEntity model = new Entity.PlacardEntity();
            model = new Daiv_OA.BLL.PlacardBLL().GetEntity(id);
            this.lblTitle.Text = model.Ptitle;
            text = model.Ptext;
        }
    }
}
