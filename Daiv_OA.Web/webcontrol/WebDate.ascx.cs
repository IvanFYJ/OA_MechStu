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
using System.IO;
using System.Text;
namespace Daiv_OA.Web.webcontrol
{
    public partial class WebDate : System.Web.UI.UserControl
    {
        string[] arrDay;
        Daiv_OA.UI.BasicPage bg = new Daiv_OA.UI.BasicPage();
        // BLL.OA.UserOffice.Calendar bllCalendar; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //当前日期
                hidCurrDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                //是否存在用户传值
                if (Request.QueryString["ucode"] != null && Request.QueryString["ucode"] != "")
                {
                    hidUserCode.Value = Request.QueryString["ucode"];
                }
                //判断页面传值日期是否为空
                if (Request.QueryString["date"] != null)
                {
                    hidCurrDate.Value = Request.QueryString["date"];
                }
                CalendarBind();
            }
        }

        private void CalendarBind()
        {
            //当前日期
            DateTime currDate = Convert.ToDateTime(hidCurrDate.Value);
            //DateTime currDate = DateTime.Now;
            //当前年
            int currYear = currDate.Year;
            //当前月
            int currMonth = currDate.Month;
            StringBuilder strHTML = new StringBuilder();
            string[] strArr = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            strHTML.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"1\"  style=\"width:100%;background-color:Gray \">");
            strHTML.Append("<tr >");
            strHTML.Append("<td colspan=\"7\" style=\"background-color:#E0EEE0; height:23px;\";  align=\"center\">");
            strHTML.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
            strHTML.Append("<tr>");
            strHTML.Append("<td style=\"border-width:0px;color:#4B0082; height:23px;\">");
            strHTML.Append(string.Format("<a title=\"上一年\" href=\"?date={0:yyyy-MM-dd}&ucode={1}&uname={2}\">&nbsp;上一年</a>", currDate.AddYears(-1), hidUserCode.Value, hidUserName.Value));
            strHTML.Append("</td>");
            strHTML.Append("<td  style=\"border-width:0px;color:#36648B; height:23px;\">");
            strHTML.Append(string.Format("&nbsp;{0}年&nbsp;", currYear));
            strHTML.Append("</td>");
            strHTML.Append("<td style=\"border-width:0px;color:#4B0082; height:23px;\">");
            strHTML.Append(string.Format("<a title=\"下一年\" href=\"?date={0:yyyy-MM-dd}&ucode={1}&uname={2}\">下一年&nbsp;</a>", currDate.AddYears(1), hidUserCode.Value, hidUserName.Value));
            strHTML.Append("</td>");
            strHTML.Append("<td style=\"border-width:0px;padding-left:50px;color:#36648B; height:23px;\">");
            strHTML.Append(string.Format("<a title=\"上月\" href=\"?date={0:yyyy-MM-dd}&ucode={1}&uname={2}\">&nbsp;上月</a>", currDate.AddMonths(-1), hidUserCode.Value, hidUserName.Value));
            strHTML.Append("</td>");
            strHTML.Append("<td  style=\"border-width:0px;color:#CD0000;height:23px;\">");
            strHTML.Append(string.Format("&nbsp;{0}月&nbsp;", currMonth));
            strHTML.Append("</td>");
            strHTML.Append("<td style=\"border-width:0px;color:#36648B; height:23px;\">");
            strHTML.Append(string.Format("<a title=\"下月\" href=\"?date={0:yyyy-MM-dd}&ucode={1}&uname={2}\">下月&nbsp;</a>", currDate.AddMonths(1), hidUserCode.Value, hidUserName.Value));
            strHTML.Append("</td>");
            strHTML.Append("<td style=\"border-width:0px;padding-left:20px;color:#E0EEE0; height:23px;\">");
            strHTML.Append(string.Format("<a title=\"转到本月\" href=\"?date={0:yyyy-MM-dd}&ucode={1}&uname={2}\">转到本月</a>", DateTime.Now, hidUserName.Value, hidUserName.Value));
            strHTML.Append("</td>");
            strHTML.Append("</tr>");
            strHTML.Append("</table>");
            strHTML.Append("</td>");
            strHTML.Append("</tr>");
            strHTML.Append("<tr>");
            for (int i = 0; i < 7; i++)
            {
                strHTML.Append("<td style=\"height:24px;background:url(../images/pic/03.jpg);\">");
                strHTML.Append(strArr[i]);
                strHTML.Append("</td>");
            }
            strHTML.Append("</tr>");
            strHTML.Append("<tr>");
            //数据表
            DataTable tblData;

            //获取该月有几天
            int dayCount = GetMonthDays(currYear, currMonth);
            //获取该月最后一天为星期几
            int weekLastDay = (int)DateTime.Parse(currYear + "-" + currMonth + "-" + dayCount).DayOfWeek;
            //获取该月第一天为星期几
            int weekOneDay = (int)DateTime.Parse(currYear + "-" + currMonth + "-" + "1").DayOfWeek;
            //填充上一个月的最后一周
            GetPreMonthLastWeek(currYear, currMonth, weekOneDay);
            //本月不足，填补下月的前几天
            int nextDayCount = 6 - weekLastDay;
            //获取日历需要填充的天数 本月的天数+上个月最后一周的天数+下个月开始周的天数
            int count = dayCount + weekOneDay + nextDayCount;
            //定义初始天数
            int d = 1;
            //定义下月天数
            int nDay = 1;
            string strClass = "";
            for (int i = 0; i <= count; i++)
            {
                //上个月最后几天
                if (i < weekOneDay)
                {
                    strHTML.Append("<td style=\"background-color:#ffffff; color:#BFBFBF;height:50px;\">");
                    strHTML.Append(string.Format("{0:00}", arrDay[(arrDay.Length - i - 1)].ToString()));
                    strHTML.Append("</td>");
                }
                //当前月
                if (i >= weekOneDay + 1 && d <= dayCount)
                {
                    strHTML.Append("<td style=\"background-color:#ffffff; width:13%; color:#3A5FCD;height:50px;\">");
                    strHTML.Append("<fieldset style=\"background-color:#ffffff;color:##3A5FCD;height:50px;\">");
                    //今天
                    if (currYear == DateTime.Now.Year && currMonth == DateTime.Now.Month && d == DateTime.Now.Day)
                    {
                       strClass = " style=\"color:#FF0000;\"";
                    }
                    strHTML.Append(string.Format("<legend {0}>{1:00}&nbsp;", strClass, d));
                    strHTML.Append("</legend>");
                    strClass = "";
                    tblData = Daiv_OA.BLL.PersonalBLL.GetPersonal(bg.getvalue(2), (currYear + "-" + currMonth + "-" + d).ToString());
                    ////判断是否存在日程
                    if (tblData.Rows.Count!=0)
                    {
                        strHTML.Append("<table border=\"0\" cellpadding=\"1\" cellspacing=\"0\">");
                        //提取日程
                        int ii = 0;
                        foreach (DataRow row in tblData.Rows)
                        {
                            ii++;
                            string cont = "<a href=\"javascript:Additme(" + row["Id"].ToString() + ")\" title=\"查看详细\" >" + "<font style=\"color:#3B3B3B\">" + ii.ToString()+"." + Daiv_OA.Utils.Strings.Left(row["note"].ToString(), 5) + "</font>" + "</a>";
                            strHTML.Append("<tr>");
                            strHTML.Append("<td align=\"center\" style=\"background-color:#ffffff;border-width:0px;color:#FF0000;\">");
                            strHTML.Append(cont);                     
                            strHTML.Append("</td>");
                            strHTML.Append("</tr>");
                        }
                        strHTML.Append("</table>");
                    }
                    strHTML.Append("</fieldset>");
                    strHTML.Append("</td>");

                    d++;
                }
                //下个月前几天
                if (i > dayCount + weekOneDay)
                {
                    strHTML.Append("<td style=\"background-color:#ffffff;color:#BFBFBF;height:50px;\">");
                    strHTML.Append(string.Format("{0:00}", nDay));
                    strHTML.Append("</td>");
                    nDay++;
                }
                if (i % 7 == 0 && i != 0 && i != count)
                {
                    strHTML.Append("</tr>");
                    strHTML.Append("<tr>");
                }
            }
            strHTML.Append("</tr>");
            strHTML.Append("</table>");
            lblCalendar.Text = strHTML.ToString();
        }

        #region GetMonthDays 获得月的天数
        /// <summary>
        /// 获得月的天数
        /// </summary>
        /// <param name="inputDate"></param>
        /// <returns></returns>
        public int GetMonthDays(int year, int month)
        {
            return Convert.ToDateTime(DateTime.Parse(year + "-" + month + "-" + "1").AddMonths(1).AddDays(-1).ToShortDateString()).Day;
        }
        #endregion
        #region GetPreMonthLastWeek 填充上一个月最后一周
        /// <summary>
        /// 填充上一个月最后一周
        /// </summary>
        private void GetPreMonthLastWeek(int year, int month, int week)
        {
            DateTime dt = new DateTime();
            //判断，假如该月的第一天不是星期日
            if (week != 7)
            {
                dt = DateTime.Parse(year + "-" + month + "-" + "1").AddMonths(-1);
            }
            //获取上一个月有几天
            int dayCount = Convert.ToDateTime(dt.AddMonths(1).AddDays(-1).ToShortDateString()).Day;
            dt = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + dayCount);
            //将获取到的天数存储到公共变量
            arrDay = new string[week];
            for (int i = 0; i < week; i++)
            {
                arrDay[i] = Convert.ToString(dt.AddDays(-i).Day);
            }
        }
        #endregion

       
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // bllCalendar = new BLL.OA.UserOffice.Calendar();
            //日程数据
        }
    }
}