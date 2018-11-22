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
    public partial class Time_List : Daiv_OA.UI.BasicPage
    {
        protected string wherestr, wherestr2 = "";
        public int _uid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("time-show");
            if (!this.Page.IsPostBack)
            {
                this.txtBegintime.Text = System.DateTime.Today.ToString("yyyy-MM") + "-01";
                this.txtEndtime.Text = System.DateTime.Today.ToString("yyyy-MM-dd");
            }
            _uid = Str2Int(q("uid"));
            if (_uid != 0)
            {
                wherestr += " and [OA_Time].Uid =" + _uid;
                wherestr2 += " and Uid =" + _uid;
            }
            else
            {
                if (this.ddlUname.SelectedValue != "" && this.ddlUname.SelectedValue != "0")
                    wherestr += " and [OA_Time].Uid =" + this.ddlUname.SelectedValue;
            }
            //if (UserPowerId == 3)
            //{//表示部门主管

            //    wherestr += " and [OA_Time].Uid in(select Uid from [OA_User] where did=" + UserDepartmentId + ")";
            //    wherestr2 += " and did=" + UserDepartmentId;
            //}
            if (UserPowerId == 2)
            {   //表示部门主管
                wherestr2 += " and Pid>1";
                wherestr += " and Pid>1";
            }
            else
            {
                wherestr2 += " and Pid>2";
                wherestr += " and Pid>2";
            }
            wherestr += " and (nowtime>='" + this.txtBegintime.Text + "' and nowtime<='" + this.txtEndtime.Text + " 23:59:59')";
            if (!this.Page.IsPostBack)
            {
                Selectinfo(wherestr);
                BindMyEmployeeInfo();
                if (_uid != 0)
                    this.ddlUname.SelectedIndex = 0;
                else
                    this.ddlUname.SelectedValue = _uid.ToString();
                this.ddlType.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// 分页
        /// </summary>
        public void Selectinfo(string str)
        {

            int count;
            BLL.AllTimeBLL bll = new Daiv_OA.BLL.AllTimeBLL();
            this.Repeater_Time.DataSource = bll.getpage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count, str);
            this.Repeater_Time.DataBind();
            AspNetPager1.RecordCount = count;
        }

        //ddlUname绑定
        void BindMyEmployeeInfo()
        {
            DataSet ds = new Daiv_OA.BLL.UserBLL().GetList(" Uid>0" + wherestr2);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.ddlUname.Items.Add(new ListItem(dt.Rows[i]["Uname"].ToString(), dt.Rows[i]["UId"].ToString()));
            }
            dt.Clear();
            dt.Dispose();
            ds.Clear();
            ds.Dispose();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Selectinfo(wherestr);
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            string type = this.ddlType.SelectedItem.Text;
            string where = wherestr;
            if (type != "所有类型")
            {
                where += " and [OA_Time].timetype = '" + type + "'";
            }
            Selectinfo(where);
        }
    }
}
