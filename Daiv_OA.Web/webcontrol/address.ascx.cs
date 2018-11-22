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

namespace Daiv_OA.Web.webcontrol
{
    public partial class address : System.Web.UI.UserControl
    {
        Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
        Daiv_OA.UI.BasicPage bp = new Daiv_OA.UI.BasicPage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (bp.getvalue(4) == "1")
            {
                c.Visible = true;
                GridView1.Columns[7].Visible = true;
                cc.Visible = false;
                GridView1.PageSize = 15;
            }
            else
            {
                if (bp.getvalue(4) == "2")
                    GridView1.PageSize = 2;
                    else
                    GridView1.PageSize = 5;
                c.Visible = false;
                GridView1.Columns[7].Visible = false;
                cc.Visible = true;
            }
            if (!IsPostBack)
            {
                GridView1.DataSource = com.COM_Proc_Sel0("Pc_SeladdressbyPower");
                GridView1.DataBind();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./address.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string sid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            if (sid.Length != 0)
            {
                com.COM_Del("OA_Address", sid, 1);
            }
            GridView1.DataSource = com.COM_Proc_Sel0("Pc_SeladdressbyPower");
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string sid=GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect("./address.aspx?address="+sid);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = com.COM_Proc_Sel0("Pc_SeladdressbyPower");
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}