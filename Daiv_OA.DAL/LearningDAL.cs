using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;
using System.Collections.Generic;//请先添加引用
namespace Daiv_OA.DAL
{
    /// <summary>
    /// 数据访问类StudyInfo。
    /// </summary>
    public class LearningDAL
    {
        public LearningDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Sid", "[OA_Learning]");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [OA_Learning]");
            strSql.Append(" where Sid=@Sid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.Int,4)};
            parameters[0].Value = Sid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.LearningEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [OA_Learning](");
            strSql.Append("Stitle,Sauthor,Sdate,Spath,Did)");
            strSql.Append(" values (");
            strSql.Append("@Stitle,@Sauthor,@Sdate,@Spath,@Did)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Stitle", SqlDbType.VarChar,30),
					new SqlParameter("@Sauthor", SqlDbType.VarChar,10),
					new SqlParameter("@Sdate", SqlDbType.DateTime),
					new SqlParameter("@Spath", SqlDbType.NText),
                    new SqlParameter("@Did", SqlDbType.Int,4)};
            parameters[0].Value = model.Stitle;
            parameters[1].Value = model.Sauthor;
            parameters[2].Value = model.Sdate;
            parameters[3].Value = model.Spath;
            parameters[4].Value = model.Did;

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
        public void Update(Entity.LearningEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Learning] set ");
            strSql.Append("Stitle=@Stitle,");
            strSql.Append("Sauthor=@Sauthor,");
            strSql.Append("Sdate=@Sdate,");
            strSql.Append("Spath=@Spath,");
            strSql.Append("Did=@Did");
            strSql.Append(" where Sid=@Sid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@Stitle", SqlDbType.VarChar,30),
					new SqlParameter("@Sauthor", SqlDbType.VarChar,10),
					new SqlParameter("@Sdate", SqlDbType.DateTime),
					new SqlParameter("@Spath", SqlDbType.NText),
                    new SqlParameter("@Did", SqlDbType.Int,4)};
            parameters[0].Value = model.Sid;
            parameters[1].Value = model.Stitle;
            parameters[2].Value = model.Sauthor;
            parameters[3].Value = model.Sdate;
            parameters[4].Value = model.Spath;
            parameters[5].Value = model.Did;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [OA_Learning] ");
            strSql.Append(" where Sid=@Sid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.Int,4)};
            parameters[0].Value = Sid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.LearningEntity GetEntity(int Sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Sid,Stitle,Sauthor,Sdate,Spath,Did from [OA_Learning] ");
            strSql.Append(" where Sid=@Sid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.Int,4)};
            parameters[0].Value = Sid;

            Entity.LearningEntity model = new Entity.LearningEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Sid"].ToString() != "")
                {
                    model.Sid = int.Parse(ds.Tables[0].Rows[0]["Sid"].ToString());
                }
                model.Stitle = ds.Tables[0].Rows[0]["Stitle"].ToString();
                model.Sauthor = ds.Tables[0].Rows[0]["Sauthor"].ToString();
                if (ds.Tables[0].Rows[0]["Sdate"].ToString() != "")
                {
                    model.Sdate = DateTime.Parse(ds.Tables[0].Rows[0]["Sdate"].ToString());
                }
                model.Spath = ds.Tables[0].Rows[0]["Spath"].ToString();
                model.Did = int.Parse(ds.Tables[0].Rows[0]["Did"].ToString());
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
            strSql.Append("select Sid,Stitle,Sauthor,Sdate,Spath,Did ");
            strSql.Append(" FROM [OA_Learning] ");
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
            strSql.Append(" Sid,Stitle,Sauthor,Sdate,Spath,Did ");
            strSql.Append(" FROM [OA_Learning] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Entity.LearningEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " * ";

            table = "[OA_Learning] ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "Sid";

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

            List<Entity.LearningEntity> list = new List<Entity.LearningEntity>();
            Entity.LearningEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.LearningEntity();

                if (ds.Tables[0].Rows[i]["Sid"].ToString() != "")
                {
                    model.Sid = int.Parse(ds.Tables[0].Rows[i]["Sid"].ToString());
                }
                model.Sauthor = ds.Tables[0].Rows[i]["Sauthor"].ToString();
                model.Sdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Sdate"].ToString());
                model.Stitle = ds.Tables[0].Rows[i]["Stitle"].ToString();
                model.Spath = ds.Tables[0].Rows[i]["Spath"].ToString();
                model.Did = int.Parse(ds.Tables[0].Rows[i]["Did"].ToString());
                list.Add(model);
            }

            return list;
        }
        #endregion  成员方法
    }
}

