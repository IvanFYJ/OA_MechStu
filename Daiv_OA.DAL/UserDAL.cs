using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;//请先添加引用
using System.Collections.Generic;
namespace Daiv_OA.DAL
{
    /// <summary>
    /// 数据访问类User。
    /// </summary>
    public class UserDAL
    {
        public UserDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Uid", "[OA_User]");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_User]");
            strSql.Append(" where Uid=@Uid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)};
            parameters[0].Value = Uid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Uname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_User]");
            strSql.Append(" where uname=@uname");
            SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.VarChar,50)};
            parameters[0].Value = Uname;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.UserEntity model)
        {
            if (Exists(model.Uname))//已经存在该用户
                return 0;
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            strSql1.Append("Pid,");
            strSql2.Append("" + model.Pid + ",");
            strSql1.Append("Did,");
            strSql2.Append("" + model.Did + ",");

            if (model.Uname != null)
            {
                strSql1.Append("Uname,");
                strSql2.Append("'" + model.Uname + "',");
            }
            if (model.Upwd != null)
            {
                strSql1.Append("Upwd,");
                strSql2.Append("'" + model.Upwd + "',");
            }
            if (model.Uipaddress != null)
            {
                strSql1.Append("Uipaddress,");
                strSql2.Append("'" + model.Uipaddress + "',");
            }
            if (model.Position != null)
            {
                strSql1.Append("Position,");
                strSql2.Append("'" + model.Position + "',");
            }
            if (model.Setting != null)
            {
                strSql1.Append("Setting,");
                strSql2.Append("'" + model.Setting + "',");
            }
            strSql.Append("insert into [OA_User](");
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
        public void Update(Daiv_OA.Entity.UserEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_User] set ");
            strSql.Append("Pid=" + model.Pid + ",");
            strSql.Append("Uname='" + model.Uname + "',");
            strSql.Append("Did='" + model.Did + "',");
            strSql.Append("Upwd='" + model.Upwd + "',");
            strSql.Append("Position='" + model.Position + "',");
            strSql.Append("Setting='" + model.Setting + "',");
            strSql.Append("Uipaddress='" + model.Uipaddress + "'");
            strSql.Append(" where Uid=" + model.Uid + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Uid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM [OA_User] ");
            strSql.Append(" where Uid=@Uid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)};
            parameters[0].Value = Uid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        public bool UpdateTime(int Uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_User] set ");
            strSql.Append("UpdateTime='" + System.DateTime.Now.ToString() + "'");
            strSql.Append(" where Uid=" + Uid + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
            return true;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.UserEntity GetEntity(int Uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" Uid,Pid,Did,Uname,Upwd,Uipaddress,Position,Setting ");
            strSql.Append(" FROM [OA_User] ");
            strSql.Append(" where Uid=" + Uid + " ");
            Daiv_OA.Entity.UserEntity model = new Daiv_OA.Entity.UserEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(ds.Tables[0].Rows[0]["Uid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Did"].ToString() != "")
                {
                    model.Did = int.Parse(ds.Tables[0].Rows[0]["Did"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pid"].ToString() != "")
                {
                    model.Pid = int.Parse(ds.Tables[0].Rows[0]["Pid"].ToString());
                }
                model.Uname = ds.Tables[0].Rows[0]["Uname"].ToString();
                model.Upwd = ds.Tables[0].Rows[0]["Upwd"].ToString();
                model.Uipaddress = ds.Tables[0].Rows[0]["Uipaddress"].ToString();
                model.Position = ds.Tables[0].Rows[0]["Position"].ToString();
                model.Setting = ds.Tables[0].Rows[0]["Setting"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Uid,Pid,Did,Uname,Upwd,Uipaddress,Position,Setting ");
            strSql.Append(" FROM [OA_User] ");
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
            strSql.Append(" Uid,Pid,Did,Uname,Upwd,Uipaddress,Position,Setting ");
            strSql.Append(" FROM [OA_User] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public string Existslongin(string uname, string upwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM [OA_User]");
            strSql.Append(" where uname=@uname and upwd=@upwd");
            SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.VarChar,50),
                    new SqlParameter("@upwd", SqlDbType.VarChar,250)};
            parameters[0].Value = uname;
            parameters[1].Value = upwd;


            //return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            SqlDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
            string uid = "";
            if (dr.Read())
            {
                uid = dr["Uid"].ToString();
            }
            return uid;
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
            Entity.PowerEntity pos = new Entity.PowerEntity();
            SqlDataReader dr = DbHelperSQL.ExecuteReader(sql);
            if (dr.Read())
            {
                pos.Pid = Convert.ToInt32(dr["Pid"]);
                pos.PName = dr["PName"].ToString();
            }
            return pos;
        }

        /// <summary>
        /// 获取uname
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public Entity.UserEntity Getuname(string sql)
        {
            Entity.UserEntity userEntity = new Entity.UserEntity();
            SqlDataReader dr = DbHelperSQL.ExecuteReader(sql);
            if (dr.Read())
            {
                userEntity.Uid = Convert.ToInt32(dr["Uid"]);
                userEntity.Pid = Convert.ToInt32(dr["Pid"]);
                userEntity.Uname = dr["Uname"].ToString();
                userEntity.Upwd = dr["Upwd"].ToString();
            }
            return userEntity;
        }

        /// <summary>
        /// 多表连接查询
        /// </summary>
        /// <param name="kls_uid"></param>
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
        /// <param name="kls_uid"></param>
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

