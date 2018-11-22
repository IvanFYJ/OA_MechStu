using System;
using System.Data;
using System.Collections.Generic;
using Daiv_OA.Entity;
namespace Daiv_OA.BLL
{
    /// <summary>
    /// ҵ���߼���Department ��ժҪ˵����
    /// </summary>
    public class DepartmentBLL
    {
        private readonly DAL.DepartmentDAL dal = new DAL.DepartmentDAL();
        public DepartmentBLL()
        { }
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
        public bool Exists(int Did)
        {
            return dal.Exists(Did);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Entity.DepartmentEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Entity.DepartmentEntity model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int Did)
        {

            dal.Delete(Did);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Entity.DepartmentEntity GetEntity(int Did)
        {

            return dal.GetEntity(Did);
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Entity.DepartmentEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Entity.DepartmentEntity> DataTableToList(DataTable dt)
        {
            List<Entity.DepartmentEntity> modelList = new List<Entity.DepartmentEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Entity.DepartmentEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Entity.DepartmentEntity();
                    if (dt.Rows[n]["Did"].ToString() != "")
                    {
                        model.Did = int.Parse(dt.Rows[n]["Did"].ToString());
                    }
                    model.DName = dt.Rows[n]["DName"].ToString();
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

        #endregion  ��Ա����
    }
}

