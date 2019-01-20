using Daiv_OA.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.WebControls;

namespace Daiv_OA.Web
{
    public partial class Student_Import : Daiv_OA.UI.BasicPage
    {

        string[] colmun = { "学号", "姓名", "班级", "出生年月日", "家长联系电话1", "家长联系电话2", "家长联系电话3", "家长联系电话4" };

        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("student-add");
        }


        //更新
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.StudentEntity model = new Entity.StudentEntity();
            Daiv_OA.BLL.ContactBLL contactBll = new Daiv_OA.BLL.ContactBLL();
            Daiv_OA.BLL.StudentBLL studentBll = new Daiv_OA.BLL.StudentBLL();
            Daiv_OA.BLL.GradeBLL gradeBll = new BLL.GradeBLL();
            string uuid = Guid.NewGuid().ToString("N");
            //修改联系电话
            //保存上传文件
            string fName = UploadFile(uuid);
            string path = Path.Combine(Server.MapPath("/"),  "upload/" + DateTime.Now.ToString("yyyy/MM").Replace("/", "").Substring(0, 6));
            ImportExcel import = new ImportExcel();
            import.LoadFile(path + "/" + fName);
            DataSet ds = import.GetAllTables(true);
            DataTable dataTable = ds.Tables[0];
            //获取班级数据
            List<Entity.GradeEntity> glist =  gradeBll.GetModelList("");
            if(glist == null || glist.Count <= 0)
            {
                logHelper.logInfo("未添加任何班级数据！");
                FinalMessage("导入失败，请先添加班级数据！", "", 0);
            }
            #region 验证表格
            //验证表格
            if (dataTable.Rows.Count <= 0)
            {
                logHelper.logInfo(fName + ",未填写任何学生数据！");
                FinalMessage(fName + ",未填写任何学生数据！", "", 0);
                return;
            }
            for (int i = 0; i < colmun.Length; i++)
            {
                if (colmun[i] != dataTable.Columns[i].ColumnName)
                {
                    FinalMessage("导入的excel表与模板excel表不符合！","", 0);
                    message.Visible = true;
                    return;
                }
            }
            //验证班级数据
            int tbCount = dataTable.Rows.Count;
            string tempCName = string.Empty;
            if (Request["schClassgcid"] == null || string.IsNullOrEmpty(Request["schClassgcid"].ToString()))
            {
                FinalMessage("没有选择班级，请重新选择!", "", 0);
                return;
            }
            try
            {
                SchClassId = int.Parse(Request["schClassgcid"].ToString());
            }
            catch (Exception ex)
            {
                FinalMessage("班级转换失败，请重新选择!", "", 0);
                return;
            }
            //for (int j = 0; j < tbCount; j++)
            //{
            //    tempCName = Convert.ToString(dataTable.Rows[j][colmun[2]]);
            //    if (glist.Where(g=>g.Gname == tempCName).FirstOrDefault() == null)
            //    {
            //        logHelper.logInfo(tempCName + " 未匹配到此班级名称!");
            //        FinalMessage(tempCName + " 未匹配到此班级名称!", "", 0);
            //        message.Visible = true;
            //        return;
            //    }
            //}
            //验证时间的有效性
            for (int i = 0; i < tbCount; i++)
            {
                try
                {
                    Convert.ToDateTime(dataTable.Rows[i][colmun[3]]);
                }
                catch (Exception)
                {
                    logHelper.logInfo(string.Format("'{0}' 出生年月日无效!", tempCName ));
                    FinalMessage(Convert.ToString(dataTable.Rows[i][colmun[1]]) + "学生出生时间无效！", "", 0);
                    message.Visible = true;
                    return;
                }

                //验证学号
                //验证学生序号是否存在
                string snumbertemp = Convert.ToString(dataTable.Rows[i][colmun[0]]);
                bool exixt = new Daiv_OA.BLL.StudentBLL().Exists(snumbertemp);
                Daiv_OA.BLL.ContactBLL ctBll = new Daiv_OA.BLL.ContactBLL();
                if (exixt)
                {
                    FinalMessage(snumbertemp + "相同的学生学号已经存在", "", 0);
                    message.Visible = true;
                    return;
                }
            }


