using Daiv_OA.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Daiv_OA.DAL
{
    public class ParentMessageDAL
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger("ParentMessageDAL");

        public ParentMessageDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Mid", "[OA_ParentMessage]");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_ParentMessage]");
            strSql.Append(" where Mid=@Mid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Mid", SqlDbType.Int,4)};
            parameters[0].Value = Mid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.ParentMessageEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            
            if (model.ToUid > 0)
            {
                strSql1.Append("ToUid,");
                strSql2.Append("" + model.ToUid + ",");
            }
            if (model.FromUid >= 0)
            {
                strSql1.Append("FromUid,");
                strSql2.Append("" + model.FromUid + ",");
            }
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
            if (model.IsRead >= 0)
            {
                strSql1.Append("IsRead,");
                strSql2.Append("" + model.IsRead + ",");
            }
            if (model.Addtime != null)
            {
                strSql1.Append("Addtime,");
                strSql2.Append("'" + model.Addtime + "',");
            }
            if (model.Touser != null)
            {
                strSql1.Append("Touser,");
                strSql2.Append("'" + model.Touser + "',");
            }
            if (model.IsDeleted >= 0)
            {
                strSql1.Append("IsDeleted,");
                strSql2.Append("" + model.IsDeleted + ",");
            }
            strSql.Append("insert into [OA_ParentMessage](");
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
        public void Update(Daiv_OA.Entity.ParentMessageEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_ParentMessage] set ");
            strSql.Append("ToUid=" + model.ToUid + ",");
            strSql.Append("FromUid=" + model.FromUid + ",");
            strSql.Append("Mtitle='" + model.Mtitle + "',");
            strSql.Append("Content='" + model.Content + "',");
            strSql.Append("IsRead=" + model.IsRead + ",");
            strSql.Append("Addtime='" + model.Addtime + "',");
            strSql.Append("Touser='" + model.Touser + "',");
            strSql.Append("IsDeleted=" + model.IsDeleted + "");//注意：最后拼接内容
            strSql.Append(" where Mid=" + model.Mid + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Mid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM [OA_ParentMessage] ");
            strSql.Append(" where Mid=@Mid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Mid", SqlDbType.Int,4)};
            parameters[0].Value = Mid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.ParentMessageEntity GetEntity(int Mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" Mid ,ToUid ,FromUid ,Mtitle ,Content ,IsRead ,Addtime ,Touser ,IsDeleted  ");
            strSql.Append(" FROM [OA_ParentMessage] ");
            strSql.Append(" where Mid=" + Mid + " ");
            Daiv_OA.Entity.ParentMessageEntity model = new Daiv_OA.Entity.ParentMessageEntity();
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
        public Daiv_OA.Entity.ParentMessageEntity ConvertModel(DataTable dt, int rowindex)
        {
            Daiv_OA.Entity.ParentMessageEntity model = new Daiv_OA.Entity.ParentMessageEntity();
            try
            {
                if (dt.Rows[rowindex]["Mid"].ToString() != "")
                {
                    model.Mid = int.Parse(dt.Rows[rowindex]["Mid"].ToString());
                }
                if (dt.Rows[rowindex]["ToUid"].ToString() != "")
                {
                    model.ToUid = int.Parse(dt.Rows[rowindex]["ToUid"].ToString());
                }
                if (dt.Rows[rowindex]["FromUid"].ToString() != "")
                {
                    model.FromUid = int.Parse(dt.Rows[rowindex]["FromUid"].ToString());
                }
                model.Mtitle = dt.Rows[rowindex]["Mtitle"].ToString();
                model.Content = dt.Rows[rowindex]["Content"].ToString();
                if (dt.Rows[rowindex]["IsRead"].ToString() != "")
                {
                    model.IsRead = int.Parse(dt.Rows[rowindex]["IsRead"].ToString());
                }
                if (dt.Rows[rowindex]["Addtime"] != null)
                {
                    model.Addtime = DateTime.Parse(dt.Rows[rowindex]["Addtime"].ToString());
                }
                model.Touser = dt.Rows[rowindex]["Touser"].ToString();
                if (dt.Rows[rowindex]["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(dt.Rows[rowindex]["IsDeleted"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Info("转换成用户对象失败！原因：" + ex.Message);
                return new Entity.ParentMessageEntity();
            }
            return model;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Mid ,ToUid ,FromUid ,Mtitle ,Content ,IsRead ,Addtime ,Touser ,IsDeleted  ");
            strSql.Append(" FROM [OA_ParentMessage] ");
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
            strSql.Append(" Mid ,ToUid ,FromUid ,Mtitle ,Content ,IsRead ,Addtime ,Touser ,IsDeleted");
            strSql.Append(" FROM [OA_ParentMessage] ");
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
        /// <param name="kls_Mid"></param>
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
        /// <param name="kls_Mid"></param>
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
