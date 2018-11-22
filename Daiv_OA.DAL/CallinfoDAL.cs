using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;

using System.Collections.Generic;//请先添加引用
namespace Daiv_OA.DAL
{
    /// <summary>
    /// 数据访问类Callinfo。
    /// </summary>
    public class CallinfoDAL
    {
        public CallinfoDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [OA_Callinfo]");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.CallinfoEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            strSql1.Append("Uid,");
            strSql2.Append("" + model.Uid + ",");
            if (model.Userinfo != null)
            {
                strSql1.Append("Userinfo,");
                strSql2.Append("'" + model.Userinfo + "',");
            }
            if (model.Title != null)
            {
                strSql1.Append("Title,");
                strSql2.Append("'" + model.Title + "',");
            }
            if (model.Unit != null)
            {
                strSql1.Append("Unit,");
                strSql2.Append("'" + model.Unit + "',");
            }
            if (model.Addtime != null)
            {
                strSql1.Append("Addtime,");
                strSql2.Append("'" + model.Addtime + "',");
            }
            if (model.Reply != null)
            {
                strSql1.Append("Reply,");
                strSql2.Append("'" + model.Reply + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            strSql.Append("insert into [OA_Callinfo](");
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
        public void Update(Daiv_OA.Entity.CallinfoEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Callinfo] set ");
            strSql.Append("Uid=" + model.Uid + ",");
            strSql.Append("Userinfo='" + model.Userinfo + "',");
            strSql.Append("Title='" + model.Title + "',");
            strSql.Append("Unit='" + model.Unit + "',");
            strSql.Append("Addtime='" + model.Addtime + "',");
            strSql.Append("Reply='" + model.Reply + "',");
            strSql.Append("Remark='" + model.Remark + "'");
            strSql.Append(" where Id=" + model.Id + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [OA_Callinfo] ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.CallinfoEntity GetEntity(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" * ");
            strSql.Append(" from [OA_Callinfo] ");
            strSql.Append(" where Id=" + Id + " ");
            Daiv_OA.Entity.CallinfoEntity model = new Daiv_OA.Entity.CallinfoEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(ds.Tables[0].Rows[0]["Uid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Userinfo"].ToString() != "")
                {
                    model.Userinfo = ds.Tables[0].Rows[0]["Userinfo"].ToString();
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Unit = ds.Tables[0].Rows[0]["Unit"].ToString();
                if (ds.Tables[0].Rows[0]["Addtime"].ToString() != "")
                {
                    model.Addtime = DateTime.Parse(ds.Tables[0].Rows[0]["Addtime"].ToString());
                }
                model.Reply = ds.Tables[0].Rows[0]["Reply"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
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
            strSql.Append("select Id,Uid,Userinfo,Title,Unit,Addtime,Reply,Remark ");
            strSql.Append(" FROM [OA_Callinfo] ");
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
            strSql.Append(" Id,Uid,Userinfo,Title,Unit,Addtime,Reply,Remark ");
            strSql.Append(" FROM [OA_Callinfo] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<Entity.CallinfoEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " * ";

            table = "[OA_Callinfo] ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "Id";

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

            List<Entity.CallinfoEntity> list = new List<Entity.CallinfoEntity>();
            Entity.CallinfoEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.CallinfoEntity();

                if (ds.Tables[0].Rows[i]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                }
                model.Addtime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Addtime"].ToString());
                model.Userinfo = ds.Tables[0].Rows[i]["Userinfo"].ToString();
                model.Unit = ds.Tables[0].Rows[i]["Unit"].ToString();
                model.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                model.Uid = Convert.ToInt32(ds.Tables[0].Rows[i]["Uid"].ToString());
                model.Reply = ds.Tables[0].Rows[i]["Reply"].ToString();
                model.Remark = ds.Tables[0].Rows[i]["Remark"].ToString();
                list.Add(model);
            }

            return list;
        }

        #endregion  成员方法
    }
}

