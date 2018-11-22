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
    public class MessageDAL
    {
        public MessageDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [OA_Message]");
            strSql.Append(" where Mid=@Mid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Mid", SqlDbType.Int,4)};
            parameters[0].Value = Mid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.MessageEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            strSql1.Append("ToUid,");
            strSql2.Append("" + model.ToUid + ",");
            strSql1.Append("FromUid,");
            strSql2.Append("" + model.FromUid + ",");
            if (model.Mtitle != null)
            {
                strSql1.Append("Mtitle,");
                strSql2.Append("'" + model.Mtitle + "',");
            }
            if (model.Content != null)
            {
                strSql1.Append("Content,");
                strSql2.Append("'" + model.Content + "',");
            }
            if (model.Addtime != null)
            {
                strSql1.Append("Addtime,");
                strSql2.Append("'" + model.Addtime + "',");
            }
            strSql1.Append("touser,");
            strSql2.Append("'" + model.Touser + "',");
           
            strSql.Append("insert into [OA_Message](");
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
        public void Update(Daiv_OA.Entity.MessageEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Message] set ");
            strSql.Append("ToUid=" + model.ToUid + ",");
            strSql.Append("FromUid=" + model.FromUid + ",");
            strSql.Append("Mtitle='" + model.Mtitle + "',");
            strSql.Append("Content='" + model.Content + "',");
            strSql.Append("Addtime='" + model.Addtime + "'");
            strSql.Append("touser='" + model.Touser + "'");
            strSql.Append(" where Mid=" + model.Mid + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Mid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [OA_Message] ");
            strSql.Append(" where Mid=@Mid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Mid", SqlDbType.Int,4)};
            parameters[0].Value = Mid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Delete(int Mid, int Uid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [OA_Message] ");
            strSql.Append(" where Mid=@Mid and ToUid=@Uid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Mid", SqlDbType.Int,4),
                    new SqlParameter("@Uid", SqlDbType.Int,4)
                                        };
            parameters[0].Value = Mid;
            parameters[1].Value = Uid;
            return (DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) == 1);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.MessageEntity GetEntity(int Mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" Mid,ToUid,FromUid,Mtitle,Content,Addtime,IsRead,(select uname from [OA_User] where Uid=[OA_Message].ToUid) as ToUname,(select uname from [OA_User] where Uid=[OA_Message].FromUid) as FromUname ");
            strSql.Append(",Touser from [OA_Message] ");
            strSql.Append(" where Mid=" + Mid + " ");
            Daiv_OA.Entity.MessageEntity model = new Daiv_OA.Entity.MessageEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Mid"].ToString() != "")
                {
                    model.Mid = int.Parse(ds.Tables[0].Rows[0]["Mid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ToUid"].ToString() != "")
                {
                    model.ToUid = int.Parse(ds.Tables[0].Rows[0]["ToUid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FromUid"].ToString() != "")
                {
                    model.FromUid = int.Parse(ds.Tables[0].Rows[0]["FromUid"].ToString());
                }
                model.Mtitle = ds.Tables[0].Rows[0]["Mtitle"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["Addtime"].ToString() != "")
                {
                    model.Addtime = DateTime.Parse(ds.Tables[0].Rows[0]["Addtime"].ToString());
                }
               
                model.ToUname = ds.Tables[0].Rows[0]["ToUname"].ToString();
                model.FromUname = ds.Tables[0].Rows[0]["FromUname"].ToString();
                model.IsRead = Convert.ToInt32(ds.Tables[0].Rows[0]["IsRead"].ToString());
                model.Touser = ds.Tables[0].Rows[0]["touser"].ToString();
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
            strSql.Append("select Mid,ToUid,FromUid,Mtitle,Content,Addtime,IsRead,(select uname from [OA_User] where Uid=[OA_Message].ToUid) as ToUname,(select uname from [OA_User] where Uid=[OA_Message].FromUid) as FromUname ");
            strSql.Append(",Touser FROM [OA_Message] ");
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
            strSql.Append(" Mid,ToUid,FromUid,Mtitle,Content,Addtime,IsRead,(select uname from [OA_User] where Uid=[OA_Message].ToUid) as ToUname,(select uname from [OA_User] where Uid=[OA_Message].FromUid) as FromUname ");
            strSql.Append(" FROM [OA_Message] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<Entity.MessageEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " *,(select uname from [OA_User] where Uid=[OA_Message].ToUid) as ToUname,(select uname from [OA_User] where Uid=[OA_Message].FromUid) as FromUname ";

            table = "[OA_Message] ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "Mid";

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

            List<Entity.MessageEntity> list = new List<Entity.MessageEntity>();
            Entity.MessageEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.MessageEntity();

                if (ds.Tables[0].Rows[i]["Mid"].ToString() != "")
                {
                    model.Mid = int.Parse(ds.Tables[0].Rows[i]["Mid"].ToString());
                }
                model.Addtime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Addtime"].ToString());
                model.Mtitle = ds.Tables[0].Rows[i]["Mtitle"].ToString();
                model.ToUid = Convert.ToInt32(ds.Tables[0].Rows[i]["ToUid"].ToString());
                model.ToUname = ds.Tables[0].Rows[i]["ToUname"].ToString();
                model.FromUid = Convert.ToInt32(ds.Tables[0].Rows[i]["FromUid"].ToString());
                model.FromUname = ds.Tables[0].Rows[i]["FromUname"].ToString();
                model.IsRead = Convert.ToInt32(ds.Tables[0].Rows[i]["IsRead"].ToString());
                model.Touser = ds.Tables[0].Rows[i]["touser"].ToString();
                list.Add(model);
            }

            return list;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void SetReadById(int Mid)
        {
            string sql = "update [OA_Message] set [IsRead]=1 where Mid=" + Mid;
            DbHelperSQL.ExecuteSql(sql);
        }
        #endregion  成员方法
    }
}

