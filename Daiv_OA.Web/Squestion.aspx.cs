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
    public partial class Squestion : Daiv_OA.UI.BasicPage
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("login");
            if (!IsPostBack)
            {
                drop();
                GetList();
            }
        }

        private void GetList()
        {
            Daiv_OA.DAL.BaseDAL BLL = new Daiv_OA.DAL.BaseDAL();
            int rowCount = 0;
            Daiv_OA.Entity.PageListModel pageModel = new Daiv_OA.Entity.PageListModel();
            pageModel.SelectList = "*";
            pageModel.Tables = "OA_QuestionTB";
            pageModel.PriKey = "Id";
            pageModel.BlPage = 1;
            pageModel.PageSize = AspNetPager1.PageSize;
            pageModel.StrWhere = GetWhere();
            pageModel.PageIndex = AspNetPager1.CurrentPageIndex;
            pageModel.OrderByField = "Id desc";  //
            DataTable dt = BLL.GetList(pageModel, ref rowCount).Tables[0];
            AspNetPager1.RecordCount = rowCount;
            gvlist.DataSource= dt;
            gvlist.DataBind();

        }
        /// <summary>
        /// 获得查询where
        /// </summary>
        /// <returns></returns>
        string GetWhere()
        {
            string str = "(quuser=" +"'"+ getvalue(2)+"'" + " or touser=" +"'"+ getvalue(2)+"'"+")";
            if (rescuedp.SelectedValue != "0")
            {
                str += " and rescue="+"'"+rescuedp.Text+"'";
            }
            if ( dropitem.SelectedValue != "")
            {
                if (dropitem.SelectedValue.ToString() != "0")
                    str += " and Itemid=" + dropitem.SelectedValue.ToString();
            }
            if ( DropDownList1.SelectedValue.ToString() != "0")
                str += " and class=" + "'" + DropDownList1.SelectedValue.ToString() + "'";
            return str;
        }
        protected void drop()
        {
            Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
            dropitem.DataSource = com.COM_Select("OA_ItemTB", "typeid", "parentid", "1", "0", 8);
            dropitem.DataTextField = "titlename";
            dropitem.DataValueField = "Id";
            dropitem.DataBind();
            dropitem.Items.Insert(0, new ListItem("======全部项目======", "0"));
        }
        public string getstrobj(object name, int i)
        {
            Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL(); string str = "";
            if (i == 1)
            {
                DataTable dt = com.COM_Select("OA_ItemTB", "id", "", name.ToString(), "", 4);
                if (dt.Rows.Count != 0)
                    str = dt.Rows[0]["titlename"].ToString();
            }
            else
            {
                if (name.ToString() == "1")
                    str = "一般";
                else if (name.ToString() == "2")
                    str = "紧急";
                else
                    str = "十分紧急";
            }
                return str;
        }
        public string gets(object name,object id)
        { 
            string str="";
        if(name.ToString()=="问题已处理")
            str = "处理完毕";
            else
            str =" <a style=\"color:Blue\"; href=\"Squestiondetail.aspx?sques="+id.ToString()+"\">立刻执行</a>";
            return str;
        }
        public string getstr(object name)
        {
            string str = "待解决";
            if (name.ToString() != "")
                str = name.ToString();
            return str;
        
        }
        protected void AspNetPager1_PageChanged1(object src, Sisans.AspNetPager.PageChangedEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            GetList();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            GetList();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Squestiondetail.aspx");
        }

        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#ececec'");
                e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
                e.Row.Attributes["style"] = "Cursor:hand";
            }
        }
    }
}
