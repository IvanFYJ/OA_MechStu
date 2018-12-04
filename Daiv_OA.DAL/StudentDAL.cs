using Daiv_OA.DBUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Daiv_OA.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class StudentDAL
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger("GradeDAL");

        public StudentDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Gid", "[OA_Student]");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Gid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_Student]");
            strSql.Append(" where Gid=@Gid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Gid", SqlDbType.Int,4)};
            parameters[0].Value = Gid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Snumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_Student]");
            strSql.Append(" where Snumber=@Snumber");
            SqlParameter[] parameters = {
                    new SqlParameter("@Snumber", SqlDbType.VarChar,50)};
            parameters[0].Value = Snumber;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.StudentEntity model)
        {
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
            if (model.Snumber != null)
            {
                strSql1.Append("Snumber,");
                strSql2.Append("'" + model.Snumber + "',");
            }
            if (model.Gid > 0)
            {
                strSql1.Append("Gid,");
                strSql2.Append("" + model.Gid + ",");
            }
            if (model.Uid > 0)
            {
                strSql1.Append("Uid,");
                strSql2.Append("" + model.Uid + ",");
            }
            if (model.MechID > 0)
            {
                strSql1.Append("MechID,");
                strSql2.Append("" + model.MechID + ",");
            }
            if (model.Sbirthday != null)
            {
                strSql1.Append("Sbirthday,");
                strSql2.Append("'" + model.Sbirthday + "',");
            }
            if (model.Sname != null)
            {
                strSql1.Append("Sname,");
                strSql2.Append("'" + model.Sname + "',");
            }
            if (model.IsDeleted >= 0)
            {
                strSql1.Append("IsDeleted,");
                strSql2.Append("" + model.IsDeleted + ",");
            }
            strSql.Append("insert into [OA_Student](");
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
        public void Update(Daiv_OA.Entity.StudentEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Student] set ");
            strSql.Append("Gname='" + model.Gname + "',");
            strSql.Append("Snumber='" + model.Snumber + "',"); 
            strSql.Append("Gid=" + model.Gid + ",");
            strSql.Append("MechID=" + model.MechID + ",");
            strSql.Append("Uid=" + model.Uid + ",");
            strSql.Append("Sname='" + model.Sname + "',");
            strSql.Append("Sbirthday='" + model.Sbirthday + "'");
            strSql.Append(" where Gid=" + model.Gid + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM [OA_Student] ");
            strSql.Append(" where Sid=@Sid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Sid", SqlDbType.Int,4)};
            parameters[0].Value = Sid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.StudentEntity GetEntity(int Sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" Sid ,Snumber ,Gid ,Uid ,Sbirthday ,IsDeleted,MechID ,Sname,Gname  ");
            strSql.Append(" FROM [OA_Student] ");
            strSql.Append(" where Sid=" + Sid + " ");
            Daiv_OA.Entity.StudentEntity model = new Daiv_OA.Entity.StudentEntity();
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
        /// 根据学号获取学生信息
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Daiv_OA.Entity.StudentEntity GetEntityByNumber(string number)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" Sid ,Snumber ,Gid ,Uid ,Sbirthday ,IsDeleted,MechID ,Sname,Gname  ");
            strSql.Append(" FROM [OA_Student] ");
            strSql.Append(" where Snumber='" + number + "' ");
            Daiv_OA.Entity.StudentEntity model = new Daiv_OA.Entity.StudentEntity();
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
        public Daiv_OA.Entity.StudentEntity ConvertModel(DataTable dt, int rowindex)
        {
            Daiv_OA.Entity.StudentEntity model = new Daiv_OA.Entity.StudentEntity();
            try
            {
                if (dt.Rows[rowindex]["Sid"].ToString() != "")
                {
                    model.Sid = int.Parse(dt.Rows[rowindex]["Sid"].ToString());
                }
                if (dt.Rows[rowindex]["Gid"].ToString() != "")
                {
                    model.Gid = int.Parse(dt.Rows[rowindex]["Gid"].ToString()); 
                }
                if (dt.Rows[rowindex]["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(dt.Rows[rowindex]["Uid"].ToString());
                }
                if (dt.Rows[rowindex]["MechID"].ToString() != "")
                {
                    model.MechID = int.Parse(dt.Rows[rowindex]["MechID"].ToString());
                }
                if (dt.Rows[rowindex]["Sbirthday"].ToString() != "")
                {
                    model.Sbirthday = DateTime.Parse(dt.Rows[rowindex]["Sbirthday"].ToString());
                }
                model.Snumber = dt.Rows[rowindex]["Snumber"].ToString();
                model.Gname = dt.Rows[rowindex]["Gname"].ToString();
                model.Sname = dt.Rows[rowindex]["Sname"].ToString();
                if (dt.Rows[rowindex]["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(dt.Rows[rowindex]["IsDeleted"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Info("转换成用户对象失败！原因：" + ex.Message);
                return new Entity.StudentEntity();
            }
            return model;
        }

        /// <summary>
        /// 分页查询学生数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="mPhone"></param>
        /// <returns></returns>
        public IList<Hashtable> List(int pageIndex,int pageSize,string mPhone)
        {
            string sql = @"WITH listtab AS (
SELECT g.Gid,s.Sname,s.Snumber,c.Cphone,c.Cphone2,c.Cphone3,c.Cphone4,
ROW_NUMBER() OVER (ORDER BY g.Gid ASC, s.Snumber ASC) AS req
FROM dbo.OA_Grade(NOLOCK) g
JOIN dbo.OA_Student(NOLOCK) s ON s.Gid = g.Gid
JOIN dbo.OA_Contact(NOLOCK) c ON c.Sid = s.Sid
WHERE g.Mphone = @mPhone
)
SELECT Gid,Sname,Snumber,Cphone,Cphone2,Cphone3,Cphone4 FROM listtab
WHERE req BETWEEN @begin AND @end";
            SqlParameter[] parameters = {
                    new SqlParameter("@mPhone", SqlDbType.VarChar,50),
                    new SqlParameter("@begin", SqlDbType.Int,4),
                    new SqlParameter("@end", SqlDbType.Int,4)};
            parameters[0].Value = mPhone;
            parameters[1].Value = (pageIndex-1)*pageSize;
            parameters[2].Value = pageIndex*pageSize;
            //分页查询
            return DbHelperSQL.ExecuteReaderHashtable(sql, parameters);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Sid ,Snumber ,Gid ,Uid ,Sbirthday ,IsDeleted,MechID ,Sname,Gname  ");
            strSql.Append(" FROM [OA_Student] ");
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
            strSql.Append(" Sid ,Snumber ,Gid ,Uid ,Sbirthday ,IsDeleted ,MechID,Sname,Gname ");
            strSql.Append(" FROM [OA_Student] ");
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
