using Daiv_OA.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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
                //this.Snumber.ReadOnly = true;
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
            List<Daiv_OA.Entity.ContactEntity> cModels = new Daiv_OA.BLL.ContactBLL().GetEntitysBySid(model.Sid);
            StringBuilder sbuilder = new StringBuilder();
            sbuilder.AppendLine("<table id = \"contactTable\"  class=\"ipt\" width=\"280px;\" >");
            sbuilder.AppendLine("<thead><tr><td>名称</td><td>电话号码</td><td>操作<input type=\"button\" id =\"contactAdd\" value =\"添加\" /></td></tr></thead>");
            int index = 0;
            if (cModels != null && cModels.Count > 0)
            {
                foreach (var item in cModels)
                {
                    sbuilder.AppendLine("<tr class=\"contactTr\">");
                    sbuilder.AppendLine("<td><input type = \"text\" name =\"contactName\" value =\""+ item.CPhoneName + "\" maxlength=\"32\"  onkeyup =\"value = value.replace(/[^\\a-\\z\\-\\Z0-9\\u4E00-\\u9FA5]/g, '')\" onpaste =\"return false\" oncontextmenu =\"return false; \" /></td>");
                    sbuilder.AppendLine("<td ><input type = \"text\" name =\"contactPhone\" value =\"" + item.Cphone + "\" style =\"width:120px;\" onkeyup=\"value = value.replace(/[^0-9]/g,'')\" onpaste=\"return false\" oncontextmenu=\"return false; \" /></td>");
                    sbuilder.AppendLine("<td><input type = \"button\" class=\"contactDelete\" value =\"删除\"  style =\""+(index==0? "display:none;" : "") +"\" /></td>");
                    sbuilder.AppendLine("</tr>");
                    index++;
                }
            }
            else
            {
                sbuilder.AppendLine("<tr class=\"contactTr\">");
                sbuilder.AppendLine("<td><input type = \"text\" name =\"contactName\" value =\"\" style =\"width:60px;\" /></td>");
                sbuilder.AppendLine("<td ><input type = \"text\" name =\"contactPhone\" value =\"\" style =\"width:120px;\" /></td>");
                sbuilder.AppendLine("<td><input type = \"button\" class=\"contactDelete\" value =\"删除\"  style =\"display:none;\" /></td>");
                sbuilder.AppendLine("</tr>");
            }
            sbuilder.AppendLine("</table>");
            this.ltMasterSetting.Text = sbuilder.ToString();

            //设置班级
            SchClassId = model.Gid;
            //设置年级
            Entity.GradeEntity cmodel = new BLL.GradeBLL().GetEntity(SchClassId);
            Entity.SchoolGradeEntity gmodel = null;
            if(cmodel != null)
            {
                SchGradeId = cmodel.GgradeID;
                //获取学校对象
                gmodel = new BLL.SchoolGradeBLL().GetEntity(SchGradeId);
            }
            //设置学校
            if(gmodel != null)
            {
                SchID = gmodel.SchoolID;
            }

        }



        //更新
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.StudentEntity model = new Entity.StudentEntity();
            Daiv_OA.BLL.ContactBLL contactBll = new Daiv_OA.BLL.ContactBLL();
            Daiv_OA.BLL.StudentBLL studentBll = new Daiv_OA.BLL.StudentBLL();
            if (Request["schClassgcid"]== null || string.IsNullOrEmpty(Request["schClassgcid"].ToString()) )
            {
                FinalMessage("班级无效!", "Student_Edit.aspx?id=" + q("id"), 0);
                return;
            }
            model = studentBll.GetEntity(Str2Int(q("id"), 0));
            model.Gname = "";
            model.Gid = int.Parse(Request["schClassgcid"]);
            model.Sname = this.Sname.Text;
            model.Sbirthday = Convert.ToDateTime(this.Sbirthday.Text);

            List<Entity.ContactEntity> contactList = new List<Entity.ContactEntity>();
            string[] contactpArr = Request.Form["contactPhone"].Split(',');
            string[] contactnArr = Request.Form["contactName"].Split(',');
            //检查电话号码
            for (int i = 0; i < contactpArr.Length; i++)
            {
                if (string.IsNullOrEmpty(contactpArr[i]) || string.IsNullOrEmpty(contactnArr[i]))
                    continue;
                if (!string.IsNullOrEmpty(contactpArr[i]) && !Validator.IsMobileNum(contactpArr[i]))
                {
                    FinalMessage(contactpArr[i] + "电话号码无效!", "Student_Edit.aspx?id=" + q("id"), 0);
                    return;
                }
                contactList.Add(new Entity.ContactEntity() { Cphone = contactpArr[i], CPhoneName = contactnArr[i] });
            }
            //检查电话号码
            //if (!string.IsNullOrEmpty(Cphone.Text) && !Validator.IsMobileNum(Cphone.Text)) {
            //    FinalMessage(Cphone.Text + "电话号码无效!", "Student_Edit.aspx?id="+ q("id"), 0);
            //    return;
            //}
            //if (!string.IsNullOrEmpty(Cphone2.Text) && !Validator.IsMobileNum(Cphone2.Text)) {
            //    FinalMessage(Cphone2.Text + "电话号码无效!", "Student_Edit.aspx?id=" + q("id"), 0);
            //    return;
            //}
            //if (!string.IsNullOrEmpty(Cphone3.Text) && !Validator.IsMobileNum(Cphone3.Text)) {
            //    FinalMessage(Cphone3.Text + "电话号码无效!", "Student_Edit.aspx?id=" + q("id"), 0);
            //    return;
            //}
            //if (!string.IsNullOrEmpty(Cphone4.Text) && !Validator.IsMobileNum(Cphone4.Text))
            //{
            //    FinalMessage(Cphone4.Text + "电话号码无效!", "Student_Edit.aspx?id=" + q("id"), 0);
            //    return;
            //}
            studentBll.Update(model);
            //修改联系电话
            //Entity.ContactEntity cModel = contactBll.GetEntityBySid(model.Sid);
            //cModel.Cphone = this.Cphone.Text;
            //cModel.Cphone2 = this.Cphone2.Text;
            //cModel.Cphone3 = this.Cphone3.Text;
            //cModel.Cphone4 = this.Cphone4.Text;
            //contactBll.Update(cModel);
            //获取情亲号数据
            //删除数据
            //contactBll.DeleteBySid(model.Sid);
            ////联系电话实体添加
            //foreach (var item in contactList)
            //{
            //    item.Sid = model.Sid;
            //    contactBll.Add(item);
            //}
            contactBll.AddBatch(contactList, model.Sid);
            logHelper.logInfo("修改班级成功！操作人：" + UserId);
            FinalMessage("操作成功", "Student_List.aspx", 0);
        }
    }
}