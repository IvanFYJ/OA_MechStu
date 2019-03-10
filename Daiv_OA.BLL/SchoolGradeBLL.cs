using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Daiv_OA.Entity;

namespace Daiv_OA.BLL
{
    public class SchoolGradeBLL
    {
        private readonly DAL.SchoolGradeDAL dal = new DAL.SchoolGradeDAL();
        public SchoolGradeBLL()
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
        public int Add(Entity.SchoolGradeEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Entity.SchoolGradeEntity model)
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
        public void DeleteByNameAndScId(string name, int scid)
        {
            dal.DeleteByNameAndScId(name, scid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.SchoolGradeEntity GetEntity(int id)
        {

            return dal.GetEntity(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.SchoolGradeEntity GetEntityByName(string name)
        {

            return dal.GetEntityByName(name);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.SchoolGradeEntity GetEntityByNameAndScId(string name, int scId)
        {
            return dal.GetEntityByNameAndScId(name, scId);
        }


        /// <summary>
        /// 获取学校和年级json字符串
        /// </summary>
        /// <returns></returns>
        public List<object> GetSchoolAndGradeData(int schId = 0)
        {
            SchoolBLL sbll = new SchoolBLL();
            SchoolGradeBLL sbgradell = new SchoolGradeBLL();
            List<Entity.SchoolEntity> schList =  sbll.GetModelList(" IsDeleted=0");
            List<Entity.SchoolGradeEntity> sbgradelList = sbgradell.GetModelList(" IsDeleted=0");
            List<object> resultList = new List<object>();
            foreach (var item in schList)
            {
                if(schId > 0 && item.ID != schId)
                {
                    continue;
                }
                List<Entity.SchoolGradeEntity> sgTemp = sbgradelList.Where(g => g.SchoolID == item.ID).ToList();
                resultList.Add(new { shname = item.Name, shid = item.ID, grades = sgTemp });
            }
            return resultList;
        }

        /// <summary>
        /// 获取学校和年级json字符串
        /// </summary>
        /// <returns></returns>
        public List<object> GetGradeAndClassData()
        {
            SchoolGradeBLL sbgradell = new SchoolGradeBLL();
            List<Entity.SchoolGradeEntity> sbgradelList = sbgradell.GetModelList(" IsDeleted=0");
            GradeBLL clasBll = new GradeBLL();
            List<Entity.GradeEntity> classList = clasBll.GetModelList(" IsDeleted=0");
            List<object> resultList = new List<object>();
            foreach (var item in sbgradelList)
            {
                List<Entity.GradeEntity> sgTemp = classList.Where(g => g.GgradeID == item.ID).ToList();
                resultList.Add(new { shcgname = item.Name, shcgid = item.ID, classes = sgTemp });
            }
            return resultList;
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
        public List<Daiv_OA.Entity.SchoolGradeEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Daiv_OA.Entity.SchoolGradeEntity> modelList = new List<Daiv_OA.Entity.SchoolGradeEntity>();
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

        public List<Entity.SchoolGradeEntity> GetAllListByScId(string shid)
        {
            StringBuilder sqlBuiler = new StringBuilder();
            sqlBuiler.Append(" IsDeleted = 0");
            if (!string.IsNullOrEmpty(shid))
            {
                sqlBuiler.Append(" AND SchoolID=" + shid);
            }
            DataSet ds = GetList(sqlBuiler.ToString());
            List<Daiv_OA.Entity.SchoolGradeEntity> modelList = new List<Daiv_OA.Entity.SchoolGradeEntity>();
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
