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
    public partial class ItemDetail :Daiv_OA.UI.BasicPage
    {
        Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("login");
            if (!IsPostBack)
            {
                string id = com.getsid("id");
                if (id != "-1")
                { 
                 DataTable table = com.COM_Select("OA_ItemTB", "Id", "", id, "", 4);
                 if (table.Rows.Count != 0)
                 {
                     titlename.Text = table.Rows[0]["titlename"].ToString();
                 }
                }
            }
        }
        //提交
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sid = com.getsid("fid");
            string id = com.getsid("id");
           
            DataTable table = com.COM_Select("OA_ItemTB", "Id", "", id, "", 4);
            if (table.Rows.Count != 0)
            {
                DataRow dr = table.Rows[0];
                dr["titlename"] = titlename.Text.Trim();
                com.COM_Up(table, "OA_ItemTB", "titlename=@titlename", id);
                Response.Write("<script>parent.location.href='Item.aspx'</script>");

            }
            else
            {
                if (sid != "-1")
                {
                    table.Rows.Clear();
                    DataRow dr = table.NewRow();
                    dr["titlename"] = titlename.Text.Trim();
                    dr["parentid"] = sid;
                    dr["Isdelete"] = 1;
                    table.Rows.Add(dr);
                    com.COM_Add(table, "OA_ItemTB", "@titlename,@parentid,@Isdelete");
                    Response.Write("<script>parent.location.href='Item.aspx'</script>");

                }
                else
                    Label2.Text = "提交无效！";
            }
        }
        //返回
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<script>parent.location.href='Item.aspx'</script>");//刷新父窗体，也可传参数
        }
    }
}
