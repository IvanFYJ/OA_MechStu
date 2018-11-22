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
    public partial class Task_List : Daiv_OA.UI.BasicPage
    {
        string wherestr = " and Workprogress in(1,2)";
        string wherestr2 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("task-show");
            if (!this.Page.IsPostBack)
            {
                this.txtBegintime.Text = System.DateTime.Today.ToString("yyyy-MM-dd");
                this.txtEndtime.Text = System.DateTime.Today.AddMonths(1).ToString("yyyy-MM-01");
            }

            if (this.ddlUname.SelectedValue != "" && this.ddlUname.SelectedValue != "0")
                wherestr += " and [OA_Task].Uid =" + this.ddlUname.SelectedValue;
            if (UserPowerId == 3)
            {  //表示部门主管
                wherestr += " and [OA_Task].Manager=" + "'" + getvalue(2) + "'";
                wherestr2 += " Pid>2";
            }
            if (UserPowerId == 2)//主管
            {
                wherestr += " and Pid>1";
                wherestr2 += " Pid>1";
            }
            wherestr += " and (Plantime>='" + this.txtBegintime.Text + "' and Plantime<='" + this.txtEndtime.Text + " 23:59:59')";
            if (!this.Page.IsPostBack)
            {
                Selectinfo(wherestr);
                BindMyEmployeeInfo();
                //if (_uid != 0)
                //    this.ddlUname.SelectedIndex = 0;
                //else
                //    this.ddlUname.SelectedValue = _uid.ToString();
            }
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        public void Selectinfo(string str)
        {
            int count;
            Daiv_OA.BLL.AllTaskBLL bll = new Daiv_OA.BLL.AllTaskBLL();
            this.pro_repeater.DataSource = bll.getpage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count, str);
            this.pro_repeater.DataBind();
            AspNetPager1.RecordCount = count;

        }

        //ddlUname绑定
        void BindMyEmployeeInfo()
        {
            DataSet ds = new Daiv_OA.BLL.UserBLL().GetList( wherestr2);
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
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbEdit_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("Task_Edit.aspx?id=" + e.CommandArgument);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbDel_Click(object sender, CommandEventArgs e)
        {
            User_Load("task-del");
            Daiv_OA.Entity.TaskEntity taskEntity = new Daiv_OA.Entity.TaskEntity();
            taskEntity = new Daiv_OA.BLL.TaskBLL().GetEntity(Convert.ToInt32(e.CommandArgument));
            if (UserName == taskEntity.Manager)
            {
                if (taskEntity.Ttype == "锁定")
                {
                    System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                    page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('该任务已锁定！');</script>");
                }
                else
                {
                    new Daiv_OA.BLL.TaskBLL().Delete(Convert.ToInt32(e.CommandArgument));
                    Selectinfo(wherestr);
                }
            }
            else
            {
                System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('该任务你无权修改！');</script>");
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            Selectinfo(wherestr);
        }
    }
}
