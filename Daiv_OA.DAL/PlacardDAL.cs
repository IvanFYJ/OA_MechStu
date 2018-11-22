using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;
using System.Collections.Generic;//请先添加引用
namespace Daiv_OA.DAL
{
    /// <summary>
    /// 数据访问类Message。
    /// </summary>
    public class PlacardDAL
    {
        public PlacardDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Pid", "OA_Placard");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Pid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [OA_Placard]");
            strSql.Append(" where Pid=@Pid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4)};
            parameters[0].Value = Pid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.PlacardEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [OA_Placard](");
            strSql.Append("Ptitle,Pauthor,Pdate,Ptext)");
            strSql.Append(" values (");
            strSql.Append("@Ptitle,@Pauthor,@Pdate,@Ptext)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Ptitle", SqlDbType.VarChar,30),
					new SqlParameter("@Pauthor", SqlDbType.VarChar,10),
					new SqlParameter("@Pdate", SqlDbType.DateTime),
					new SqlParameter("@Ptext", SqlDbType.NText)};
            parameters[0].Value = model.Ptitle;
            parameters[1].Value = model.Pauthor;
            parameters[2].Value = model.Pdate;
            parameters[3].Value = model.Ptext;

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
        public void Update(Entity.PlacardEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Placard] set ");
            strSql.Append("Ptitle=@Ptitle,");
            strSql.Append("Pauthor=@Pauthor,");
            strSql.Append("Pdate=@Pdate,");
            strSql.Append("Ptext=@Ptext");
            strSql.Append(" where Pid=@Pid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@Ptitle", SqlDbType.VarChar,30),
					new SqlParameter("@Pauthor", SqlDbType.VarChar,10),
					new SqlParameter("@Pdate", SqlDbType.DateTime),
					new SqlParameter("@Ptext", SqlDbType.NText)};
            parameters[0].Value = model.Pid;
            parameters[1].Value = model.Ptitle;
            parameters[2].Value = model.Pauthor;
            parameters[3].Value = model.Pdate;
            parameters[4].Value = model.Ptext;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Pid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [OA_Placard] ");
            strSql.Append(" where Pid=@Pid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4)};
            parameters[0].Value = Pid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.PlacardEntity GetEntity(int Pid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Pid,Ptitle,Pauthor,Pdate,Ptext from [OA_Placard] ");
            strSql.Append(" where Pid=@Pid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4)};
            parameters[0].Value = Pid;

            Entity.PlacardEntity model = new Entity.PlacardEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Pid"].ToString() != "")
                {
                    model.Pid = int.Parse(ds.Tables[0].Rows[0]["Pid"].ToString());
                }
                model.Ptitle = ds.Tables[0].Rows[0]["Ptitle"].ToString();
                model.Pauthor = ds.Tables[0].Rows[0]["Pauthor"].ToString();
                if (ds.Tables[0].Rows[0]["Pdate"].ToString() != "")
                {
                    model.Pdate = DateTime.Parse(ds.Tables[0].Rows[0]["Pdate"].ToString());
                }
                model.Ptext = ds.Tables[0].Rows[0]["Ptext"].ToString();
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
            strSql.Append("select Pid,Ptitle,Pauthor,Pdate,Ptext ");
            strSql.Append(" FROM [OA_Placard] ");
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
            strSql.Append(" Pid,Ptitle,Pauthor,Pdate,Ptext ");
            strSql.Append(" FROM [OA_Placard] ");
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
        public List<Entity.PlacardEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " * ";

            table = "OA_Placard ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "Pid";

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

            List<Entity.PlacardEntity> list = new List<Entity.PlacardEntity>();
            Entity.PlacardEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.PlacardEntity();

                if (ds.Tables[0].Rows[i]["Pid"].ToString() != "")
                {
                    model.Pid = int.Parse(ds.Tables[0].Rows[i]["Pid"].ToString());
                }
                model.Pauthor = ds.Tables[0].Rows[i]["Pauthor"].ToString();
                model.Pdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Pdate"].ToString());
                model.Ptitle = ds.Tables[0].Rows[i]["Ptitle"].ToString();
                model.Ptext = ds.Tables[0].Rows[i]["Ptext"].ToString();

                list.Add(model);
            }

            return list;
        }
        #endregion  成员方法
    }
}

