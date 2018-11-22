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
    public partial class Error : Daiv_OA.UI.BasicPage
    {
        public string ErrInfo = "操作失败，请规范操作！！！";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (q("info") != "")
                ErrInfo = q("info");
        }
    }
}
