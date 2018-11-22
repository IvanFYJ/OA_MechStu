using System;
using System.Data;
using System.Collections.Generic;
using Daiv_OA.Entity;
namespace Daiv_OA.BLL
{
    /// <summary>
    /// 业务逻辑类Operatelog 的摘要说明。
    /// </summary>
    public class OperatelogBLL
    {
        private readonly DAL.OperatelogDAL dal = new DAL.OperatelogDAL();
        public OperatelogBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Operatelogid)
        {
            return dal.Exists(Operatelogid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.OperatelogEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Entity.OperatelogEntity model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Operatelogid)
        {

            dal.Delete(Operatelogid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.OperatelogEntity GetEntity(int Operatelogid)
        {

            return dal.GetEntity(Operatelogid);
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
        public List<Entity.OperatelogEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.OperatelogEntity> DataTableToList(DataTable dt)
        {
            List<Entity.OperatelogEntity> modelList = new List<Entity.OperatelogEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Entity.OperatelogEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Entity.OperatelogEntity();
                    if (dt.Rows[n]["Operatelogid"].ToString() != "")
                    {
                        model.Operatelogid = int.Parse(dt.Rows[n]["Operatelogid"].ToString());
                    }
                    model.Eupdatetitle = dt.Rows[n]["Eupdatetitle"].ToString();
                    if (dt.Rows[n]["Eupadatetime"].ToString() != "")
                    {
                        model.Eupadatetime = DateTime.Parse(dt.Rows[n]["Eupadatetime"].ToString());
                    }
                    model.Eupdatetype = dt.Rows[n]["Eupdatetype"].ToString();
                    if (dt.Rows[n]["Uid"].ToString() != "")
                    {
                        model.Uid = int.Parse(dt.Rows[n]["Uid"].ToString());
                    }
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        public List<Entity.OperatelogEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            return dal.getpage(pageSize, pageNum, out count, str);
        }
        #endregion  成员方法
    }
}

