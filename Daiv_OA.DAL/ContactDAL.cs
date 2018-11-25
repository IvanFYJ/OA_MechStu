using Daiv_OA.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Daiv_OA.DAL
{
    public class ContactDAL
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger("ContactDAL");

        public ContactDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Cid", "[OA_Contact]");
        }

        /// <summary>
        /// 是否存在该记录(根据学生ID来添加)
        /// </summary>
        public bool Exists(int Sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_Contact]");
            strSql.Append(" where Sid=@Sid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Sid", SqlDbType.Int,4)};
            parameters[0].Value = Sid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Cphone)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_Contact]");
            strSql.Append(" where Cphone=@Cphone");
            SqlParameter[] parameters = {
                    new SqlParameter("@Cphone", SqlDbType.VarChar,50)};
            parameters[0].Value = Cphone;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.ContactEntity model)
        {
            if (model.Cid > 0 && Exists(model.Sid))//已经存在该用户
                return 0;
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();

            if (model.Sid > 0)
            {
                strSql1.Append("Sid,");
                strSql2.Append("" + model.Sid + ",");
            }
            if (model.Cphone != null)
            {
                strSql1.Append("Cphone,");
                strSql2.Append("'" + model.Cphone + "',");
            }
            if (model.Cphone2 != null)
            {
                strSql1.Append("Cphone2,");
                strSql2.Append("'" + model.Cphone2 + "',");
            }
            if (model.Cphone3 != null)
            {
                strSql1.Append("Cphone3,");
                strSql2.Append("'" + model.Cphone3 + "',");
            }
            if (model.Cphone4 != null)
            {
                strSql1.Append("Cphone4,");
                strSql2.Append("'" + model.Cphone4 + "',");
            }
            if (model.Cblacklistflag >= 0)
            {
                strSql1.Append("Cblacklistflag,");
                strSql2.Append("" + model.Cblacklistflag + ",");
            }
            if (model.IsDeleted >= 0)
            {
                strSql1.Append("IsDeleted,");
                strSql2.Append("" + model.IsDeleted + ",");
            }
            strSql.Append("insert into [OA_Contact](");
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
        public void Update(Daiv_OA.Entity.ContactEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Contact] set ");
            strSql.Append("Cphone='" + model.Cphone + "',");
            strSql.Append("Cphone2='" + model.Cphone2 + "',");
            strSql.Append("Cphone3='" + model.Cphone3 + "',");
            strSql.Append("Cphone4='" + model.Cphone4 + "'");//注意： 最后不需要加逗号
            strSql.Append(" where Cid=" + model.Cid + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Cid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM [OA_Contact] ");
            strSql.Append(" where Cid=@Cid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Cid", SqlDbType.Int,4)};
            parameters[0].Value = Cid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.ContactEntity GetEntity(int Cid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" Cid,Sid ,Cphone ,Cphone2 ,Cphone3 ,Cphone4 ,Cblacklistflag ,IsDeleted  ");
            strSql.Append(" FROM [OA_Contact] ");
            strSql.Append(" where Cid=" + Cid + " ");
            Daiv_OA.Entity.ContactEntity model = new Daiv_OA.Entity.ContactEntity();
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
        public Daiv_OA.Entity.ContactEntity GetEntityBySid(int Sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" Cid,Sid ,Cphone ,Cphone2 ,Cphone3 ,Cphone4 ,Cblacklistflag ,IsDeleted  ");
            strSql.Append(" FROM [OA_Contact] ");
            strSql.Append(" where Sid=" + Sid + " ");
            Daiv_OA.Entity.ContactEntity model = new Daiv_OA.Entity.ContactEntity();
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
        public Daiv_OA.Entity.ContactEntity ConvertModel(DataTable dt, int rowindex)
        {
            Daiv_OA.Entity.ContactEntity model = new Daiv_OA.Entity.ContactEntity();
            try
            {
                if (dt.Rows[rowindex]["Cid"].ToString() != "")
                {
                    model.Cid = int.Parse(dt.Rows[rowindex]["Cid"].ToString());
                }
                if (dt.Rows[rowindex]["Cblacklistflag"].ToString() != "")
                {
                    model.Cblacklistflag = int.Parse(dt.Rows[rowindex]["Cblacklistflag"].ToString());
                }
                model.Cphone = dt.Rows[rowindex]["Cphone"].ToString();
                model.Cphone2 = dt.Rows[rowindex]["Cphone2"].ToString();
                model.Cphone3 = dt.Rows[rowindex]["Cphone3"].ToString();
                model.Cphone4 = dt.Rows[rowindex]["Cphone4"].ToString();
                if (dt.Rows[rowindex]["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(dt.Rows[rowindex]["IsDeleted"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Info("转换成用户对象失败！原因：" + ex.Message);
                return new Entity.ContactEntity();
            }
            return model;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Cid,Sid ,Cphone ,Cphone2 ,Cphone3 ,Cphone4 ,Cblacklistflag ,IsDeleted   ");
            strSql.Append(" FROM [OA_Contact] ");
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
            strSql.Append(" Cid,Sid ,Cphone ,Cphone2 ,Cphone3 ,Cphone4 ,Cblacklistflag ,IsDeleted  ");
            strSql.Append(" FROM [OA_Contact] ");
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
        /// <param name="kls_Cid"></param>
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
        /// <param name="kls_Cid"></param>
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
