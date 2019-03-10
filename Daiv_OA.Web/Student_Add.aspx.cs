using Daiv_OA.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class Student_Add : Daiv_OA.UI.BasicPage
    {
        protected int classId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("student-add");
            //班级ID
            string cid = Request["cid"];
            if (!string.IsNullOrEmpty(cid))
            {
                try
                {
                    classId = Convert.ToInt32(cid);
                }
                catch (Exception)
                {
                }
            }

            if (!this.IsPostBack)
            {
                //string sql = "";
                //Daiv_OA.BLL.GradeBLL dp = new Daiv_OA.BLL.GradeBLL();
                //DataSet ds = dp.GetList(sql);
                //for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                //{
                //    ListItem listItem = new ListItem();
                //    listItem.Text = ds.Tables[0].Rows[j]["Gname"].ToString();
                //    listItem.Value = ds.Tables[0].Rows[j]["Gid"].ToString();
                //    this.ddlGid.Items.Add(listItem);
                //}
                //ds.Clear();
            }

            //设置班级
            SchClassId = classId;
            //设置年级
            Entity.GradeEntity cmodel = new BLL.GradeBLL().GetEntity(SchClassId);
            Entity.SchoolGradeEntity gmodel = null;
            if (cmodel != null)
            {
                SchGradeId = cmodel.GgradeID;
                //获取学校对象
                gmodel = new BLL.SchoolGradeBLL().GetEntity(SchGradeId);
            }
            //设置学校
            if (gmodel != null)
            {
                SchID = gmodel.SchoolID;
            }
        }



        //添加
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.StudentEntity studentEntity = new Entity.StudentEntity();
            Entity.UserEntity parent = new Entity.UserEntity();
            Entity.ContactEntity contactEnitty = new Entity.ContactEntity();
            if (Request["schClassgcid"] == null || string.IsNullOrEmpty(Request["schClassgcid"].ToString()))
            {
                FinalMessage("班级无效!", "Student_Add.aspx?id=" + q("id"), 0);
                return;
            }
            //学生实体相关信息保存
            studentEntity.Gname = "";
            studentEntity.Gid = int.Parse( Request["schClassgcid"]);
            studentEntity.Snumber = this.Snumber.Text;
            studentEntity.Sname = this.Sname.Text;
            studentEntity.Sbirthday =Convert.ToDateTime(this.Sbirthday.Text);
            //家长实体相关信息保存
            parent.Uname = studentEntity.Snumber;
            string pwd = studentEntity.Sbirthday.ToString("yy") + studentEntity.Sbirthday.ToString("MM") + studentEntity.Sbirthday.ToString("dd");
            parent.Upwd = Daiv_OA.Utils.MD5.Lower32(pwd);
            parent.Pid = 4;
            parent.Did = 0;
            parent.Position = "家长";
            parent.Mphone = "";
            Entity.PowerEntity powerEntity = new BLL.PowerBLL().GetEntity(parent.Pid);
            parent.Setting = powerEntity.Setting;
            //联系电话实体相关信息保存
            //contactEnitty.Cphone = this.Cphone.Text;
            //contactEnitty.Cphone2 = this.Cphone2.Text;
            //contactEnitty.Cphone3 = this.Cphone3.Text;
            //contactEnitty.Cphone4 = this.Cphone4.Text;
            List<Entity.ContactEntity> contactList = new List<Entity.ContactEntity>();
            string[] contactpArr = Request.Form["contactPhone"].Split(',');
            string[] contactnArr = Request.Form["contactName"].Split(',');
            for (int i = 0; i < contactpArr.Length; i++)
            {
                if (string.IsNullOrEmpty(contactpArr[i]) || string.IsNullOrEmpty(contactnArr[i]))
                    continue;
                contactList.Add(new Entity.ContactEntity() { Cphone=contactpArr[i], CPhoneName=contactnArr[i] });
            }
            //当前操作人对象
            Entity.UserEntity opera = new Daiv_OA.BLL.UserBLL().GetEntity(UserId);
            //保存数据
            try
            {
                new Daiv_OA.BLL.StudentBLL().Add(studentEntity, parent, contactList, opera);
            }
            catch (Exception ex)
            {
                FinalMessage("操作失败！"+ ex.Message, "Student_List.aspx?cid="+classId, 1);
                return;
            }

            FinalMessage("操作成功", "Student_List.aspx?cid=" + classId, 0);
            ////验证学生序号是否存在
            //bool exixt =  new Daiv_OA.BLL.StudentBLL().Exists(studentEntity.Snumber);
            //if (exixt)
            //{
            //    FinalMessage("相同的学生学号已经存在", "", 1);
            //    return;
            //}
            //int pId = 0;
            //int sid = 0;
            //try
            //{
            //    //添加家长信息
            //    pId = new Daiv_OA.BLL.UserBLL().Add(parent);
            //    if (pId > 0)
            //    {
            //        studentEntity.Uid = pId;
            //        //添加设置人员
            //        studentEntity.MechID = UserId;
            //    }
            //    else
            //    {
            //        throw new Exception("添加家长账号失败，请重新添加！");
            //    }
            //    sid = new Daiv_OA.BLL.StudentBLL().Add(studentEntity);
            //    if (sid > 0)
            //    {
            //        //联系电话实体添加
            //        contactEnitty.Sid = sid;
            //        new Daiv_OA.BLL.ContactBLL().Add(contactEnitty);
            //    }
            //    else if (sid == 0)
            //    {
            //        throw new Exception("相同的学生已经存在");
            //    }
            //    else if (sid == -1)
            //    {
            //        throw new Exception("相同的年级已经存在");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (!ex.Message.Contains("正在中止线程"))
            //    {
            //        try
            //        {
            //            if (pId > 0)
            //            {
            //                new Daiv_OA.BLL.UserBLL().Delete(pId);
            //            }
            //            if (sid > 0)
            //            {
            //                new Daiv_OA.BLL.StudentBLL().Delete(sid);
            //            }
            //        }
            //        catch (Exception)
            //        {
            //        }
            //        logHelper.logInfo("添加学生失败！操作员ID:" + UserId + " 失败原因：" + ex.Message);
            //        FinalMessage("添加失败，请重试！", "", 1);
            //        return;
            //    }
            //}
        }
    }
}