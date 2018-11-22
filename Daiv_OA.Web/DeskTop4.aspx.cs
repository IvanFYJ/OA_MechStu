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
    public partial class DeskTop4 : Daiv_OA.UI.BasicPage
    {
        Daiv_OA.BLL.TaskBLL com = new Daiv_OA.BLL.TaskBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("login");
            if (UserPowerId != 4)
                Response.Redirect("DeskTop" + UserPowerId + ".aspx");
            if (!this.Page.IsPostBack)
            {
                BindPlacard();
                BindWorkinfo();
                Up();
               
            }
        }

        ////学习资料绑定
        //void BindLearning()
        //{
        //    this.Repeater_Learning.DataSource = new Daiv_OA.BLL.LearningBLL().GetList(5, " did=" + UserDepartmentId, "Sid Desc");
        //    this.Repeater_Learning.DataBind();
        //}

        //通知绑定
        void BindPlacard()
        {
            this.Repeater_Placard.DataSource = new Daiv_OA.BLL.PlacardBLL().GetList(5, "", "Pid Desc");
            this.Repeater_Placard.DataBind();
        }

        //工作任务绑定
        void BindWorkinfo()
        {
            string where = " uid = " + UserId + " and [Workprogress]in(1,2,8)";
            this.Repeater_Work.DataSource = new Daiv_OA.BLL.TaskBLL().GetList(5, where, "worktime desc");
            this.Repeater_Work.DataBind();
        }
        public string strimg(object sumtime,object progresstime)
        { 
            string str="";
        if(sumtime.ToString()=="0" || progresstime.ToString()=="0")
        {
            for(int i=1;i<13;i++)
            {
            str+="<img src=\"images/pic/no.gif\" />";
            }
        }
          else 
        {
            int start = (Convert.ToInt32(progresstime.ToString()) * 12 / Convert.ToInt32(sumtime.ToString()));
            int end = 12 - start;
            for (int ii = 1; ii <= start;ii++ )
            {
                str += "<img src=\"images/pic/ok.gif\" />";
            
            }
            for(int j=1;j<=end;j++)
            {
                str += "<img src=\"images/pic/no.gif\" />";
            }
        }

        return str;  
        
        }
        void Up()
        {

            DataTable table =com.GetList("uid = " + UserId + " and Workprogress in(2,5,6)").Tables[0];
            Daiv_OA.Entity.TaskEntity model = new Daiv_OA.Entity.TaskEntity();
            foreach( DataRow dr in table.Rows)
            {
                if (Convert.ToInt32(dr["Workprogress"].ToString()) == 2)
                { 
                    DateTime now=Convert.ToDateTime(DateTime.Now.ToString("yyyy-M-d HH:mm:ss"));
                    if (now <= Convert.ToDateTime(dr["Plantime"].ToString()))
                    {
                        int i = Daiv_OA.BLL.TaskBLL.timespans(Convert.ToDateTime(dr["Nowtime"].ToString()), now);
                        model.Progresstime = i;
                    }
                    else
                        continue;
                }
                else
                {   //提前完成或提交已完成
                  model.Progresstime = Convert.ToInt32(dr["sumtime"].ToString());
                }
                model.Tlid =Convert.ToInt32(dr["Tlid"].ToString());
                model.Worktime =Convert.ToDateTime( dr["Worktime"].ToString());
                model.Nowtime =Convert.ToDateTime( dr["Nowtime"].ToString());
                model.Plantime =Convert.ToDateTime( dr["Plantime"].ToString());
                model.Newnote = dr["newnote"].ToString();
                com.Update(model);
            }
        }
    }
}
