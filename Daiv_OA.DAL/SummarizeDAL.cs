using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;
using System.Collections.Generic;//请先添加引用
namespace Daiv_OA.DAL
{
    /// <summary>
    /// 数据访问类Summarize。
    /// </summary>
    public class SummarizeDAL
    {
        public SummarizeDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Suid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [OA_Summarize]");
            strSql.Append(" where Suid=@Suid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Suid", SqlDbType.Int,4)};
            parameters[0].Value = Suid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.SummarizeEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [OA_Summarize](");
            strSql.Append("Sutitle,Uid,Sutext,Sutime)");
            strSql.Append(" values (");
            strSql.Append("@Sutitle,@Uid,@Sutext,@Sutime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Sutitle", SqlDbType.NVarChar,30),
					new SqlParameter("@Uid", SqlDbType.Int,4),
					new SqlParameter("@Sutext", SqlDbType.NText),
					new SqlParameter("@Sutime", SqlDbType.DateTime)};
            parameters[0].Value = model.Sutitle;
            parameters[1].Value = model.Uid;
            parameters[2].Value = model.Sutext;
            parameters[3].Value = model.Sutime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public void Update(Entity.SummarizeEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Summarize] set ");
            strSql.Append("Sutitle=@Sutitle,");
            strSql.Append("Sutext=@Sutext,");
            strSql.Append("Sutime=@Sutime");
            strSql.Append(" where Suid=@Suid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Suid", SqlDbType.Int,4),
					new SqlParameter("@Sutitle", SqlDbType.NVarChar,30),
					new SqlParameter("@Sutext", SqlDbType.NText),
					new SqlParameter("@Sutime", SqlDbType.DateTime)};
            parameters[0].Value = model.Suid;
            parameters[1].Value = model.Sutitle;
            parameters[2].Value = model.Sutext;
            parameters[3].Value = model.Sutime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Suid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [OA_Summarize] ");
            strSql.Append(" where Suid=@Suid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Suid", SqlDbType.Int,4)};
            parameters[0].Value = Suid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.SummarizeEntity GetEntity(int Suid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Suid,Sutitle,Uid,Sutext,Sutime,Locked from [OA_Summarize] ");
            strSql.Append(" where Suid=@Suid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Suid", SqlDbType.Int,4)};
            parameters[0].Value = Suid;

            Entity.SummarizeEntity model = new Entity.SummarizeEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Suid"].ToString() != "")
                {
                    model.Suid = int.Parse(ds.Tables[0].Rows[0]["Suid"].ToString());
                }
                model.Sutitle = ds.Tables[0].Rows[0]["Sutitle"].ToString();
                if (ds.Tables[0].Rows[0]["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(ds.Tables[0].Rows[0]["Uid"].ToString());
                }
                model.Sutext = ds.Tables[0].Rows[0]["Sutext"].ToString();
                if (ds.Tables[0].Rows[0]["Sutime"].ToString() != "")
                {
                    model.Sutime = DateTime.Parse(ds.Tables[0].Rows[0]["Sutime"].ToString());
                }
                model.Locked = int.Parse(ds.Tables[0].Rows[0]["Locked"].ToString());
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
            strSql.Append("select Suid,Sutitle,Uid,Sutext,Sutime,Locked ");
            strSql.Append(" FROM [OA_Summarize] ");
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
            strSql.Append(" Suid,Sutitle,Uid,Sutext,Sutime,Locked ");
            strSql.Append(" FROM [OA_Summarize] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<Entity.SummarizeEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " * ";

            table = "OA_Summarize ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "Suid";

            string sql = "exec Pagination @select, @table, @where, @orderField, @orderType, @pageSize, @pageNum ";

            SqlParameter[] paras ={ 
                new SqlParameter("@select",     select),
                new SqlParameter("@table",      table),
                new SqlParameter("@where",      where),
                new SqlParameter("@orderField", order),
                new SqlParameter("@orderType",  '1'),
                new SqlParameter("@pageSize",   pageSize),
                new SqlParameter("@pageNum",    pageNum)
            };

            DataSet ds = DbHelperSQL.Query(sql, paras);

            count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);

            List<Entity.SummarizeEntity> list = new List<Entity.SummarizeEntity>();
            Entity.SummarizeEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.SummarizeEntity();

                if (ds.Tables[0].Rows[i]["Suid"].ToString() != "")
                {
                    model.Suid = int.Parse(ds.Tables[0].Rows[i]["Suid"].ToString());
                }
                if (ds.Tables[0].Rows[i]["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(ds.Tables[0].Rows[i]["Uid"].ToString());
                }
                model.Sutext = ds.Tables[0].Rows[i]["Sutext"].ToString();
                model.Sutitle = ds.Tables[0].Rows[i]["Sutitle"].ToString();
                model.Sutime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Sutime"].ToString());
                model.Locked = int.Parse(ds.Tables[0].Rows[i]["Locked"].ToString());
                list.Add(model);
            }

            return list;
        }

        /// <summary>
        /// datediff
        /// </summary>
        public int Getdatediff(int id)
        {
            string sql = "select datediff(day,(select Sutime from [OA_Summarize] where Suid =" + id + "),getdate())";
            int i = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            return i;
        }


        /// <summary>
        /// 通过UID得到一个对象实体
        /// </summary>
        public Entity.SummarizeEntity GetModelbyuid(int uid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Suid,Sutitle,Uid,Sutext,Sutime,Locked from [OA_Summarize] ");
            strSql.Append(" where Uid=@Uid order by Suid desc");
            SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)};
            parameters[0].Value = uid;

            Entity.SummarizeEntity model = new Entity.SummarizeEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Suid"].ToString() != "")
                {
                    model.Suid = int.Parse(ds.Tables[0].Rows[0]["Suid"].ToString());
                }
                model.Sutitle = ds.Tables[0].Rows[0]["Sutitle"].ToString();
                if (ds.Tables[0].Rows[0]["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(ds.Tables[0].Rows[0]["Uid"].ToString());
                }
                model.Sutext = ds.Tables[0].Rows[0]["Sutext"].ToString();
                if (ds.Tables[0].Rows[0]["Sutime"].ToString() != "")
                {
                    model.Sutime = DateTime.Parse(ds.Tables[0].Rows[0]["Sutime"].ToString());
                }
                model.Locked = int.Parse(ds.Tables[0].Rows[0]["Locked"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得某人本周的工作总结
        /// </summary>
        public Entity.SummarizeEntity GetThisWeekModelbByUid(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Suid,Sutitle,Uid,Sutext,Sutime,Locked from [OA_Summarize] ");
            strSql.Append(" where Uid=@Uid and (DATEDIFF(w, Sutime, GETDATE()) = 0) order by Suid desc");
            SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)};
            parameters[0].Value = uid;

            Entity.SummarizeEntity model = new Entity.SummarizeEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Suid"].ToString() != "")
                {
                    model.Suid = int.Parse(ds.Tables[0].Rows[0]["Suid"].ToString());
                }
                model.Sutitle = ds.Tables[0].Rows[0]["Sutitle"].ToString();
                if (ds.Tables[0].Rows[0]["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(ds.Tables[0].Rows[0]["Uid"].ToString());
                }
                model.Sutext = ds.Tables[0].Rows[0]["Sutext"].ToString();
                if (ds.Tables[0].Rows[0]["Sutime"].ToString() != "")
                {
                    model.Sutime = DateTime.Parse(ds.Tables[0].Rows[0]["Sutime"].ToString());
                }
                model.Locked = int.Parse(ds.Tables[0].Rows[0]["Locked"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 锁定非本周的工作总结
        /// </summary>
        public int LockSummarize()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Summarize] set ");
            strSql.Append("Locked=1");
            strSql.Append(" where DATEDIFF(w, Sutime, GETDATE()) > 0");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        #endregion  成员方法
    }
}

