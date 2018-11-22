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
    public partial class My_TaskCheckt : Daiv_OA.UI.BasicPage //System.Web.UI.Page
    {
        Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
             string sid=com.getsid("id");
            Daiv_OA.BLL.TaskBLL s=new Daiv_OA.BLL.TaskBLL ();
             if (sid != "-1")
             {
                 DataTable dt = s.GetList("Tlid=" + sid).Tables[0];
                if (dt.Rows.Count != 0)
                {
                     Workprogress.SelectedValue = dt.Rows[0]["Workprogress"].ToString();
                     titlename.Text = dt.Rows[0]["remark"].ToString();
                }
             }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sid=com.getsid("id");
            string names = new Daiv_OA.UI.BasicPage().getvalue(2);
            if(sid!="-1")
            {
                string uid = "0";
                DataTable dt = com.COM_Select("OA_Task", "Tlid", "",sid, "", 4);
                if (dt.Rows.Count != 0)
                {
                    string uname= dt.Rows[0]["Manager"].ToString();
                  DataTable  dts = com.COM_Select("OA_User", "Uname", "",uname, "", 4);
                    if(dts.Rows.Count!=0)
                       uid= dts.Rows[0]["Uid"].ToString();
                }
               
            
                new Daiv_OA.BLL.TaskBLL().UpworkprogressTs(Workprogress.SelectedValue.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),titlename.Text,Convert.ToInt32(sid));
               switch(Workprogress.SelectedValue.ToString())
               {
                   case "5":
                       Daiv_OA.BLL.OA_SysMessageIn.ADDsysMessage(5, "," + uid + ",", "请求任务验收", names + "提前完成了任务请您验收", "TastCheck.aspx?tast=45678");
                       break;
                        case "6":
                       Daiv_OA.BLL.OA_SysMessageIn.ADDsysMessage(5, "," + uid + ",", "请求任务验收", names + "完成了任务请您验收", "TastCheck.aspx?tast=45678");
                        break;
                        case "7":
                        Daiv_OA.BLL.OA_SysMessageIn.ADDsysMessage(5, "," + uid + ",", "请求任务验收", names + "未按时完成了任务阅读详细", "TastCheck.aspx?tast=45678");
                       break;
                        case "8":
                       Daiv_OA.BLL.OA_SysMessageIn.ADDsysMessage(8, "," + uid + ",", "请求任务验收", names + "申请工作协调新时间急需您安排新时间", "TastCheck.aspx?tast=45678");
                       break;
                        case "9":
                       Daiv_OA.BLL.OA_SysMessageIn.ADDsysMessage(5, "," + uid + ",", "请求任务验收", names + "拒收了您安排的任务阅读详细", "TastCheck.aspx?tast=9");
                       break;
               }
            }
            Response.Write("<script>parent.location.href='My_Task_List.aspx'</script>"); 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            page.ClientScript.RegisterStartupScript(this.GetType(), "", "javascritp:close();", true);
        }

        //protected void Workprogress_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (Workprogress.SelectedValue.ToString() == "9")
        //        ju.Visible = true;
        //    else
        //        ju.Visible = false;
        //}
    }
}
