﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Daiv_OA.BLL
{
    public class GradeBLL
    {

        private readonly DAL.GradeDAL dal = new DAL.GradeDAL();
        public GradeBLL()
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
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.GradeEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Entity.GradeEntity model)
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
        public Entity.GradeEntity GetEntity(int Gid)
        {

            return dal.GetEntity(Gid);
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="mPhone"></param>
        /// <returns></returns>
        public IList<Hashtable> List(int pageIndex, int pageSize)
        {
            return dal.List(pageIndex, pageSize);
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
        public List<Daiv_OA.Entity.GradeEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Daiv_OA.Entity.GradeEntity> modelList = new List<Daiv_OA.Entity.GradeEntity>();
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
        /// 根据年级ID获取班级数据
        /// </summary>
        /// <param name="shid"></param>
        /// <returns></returns>
        public List<Daiv_OA.Entity.GradeEntity> GetAllListByScId(string shid)
        {
            StringBuilder sqlBuiler = new StringBuilder();
            sqlBuiler.Append(" IsDeleted = 0");
            if(!string.IsNullOrEmpty(shid))
            {
                sqlBuiler.Append(" AND GgradeID=" + shid);
            }
            DataSet ds = GetList(sqlBuiler.ToString());
            List<Daiv_OA.Entity.GradeEntity> modelList = new List<Daiv_OA.Entity.GradeEntity>();
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
