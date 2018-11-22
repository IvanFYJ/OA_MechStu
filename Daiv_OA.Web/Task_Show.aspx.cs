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
    public partial class Task_Show : Daiv_OA.UI.BasicPage
    {
        public string text;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("task-show");
            if (!this.Page.IsPostBack)
            {
                Msgbind();
            }
        }

        void Msgbind()
        {
            int id = Str2Int(q("id"), 0);
            Entity.TaskEntity model = new Entity.TaskEntity();
            model = new Daiv_OA.BLL.TaskBLL().GetEntity(id);
            this.lblTitle.Text = model.Tasktitle;
            this.lblBegintime.Text = model.Nowtime.ToString();
            this.lblEndtime.Text = model.Plantime.ToString();
            txt.Text = model.Content;
            question.Text = model.Question;
            classse.Text = model.Classse;
            Manager.Text = model.Manager;
            labwork.Text = model.Worktime.ToString();
        }

        public string download()
        {
            string str ="";
            int id = Str2Int(q("id"), 0);
            Entity.TaskEntity model = new Entity.TaskEntity();
            model = new Daiv_OA.BLL.TaskBLL().GetEntity(id);
            if (model.Filepath != null)
            {
                string[] rows = model.Filepath.ToString().Split(",".ToCharArray());
                if (rows.Length > 1)
                {
                    for (int i = 0; i < rows.Length - 1;i++ )
                    {
                        str += "<a href=\"/workfile/" + rows[i].ToString() + "\" style=\"border:0\">" + rows[i].Substring(rows[i].LastIndexOf("$") + 1) + "</a><br />&nbsp;";

                    }
                }
            }
            return str;
        }

    }
}
