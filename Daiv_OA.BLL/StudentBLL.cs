﻿using Daiv_OA.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Daiv_OA.BLL
{
    public class StudentBLL
    {

        private readonly DAL.StudentDAL dal = new DAL.StudentDAL();
        public StudentBLL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Gid)
        {
            return dal.Exists(Gid);
        }


        /// <summary>
        /// 是否存在该记录(学号)
        /// </summary>
        public bool Exists(string Snumber)
        {
            return dal.Exists(Snumber);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.StudentEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="studentEntity"></param>
        /// <param name="parent"></param>
        /// <param name="contactEnitty"></param>
        /// <param name="operatModel"></param>
        /// <returns></returns>
        public int Add(Entity.StudentEntity studentEntity, Entity.UserEntity parent, List<Entity.ContactEntity> contactList, Entity.UserEntity operatModel)
        {
            //验证学生序号是否存在
            bool exixt = new Daiv_OA.BLL.StudentBLL().Exists(studentEntity.Snumber);
            Daiv_OA.BLL.ContactBLL ctBll = new Daiv_OA.BLL.ContactBLL();
            if (exixt)
            {
                throw new Exception("相同的学生学号已经存在");
            }
            int pId = 0;
            int sid = 0;
            try
            {
                //验证电话号码
                foreach (var item in contactList)
                {
                    if (!string.IsNullOrEmpty(item.Cphone) && !Validator.IsMobileNum(item.Cphone))
                    { throw new Exception(item.Cphone + "电话号码无效!"); }
                }
                //添加家长信息
                pId = new Daiv_OA.BLL.UserBLL().Add(parent);
                if (pId > 0)
                {
                    studentEntity.Uid = pId;
                    //添加设置人员
                    studentEntity.MechID = operatModel.Uid;
                }
                else
                {
                    throw new Exception("添加家长账号失败，请重新添加！");
                }
                sid = new Daiv_OA.BLL.StudentBLL().Add(studentEntity);
                if (sid > 0)
                {
                    //删除情亲好
                    ctBll.DeleteBySid(sid);
                    //联系电话实体添加
                    foreach (var item in contactList)
                    {
                        item.Sid = sid;
                        new Daiv_OA.BLL.ContactBLL().Add(item);
                    }
                }
                else if (sid == 0)
                {
                    throw new Exception("相同的学生已经存在");
                }
                else if (sid == -1)
                {
                    throw new Exception("相同的年级已经存在");
                }
            }
            catch (Exception ex)
            {
                if (pId > 0)
                {
                    new Daiv_OA.BLL.UserBLL().Delete(pId);
                }
                if (sid > 0)
                {
                    Delete(sid);
                }
                logHelper.logInfo("添加学生失败！操作员ID:" + operatModel.Uname + " 失败原因：" + ex.Message);
                throw ex;
            }
            return 1;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Entity.StudentEntity model)
        {
            dal.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Gid)
        {

            dal.Delete(Gid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.StudentEntity GetEntity(int Gid)
        {

            return dal.GetEntity(Gid);
        }

        /// <summary>
        /// 根据学号获取学生信息
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Daiv_OA.Entity.StudentEntity GetEntityByNumber(string number)
        {
            return dal.GetEntityByNumber(number);
        }

        /// <summary>
        /// 根据微信openid获取情亲号学生学号
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public IList<Hashtable> GetFamilyNumberByOpenId(string openId)
        {
            return dal.GetFamilyNumberByOpenId(openId);
        }

        /// <summary>
        /// 分页查询学生数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="mPhone"></param>
        /// <returns></returns>
        public IList<Hashtable> List(int pageIndex, int pageSize, string mPhone)
        {
            #region 如果页容量等于-1，表示根据mPhone获取所有的数据 add by fanyongjian date:20181221
            //如果页容量等于-1，表示根据mPhone获取所有的数据
            //if (pageSize == -1)
                //return dal.List(mPhone); 
            #endregion
            return dal.List(pageIndex, pageSize, mPhone);
        }


        /// <summary>
        /// 获取更新年级学生数据
        /// </summary>
        /// <returns></returns>
        public IList<Hashtable> getUpdateGradeData()
        {
            string where = "";
            return dal.getUpdateGradeData(where);
        }

        /// <summary>
        /// 更新学生年级
        /// </summary>
        public void UpdateStudentGrade(string webroot = "")
        {
            string dateStr = DateTime.Now.ToString("yyyy-MM-dd");
            string updateStr = "UP";
            string directoryPath = "databak\\";
            if (string.IsNullOrEmpty(webroot))
            {
                webroot = HttpContext.Current.Server.MapPath("/");
            }
            logHelper.logInfo("当前项目根路径："+webroot);
            //判断当前时间是否为每年的8月30号
            if (8!=DateTime.Now.Month || 30!= DateTime.Now.Day)
            {
                logHelper.logInfo("不是8月30号，不需要更新！");
                return;
            }
            //判断执行文件是否存在，如果存在，直接返回
            if (File.Exists(webroot + directoryPath + dateStr + "-"+updateStr+ ".txt"))
            {
                logHelper.logInfo("更新文件已经存在，不需要更新！");
                return;
            }
            if (!Directory.Exists(webroot + directoryPath))
            {
                Directory.CreateDirectory(webroot + directoryPath);
            }
            //1.获取需要更新的数据，备份到一个文件中,文件名称：当前年  xxxx-8-30.txt 号
            IList<Hashtable> list = getUpdateGradeData();
            string seriesdata = new JavaScriptSerializer().Serialize(list);
            System.IO.File.WriteAllText(webroot+directoryPath+dateStr+".txt", seriesdata, Encoding.UTF8);

            //2.更新数据
            dal.UpdateStudentGrade();
            System.IO.File.WriteAllText(webroot + directoryPath + dateStr +"-"+updateStr+ ".txt", dateStr, Encoding.UTF8);

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Daiv_OA.Entity.StudentEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Daiv_OA.Entity.StudentEntity> modelList = new List<Daiv_OA.Entity.StudentEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    modelList.Add(dal.ConvertModel(ds.Tables[0], n));
                }
            }
            return modelList;
        }


        public List<Daiv_OA.Entity.StudentEntity> GetAllListByGid(string gid)
        {
            StringBuilder sqlBuiler = new StringBuilder();
            sqlBuiler.Append(" IsDeleted = 0");
            if (!string.IsNullOrEmpty(gid))
            {
                sqlBuiler.Append("  and Gid = "+Convert.ToInt32(gid));
            }
            DataSet ds = GetList(sqlBuiler.ToString());
            List<Daiv_OA.Entity.StudentEntity> modelList = new List<Daiv_OA.Entity.StudentEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    modelList.Add(dal.ConvertModel(ds.Tables[0], n));
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}



        /// <summary>
        /// 多表连接
        /// </summary>
        /// <param name="kls_Gid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public DataSet Getall(string sql)
        {
            return dal.Getall(sql);
        }

        /// <summary>
        /// 工作状态
        /// </summary>
        /// <param name="kls_Gid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public DataSet Getsta(string sql)
        {
            return dal.Getsta(sql);
        }
        #endregion  成员方法
    }
}
