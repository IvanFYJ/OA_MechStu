using System;
using System.Data;
using System.Collections.Generic;
using Daiv_OA.Entity;
namespace Daiv_OA.BLL
{
	/// <summary>
	/// ҵ���߼���Workplaninfo ��ժҪ˵����
	/// </summary>
	public class Workplaninfo
	{
		private readonly DAL.Workplaninfo dal=new DAL.Workplaninfo();
		public Workplaninfo()
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
		public bool Exists(int Wid)
		{
			return dal.Exists(Wid);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Entity.Workplaninfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Entity.Workplaninfo model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int Wid)
		{
			
			dal.Delete(Wid);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Entity.Workplaninfo GetEntity(int Wid)
		{
			
			return dal.GetEntity(Wid);
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
		public List<Entity.Workplaninfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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
        public List<Entity.Workplaninfo> getpage(int pageSize, int pageNum, out int count, string str)
        {
            return dal.getpage(pageSize, pageNum, out count, str);
        }
		#endregion  ��Ա����
	}
}

