using System;
using System.Data;
using System.Collections.Generic;
using Daiv_OA.Entity;
namespace Daiv_OA.BLL
{
	/// <summary>
	/// 业务逻辑类Learning 的摘要说明。
	/// </summary>
	public class LearningBLL
	{
		private readonly DAL.LearningDAL dal=new DAL.LearningDAL();
		public LearningBLL()
		{}
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
		public bool Exists(int Sid)
		{
			return dal.Exists(Sid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Entity.LearningEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Entity.LearningEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Sid)
		{
			
			dal.Delete(Sid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.LearningEntity GetEntity(int Sid)
		{
			
			return dal.GetEntity(Sid);
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.LearningEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.LearningEntity> DataTableToList(DataTable dt)
		{
			List<Entity.LearningEntity> modelList = new List<Entity.LearningEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Entity.LearningEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Entity.LearningEntity();
					if(dt.Rows[n]["Sid"].ToString()!="")
					{
						model.Sid=int.Parse(dt.Rows[n]["Sid"].ToString());
					}
					model.Stitle=dt.Rows[n]["Stitle"].ToString();
					model.Sauthor=dt.Rows[n]["Sauthor"].ToString();
					if(dt.Rows[n]["Sdate"].ToString()!="")
					{
						model.Sdate=DateTime.Parse(dt.Rows[n]["Sdate"].ToString());
					}
					model.Spath=dt.Rows[n]["Spath"].ToString();
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
        public List<Entity.LearningEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            return dal.getpage(pageSize, pageNum, out count, str);
        }
		#endregion  成员方法
	}
}

