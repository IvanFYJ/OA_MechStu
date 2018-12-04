using System;
using System.Data;
using System.Collections.Generic;
using Daiv_OA.Entity;
namespace Daiv_OA.BLL
{
    /// <summary>
    /// 业务逻辑类User 的摘要说明。
    /// </summary>
    public class UserBLL
    {
        private readonly DAL.UserDAL dal = new DAL.UserDAL();
        public UserBLL()
        { }
        #region  成员方法

        /// <summary>
        /// 设置Cookies
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <param name="userhAddress">用户登录地址</param>
        /// <param name="iExpires">服务器持久化时间</param>
        public void SetUserCookies(UserEntity user,string userhAddress,int iExpires)
        {

            //设置Cookies
            System.Collections.Specialized.NameValueCollection myCol = new System.Collections.Specialized.NameValueCollection();
            myCol.Add("id", user.Uid.ToString());
            myCol.Add("name", user.Uname);
            myCol.Add("ip", userhAddress);
            new BLL.UserBLL().UpdateTime(user.Uid);
            int pid = user.Pid;
            myCol.Add("Powerid", pid.ToString());
            Daiv_OA.Utils.Cookie.SetObj("oa_user", 60 * 60 * 15 * iExpires, myCol, "", "/");
        }

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
        public bool Exists(int Uid)
        {
            return dal.Exists(Uid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.UserEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Entity.UserEntity model)
        {
            dal.Update(model);
        }

        public bool UpdateTime(int Uid)
        {
            return dal.UpdateTime(Uid);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Uid)
        {

            dal.Delete(Uid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.UserEntity GetEntity(int Uid)
        {

            return dal.GetEntity(Uid);
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
        public List<Daiv_OA.Entity.UserEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Daiv_OA.Entity.UserEntity> modelList = new List<Daiv_OA.Entity.UserEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Daiv_OA.Entity.UserEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    //model = new Daiv_OA.Entity.UserEntity();
                    //if (ds.Tables[0].Rows[n]["Uid"].ToString() != "")
                    //{
                    //    model.Uid = int.Parse(ds.Tables[0].Rows[n]["Uid"].ToString());
                    //}
                    //if (ds.Tables[0].Rows[n]["Pid"].ToString() != "")
                    //{
                    //    model.Pid = int.Parse(ds.Tables[0].Rows[n]["Pid"].ToString());
                    //}
                    //model.Uname = ds.Tables[0].Rows[n]["Uname"].ToString();
                    //model.Upwd = ds.Tables[0].Rows[n]["Upwd"].ToString();
                    //model.Uipaddress = ds.Tables[0].Rows[n]["Uipaddress"].ToString();
                    //model.Setting = ds.Tables[0].Rows[n]["Setting"].ToString();
                    //modelList.Add(model);

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
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public string Existslongin(string uname, string upwd)
        {
            return dal.Existslongin(uname, upwd);
        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public Entity.PowerEntity Getpomodel(string sql)
        {
            return dal.Getpomodel(sql);
        }

        /// <summary>
        /// 获取UID
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public Entity.UserEntity Getuname(string sql)
        {
            return dal.Getuname(sql);
        }

        /// <summary>
        /// 多表连接
        /// </summary>
        /// <param name="kls_uid"></param>
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
        /// <param name="kls_uid"></param>
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

