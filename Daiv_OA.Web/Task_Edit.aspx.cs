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
    public partial class Task_Edit : Daiv_OA.UI.BasicPage
    {
        protected string wherestr2 = "";
        Daiv_OA.DAL.FilenameDAL sql = new Daiv_OA.DAL.FilenameDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("task-edit");
            if (UserPowerId == 2)
            {   //表示部门主管
                wherestr2 = " Pid>1";
            }
            else
            {
                wherestr2 = " Pid>2";
            }
            if (!this.Page.IsPostBack)
            {
                ddlWorkerbind();
                Bind();
                MyValidate();
                showfile();
            }
        }

        //判断是否是发布任务的本人
        void MyValidate()
        {
            Daiv_OA.Entity.TaskEntity taskEntity = new Daiv_OA.Entity.TaskEntity();
            taskEntity = new Daiv_OA.BLL.TaskBLL().GetEntity(Str2Int(q("id")));
            if (UserName != taskEntity.Manager)
            {
                FinalMessage("该任务你无权修改", "", 1);
            }
        }

        //checkboxlist的绑定
        void ddlWorkerbind()
        {
            this.ddlWorker.DataSource = new Daiv_OA.BLL.UserBLL().GetList(wherestr2);
            this.ddlWorker.DataTextField = "Uname";
            this.ddlWorker.DataValueField = "Uid";
            this.ddlWorker.DataBind();
        }

        //信息绑定
        void Bind()
        {
            Daiv_OA.Entity.TaskEntity model = new Daiv_OA.Entity.TaskEntity();
            model = new BLL.TaskBLL().GetEntity(Str2Int(q("id")));
            if (model.Ttype == "锁定")
            {
                Response.Redirect("Locked.aspx");

            }
            Daiv_OA.Entity.UserEntity userEntity = new Daiv_OA.Entity.UserEntity();
            userEntity = new BLL.UserBLL().GetEntity(model.Uid);
            this.txtBegintime.Text = model.Nowtime.ToString();
            this.txtEndtime.Text = model.Plantime.ToString();
            this.txtTitle.Text = model.Tasktitle;
            this.ddlWorker.SelectedValue = userEntity.Uid.ToString();
            txt.Text = model.Content;
            questext.Text = model.Question;
            this.ddlWorker.Enabled = false;
            this.classse.SelectedValue = model.Classse;

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Daiv_OA.Entity.TaskEntity taskEntity = new Daiv_OA.BLL.TaskBLL().GetEntity(Str2Int(q("id")));
            taskEntity.Content = txt.Text;
            taskEntity.Nowtime = Convert.ToDateTime(this.txtBegintime.Text);
            taskEntity.Plantime = Convert.ToDateTime(this.txtEndtime.Text);
            taskEntity.Worktime = Convert.ToDateTime(this.txtEndtime.Text);
            taskEntity.Tasktitle = this.txtTitle.Text;
            taskEntity.Ttype = "未锁定";
            taskEntity.Uid = Convert.ToInt32(this.ddlWorker.SelectedValue);
            taskEntity.Sumtime = Daiv_OA.BLL.TaskBLL.timespans(taskEntity.Nowtime, taskEntity.Plantime);
            taskEntity.Progresstime = 0;
            taskEntity.Classse = this.classse.SelectedValue;
            taskEntity.Question = questext.Text;
            taskEntity.Tlid = Str2Int(q("id"));
            if (taskEntity.Nowtime > taskEntity.Plantime)
            {
                System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('任务发布时间必须小于计划完成时间！');</script>");
            }
            else
            {
                new BLL.TaskBLL().Update(taskEntity);
                FinalMessage("任务修改成功", "Task_List.aspx", 0);
            }
            //查看任务详情，工作信息表的更新
        }

        public string GetFileSize(int size)
        {
            string FileSize = "";
            if (size != 0)
            {
                if (size >= 1073741824)
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1073741824), 3).ToString() + " GB";  //GB
                }
                else if (size >= 1048576)
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1048576), 3).ToString() + " MB";
                }
                else if (size >= 1024)
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1024), 3).ToString() + " KB";
                }
                else
                {
                    FileSize = size.ToString() + " bytes";
                }
            }
            else
            {
                FileSize = size.ToString() + " bytes";
            }
            return FileSize;
        }
        ////上传附件
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    foreach (UploadedFile file in RadUploadContext.Current.UploadedFiles)
        //    {
        //        string files = DateTime.Now.ToString("yyMMddHHmmss");
        //        string Newname = files + "$" + file.GetName().ToString();
        //        //组合路径，file.GetName()取得文件名
        //        string Path = Server.MapPath(@"/workfile/" + Newname);
        //        if (file != null)
        //        {
        //            string fileName = file.GetName().ToString(); //上传文件名
        //            int side = file.ContentLength;
        //            string fileExtension = file.GetExtension();//上传文件的扩展名
        //            if (fileExtension.ToLower().Contains(".doc") || fileExtension.ToLower().Contains(".rar") || fileExtension.ToLower().Contains(".zip"))//检测是否为允许的上传文件类型
        //            {
        //                message.Visible = false;
        //                if (Utils.DirFile.FileExists("/workfile/" + Newname))
        //                {
        //                    System.IO.File.Delete(Server.MapPath(@"/workfile/" + Newname));
        //                }
        //                //保存
        //                file.SaveAs(Path, true);
        //                //添加数据并显示
        //                sql.Add(Convert.ToInt32(getvalue(1)), Newname, GetFileSize(side));
        //                showfile();
        //            }
        //            else
        //            {
        //                message.Visible = true;
        //                return;
        //            }

        //        }

        //    }
        //}
        public string getfile(object str)
        {
            string[] a = str.ToString().Split("$".ToCharArray());
            return a[1].ToString();
        }
        protected void Repeater1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(Repeater1.DataKeys[e.RowIndex].Value.ToString());
            sql.Del(Convert.ToInt32(getvalue(1)), id);
            showfile();
        }

        void showfile()
        {
            Repeater1.DataSource = sql.Select(Convert.ToInt32(getvalue(1)), Str2Int(q("id")));
            Repeater1.DataBind();
        }
    }
}
