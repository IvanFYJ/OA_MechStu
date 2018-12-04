using Daiv_OA.DBUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Daiv_OA.DAL
{
    public class GradeDAL
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("GradeDAL");

        public GradeDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Gid", "[OA_Grade]");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Gid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_Grade]");
            strSql.Append(" where Gid=@Gid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Gid", SqlDbType.Int,4)};
            parameters[0].Value = Gid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Gname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_Grade]");
            strSql.Append(" where Gname=@Gname");
            SqlParameter[] parameters = {
                    new SqlParameter("@Gname", SqlDbType.VarChar,50)};
            parameters[0].Value = Gname;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 是否存在年级该记录
        /// </summary>
        public bool ExistsGrade(string GgradeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_Grade]");
            strSql.Append(" where GgradeName=@GgradeName");
            SqlParameter[] parameters = {
                    new SqlParameter("@GgradeName", SqlDbType.VarChar,50)};
            parameters[0].Value = GgradeName;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.GradeEntity model)
        {
            if (ExistsGrade(model.GgradeName))
                return -1;
            if (Exists(model.Gname))//已经存在该用户
                return 0;
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();

            if (model.Gname != null)
            {
                strSql1.Append("Gname,");
                strSql2.Append("'" + model.Gname + "',");
            }
            if (model.Gdescription != null)
            {
                strSql1.Append("Gdescription,");
                strSql2.Append("'" + model.Gdescription + "',");
            }
            if (model.Gsnumber > 0)
            {
                strSql1.Append("Gsnumber,");
                strSql2.Append("" + model.Gsnumber + ",");
            }
            if (model.MechID >= 0)
            {
                strSql1.Append("MechID,");
                strSql2.Append("" + model.MechID + ",");
            }
            if (model.GgradeName != null)
            {
                strSql1.Append("GgradeName,");
                strSql2.Append("'" + model.GgradeName + "',");
            }
            if (model.Mphone != null)
            {
                strSql1.Append("Mphone,");
                strSql2.Append("'" + model.Mphone + "',");
            }
            if (model.IsDeleted >= 0)
            {
                strSql1.Append("IsDeleted,");
                strSql2.Append("" + model.IsDeleted + ",");
            }
            strSql.Append("insert into [OA_Grade](");
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
        public void Update(Daiv_OA.Entity.GradeEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Grade] set ");
            strSql.Append("Gname='" + model.Gname + "',");
            strSql.Append("Gdescription='" + model.Gdescription + "',");
            strSql.Append("GgradeName='" + model.GgradeName + "',");
            strSql.Append("MechID=" + model.MechID + ",");
            strSql.Append("Gsnumber=" + model.Gsnumber + ",");
            strSql.Append("Mphone=" + model.Mphone + "");
            strSql.Append(" where Gid=" + model.Gid + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Gid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM [OA_Grade] ");
            strSql.Append(" where Gid=@Gid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Gid", SqlDbType.Int,4)};
            parameters[0].Value = Gid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.GradeEntity GetEntity(int Gid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" Gid ,Gname ,Gsnumber ,Gdescription,MechID ,GgradeName,Mphone ,IsDeleted  ");
            strSql.Append(" FROM [OA_Grade] ");
            strSql.Append(" where Gid=" + Gid + " ");
            Daiv_OA.Entity.GradeEntity model = new Daiv_OA.Entity.GradeEntity();
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
        public Daiv_OA.Entity.GradeEntity ConvertModel(DataTable dt, int rowindex)
        {
            Daiv_OA.Entity.GradeEntity model = new Daiv_OA.Entity.GradeEntity();
            try
            {
                if (dt.Rows[rowindex]["Gid"].ToString() != "")
                {
                    model.Gid = int.Parse(dt.Rows[rowindex]["Gid"].ToString());
                }
                if (dt.Rows[rowindex]["Gsnumber"].ToString() != "")
                {
                    model.Gsnumber = int.Parse(dt.Rows[rowindex]["Gsnumber"].ToString());
                }
                if (dt.Rows[rowindex]["MechID"].ToString() != "")
                {
                    model.MechID = int.Parse(dt.Rows[rowindex]["MechID"].ToString());
                }
                model.Gdescription = dt.Rows[rowindex]["Gdescription"].ToString();
                model.GgradeName = dt.Rows[rowindex]["GgradeName"].ToString();
                model.Gname = dt.Rows[rowindex]["Gname"].ToString();
                model.Mphone = dt.Rows[rowindex]["Mphone"].ToString();
                if (dt.Rows[rowindex]["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(dt.Rows[rowindex]["IsDeleted"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Info("转换成用户对象失败！原因：" + ex.Message);
                return new Entity.GradeEntity();
            }
            return model;
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="mPhone"></param>
        /// <returns></returns>
        public IList<Hashtable> List(int pageIndex, int pageSize)
        {
            string sql = @"WITH listtab AS (
SELECT Gid,GgradeName,Mphone,Gname,Gdescription,
ROW_NUMBER() OVER (ORDER BY Gid ASC) AS req
FROM dbo.OA_Grade
)
SELECT * FROM listtab
WHERE req BETWEEN @begin AND @end";
            SqlParameter[] parameters = {
                    new SqlParameter("@begin", SqlDbType.Int,4),
                    new SqlParameter("@end", SqlDbType.Int,4)};
            parameters[0].Value = (pageIndex - 1) * pageSize;
            parameters[1].Value = pageIndex * pageSize;
            //分页查询
            return DbHelperSQL.ExecuteReaderHashtable(sql, parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Gid ,Gname ,Gsnumber ,Gdescription,MechID ,Mphone,GgradeName  ,IsDeleted  ");
            strSql.Append(" FROM [OA_Grade] ");
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
            strSql.Append(" Gid ,Gname ,Gsnumber ,Gdescription ,MechID,Mphone ,GgradeName ,IsDeleted ");
            strSql.Append(" FROM [OA_Grade] ");
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
        /// <param name="kls_Gid"></param>
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
        /// <param name="kls_Gid"></param>
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
