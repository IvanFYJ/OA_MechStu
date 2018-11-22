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

namespace Daiv_OA.Web
{
    public partial class My_Plan_Add : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("");
            if (!this.Page.IsPostBack)
            {
                Bind();
                this.ddlManager.SelectedIndex = 0;
            }
        }

        //绑定领导
        void Bind()
        {
            this.ddlManager.DataSource = new Daiv_OA.BLL.UserBLL().GetList("(did=" + UserDepartmentId + " and pid=3) OR pid=2");
            this.ddlManager.DataTextField = "Uname";
            this.ddlManager.DataValueField = "Uid";
            this.ddlManager.DataBind();
        }

        //插入信息
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string dirpath = Server.MapPath("~/Worddoc");

            if (Directory.Exists(dirpath) == false)
            {
                Directory.CreateDirectory(dirpath);
            }
            Random ro = new Random();
            int name = 1;
            string FileName = "";
            string FileExtention = "";
            FileName = Path.GetFileName(this.fuFile.FileName);
            string stro = ro.Next(100, 100000000).ToString() + name.ToString();//产生一个随机数用于新命名的文件
            string NewName = DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + stro;
            if (FileName.Length > 0)//有文件才执行上传操作再保存到数据库
            {
                FileExtention = Path.GetExtension(this.fuFile.FileName);
                string ppath = dirpath + @"\" + NewName + FileExtention;
                this.fuFile.SaveAs(ppath);
                Daiv_OA.Entity.PlanEntity model = new Daiv_OA.Entity.PlanEntity();
                model.Uid = UserId;
                model.Pwtitle = this.txtTitle.Text;
                model.Pwdate = DateTime.Now;
                model.Manager = this.ddlManager.SelectedValue;
                model.Pwpath = "Worddoc/" + NewName + FileExtention;
                model.Locked = "未锁定";
                int i = new Daiv_OA.BLL.PlanBLL().Add(model);
                if (i > 0)
                {
                    FinalMessage("操作成功", "My_Plan_List.aspx", 0);
                }
                else
                {
                    System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                    page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('对不起，操作失败！');</script>");
                }
            }
        }
    }
}
