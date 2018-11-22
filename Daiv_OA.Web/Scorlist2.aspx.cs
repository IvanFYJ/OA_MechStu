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
    public partial class Scorlist2 :Daiv_OA.UI.BasicPage
    {
        Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
        int Snum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("login");
            if (!IsPostBack)
                SHgvlist();
        }

        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int num = 0;
      //  
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                #region 行事件
                string fid = gvlist.DataKeys[e.Row.RowIndex].Value.ToString().Trim();
                GridView gvlist3 = (GridView)e.Row.FindControl("GridView2");
                if (fid != "")
                {
                       Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
                        DataTable dt = com.COM_Select("OA_ItemTB", "parentid", "Isdelete", fid, "1", 8);
                        gvlist3.DataSource = dt; gvlist3.DataBind();
                    if (com.getsid("uid") != "-1" && com.getsid("kq") != "-1")
                     {
                         DataTable ds =com.COM_Proc_Sel3("Pc_SelOpposebyPTI",fid,com.getsid("uid"), com.getsid("kq"));
                         for (int i = 0; i < ds.Rows.Count; i++)
                         {
                             Label lb = (Label)gvlist3.Rows[i].FindControl("lbtxt");
                                 switch (getvalue(4))
                                 {
                                     case "1":
                                         lb.Text = ds.Rows[i]["threescore"].ToString();
                                         break;
                                     case "2":
                                         lb.Text = ds.Rows[i]["twoscore"].ToString();
                                         break;
                                     case "3":
                                         lb.Text = ds.Rows[i]["onescore"].ToString();
                                         break;
                                     case "4":
                                         lb.Text = ds.Rows[i]["custom"].ToString();
                                         break;
                                 }
                                 num +=Convert.ToInt32(lb.Text.Trim());
                                 TextBox txt = (TextBox)gvlist3.Rows[i].FindControl("txtremark");
                                 txt.Text = ds.Rows[i]["remrk"].ToString();
                         }
                     }
                }
                #endregion
                Label lbtxt = (Label)e.Row.FindControl("labnum");
                lbtxt.Text = num.ToString();
                Snum += num;
            }
         
            // 合计
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text = "合计您给的总分：<font style=\"color:red\">"+Snum.ToString()+"</font>";
            }
        }
        protected void SHgvlist()
        {
            gvlist.DataSource = com.COM_Select("OA_ItemTB", "typeid", "", "0", "", 7);
            gvlist.DataBind();
        }
   
    }
}
