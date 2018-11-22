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
using Telerik.WebControls;

namespace Daiv_OA.Web
{
    public partial class Task_Add : Daiv_OA.UI.BasicPage
    {
        Daiv_OA.DAL.FilenameDAL sql = new Daiv_OA.DAL.FilenameDAL();
      
        protected string wherestr2 = "";
        public int _uid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("task-add");
            _uid = Str2Int(q("uid"));
            if (getvalue(4) == "2")
            {//表示部门主管
                wherestr2 = "Pid>1 and Uid!=" + getvalue(1);
            }
            else
            {
                wherestr2 = "Pid>2 and Uid!=" + getvalue(1);
            }
         
            if (!this.Page.IsPostBack)
            {
                show();
                showfile();
            }
            
        }

        //checkboxlist的绑定
        void ddlWorkerbind()
        {
            this.txtBegintime.Text = DateTime.Now.ToString();
            Daiv_OA.BLL.UserBLL user=new Daiv_OA.BLL.UserBLL ();
             DataTable table= user.GetList(wherestr2).Tables[0];
             for(int i=0;i<table.Rows.Count;i++)
             {
                 ListItem item = new ListItem();
                 item.Value = table.Rows[i]["Uid"].ToString();
                 DataSet ds = new Daiv_OA.BLL.TaskBLL().GetList(" uid = " + Convert.ToInt32(table.Rows[i]["Uid"].ToString()) + " and worktime > '" + Convert.ToDateTime(this.txtBegintime.Text) + "' and [Workprogress]in(2,5,6,7,8)");
                 if (ds.Tables[0].Rows.Count != 0)
                     item.Text =table.Rows[i]["Uname"].ToString()+ "<font style=\"color:#FF0000\">(" + ds.Tables[0].Rows.Count + ")</font>";
                 else
                     item.Text = table.Rows[i]["Uname"].ToString();
                 ddlWorker.Items.Add(item);
             }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Daiv_OA.Entity.TaskEntity taskEntity = new Daiv_OA.Entity.TaskEntity();
            if (this.ddlWorker.SelectedValue.ToString()!="")
            {
               
                DateTime begin = Convert.ToDateTime(this.txtBegintime.Text);
                DateTime end = Convert.ToDateTime(this.txtEndtime.Text);
                if (begin < end)
                {
                        //可以添加
                        taskEntity.Content = txt.Text.Trim();
                        taskEntity.Manager = UserName;
                        taskEntity.Nowtime = Convert.ToDateTime(this.txtBegintime.Text);
                        taskEntity.Plantime = Convert.ToDateTime(this.txtEndtime.Text);
                        taskEntity.Tasktitle = this.txtTitle.Text;
                        taskEntity.Worktime = Convert.ToDateTime(this.txtEndtime.Text);
                        taskEntity.Workprogress = 1;
                        taskEntity.Ttype = "未锁定";
                        taskEntity.Sumtime = Daiv_OA.BLL.TaskBLL.timespans(taskEntity.Nowtime,taskEntity.Plantime);
                        taskEntity.Progresstime = 0;
                        taskEntity.Classse = classse.SelectedValue.ToString();
                    DataTable dt=sql.Select(Convert.ToInt32(getvalue(1)),0);
                    foreach(DataRow dr in dt.Rows)
                    {
                        taskEntity.Filepath += dr["names"] + ",";
                    }
                    taskEntity.Question=questext.Text;
                        int i = 0;
                    for (int c = 0; c < ddlWorker.Items.Count; c++)
                        {
                            if (ddlWorker.Items[c].Selected)
                            {
                              taskEntity.Uid = Convert.ToInt32(ddlWorker.Items[c].Value.ToString());
                              string ToUid = "," + taskEntity.Uid + ",";
                              i = new Daiv_OA.BLL.TaskBLL().Add(taskEntity);
                              Daiv_OA.BLL.OA_SysMessageIn.ADDsysMessage(4, ToUid, "新的工作任务" + taskEntity.Tasktitle, Daiv_OA.Utils.Strings.Left(Daiv_OA.Utils.Strings.delhtml(txt.Text.ToString()), 53), "My_Work_Show.aspx?id=" + i.ToString());
                       
                            }
                        }
                        if (i > 0)
                        {
                           // Daiv_OA.Utils.QQRobotHelp.SendClusterMessage();
                            sql.Up(Convert.ToInt32(getvalue(1)),i);
                            FinalMessage("任务添加成功", "Task_List.aspx", 0);
                        }
                        else
                        {
                            FinalMessage("任务添加失败", "Task_List.aspx", 0);
                        }
                  
                }
                else
                {
                    System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                    page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('任务开始时间必须大于计划结束时间！');</script>");
                }
            }
            else
            {
                System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('请选择员工！');</script>");
            }
        }

        void show()
        {
            if (_uid != 0)
            {
                ddlWorkerbind();
            for(int i=0;i<this.ddlWorker.Items.Count;i++)
            {
                if (ddlWorker.Items[i].Value == _uid.ToString())
                    ddlWorker.Items[i].Selected = true;
             }
            }
            else
            {
                ddlWorkerbind();
            }
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
        //上传附件
        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (UploadedFile file in RadUploadContext.Current.UploadedFiles)
            {
                string files = DateTime.Now.ToString("yyMMddHHmmss");
                string Newname = files + "$" + file.GetName().ToString();
                //组合路径，file.GetName()取得文件名
                string Path = Server.MapPath(@"/workfile/" + Newname);
                if (file != null)
                {
                   string fileName = file.GetName().ToString(); //上传文件名
                   int side = file.ContentLength;
                    string fileExtension = file.GetExtension();//上传文件的扩展名
                    if (fileExtension.ToLower().Contains(".doc") || fileExtension.ToLower().Contains(".rar") || fileExtension.ToLower().Contains(".zip"))//检测是否为允许的上传文件类型
                    {
                        message.Visible = false;
                        if (Utils.DirFile.FileExists("/workfile/" + Newname))
                            {
                                System.IO.File.Delete(Server.MapPath(@"/workfile/" + Newname));
                            }
                            //保存
                            file.SaveAs(Path, true);
                            //添加数据并显示
                            sql.Add(Convert.ToInt32(getvalue(1)), Newname, GetFileSize(side));
                            showfile();
                    }
                    else
                    {
                        message.Visible = true;
                        return;
                    }

                }

            }
        }
        public string getfile(object str)
        {
            string[] a = str.ToString().Split("$".ToCharArray());
            return a[1].ToString();
        }
        protected void Repeater1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(Repeater1.DataKeys[e.RowIndex].Value.ToString());
            sql.Del(Convert.ToInt32(getvalue(1)),id);
            showfile();
        }

        void showfile()
        {
            Repeater1.DataSource = sql.Select(Convert.ToInt32(getvalue(1)),0);
            Repeater1.DataBind();
        }
    }
}
