using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Daiv_OA.Entity;
using Daiv_OA.DAL;
namespace Daiv_OA.BLL
{
    /// <summary>
    /// 业务逻辑类Diary 的摘要说明。
    /// </summary>
    public class DiaryBLL
    {
        private readonly DiaryDAL dal = new DiaryDAL();
        public DiaryBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public DiaryEntity GetModelByDate(int accountID,DateTime dtTime)
        {
            return dal.GetModelByDate(accountID,dtTime);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DiaryEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DiaryEntity model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 更新评论
        /// </summary>
        public void Update(long ID, string comment)
        {
            dal.Update(ID, comment);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long ID)
        {

            dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DiaryEntity GetEntity(long ID)
        {

            return dal.GetEntity(ID);
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
        public List<DiaryEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DiaryEntity> DataTableToList(DataTable dt)
        {
            List<DiaryEntity> modelList = new List<DiaryEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DiaryEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DiaryEntity();
                    //model.ID=dt.Rows[n]["ID"].ToString();
                    model.Title = dt.Rows[n]["Title"].ToString();
                    if (dt.Rows[n]["WorkDate"].ToString() != "")
                    {
                        model.WorkDate = DateTime.Parse(dt.Rows[n]["WorkDate"].ToString());
                    }
                    if (dt.Rows[n]["WorkDuration"].ToString() != "")
                    {
                        model.WorkDuration = decimal.Parse(dt.Rows[n]["WorkDuration"].ToString());
                    }
                    model.Note = dt.Rows[n]["Note"].ToString();
                    if (dt.Rows[n]["OwnerID"].ToString() != "")
                    {
                        model.OwnerID = int.Parse(dt.Rows[n]["OwnerID"].ToString());
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
        public DataSet GetListData(int ownerID, DateTime dtBegin, DateTime dtEnd)
        {
            DataSet ds = dal.GetListData(ownerID, dtBegin, dtEnd);
            return ds;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public bool Judge(int accountID)
        {   
            bool bExist=false;
            bExist = dal.JudgePosition(accountID);
            return bExist;
        }

        public DataSet GetListData(int ownerID, DateTime dtBegin, DateTime dtEnd,string note,int pageSize, int currentPageIndex, string orderByField, string sort)
        {
            DataSet ds = dal.GetListData(ownerID, dtBegin, dtEnd,note, pageSize, currentPageIndex, orderByField, sort);
            return ds;
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
