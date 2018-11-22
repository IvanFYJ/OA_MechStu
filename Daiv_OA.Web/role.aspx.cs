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
    public partial class role : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("login");
            if (!IsPostBack)
            {
                showlist();
            }
        }

       
        void showlist()
        {
            int uid = Str2Int(q("roleid"), 0); //1==部门
            if (uid == 1)
            {
                GridView1.DataKeyNames = new string[] { "Did" };//主键
                GridView1.DataSource = new Daiv_OA.BLL.DepartmentBLL().GetList("").Tables[0];
                GridView1.DataBind();
            }
            else
            {
                gvlist.DataKeyNames = new string[] { "Pid" };//主键
                gvlist.DataSource = new Daiv_OA.BLL.PowerBLL().GetList("").Tables[0];
                gvlist.DataBind();
            }
        
        }
        public string sty(int i)
        {
            if (i == 1)
            {
                int uid = Str2Int(q("roleid"), 0); //1==部门
                if (uid == 1)
                    return "active";
                else
                    return "";
            }
            else
            {
                int uid = Str2Int(q("roleid"), 0); //1==部门
                if (uid == 0)
                    return "active";
                else
                    return "";
            
            }
        
        }
      public  string names(object obj)
        {
               return obj.ToString();
        }
      public string ns()
      { 
       int uid = Str2Int(q("roleid"), 0); //1==部门
       if (uid == 1)
           return "部门名称";
       else
           return "角色名称";
      }
        protected void gvlist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new Daiv_OA.BLL.PowerBLL().Delete(Convert.ToInt32(gvlist.DataKeys[e.RowIndex].Value.ToString()));
            showlist();
        }

        protected void gvlist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Entity.PowerEntity model = new Daiv_OA.Entity.PowerEntity();
            model.Pid = Convert.ToInt32(gvlist.DataKeys[e.RowIndex].Value.ToString());
            model.PName = ((TextBox)(gvlist.Rows[e.RowIndex].Cells[2].FindControl("TextBox2"))).Text.Trim();
            new Daiv_OA.BLL.PowerBLL().Update(model);
           
            gvlist.EditIndex = -1;
            showlist();

        }
        protected void gvlist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvlist.EditIndex = e.NewEditIndex;
            showlist();
        }
        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //鼠标经过时，行背景色变 
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
                //鼠标移出时，行背景色变 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            
            } 
        }

        protected void gvlist_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvlist.EditIndex = -1;
            showlist();
        }

      

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //鼠标经过时，行背景色变 
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
                //鼠标移出时，行背景色变 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
             
            } 
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            showlist();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new Daiv_OA.BLL.DepartmentBLL().Delete(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
            showlist();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Entity.DepartmentEntity model = new Daiv_OA.Entity.DepartmentEntity();
            model.Did = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            model.DName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].FindControl("TextBox2"))).Text.Trim();
            new Daiv_OA.BLL.DepartmentBLL().Update(model);
            GridView1.EditIndex = -1;
            showlist();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            showlist();
        }

      

    }
}