            #endregion

            //遍历表格
            Entity.StudentEntity studentEntity = null;
            Entity.UserEntity parent = null;
            Entity.ContactEntity contactEnitty = null;
            for (int i = 0; i < tbCount; i++)
            {
                 studentEntity = new Entity.StudentEntity();
                 parent = new Entity.UserEntity();
                 contactEnitty = new Entity.ContactEntity();
                //保存数据
                try
                {
                    //学生实体相关信息保存
                    studentEntity.Gname = glist.Where(g => g.Gid == SchClassId).FirstOrDefault().Gname;//班级名称 列索引：2
                    studentEntity.Gid = glist.Where(g => g.Gid == SchClassId).FirstOrDefault().Gid;
                    studentEntity.Snumber = Convert.ToString(dataTable.Rows[i][colmun[0]]);//学生学号 列索引：0
                    studentEntity.Sname = Convert.ToString(dataTable.Rows[i][colmun[1]]);//学生名称 列索引：1
                    studentEntity.Sbirthday = Convert.ToDateTime(dataTable.Rows[i][colmun[3]]);//出生年月日 列索引：3
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
                    contactEnitty.Cphone = Convert.ToString(dataTable.Rows[i][colmun[4]]);//家长联系电话1 列索引：4
                    contactEnitty.Cphone2 = Convert.ToString(dataTable.Rows[i][colmun[5]]);//家长联系电话2 列索引：5
                    contactEnitty.Cphone3 = Convert.ToString(dataTable.Rows[i][colmun[6]]);//家长联系电话3 列索引：6
                    contactEnitty.Cphone4 = Convert.ToString(dataTable.Rows[i][colmun[7]]);//家长联系电话4 列索引：7

                    List<Entity.ContactEntity> contactList = new List<Entity.ContactEntity>();
                    contactList.Add(new Entity.ContactEntity() { CPhoneName = "家长1", Cphone = contactEnitty.Cphone });
                    contactList.Add(new Entity.ContactEntity() { CPhoneName = "家长2", Cphone = contactEnitty.Cphone2 });
                    contactList.Add(new Entity.ContactEntity() { CPhoneName = "家长3", Cphone = contactEnitty.Cphone3 });
                    contactList.Add(new Entity.ContactEntity() { CPhoneName = "家长4", Cphone = contactEnitty.Cphone4 });

                    //当前操作人对象
                    Entity.UserEntity opera = new Daiv_OA.BLL.UserBLL().GetEntity(UserId);
                    new Daiv_OA.BLL.StudentBLL().Add(studentEntity, parent, contactList, opera);
                }
                catch (Exception ex)
                {
                    FinalMessage("操作失败！" + ex.Message, "Student_List.aspx", 1);
                    return;
                }

               // FinalMessage("操作成功", "Student_List.aspx", 0);
            }
            logHelper.logInfo("导入成功！操作人：" + UserId);
            FinalMessage("导入成功", "Student_List.aspx", 0);
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
                    }
                    else
                    {
                        message.Visible = true;
                        return;
                    }

                }

            }
        }

        /// <summary>
        /// 上传UPC文件
        /// </summary>
        /// <param name="guid">guid</param>
        /// <returns>返回文件名</returns>
        /// <author>范永坚 2017/11/29</author>
        public string UploadFile(string guid)
        {
            //HttpPostedFile 和 HttpPostedFileBase不存在关系，但是可以通过包装类来转换
            HttpPostedFileBase file = new HttpPostedFileWrapper(Request.Files["stuExcel"]);
            UploadFileHelper upload = new UploadFileHelper(file);
            return upload.Upload(file.FileName + guid,"upload");
        }
    }
}