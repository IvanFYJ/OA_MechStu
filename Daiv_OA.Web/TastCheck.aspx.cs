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
    public partial class TastCheck : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("login");
             Show();
            if (!IsPostBack)
            {
                showlist();
                GetList();
            }
        }

        protected void Show()
        {
            Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
            string id = com.getsid("tast").ToString();
            switch (id)
            { 
                case "-1":
                    gvlist.Visible = false; AspNetPager1.Visible = false;
                    break;
                case "3":
                    gvlist.Columns[7].Visible=false;gvlist.Columns[9].Visible=false;gvlist.Columns[4].Visible=false;
                    break;
                case "9":
                    gvlist.Columns[5].Visible = false; 
                    break;
                case "45678":
                    gvlist.Columns[7].Visible = false;gvlist.Columns[8].Visible=false;
                    break;
            }
           
        }
        public string str(object name)
        {
            string namestr = name.ToString();
            switch (namestr)
            { 
                case "3":
                    namestr = "已归档";
                    break;
                case "4":
                    namestr = "验收任务未完成";
                    break;
                case "5":
                    namestr = "提交：提前完成";
                    break;
                case "6":
                    namestr = "提交：按时完成";
                    break;
                case "7":
                    namestr = "提交：未完成";
                    break;
                case "8":
                    namestr = "重新申请时间";
                    break;
                case "9":
                    namestr = "拒收此任务";
                    break;
                default :
                    namestr = "错误状态";
                    break;
            }
            return namestr;
        
        }
        private void GetList()
        {
            Daiv_OA.DAL.BaseDAL BLL = new Daiv_OA.DAL.BaseDAL();
            int rowCount = 0;
            Daiv_OA.Entity.PageListModel pageModel = new Daiv_OA.Entity.PageListModel();
            pageModel.SelectList = "*";
            pageModel.Tables = "OA_ViewTast";
            pageModel.PriKey = "Tlid";
            pageModel.BlPage = 1;
            pageModel.PageSize = AspNetPager1.PageSize;
            pageModel.StrWhere = GetWhere();
            pageModel.PageIndex = AspNetPager1.CurrentPageIndex;
            pageModel.OrderByField = "Tlid desc";  //Id desc
            DataTable dt = BLL.GetList(pageModel, ref rowCount).Tables[0];
            AspNetPager1.RecordCount = rowCount;
            gvlist.DataSource = dt;
            gvlist.DataBind();

        }
        /// <summary>
        /// 获得查询where
        /// </summary>
        /// <returns></returns>
        string GetWhere()
        {
            Daiv_OA.BLL.COMDLL com=new Daiv_OA.BLL.COMDLL ();
            string str = "Workprogress=3";
            string id=com.getsid("tast").ToString();
            if (id == "3")
                str = "Workprogress=" + id.ToString();
            else if (id == "9")
            {
                str = "Workprogress=9 and Manager=" + "'" + getvalue(2) + "'";
            }
            else if (id == "45678")
            {
                str = "Workprogress in(4,5,6,7,8)";
                str += " and Manager=" + "'" + getvalue(2) + "'";
            }
            if (Tasktitle.Text.Trim() != "")
                str += " and (Tasktitle like " + "'" + Tasktitle.Text.Trim() + "%')";
            if (classse.SelectedValue.ToString() != "0")
                str += " and classse=" +"'"+ classse.SelectedValue.ToString()+"'";
            return str;
        }
       
        protected void AspNetPager1_PageChanged1(object src, Sisans.AspNetPager.PageChangedEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            GetList();
        }

        protected void gvlsit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex =1;
            GetList();
        }

        protected void gvlist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string sid=gvlist.DataKeys[e.NewEditIndex].Value.ToString();
            txtid.Text = sid;
            showlist();
        }
        //保存设置
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim() != "")
            {
                int id = Convert.ToInt32(txtid.Text.Trim());
                Daiv_OA.Entity.TaskEntity taskEntity = new Daiv_OA.BLL.TaskBLL().GetEntity(id);
                taskEntity.Nowtime = Convert.ToDateTime(this.txtBegintime.Text);
                taskEntity.Plantime = Convert.ToDateTime(this.txtEndtime.Text);
                taskEntity.Worktime = Convert.ToDateTime(this.txtEndtime.Text);
                taskEntity.Sumtime = Daiv_OA.BLL.TaskBLL.timespans(taskEntity.Nowtime, taskEntity.Plantime);
                taskEntity.Tlid = id;
                int uid = taskEntity.Uid;
                taskEntity.Workprogress =Convert.ToInt32(Workprogress.SelectedValue.ToString());
                if (taskEntity.Nowtime > taskEntity.Plantime)
                    Tools.Common.JavaScript.MessageBox(this, "任务发布时间必须小于计划完成时间！");
                else
                {
                    new BLL.TaskBLL().Update(taskEntity);
                    string name = new Daiv_OA.UI.BasicPage().getvalue(2);
                    if (Workprogress.SelectedValue.ToString() == "3")//验收此任务已完成
                        Daiv_OA.BLL.OA_SysMessageIn.ADDsysMessage(6, "," + uid + ",", "验收结果", name + "验收结果显示您的任务已完成", "My_Work_Show.aspx?id=" + id);
                    else if (Workprogress.SelectedValue.ToString() == "4")//未及时完成
                        Daiv_OA.BLL.OA_SysMessageIn.ADDsysMessage(6, "," + uid + ",", "验收结果", name + "验收结果显示您的任务未完成", "My_Work_Show.aspx?id=" + id);
                    else
                        Daiv_OA.BLL.OA_SysMessageIn.ADDsysMessage(8, "," + uid + ",", "验收结果", name + "已经重新安排了任务新时间", "My_Work_Show.aspx?id=" + id);
                    FinalMessage("任务验收执行成功", "TastCheck.aspx?tast=45678", 0);
                }

            }
        }
        void showlist()
        {
            if (txtid.Text.Trim() != "")
            {  
                qs.Visible = true;
                Daiv_OA.Entity.TaskEntity model = new Daiv_OA.Entity.TaskEntity();
                int id = Convert.ToInt32(txtid.Text.Trim());
                model = new BLL.TaskBLL().GetEntity(id);
                if (id == 4 || id == 8)
                { Workprogress.SelectedValue = model.Workprogress.ToString(); }
                this.txtBegintime.Text = model.Nowtime.ToString();
                this.txtEndtime.Text = model.Plantime.ToString();
                this.txtTitle.Text = model.Tasktitle.ToString();
                Daiv_OA.Entity.UserEntity userEntity = new Daiv_OA.Entity.UserEntity();
                userEntity = new BLL.UserBLL().GetEntity(model.Uid);
                Uidtxt.Text = userEntity.Uname.ToString();
            }
            else
                qs.Visible = false;
        }

       
       
    }
}
