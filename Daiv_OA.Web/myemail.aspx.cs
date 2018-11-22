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
using jmail;
namespace Daiv_OA.Web
{
    public partial class myemail :Daiv_OA.UI.BasicPage
    {
        Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("login");
            // set(); 
            if (!IsPostBack)
            {
                show();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Daiv_OA.BLL.URLENCRYP urlen = new Daiv_OA.BLL.URLENCRYP();
            DataTable dt = com.COM_Proc_Sel1("PC_getOA_email", UserId.ToString());
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Clear();
                DataRow dr = dt.NewRow();
                dr["emailname"] = emailname.Text.Trim() + Tpdropdown.Text.Trim();
                dr["emailpwd"] = urlen.Encryp(emailpwd.Text.Trim());
                dr["uid"] = UserId.ToString();
                dr["inserttime"] = DateTime.Now.ToString();
                dt.Rows.Add(dr);
                com.COM_Add(dt, "OA_emailTB", "@emailname,@emailpwd,@uid,@inserttime");
                emailname.Text = emailpwd.Text = "";
                Tools.Common.JavaScript.MessageBox(this, "保存成功！");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Daiv_OA.BLL.URLENCRYP urlen = new Daiv_OA.BLL.URLENCRYP();
            DataTable dt = com.COM_Proc_Sel1("PC_getOA_email", UserId.ToString());
            if (dt.Rows.Count != 0)
            {
                Button1.Visible = false;
                Button2.Visible = true;
            }else
                Tools.Common.JavaScript.MessageBox(this, "温馨提示：请先保存邮箱！");

        }
        //修改
        protected void Button2_Click(object sender, EventArgs e)
        {
            Daiv_OA.BLL.URLENCRYP urlen = new Daiv_OA.BLL.URLENCRYP();
            DataTable dt = com.COM_Proc_Sel1("PC_getOA_email", UserId.ToString());
            string sid=dt.Rows[0]["Id"].ToString();
            DataRow dr=dt.Rows[0];
            dr["emailpwd"] = urlen.Encryp(emailpwd.Text.Trim());
            com.COM_Up(dt, "OA_emailTB", "emailpwd=@emailpwd", sid);
            Tools.Common.JavaScript.Redirect(Page,"修改成功！", "myemail.aspx");
        }

        void show()
        {
            Daiv_OA.BLL.URLENCRYP urlen = new Daiv_OA.BLL.URLENCRYP();
            DataTable dt = com.COM_Proc_Sel1("PC_getOA_email", UserId.ToString());
            if (dt.Rows.Count != 0)
            {
                Button1.Visible = false;
                string email = dt.Rows[0]["emailname"].ToString();
                string[] str = email.Split("@".ToCharArray());
                emailname.Text = str[0].ToString();
                Tpdropdown.Text = str[1].ToString();
                emailname.Enabled = false; Tpdropdown.Enabled = false;
            }
            else
            {
                Button1.Visible = true;
                emailname.Enabled = true;
                Tpdropdown.Enabled = true;
            }
        }
          
    }
}
