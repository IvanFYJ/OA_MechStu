using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;
using System.Collections.Generic;//请先添加引用
namespace Daiv_OA.DAL
{
    /// <summary>
    /// 数据访问类Operatelog。
    /// </summary>
    public class OperatelogDAL
    {
        public OperatelogDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Operatelogid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [OA_Operatelog]");
            strSql.Append(" where Operatelogid=@Operatelogid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Operatelogid", SqlDbType.Int,4)};
            parameters[0].Value = Operatelogid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Entity.OperatelogEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [OA_Operatelog](");
            strSql.Append("Eupdatetitle,Eupadatetime,Eupdatetype,Uid)");
            strSql.Append(" values (");
            strSql.Append("@Eupdatetitle,@Eupadatetime,@Eupdatetype,@Uid)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Eupdatetitle", SqlDbType.VarChar,30),
					new SqlParameter("@Eupadatetime", SqlDbType.DateTime),
					new SqlParameter("@Eupdatetype", SqlDbType.VarChar,30),
					new SqlParameter("@Uid", SqlDbType.Int,4)};
            parameters[0].Value = model.Eupdatetitle;
            parameters[1].Value = model.Eupadatetime;
            parameters[2].Value = model.Eupdatetype;
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
        /// 更新一条数据
        /// </summary>
        public void Update(Entity.OperatelogEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OA_Operatelog set ");
            strSql.Append("Eupdatetitle=@Eupdatetitle,");
            strSql.Append("Eupadatetime=@Eupadatetime,");
            strSql.Append("Eupdatetype=@Eupdatetype,");
            strSql.Append("Uid=@Uid");
            strSql.Append(" where Operatelogid=@Operatelogid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Operatelogid", SqlDbType.Int,4),
					new SqlParameter("@Eupdatetitle", SqlDbType.VarChar,30),
					new SqlParameter("@Eupadatetime", SqlDbType.DateTime),
					new SqlParameter("@Eupdatetype", SqlDbType.VarChar,30),
					new SqlParameter("@Uid", SqlDbType.Int,4)};
            parameters[0].Value = model.Operatelogid;
            parameters[1].Value = model.Eupdatetitle;
            parameters[2].Value = model.Eupadatetime;
            parameters[3].Value = model.Eupdatetype;
            parameters[4].Value = model.Uid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Operatelogid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [OA_Operatelog] ");
            strSql.Append(" where Operatelogid=@Operatelogid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Operatelogid", SqlDbType.Int,4)};
            parameters[0].Value = Operatelogid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.OperatelogEntity GetEntity(int Operatelogid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Operatelogid,Eupdatetitle,Eupadatetime,Eupdatetype,Uid,(select uname FROM [OA_User] where uid=[OA_Operatelog].uid) as uname from [OA_Operatelog] ");
            strSql.Append(" where Operatelogid=@Operatelogid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Operatelogid", SqlDbType.Int,4)};
            parameters[0].Value = Operatelogid;

            Entity.OperatelogEntity model = new Entity.OperatelogEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Operatelogid"].ToString() != "")
                {
                    model.Operatelogid = int.Parse(ds.Tables[0].Rows[0]["Operatelogid"].ToString());
                }
                model.Eupdatetitle = ds.Tables[0].Rows[0]["Eupdatetitle"].ToString();
                if (ds.Tables[0].Rows[0]["Eupadatetime"].ToString() != "")
                {
                    model.Eupadatetime = DateTime.Parse(ds.Tables[0].Rows[0]["Eupadatetime"].ToString());
                }
                model.Eupdatetype = ds.Tables[0].Rows[0]["Eupdatetype"].ToString();
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
            strSql.Append("select Operatelogid,Eupdatetitle,Eupadatetime,Eupdatetype,Uid,(select uname FROM [OA_User] where uid=[OA_Operatelog].uid) as uname");
            strSql.Append(" FROM [OA_Operatelog] ");
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
            strSql.Append(" Operatelogid,Eupdatetitle,Eupadatetime,Eupdatetype,Uid,(select uname FROM [OA_User] where uid=[OA_Operatelog].uid) as uname");
            strSql.Append(" FROM [OA_Operatelog] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<Entity.OperatelogEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " *,(select uname FROM [OA_User] where uid=[OA_Operatelog].uid) as uname";

            table = "[OA_Operatelog] ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "Operatelogid";

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

            List<Entity.OperatelogEntity> list = new List<Entity.OperatelogEntity>();
            Entity.OperatelogEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.OperatelogEntity();

                if (ds.Tables[0].Rows[i]["Operatelogid"].ToString() != "")
                {
                    model.Operatelogid = int.Parse(ds.Tables[0].Rows[i]["Operatelogid"].ToString());
                }
                model.Eupadatetime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Eupadatetime"].ToString());
                model.Eupdatetitle = ds.Tables[0].Rows[i]["Eupdatetitle"].ToString();
                model.Eupdatetype = ds.Tables[0].Rows[i]["Eupdatetype"].ToString();
                model.Uid = Convert.ToInt32(ds.Tables[0].Rows[i]["Uid"].ToString());
                model.Uname = ds.Tables[0].Rows[i]["Uname"].ToString();

                list.Add(model);
            }

            return list;
        }
        #endregion  成员方法
    }
}

