using System;
using System.Data;
using System.Collections.Generic;
using Daiv_OA.Entity;
namespace Daiv_OA.BLL
{
    /// <summary>
    /// 业务逻辑类Department 的摘要说明。
    /// </summary>
    public class DepartmentBLL
    {
        private readonly DAL.DepartmentDAL dal = new DAL.DepartmentDAL();
        public DepartmentBLL()
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
        public bool Exists(int Did)
        {
            return dal.Exists(Did);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.DepartmentEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Entity.DepartmentEntity model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Did)
        {

            dal.Delete(Did);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.DepartmentEntity GetEntity(int Did)
        {

            return dal.GetEntity(Did);
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
        public List<Entity.DepartmentEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.DepartmentEntity> DataTableToList(DataTable dt)
        {
            List<Entity.DepartmentEntity> modelList = new List<Entity.DepartmentEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Entity.DepartmentEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Entity.DepartmentEntity();
                    if (dt.Rows[n]["Did"].ToString() != "")
                    {
                        model.Did = int.Parse(dt.Rows[n]["Did"].ToString());
                    }
                    model.DName = dt.Rows[n]["DName"].ToString();
                    modelList.Add(model);
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

        #endregion  成员方法
    }
}

