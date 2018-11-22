using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;
using System.Collections.Generic;//请先添加引用
namespace Daiv_OA.DAL
{
    /// <summary>
    /// 数据访问类Adminlog。
    /// </summary>
    public class AdminlogDAL
    {
        public AdminlogDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Adminlogid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_AdminLog]");
            strSql.Append(" where Adminlogid=@Adminlogid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Adminlogid", SqlDbType.Int,4)};
            parameters[0].Value = Adminlogid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.AdminlogEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [OA_AdminLog](");
            strSql.Append("Updatetitle,Updatetime,Updatetype,Uid)");
            strSql.Append(" values (");
            strSql.Append("@Updatetitle,@Updatetime,@Updatetype,@Uid)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Updatetitle", SqlDbType.VarChar,30),
					new SqlParameter("@Updatetime", SqlDbType.DateTime),
					new SqlParameter("@Updatetype", SqlDbType.VarChar,50),
					new SqlParameter("@Uid", SqlDbType.Int,4)};
            parameters[0].Value = model.Updatetitle;
            parameters[1].Value = model.Updatetime;
            parameters[2].Value = model.Updatetype;
            parameters[3].Value = model.Uid;

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
        /// 更新一条数据 51aspx.com 提供下载
        /// </summary>
        public void Update(Entity.AdminlogEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_AdminLog] set ");
            strSql.Append("Updatetitle=@Updatetitle,");
            strSql.Append("Updatetime=@Updatetime,");
            strSql.Append("Updatetype=@Updatetype,");
            strSql.Append("Uid=@Uid");
            strSql.Append(" where Adminlogid=@Adminlogid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Adminlogid", SqlDbType.Int,4),
					new SqlParameter("@Updatetitle", SqlDbType.VarChar,30),
					new SqlParameter("@Updatetime", SqlDbType.DateTime),
					new SqlParameter("@Updatetype", SqlDbType.VarChar,50),
					new SqlParameter("@Uid", SqlDbType.Int,4)};
            parameters[0].Value = model.Adminlogid;
            parameters[1].Value = model.Updatetitle;
            parameters[2].Value = model.Updatetime;
            parameters[3].Value = model.Updatetype;
            parameters[4].Value = model.Uid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Adminlogid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM [OA_AdminLog] ");
            strSql.Append(" where Adminlogid=@Adminlogid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Adminlogid", SqlDbType.Int,4)};
            parameters[0].Value = Adminlogid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.AdminlogEntity GetEntity(int Adminlogid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Adminlogid,Updatetitle,Updatetime,Updatetype,Uid,(select uname FROM [OA_User] where uid=[OA_AdminLog].uid) as uname FROM [OA_AdminLog] ");
            strSql.Append(" where Adminlogid=@Adminlogid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Adminlogid", SqlDbType.Int,4)};
            parameters[0].Value = Adminlogid;

            Entity.AdminlogEntity model = new Entity.AdminlogEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Adminlogid"].ToString() != "")
                {
                    model.Adminlogid = int.Parse(ds.Tables[0].Rows[0]["Adminlogid"].ToString());
                }
                model.Updatetitle = ds.Tables[0].Rows[0]["Updatetitle"].ToString();
                if (ds.Tables[0].Rows[0]["Updatetime"].ToString() != "")
                {
                    model.Updatetime = DateTime.Parse(ds.Tables[0].Rows[0]["Updatetime"].ToString());
                }
                model.Updatetype = ds.Tables[0].Rows[0]["Updatetype"].ToString();
                if (ds.Tables[0].Rows[0]["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(ds.Tables[0].Rows[0]["Uid"].ToString());
                }
                model.Uname = ds.Tables[0].Rows[0]["Uname"].ToString();
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
            strSql.Append("select Adminlogid,Updatetitle,Updatetime,Updatetype,Uid,(select uname FROM [OA_User] where uid=[OA_AdminLog].uid) as uname");
            strSql.Append(" FROM [OA_AdminLog] ");
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
            strSql.Append(" Adminlogid,Updatetitle,Updatetime,Updatetype,Uid,(select uname FROM [OA_User] where uid=[OA_AdminLog].uid) as uname");
            strSql.Append(" FROM [OA_AdminLog] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        public List<Entity.AdminlogEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " *,(select uname FROM [OA_User] where uid=[OA_AdminLog].uid) as uname";

            table = "[OA_AdminLog] ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "Adminlogid";

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

            List<Entity.AdminlogEntity> list = new List<Entity.AdminlogEntity>();
            Entity.AdminlogEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.AdminlogEntity();

                if (ds.Tables[0].Rows[i]["Adminlogid"].ToString() != "")
                {
                    model.Adminlogid = int.Parse(ds.Tables[0].Rows[i]["Adminlogid"].ToString());
                }
                model.Updatetime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Updatetime"].ToString());
                model.Updatetitle = ds.Tables[0].Rows[i]["Updatetitle"].ToString();
                model.Updatetype = ds.Tables[0].Rows[i]["Updatetype"].ToString();
                model.Uid = Convert.ToInt32(ds.Tables[0].Rows[i]["Uid"].ToString());
                model.Uname = ds.Tables[0].Rows[i]["Uname"].ToString();

                list.Add(model);
            }

            return list;
        }
        #endregion  成员方法
    }
}

