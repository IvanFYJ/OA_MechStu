using System;
using System.Data;
using System.Collections.Generic;
using Daiv_OA.Entity;
namespace Daiv_OA.BLL
{
	/// <summary>
	/// ҵ���߼���Learning ��ժҪ˵����
	/// </summary>
	public class LearningBLL
	{
		private readonly DAL.LearningDAL dal=new DAL.LearningDAL();
		public LearningBLL()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Sid)
		{
			return dal.Exists(Sid);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Entity.LearningEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Entity.LearningEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int Sid)
		{
			
			dal.Delete(Sid);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Entity.LearningEntity GetEntity(int Sid)
		{
			
			return dal.GetEntity(Sid);
		}

		
		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.LearningEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        public List<Entity.LearningEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            return dal.getpage(pageSize, pageNum, out count, str);
        }
		#endregion  ��Ա����
	}
}

