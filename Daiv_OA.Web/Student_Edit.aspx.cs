using Daiv_OA.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class Student_Edit : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("student-edit");
            if (!this.Page.IsPostBack)
            {
                Bind();
                this.Snumber.ReadOnly = true;
            }
        }

        //数据绑定
        void Bind()
        {
            int gid = Str2Int(q("id"), 0);
            Daiv_OA.Entity.StudentEntity model = new Daiv_OA.Entity.StudentEntity();
            model = new Daiv_OA.BLL.StudentBLL().GetEntity(gid);
            this.Snumber.Text = model.Snumber;
            this.Sname.Text = model.Sname;
            this.Sbirthday.Text = model.Sbirthday.ToString("yyyy-MM-dd");
            //绑定家长联系电话
            Daiv_OA.Entity.ContactEntity cModel = new Daiv_OA.BLL.ContactBLL().GetEntityBySid(model.Sid);
            this.Cphone.Text = cModel.Cphone;
            this.Cphone2.Text = cModel.Cphone2;
            this.Cphone3.Text = cModel.Cphone3;
            this.Cphone4.Text = cModel.Cphone4;

            string sql = "";
            Daiv_OA.BLL.StudentBLL dp = new Daiv_OA.BLL.StudentBLL();
            DataSet ds = dp.GetList(sql);
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                ListItem listItem = new ListItem();
                listItem.Text = ds.Tables[0].Rows[j]["Gname"].ToString();
                listItem.Value = ds.Tables[0].Rows[j]["Gid"].ToString();
                this.ddlGid.Items.Add(listItem);
            }
            this.ddlGid.SelectedValue = model.Gid.ToString();
            ds.Clear();
        }



        //更新
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.StudentEntity model = new Entity.StudentEntity();
            Daiv_OA.BLL.ContactBLL contactBll = new Daiv_OA.BLL.ContactBLL();
            Daiv_OA.BLL.StudentBLL studentBll = new Daiv_OA.BLL.StudentBLL();
            model = studentBll.GetEntity(Str2Int(q("id"), 0));
            model.Gname = this.ddlGid.SelectedItem.Text;
            model.Gid = int.Parse(this.ddlGid.SelectedValue);
            model.Sname = this.Sname.Text;
            model.Sbirthday = Convert.ToDateTime(this.Sbirthday.Text);
            //检查电话号码
            if (!string.IsNullOrEmpty(Cphone.Text) && !Validator.IsMobileNum(Cphone.Text)) {
                FinalMessage(Cphone.Text + "电话号码无效!", "Student_Edit.aspx?id="+ q("id"), 0);
                return;
            }
            if (!string.IsNullOrEmpty(Cphone2.Text) && !Validator.IsMobileNum(Cphone2.Text)) {
                FinalMessage(Cphone2.Text + "电话号码无效!", "Student_Edit.aspx?id=" + q("id"), 0);
                return;
            }
            if (!string.IsNullOrEmpty(Cphone3.Text) && !Validator.IsMobileNum(Cphone3.Text)) {
                FinalMessage(Cphone3.Text + "电话号码无效!", "Student_Edit.aspx?id=" + q("id"), 0);
                return;
            }
            if (!string.IsNullOrEmpty(Cphone4.Text) && !Validator.IsMobileNum(Cphone4.Text))
            {
                FinalMessage(Cphone4.Text + "电话号码无效!", "Student_Edit.aspx?id=" + q("id"), 0);
                return;
            }
            studentBll.Update(model);
            //修改联系电话
            Entity.ContactEntity cModel = contactBll.GetEntityBySid(model.Sid);
            cModel.Cphone = this.Cphone.Text;
            cModel.Cphone2 = this.Cphone2.Text;
            cModel.Cphone3 = this.Cphone3.Text;
            cModel.Cphone4 = this.Cphone4.Text;
            contactBll.Update(cModel);
            logHelper.logInfo("修改班级成功！操作人：" + UserId);
            FinalMessage("操作成功", "Student_List.aspx", 0);
        }
    }
}