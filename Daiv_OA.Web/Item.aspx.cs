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
    public partial class Item :Daiv_OA.UI.BasicPage
    {
        Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("login");
            if (!IsPostBack)
            {
                show();
            }
        }
        //提交
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sid = txtid.Text.Trim();
            if (sid == "")
                sid = "-1";
           DataTable table = com.COM_Select("OA_ItemTB", "Id", "",sid, "", 4);
           if (table.Rows.Count !=0)
           {
               DataRow dr = table.Rows[0];
               dr["typeid"] = typeid.SelectedValue.ToString();
               dr["titlename"] = titlename.Text.Trim();
               com.COM_Up(table, "OA_ItemTB", "typeid=@typeid,titlename=@titlename",sid);
               ok.Text = "修改成功！";
           }
           else
           {
               table.Rows.Clear();
               DataRow dr = table.NewRow();
               dr["typeid"] = typeid.SelectedValue.ToString();
               dr["titlename"] = titlename.Text.Trim();
               table.Rows.Add(dr);
               com.COM_Add(table, "OA_ItemTB", "@typeid,@titlename");
               ok.Text = "添加成功！";
           }
           show();
           txtid.Text = "";
           titlename.Text = "";
        }

        protected void show()
        {
            string sid = txtid.Text.Trim();
            if (sid != "-1")
            { 
             DataTable table = com.COM_Select("OA_ItemTB", "Id", "",sid, "", 4);
             if (table.Rows.Count != 0)
             {
                 typeid.SelectedValue = table.Rows[0]["typeid"].ToString();
                 titlename.Text = table.Rows[0]["titlename"].ToString();
             }
            }
            gvlist0.DataSource = com.COM_Select("OA_ItemTB", "Id", "","", "",3);
            gvlist0.DataBind();
        }

        protected void gvlist0_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string sid = gvlist0.DataKeys[e.NewEditIndex].Value.ToString();
            txtid.Text = sid;
            show();
        }
       public string  getbookname(object column)
        {
            if (column.ToString() == "0")
                return "在线打分";
            else
                return "项目测试汇报";

        }
        protected void gvlist0_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sid = gvlist0.DataKeys[e.RowIndex].Value.ToString();
            DataTable table = com.COM_Select("OA_ItemTB", "parentid", "", sid, "", 4);
            if (table.Rows.Count != 0)
                com.COM_Proc_DelorUp_2("Pc_DelItembyPID", sid, "1");
            com.COM_Proc_DelorUp_2("Pc_DelItembyPID", sid, "-1");
            show();
        }

        protected void gvlist0_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // if (e.Row.RowIndex != -1)
            //{
            //    int id = e.Row.RowIndex + 1;
            //    e.Row.Cells[0].Text = id.ToString();
            //}
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#d8e7ee'");
                 e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
                 e.Row.Attributes["style"] = "Cursor:hand";
                 string fid = gvlist0.DataKeys[e.Row.RowIndex].Value.ToString().Trim();
               
                 GridView gvlist = (GridView)e.Row.FindControl("GridView2");
                 if (fid != "")
                 {
                     DataTable dt = com.COM_Select("OA_ItemTB", "parentid", "Isdelete", fid, "1",8);
                     gvlist.DataSource = dt; 
                     gvlist.DataBind();
                 }
             }
        }


        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
                GridView GridView2 = sender as GridView;
                string sid = GridView2.DataKeys[e.RowIndex].Value.ToString();
                com.COM_Proc_DelorUp_2("Pc_DelItembyPID", sid, "-1");
                show();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Attributes.Add("onclick", "return confirm('你确认要删除吗?')");
            }
        }
       


    }
}
