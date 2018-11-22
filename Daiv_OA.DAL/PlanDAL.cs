using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;
using System.Collections.Generic;//请先添加引用
namespace Daiv_OA.DAL
{
    /// <summary>
    /// 数据访问类Plan。
    /// </summary>
    public class PlanDAL
    {
        public PlanDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Pwid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [OA_Plan]");
            strSql.Append(" where Pwid=@Pwid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Pwid", SqlDbType.Int,4)};
            parameters[0].Value = Pwid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.PlanEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [OA_Plan](");
            strSql.Append("Uid,Pwtitle,Pwdate,Pwpath,Locked,Manager)");
            strSql.Append(" values (");
            strSql.Append("@Uid,@Pwtitle,@Pwdate,@Pwpath,@Locked,@Manager)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4),
					new SqlParameter("@Pwtitle", SqlDbType.VarChar,80),
					new SqlParameter("@Pwdate", SqlDbType.DateTime),
					new SqlParameter("@Pwpath", SqlDbType.VarChar,50),
					new SqlParameter("@Locked", SqlDbType.VarChar,10),
					new SqlParameter("@Manager", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Uid;
            parameters[1].Value = model.Pwtitle;
            parameters[2].Value = model.Pwdate;
            parameters[3].Value = model.Pwpath;
            parameters[4].Value = model.Locked;
            parameters[5].Value = model.Manager;

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
        public void Update(Daiv_OA.Entity.PlanEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Plan] set ");
            strSql.Append("Uid=@Uid,");
            strSql.Append("Pwtitle=@Pwtitle,");
            strSql.Append("Pwdate=@Pwdate,");
            strSql.Append("Pwpath=@Pwpath,");
            strSql.Append("Locked=@Locked,");
            strSql.Append("Manager=@Manager");
            strSql.Append(" where Pwid=@Pwid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Pwid", SqlDbType.Int,4),
					new SqlParameter("@Uid", SqlDbType.Int,4),
                    new SqlParameter("@Pwtitle", SqlDbType.VarChar,80),
					new SqlParameter("@Pwdate", SqlDbType.DateTime),
					new SqlParameter("@Pwpath", SqlDbType.VarChar,50),
					new SqlParameter("@Locked", SqlDbType.VarChar,10),
					new SqlParameter("@Manager", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Pwid;
            parameters[1].Value = model.Uid;
            parameters[2].Value = model.Pwtitle;
            parameters[3].Value = model.Pwdate;
            parameters[4].Value = model.Pwpath;
            parameters[5].Value = model.Locked;
            parameters[6].Value = model.Manager;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Pwid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [OA_Plan] ");
            strSql.Append(" where Pwid=@Pwid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Pwid", SqlDbType.Int,4)};
            parameters[0].Value = Pwid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.PlanEntity GetEntity(int Pwid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Pwid,Uid,Pwtitle,Pwdate,Pwpath,Locked,Manager from [OA_Plan] ");
            strSql.Append(" where Pwid=@Pwid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Pwid", SqlDbType.Int,4)};
            parameters[0].Value = Pwid;

            Daiv_OA.Entity.PlanEntity model = new Daiv_OA.Entity.PlanEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Pwid"].ToString() != "")
                {
                    model.Pwid = int.Parse(ds.Tables[0].Rows[0]["Pwid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(ds.Tables[0].Rows[0]["Uid"].ToString());
                }
                model.Pwtitle = ds.Tables[0].Rows[0]["Pwtitle"].ToString();
                if (ds.Tables[0].Rows[0]["Pwdate"].ToString() != "")
                {
                    model.Pwdate = DateTime.Parse(ds.Tables[0].Rows[0]["Pwdate"].ToString());
                }
                model.Pwpath = ds.Tables[0].Rows[0]["Pwpath"].ToString();
                model.Locked = ds.Tables[0].Rows[0]["Locked"].ToString();
                model.Manager = ds.Tables[0].Rows[0]["Manager"].ToString();
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
            strSql.Append("select Pwid,Uid,Pwtitle,Pwdate,Pwpath,Locked,Manager ");
            strSql.Append(" FROM [OA_Plan] ");
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
            strSql.Append(" Pwid,Uid,Pwtitle,Pwdate,Pwpath,Locked,Manager ");
            strSql.Append(" FROM [OA_Plan] ");
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
        public List<Entity.PlanEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " * ";

            table = "[OA_Plan] ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "Pwid";

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

            List<Entity.PlanEntity> list = new List<Entity.PlanEntity>();
            Entity.PlanEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.PlanEntity();

                if (ds.Tables[0].Rows[i]["Pwid"].ToString() != "")
                {
                    model.Pwid = int.Parse(ds.Tables[0].Rows[i]["Pwid"].ToString());
                }
                model.Locked = ds.Tables[0].Rows[i]["Locked"].ToString();
                model.Pwtitle = ds.Tables[0].Rows[i]["Pwtitle"].ToString();
                model.Pwdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Pwdate"].ToString());
                model.Manager = ds.Tables[0].Rows[i]["Manager"].ToString();
                model.Uid = Convert.ToInt32(ds.Tables[0].Rows[i]["Uid"].ToString());
                model.Pwpath = ds.Tables[0].Rows[i]["Pwpath"].ToString();
                list.Add(model);
            }

            return list;
        }
        #endregion  成员方法
    }
}

