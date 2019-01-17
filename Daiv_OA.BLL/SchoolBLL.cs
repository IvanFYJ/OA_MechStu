using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Daiv_OA.BLL
{
    public class SchoolBLL
    {
        private readonly DAL.SchoolDAL dal = new DAL.SchoolDAL();
        public SchoolBLL()
        { }
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
        public bool Exists(int Gid)
        {
            return dal.Exists(Gid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.SchoolEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Entity.SchoolEntity model)
        {
            dal.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            dal.Delete(id);
        }

        /// <summary>
        /// 根据imei删除
        /// </summary>
        /// <param name="imei"></param>
        public void DeleteByImei(string imei)
        {
            dal.DeleteByImei(imei);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.SchoolEntity GetEntity(int id)
        {

            return dal.GetEntity(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.SchoolEntity GetEntityByImei(string imei)
        {

            return dal.GetEntityByImei(imei);
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
        public List<Daiv_OA.Entity.SchoolEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Daiv_OA.Entity.SchoolEntity> modelList = new List<Daiv_OA.Entity.SchoolEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    modelList.Add(dal.ConvertModel(ds.Tables[0], n));
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
        /// 多表连接
        /// </summary>
        /// <param name="kls_Gid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public DataSet Getall(string sql)
        {
            return dal.Getall(sql);
        }

        /// <summary>
        /// 工作状态
        /// </summary>
        /// <param name="kls_Gid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public DataSet Getsta(string sql)
        {
            return dal.Getsta(sql);
        }
        #endregion  成员方法
    }
}
