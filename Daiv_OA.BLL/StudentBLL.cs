using Daiv_OA.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
        public int Add(Entity.StudentEntity studentEntity, Entity.UserEntity parent, Entity.ContactEntity contactEnitty, Entity.UserEntity operatModel)
        {
            //验证学生序号是否存在
            bool exixt = new Daiv_OA.BLL.StudentBLL().Exists(studentEntity.Snumber);
            if (exixt)
            {
                throw new Exception("相同的学生学号已经存在");
            }
            int pId = 0;
            int sid = 0;
            try
            {
                //验证电话号码
                if (!string.IsNullOrEmpty(contactEnitty.Cphone) && !Validator.IsMobileNum(contactEnitty.Cphone)) { throw new Exception(contactEnitty.Cphone+"电话号码无效!"); }
                if (!string.IsNullOrEmpty(contactEnitty.Cphone2) && !Validator.IsMobileNum(contactEnitty.Cphone2)) { throw new Exception(contactEnitty.Cphone2 + "电话号码无效!"); }
                if (!string.IsNullOrEmpty(contactEnitty.Cphone3) && !Validator.IsMobileNum(contactEnitty.Cphone3)) { throw new Exception(contactEnitty.Cphone3 + "电话号码无效!"); }
                if (!string.IsNullOrEmpty(contactEnitty.Cphone4) && !Validator.IsMobileNum(contactEnitty.Cphone4)) { throw new Exception(contactEnitty.Cphone4 + "电话号码无效!"); }
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
                    //联系电话实体添加
                    contactEnitty.Sid = sid;
                    new Daiv_OA.BLL.ContactBLL().Add(contactEnitty);
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
            if (pageSize == -1)
                return dal.List(mPhone); 
            #endregion
            return dal.List(pageIndex, pageSize, mPhone);
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
