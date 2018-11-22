using System;
using System.Data;
using System.Collections.Generic;
using Daiv_OA.Entity;
namespace Daiv_OA.BLL
{
    /// <summary>
    /// 业务逻辑类Summarize 的摘要说明。
    /// </summary>
    public class SummarizeBLL
    {
        private readonly DAL.SummarizeDAL dal = new DAL.SummarizeDAL();
        public SummarizeBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Suid)
        {
            return dal.Exists(Suid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.SummarizeEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Entity.SummarizeEntity model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Suid)
        {

            dal.Delete(Suid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.SummarizeEntity GetEntity(int Suid)
        {

            return dal.GetEntity(Suid);
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
        public List<Entity.SummarizeEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.SummarizeEntity> DataTableToList(DataTable dt)
        {
            List<Entity.SummarizeEntity> modelList = new List<Entity.SummarizeEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Entity.SummarizeEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Entity.SummarizeEntity();
                    if (dt.Rows[n]["Suid"].ToString() != "")
                    {
                        model.Suid = int.Parse(dt.Rows[n]["Suid"].ToString());
                    }
                    model.Sutitle = dt.Rows[n]["Sutitle"].ToString();
                    if (dt.Rows[n]["Uid"].ToString() != "")
                    {
                        model.Uid = int.Parse(dt.Rows[n]["Uid"].ToString());
                    }
                    model.Sutext = dt.Rows[n]["Sutext"].ToString();
                    if (dt.Rows[n]["Sutime"].ToString() != "")
                    {
                        model.Sutime = DateTime.Parse(dt.Rows[n]["Sutime"].ToString());
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
        public List<Entity.SummarizeEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            return dal.getpage(pageSize, pageNum, out count, str);
        }

        /// <summary>
        /// datediff
        /// </summary>
        public int Getdatediff(int id)
        {
            return dal.Getdatediff(id);
        }

        /// <summary>
        /// 通过UID得到一个对象实体
        /// </summary>
        public Entity.SummarizeEntity GetModelbyuid(int uid)
        {

            return dal.GetModelbyuid(uid);
        }

        /// <summary>
        /// 
        /// </summary>
        public Entity.SummarizeEntity GetThisWeekModelbByUid(int id)
        {
            return dal.GetThisWeekModelbByUid(id);
        }
        /// <summary>
        /// 
        /// </summary>
        public int LockSummarize()
        {
            return dal.LockSummarize();
        }
        #endregion  成员方法
    }
}

