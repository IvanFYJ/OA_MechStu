using System;
using System.Data;
using System.Collections.Generic;
using Daiv_OA.Entity;
namespace Daiv_OA.BLL
{
	/// <summary>
	/// 业务逻辑类Workplaninfo 的摘要说明。
	/// </summary>
	public class Workplaninfo
	{
		private readonly DAL.Workplaninfo dal=new DAL.Workplaninfo();
		public Workplaninfo()
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
		public bool Exists(int Wid)
		{
			return dal.Exists(Wid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Entity.Workplaninfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Entity.Workplaninfo model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Wid)
		{
			
			dal.Delete(Wid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.Workplaninfo GetEntity(int Wid)
		{
			
			return dal.GetEntity(Wid);
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
		public List<Entity.Workplaninfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Entity.Workplaninfo> DataTableToList(DataTable dt)
		{
			List<Entity.Workplaninfo> modelList = new List<Entity.Workplaninfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Entity.Workplaninfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Entity.Workplaninfo();
					if(dt.Rows[n]["Wid"].ToString()!="")
					{
						model.Wid=int.Parse(dt.Rows[n]["Wid"].ToString());
					}
					if(dt.Rows[n]["Uid"].ToString()!="")
					{
						model.Uid=int.Parse(dt.Rows[n]["Uid"].ToString());
					}
					if(dt.Rows[n]["Wdate"].ToString()!="")
					{
						model.Wdate=DateTime.Parse(dt.Rows[n]["Wdate"].ToString());
					}
					model.Wtext=dt.Rows[n]["Wtext"].ToString();
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
        public List<Entity.Workplaninfo> getpage(int pageSize, int pageNum, out int count, string str)
        {
            return dal.getpage(pageSize, pageNum, out count, str);
        }
		#endregion  成员方法
	}
}

