using Daiv_OA.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Daiv_OA.DAL
{
    public class WXUserDAL
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("WXUserDAL");

        public WXUserDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "[OA_WXUser]");
        }

        /// <summary>
        /// 是否存在该记录(根据学生ID来添加)
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_WXUser]");
            strSql.Append(" where ID=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OpenId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_WXUser]");
            strSql.Append(" where OpenId=@OpenId");
            SqlParameter[] parameters = {
                    new SqlParameter("@OpenId", SqlDbType.NVarChar,128)};
            parameters[0].Value = OpenId;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.WXUserEntity model)
        {
            if (model.ID > 0 && Exists(model.OpenId))//已经存在该设备
                return 0;
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            model.IsDeleted = 0;

            if (model.OpenId != null)
            {
                strSql1.Append("OpenId,");
                strSql2.Append("'" + model.OpenId + "',");
            }
            if (model.WXUserPhone != null)
            {
                strSql1.Append("WXUserPhone,");
                strSql2.Append("'" + model.WXUserPhone + "',");
            }
            if (model.OAUserID > 0)
            {
                strSql1.Append("OAUserID,");
                strSql2.Append("" + model.OAUserID + ",");
            }
            if (model.CreateTime != null)
            {
                strSql1.Append("CreateTime,");
                strSql2.Append("'" + model.CreateTime + "',");
            }
            if (model.IsDeleted >= 0)
            {
                strSql1.Append("IsDeleted,");
                strSql2.Append("0,");
            }
            strSql.Append("insert into [OA_WXUser](");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Daiv_OA.Entity.WXUserEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_WXUser] set ");
            strSql.Append("OpenId='" + model.OpenId + "',");
            strSql.Append("WXUserPhone='" + model.WXUserPhone + "',");
            strSql.Append("CreateTime='" + model.CreateTime + "',");
            strSql.Append("OAUserID=" + model.OAUserID + "");//注意： 最后不需要加逗号
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM [OA_WXUser] ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByImei(string OpenId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update [OA_WXUser] ");
            strSql.Append(" set IsDeleted=@IsDeleted ");
            strSql.Append(" where OpenId=@OpenId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@IsDeleted", SqlDbType.Int,4),
                    new SqlParameter("@OpenId", SqlDbType.NVarChar,128)
            };
            parameters[0].Value = 1;
            parameters[1].Value = OpenId;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.WXUserEntity GetEntity(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" ID,OpenId ,WXUserPhone ,OAUserID,CreateTime ,IsDeleted  ");
            strSql.Append(" FROM [OA_WXUser] ");
            strSql.Append(" where ID=" + ID + " ");
            Daiv_OA.Entity.WXUserEntity model = new Daiv_OA.Entity.WXUserEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ConvertModel(ds.Tables[0], 0);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.WXUserEntity GetEntityByOpenId(string OpenId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" ID,OpenId ,WXUserPhone ,OAUserID,CreateTime ,IsDeleted   ");
            strSql.Append(" FROM [OA_WXUser] ");
            strSql.Append(" where IsDeleted = 0 and OpenId='" + OpenId + "' ");
            Daiv_OA.Entity.WXUserEntity model = new Daiv_OA.Entity.WXUserEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ConvertModel(ds.Tables[0], 0);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 构造实体对象
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowindex"></param>
        /// <returns></returns>
        public Daiv_OA.Entity.WXUserEntity ConvertModel(DataTable dt, int rowindex)
        {
            Daiv_OA.Entity.WXUserEntity model = new Daiv_OA.Entity.WXUserEntity();
            try
            {
                if (dt.Rows[rowindex]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[rowindex]["ID"].ToString());
                }
                model.OpenId = dt.Rows[rowindex]["OpenId"].ToString();
                model.WXUserPhone = dt.Rows[rowindex]["WXUserPhone"].ToString();
                model.CreateTime = Convert.ToDateTime(dt.Rows[rowindex]["CreateTime"]);
                if (dt.Rows[rowindex]["OAUserID"].ToString() != "")
                {
                    model.OAUserID = int.Parse(dt.Rows[rowindex]["OAUserID"].ToString());
                }
                if (dt.Rows[rowindex]["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(dt.Rows[rowindex]["IsDeleted"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Info("转换成用户对象失败！原因：" + ex.Message);
                return new Entity.WXUserEntity();
            }
            return model;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ID,OpenId ,WXUserPhone ,OAUserID,CreateTime ,IsDeleted  ");
            strSql.Append(" FROM [OA_WXUser] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append("  ID,OpenId ,WXUserPhone ,OAUserID,CreateTime ,IsDeleted   ");
            strSql.Append(" FROM [OA_WXUser] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 多表连接查询
        /// </summary>
        /// <param name="kls_ID"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public DataSet Getall(string sql)
        {
            DataSet ds = DbHelperSQL.Query(sql);
            return ds;
        }

        /// <summary>
        /// 工作状态
        /// </summary>
        /// <param name="kls_ID"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public DataSet Getsta(string sql)
        {
            DataSet ds = DbHelperSQL.Query(sql);
            return ds;
        }
        #endregion  成员方法
    }
}
