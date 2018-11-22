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
    public partial class address : Daiv_OA.UI.BasicPage
    {
        Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
        Daiv_OA.UI.BasicPage bg = new Daiv_OA.UI.BasicPage();
        string sid = "-1";
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("login");
            if (!IsPostBack)
            {
                show();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            sid = com.getsid("address").ToString();
            DataTable dt = com.COM_Select("OA_Address", "Id", "",sid, "",4);DataRow dr;
           
            if (sid != "-1")
            {
               dr=dt.Rows[0];
               drs(dr);
               com.COM_Up(dt, "OA_Address", "truename=@truename,phones=@phones,telephone=@telephone,email=@email,qq=@qq,Pids=@Pids", sid);
            }
            else
            {
                dr= dt.NewRow();
                drs(dr);
                dt.Rows.Add(dr);
                com.COM_Add(dt, "OA_Address", "@truename,@phones,@telephone,@email,@qq,@Pids");
            }
            go();
        }
        void go()
        {
            int i = Convert.ToInt32(bg.getvalue(4));
            switch (i)
            {
                case 1:
                    Response.Redirect("addresslist.aspx");
                    break;
                case 2:
                   Response.Redirect("DeskTop2.aspx");
                    break;
                case 3:
                  Response.Redirect("DeskTop3.aspx");
                    break;
                case 4:
                  Response.Redirect("DeskTop4.aspx"); 
                    break;
            }
        }
        protected void show()
        {
            DataTable table = com.COM_Select("OA_Power", "", "", "", "", 0);
            DropDid.DataSource = table;
            DropDid.DataTextField = "PName";
            DropDid.DataValueField = "Pid";
            DropDid.DataBind();
            sid = com.getsid("address").ToString();
            DataTable dt = com.COM_Select("OA_Address", "Id", "", sid, "", 4); 
          if (sid != "-1")
            {
                if (dt.Rows.Count != 0)
                {
                    truename.Text = dt.Rows[0]["truename"].ToString();
                    phones.Text = dt.Rows[0]["phones"].ToString();
                    telephone.Text = dt.Rows[0]["telephone"].ToString();
                    email.Text = dt.Rows[0]["email"].ToString();
                    qq.Text = dt.Rows[0]["qq"].ToString();
                    DropDid.SelectedValue = dt.Rows[0]["Pids"].ToString();
                }
            }
        }
        protected void drs(DataRow dr)
        {
            dr["truename"] = truename.Text.Trim();
            dr["phones"] = phones.Text.Trim();
            dr["telephone"] = telephone.Text.Trim();
            dr["email"] = email.Text.Trim();
            dr["qq"] = qq.Text.Trim();
            dr["Pids"] = DropDid.SelectedValue.ToString();
        }
    }
}
