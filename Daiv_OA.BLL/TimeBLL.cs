using System;
using System.Data;
using System.Collections.Generic;
using Daiv_OA.Entity;
namespace Daiv_OA.BLL
{
	/// <summary>
	/// ҵ���߼���Time ��ժҪ˵����
	/// </summary>
	public class TimeBLL
	{
		private readonly DAL.TimeDAL dal=new DAL.TimeDAL();
		public TimeBLL()
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
		public bool Exists(int Tid)
		{
			return dal.Exists(Tid);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Entity.TimeEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Entity.TimeEntity model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int Tid)
		{
			
			dal.Delete(Tid);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Entity.TimeEntity GetEntity(int Tid)
		{
			
			return dal.GetEntity(Tid);
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
		public List<Entity.TimeEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Entity.TimeEntity> DataTableToList(DataTable dt)
		{
			List<Entity.TimeEntity> modelList = new List<Entity.TimeEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Entity.TimeEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Entity.TimeEntity();
					if(dt.Rows[n]["Tid"].ToString()!="")
					{
						model.Tid=int.Parse(dt.Rows[n]["Tid"].ToString());
					}
					if(dt.Rows[n]["Uid"].ToString()!="")
					{
						model.Uid=int.Parse(dt.Rows[n]["Uid"].ToString());
					}
					if(dt.Rows[n]["Retime"].ToString()!="")
					{
						model.Retime=DateTime.Parse(dt.Rows[n]["Retime"].ToString());
					}
					if(dt.Rows[n]["Nowtime"].ToString()!="")
					{
						model.Nowtime=DateTime.Parse(dt.Rows[n]["Nowtime"].ToString());
					}
					model.Timetype=dt.Rows[n]["Timetype"].ToString();
					model.Ipaddress=dt.Rows[n]["Ipaddress"].ToString();
					model.Timeinfo=dt.Rows[n]["Timeinfo"].ToString();
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
        public List<Entity.TimeEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            return dal.getpage(pageSize, pageNum, out count, str);
        }

        /// <summary>
        /// �Ƿ��ѽ������°�Ǽ�
        /// </summary>
        public bool Isfirst(int uid,string type, string nowtime)
        {
            return dal.Isfirst(uid, type, nowtime);
        }
		#endregion  ��Ա����
	}
}

