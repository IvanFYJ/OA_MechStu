using System;
using System.Data;
using System.Collections.Generic;
using Daiv_OA.Entity;
namespace Daiv_OA.BLL
{
    /// <summary>
    /// 业务逻辑类Message 的摘要说明。
    /// </summary>
    public class MessageBLL
    {
        private readonly Daiv_OA.DAL.MessageDAL dal = new Daiv_OA.DAL.MessageDAL();
        public MessageBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Mid)
        {
            return dal.Exists(Mid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.MessageEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Daiv_OA.Entity.MessageEntity model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Mid)
        {

            dal.Delete(Mid);
        }
        public bool Delete(int Mid, int Uid)
        {

            return dal.Delete(Mid, Uid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.MessageEntity GetEntity(int Mid)
        {

            return dal.GetEntity(Mid);
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
        public List<Daiv_OA.Entity.MessageEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Daiv_OA.Entity.MessageEntity> modelList = new List<Daiv_OA.Entity.MessageEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Daiv_OA.Entity.MessageEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Daiv_OA.Entity.MessageEntity();
                    if (ds.Tables[0].Rows[n]["Mid"].ToString() != "")
                    {
                        model.Mid = int.Parse(ds.Tables[0].Rows[n]["Mid"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ToUid"].ToString() != "")
                    {
                        model.ToUid = int.Parse(ds.Tables[0].Rows[n]["ToUid"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["FromUid"].ToString() != "")
                    {
                        model.FromUid = int.Parse(ds.Tables[0].Rows[n]["FromUid"].ToString());
                    }
                    model.Mtitle = ds.Tables[0].Rows[n]["Mtitle"].ToString();
                    model.Content = ds.Tables[0].Rows[n]["Content"].ToString();
                    if (ds.Tables[0].Rows[n]["Addtime"].ToString() != "")
                    {
                        model.Addtime = DateTime.Parse(ds.Tables[0].Rows[n]["Addtime"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["touser"].ToString() != "")
                    {
                        model.Touser = (ds.Tables[0].Rows[n]["touser"].ToString());
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

        public List<Entity.MessageEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            return dal.getpage(pageSize, pageNum, out count, str);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void SetReadById(int Mid)
        {
            dal.SetReadById(Mid);
        }
        #endregion  成员方法
    }
}

