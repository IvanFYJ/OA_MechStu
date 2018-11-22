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
    public partial class My_Time_List : Daiv_OA.UI.BasicPage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            if (!this.Page.IsPostBack)
            {
                Selectinfo(wheres());
            }
        }
        private string wheres()
        {
            string where = " and [OA_Time].[uid]=" + UserId + " ";
            if (txtid.Text.Trim() != "")
            {
                where += " and (nowtime>='" + DateTime.Now.ToString("yyyy-MM") + "-01 06:00:00" + "' and nowtime<='" + txtid.Text.Trim() + " 23:59:59')";

            }
            return where;
        }

        //获取

        protected void btWork_Click(object sender, EventArgs e)
        {
            //获取登记记录
            string nowtime = DateTime.Today.ToString("yyyy-MM-dd");
            bool isfirst = new Daiv_OA.BLL.TimeBLL().Isfirst(UserId, "上班登记", nowtime);
            if (isfirst == true)
            {
                Tools.Common.JavaScript.MessageBox(this,"您上班已经登记了！");
                //System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                //page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('您上班已经登记了！');</script>");
            }
            //不存在记录就登记
            else
            {
                string retime = "08:30:00";
                Entity.TimeEntity timeEntity = new Entity.TimeEntity();
                timeEntity.Uid = UserId;
                timeEntity.Nowtime = DateTime.Now;
                timeEntity.Retime = Convert.ToDateTime(retime);
                timeEntity.Timeinfo = "";
                timeEntity.Timetype = this.btWork.Text;
                timeEntity.Ipaddress = Page.Request.UserHostAddress;
                int i = new Daiv_OA.BLL.TimeBLL().Add(timeEntity);
                if (i > 0)
                {
                    Tools.Common.JavaScript.MessageBox(this,"上班登记成功！");

                    //System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                    //Daiv_OA.Utils.QQRo Help.SendClusterMessage("OA平台消息：" + UserName + "上班来了。");
                    //page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('上班登记成功！');</script>");
                }
            }
            Selectinfo(wheres());
        }

        protected void btOff_Click(object sender, EventArgs e)
        {
            //获取登记记录
            string nowtime = DateTime.Now.ToString("yyyy-MM-dd");
            bool isfirst1 = new Daiv_OA.BLL.TimeBLL().Isfirst(UserId, "上班登记", nowtime);
            bool isfirst2 = new Daiv_OA.BLL.TimeBLL().Isfirst(UserId, "下班登记", nowtime);
            if (isfirst1 == false)//没有上班登记，不允许下班登记
            {
                System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('您今天还没进行上班登记！');</script>");
            }
            else if (isfirst2 == true)//已经下班登记
            {
                System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('您今天已经进行下班登记了！');</script>");
            }
            //不存在记录就登记
            else
            {
                string retime = "17:30:00";
                Entity.TimeEntity timeEntity = new Entity.TimeEntity();
                timeEntity.Uid = UserId;
                timeEntity.Nowtime = DateTime.Now;
                timeEntity.Retime = Convert.ToDateTime(retime);
                timeEntity.Timeinfo = "";
                timeEntity.Timetype = this.btOff.Text;
                timeEntity.Ipaddress = Page.Request.UserHostAddress;
                int i = new Daiv_OA.BLL.TimeBLL().Add(timeEntity);
                if (i > 0)
                {
                    System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                    Daiv_OA.Utils.QQRoHelp.SendClusterMessage("OA平台消息：" + UserName + "下班走了。");
                    page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('下班登记成功！');</script>");
                }
            }
            Selectinfo(wheres());
        }

        protected void btOut_Click(object sender, EventArgs e)
        {
            string retime = "08:30:00";
            Entity.TimeEntity timeEntity = new Entity.TimeEntity();
            timeEntity.Uid = UserId;
            timeEntity.Nowtime = DateTime.Now;
            timeEntity.Retime = Convert.ToDateTime(retime);
            timeEntity.Timeinfo = this.txtOut.Text;
            timeEntity.Timetype = this.btOut0.Text;
            timeEntity.Ipaddress = Page.Request.UserHostAddress;
            int i = new Daiv_OA.BLL.TimeBLL().Add(timeEntity);
            if (i > 0)
            {
                System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('外出登记成功！');</script>");
            }
            Selectinfo(wheres());
        }

        protected void btLeave_Click(object sender, EventArgs e)
        {
            string retime = "08:30:00";
            Entity.TimeEntity timeEntity = new Entity.TimeEntity();
            timeEntity.Uid = UserId;
            timeEntity.Nowtime = DateTime.Now;
            timeEntity.Retime = Convert.ToDateTime(retime);
            timeEntity.Timeinfo = this.txtLeave.Text;
            timeEntity.Timetype = this.btLeave0.Text;
            timeEntity.Ipaddress = Page.Request.UserHostAddress;
            int i = new Daiv_OA.BLL.TimeBLL().Add(timeEntity);
            if (i > 0)
            {
                System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                Daiv_OA.Utils.QQRoHelp.SendClusterMessage("OA平台消息：" + UserName + "有事请假了。");
                page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('事病假登记成功！');</script>");
            }
            Selectinfo(wheres());
        }

        protected void btErr_Click(object sender, EventArgs e)
        {
            string retime = "08:30:00";
            Entity.TimeEntity timeEntity = new Entity.TimeEntity();
            timeEntity.Uid = UserId;
            timeEntity.Nowtime = DateTime.Now;
            timeEntity.Retime = Convert.ToDateTime(retime);
            timeEntity.Timeinfo = this.txtErr.Text;
            timeEntity.Timetype = this.btErr0.Text;
            timeEntity.Ipaddress = Page.Request.UserHostAddress;
            int i = new Daiv_OA.BLL.TimeBLL().Add(timeEntity);
            if (i > 0)
            {
                System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('出差登记成功！');</script>");
            }
            Selectinfo(wheres());
        }
        protected void btLogout_Click(object sender, EventArgs e)
        {
            string retime = "08:30:00";
            Entity.TimeEntity timeEntity = new Entity.TimeEntity();
            timeEntity.Uid = UserId;
            timeEntity.Nowtime = DateTime.Now;
            timeEntity.Retime = Convert.ToDateTime(retime);
            timeEntity.Timeinfo = this.txtLogout.Text;
            timeEntity.Timetype = this.btLogout0.Text;
            timeEntity.Ipaddress = Page.Request.UserHostAddress;
            int i = new Daiv_OA.BLL.TimeBLL().Add(timeEntity);
            if (i > 0)
            {
                System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('销假登记成功！');</script>");
            }
            Selectinfo(wheres());
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Selectinfo(wheres());
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
            this.trOut.Visible = false;
            this.trLeave.Visible = false;
            this.trErr.Visible = false;
            this.trLogout.Visible = false;
        }

        /// <summary>
        /// 获取姓名
        /// </summary>
        public string Getuname()
        {
            return UserName;
        }

        //获取角色
        string Getposi(int uid)
        {
            string sql = "select * from [OA_Power] where Pid = (select Pid FROM [OA_User] where uid ='" + uid + "')";
            Entity.PowerEntity posi = new Entity.PowerEntity();
            posi = new Daiv_OA.BLL.UserBLL().Getpomodel(sql);
            string pname = posi.PName;
            return pname;
        }

        protected void btOut0_Click(object sender, EventArgs e)
        {
            this.trOut.Visible = true;
            this.txtOut.Text = "";
            this.trLeave.Visible = false;
            this.trErr.Visible = false;
            this.trLogout.Visible = false;
        }

        protected void btLeave0_Click(object sender, EventArgs e)
        {
            this.trOut.Visible = false;
            this.trLeave.Visible = true;
            this.txtLeave.Text = "";
            this.trErr.Visible = false;
            this.trLogout.Visible = false;
        }

        protected void btErr0_Click(object sender, EventArgs e)
        {
            this.trOut.Visible = false;
            this.trLeave.Visible = false;
            this.trErr.Visible = true;
            this.txtErr.Text = "";
            this.trLogout.Visible = false;
        }

        protected void btLogout0_Click(object sender, EventArgs e)
        {
            this.trOut.Visible = false;
            this.trLeave.Visible = false;
            this.trErr.Visible = false;
            this.trLogout.Visible = true;
            this.txtLogout.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            txtid.Text = DateTime.Now.ToString("yyyy-MM-dd").ToString();
            string  where = "";
            where = " and [OA_Time].[uid]=" + UserId + " ";
            where += " and (nowtime>='" + DateTime.Now.ToString("yyyy-MM") + "-01 06:00:00" + "' and nowtime<='" + txtid.Text.Trim() + " 23:59:59')";
            Selectinfo(where);
            txtid.Text = "";
        }


    }
}
