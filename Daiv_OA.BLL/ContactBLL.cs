using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Daiv_OA.BLL
{
    public class ContactBLL
    {

        private readonly DAL.ContactDAL dal = new DAL.ContactDAL();
        public ContactBLL()
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
        public int Add(Entity.ContactEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 批量修改情亲号
        /// </summary>
        /// <param name="adds"></param>
        /// <param name="sid"></param>
        /// <returns></returns>
        public int AddBatch(List<Entity.ContactEntity> adds,int sid)
        {
            List<Entity.ContactEntity> olds = GetEntitysBySid(sid);
            try
            {
                //添加数据
                for (int i = 0; i < adds.Count; i++)
                {
                    Entity.ContactEntity temp = olds.Where(o => o.Cphone == adds[i].Cphone && o.CPhoneName == adds[i].CPhoneName).FirstOrDefault();
                    if (temp != null)
                        continue;
                    adds[i].Sid = sid;
                    Add(adds[i]);
                }
                //删除数据
                for (int i = 0; i < olds.Count; i++)
                {
                    Entity.ContactEntity temp = adds.Where(o => o.Cphone == olds[i].Cphone && o.CPhoneName == olds[i].CPhoneName).FirstOrDefault();
                    if (temp != null)
                        continue;
                    Delete(olds[i].Cid);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return 1;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Entity.ContactEntity model)
        {
            dal.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Gid)
        {
            dal.Delete(Gid);
        }
        
        /// <summary>
        /// 根据学生ID删除情亲好
        /// </summary>
        /// <param name="Sid"></param>
        public void DeleteBySid(int Sid)
        {
            dal.DeleteBySid(Sid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.ContactEntity GetEntity(int Gid)
        {

            return dal.GetEntity(Gid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.ContactEntity GetEntityBySid(int Sid)
        {

            return dal.GetEntityBySid(Sid);
        }

        /// <summary>
        /// 得到多个联系电话
        /// </summary>
        public List<Daiv_OA.Entity.ContactEntity> GetEntitysBySid(int Sid)
        {
            return dal.GetEntitysBySid(Sid);
        }

        /// <summary>
        /// 得到多个联系电话
        /// </summary>
        public List<Daiv_OA.Entity.ContactEntity> GetEntitysBySids(int[] Sid)
        {
            return dal.GetEntitysBySid(Sid);
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
        /// 根据学校编号和时间获取亲情号
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public IList<Hashtable> GetPhoneListBySchoolAndDate(string sserie, string datetime, string pageindex, string pagesize)
        {
            DateTime dt2 = Convert.ToDateTime(datetime);
            IList<Hashtable> list = dal.GetPhoneListBySchoolAndDate(sserie, datetime, pageindex, pagesize);
            if(list == null && list.Count <= 0)
            {
                return list;
            }
            DateTime dt1 = Convert.ToDateTime(list[0]["MaxDate"]);
            if (!( dt2.CompareTo(dt1)<=0))
            {
                return null;
            }
            return list;
        }


        /// <summary>
        /// 获取亲情号最大的修改时间
        /// </summary>
        /// <returns></returns>
        public Hashtable GetMaxCreatTime()
        {
            return dal.GetMaxCreatTime();
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Daiv_OA.Entity.ContactEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Daiv_OA.Entity.ContactEntity> modelList = new List<Daiv_OA.Entity.ContactEntity>();
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
