using System;
using System.Data;
using System.Collections.Generic;
using Daiv_OA.Entity;
namespace Daiv_OA.BLL
{
	/// <summary>
	/// ҵ���߼���Message ��ժҪ˵����
	/// </summary>
	public class PlacardBLL
	{
		private readonly DAL.PlacardDAL dal=new DAL.PlacardDAL();
		public PlacardBLL()
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
		public bool Exists(int Pid)
		{
			return dal.Exists(Pid);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Entity.PlacardEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Entity.PlacardEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int Pid)
		{
			
			dal.Delete(Pid);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Entity.PlacardEntity GetEntity(int Pid)
		{
			
			return dal.GetEntity(Pid);
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
		public List<Entity.PlacardEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.PlacardEntity> DataTableToList(DataTable dt)
		{
			List<Entity.PlacardEntity> modelList = new List<Entity.PlacardEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Entity.PlacardEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Entity.PlacardEntity();
					if(dt.Rows[n]["Pid"].ToString()!="")
					{
						model.Pid=int.Parse(dt.Rows[n]["Pid"].ToString());
					}
					model.Ptitle=dt.Rows[n]["Ptitle"].ToString();
					model.Pauthor=dt.Rows[n]["Pauthor"].ToString();
					if(dt.Rows[n]["Pdate"].ToString()!="")
					{
						model.Pdate=DateTime.Parse(dt.Rows[n]["Pdate"].ToString());
					}
					model.Ptext=dt.Rows[n]["Ptext"].ToString();
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
        public List<Entity.PlacardEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            return dal.getpage(pageSize, pageNum, out count, str);
        }
		#endregion  ��Ա����
	}
}

