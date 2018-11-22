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
    public partial class My_Task_List : Daiv_OA.UI.BasicPage
    {
       
        public string where = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            int Workprogress = Str2Int(q("progress"), 0);
            if (Workprogress == 1)
            {
                this.Title = "新的任务";
                where = " and [uid]=" + UserId + " and [Workprogress] = 1";
            }
            else if (Workprogress == 3)
            {
                this.Title = "已经完成";
                where = " and [uid]=" + UserId + " and [Workprogress] = 3";
            }
            else
            {
                where = " and [uid]=" + UserId + "  and [Workprogress] in(2,4,5,6,7,8,9)";
            }
            if (!this.Page.IsPostBack)
            {
                Selectinfo(where);
            }
        }
        public string strimg(object sumtime, object progresstime)
        {
            string str = "";
            if (sumtime.ToString() == "0" || progresstime.ToString() == "0")
            {
                for (int i = 1; i < 13; i++)
                {
                    str += "<img src=\"images/pic/no.gif\" />";
                }
            }
            else
            {
                int start = (Convert.ToInt32(progresstime.ToString()) * 12 / Convert.ToInt32(sumtime.ToString()));
                int end = 12 - start;
                for (int ii = 1; ii <= start; ii++)
                {
                    str += "<img src=\"images/pic/ok.gif\" />";

                }
                for (int j = 1; j <= end; j++)
                {
                    str += "<img src=\"images/pic/no.gif\" />";
                }
            }

            return str;

        }
        public string str(object name)
        {
            string namestr = name.ToString();
            switch (namestr)
            {
                case "2":
                    namestr = "已进行中";
                    break;
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
                default:
                    namestr = "错误状态";
                    break;
            }
            return namestr;

        }
        public string astr(object id,object Workprogress)
        { 
            string s="";
            if(Workprogress.ToString()=="3")
                s="<a href=\"javascript:void(0);\" title=\"查看详细\"; onclick=\"top.OA.Popup.show('My_Work_Show.aspx?id="+id.ToString()+"',-1,-1,true)\">查看详细</a>";
            else
        s="<a href=\"javascript:Up('"+id.ToString()+"')\">确定任务</a>";
            return s;
        }
        /// <summary>
        /// 分页
        /// </summary>
        public void Selectinfo(string str)
        {

            int count;
            BLL.TaskBLL bll = new Daiv_OA.BLL.TaskBLL();
            this.Repeater_Work.DataSource = bll.getpage(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out count, str);
            this.Repeater_Work.DataBind();
            AspNetPager1.RecordCount = count;
        }

        /// <summary>
        /// 分页
        /// </summary>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Selectinfo(where);
        }
    }
}
