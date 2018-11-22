using System;
using System.Data;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;
//using LTP.Common;
using Daiv_OA.Entity;

namespace Daiv_OA.DAL
{
    /// <summary>
    /// 数据访问类Diary。
    /// </summary>
    public class DiaryDAL
    {
        public DiaryDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [OA_Diary]");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public DiaryEntity GetModelByDate(int AccountID, DateTime dateTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Title,WorkDate,WorkDuration,Note,OwnerID,Comment,CreateTime from [OA_Diary]");
            strSql.Append(" where WorkDate=convert(dateTime,'" + dateTime.ToString("yyyy-MM-dd") + "',21) ");
            strSql.Append(" and  OwnerID=@OwnerID");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkDate", SqlDbType.DateTime),
                    new SqlParameter("@OwnerID", SqlDbType.Int,4)};
            parameters[0].Value = Convert.ToDateTime(dateTime);
            parameters[1].Value = AccountID;
            DiaryEntity model = new DiaryEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["WorkDate"].ToString() != "")
                {
                    model.WorkDate = DateTime.Parse(ds.Tables[0].Rows[0]["WorkDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WorkDuration"].ToString() != "")
                {
                    model.WorkDuration = decimal.Parse(ds.Tables[0].Rows[0]["WorkDuration"].ToString());
                }
                model.Note = ds.Tables[0].Rows[0]["Note"].ToString();
                if (ds.Tables[0].Rows[0]["OwnerID"].ToString() != "")
                {
                    model.OwnerID = int.Parse(ds.Tables[0].Rows[0]["OwnerID"].ToString());
                }
                model.Note = ds.Tables[0].Rows[0]["Note"].ToString();
                model.Comment = ds.Tables[0].Rows[0]["Comment"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DiaryEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [OA_Diary](");
            strSql.Append("Title,WorkDate,WorkDuration,Note,OwnerID,Comment,CreateTime)");
            strSql.Append(" values (");
            strSql.Append("@Title,@WorkDate,@WorkDuration,@Note,@OwnerID,@Comment,@CreateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@WorkDate", SqlDbType.DateTime),
					new SqlParameter("@WorkDuration", SqlDbType.Float,8),
					new SqlParameter("@Note", SqlDbType.NVarChar,1000),
					new SqlParameter("@OwnerID", SqlDbType.Int,4),
                    new SqlParameter("@Comment", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.WorkDate;
            parameters[2].Value = model.WorkDuration;
            parameters[3].Value = model.Note;
            parameters[4].Value = model.OwnerID;
            parameters[5].Value = model.Comment;
            parameters[6].Value = DateTime.Now;
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
        public void Update(DiaryEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Diary] set ");
            strSql.Append("Title=@Title,");
            strSql.Append("WorkDate=@WorkDate,");
            strSql.Append("WorkDuration=@WorkDuration,");
            strSql.Append("Note=@Note ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@WorkDate", SqlDbType.DateTime),
					new SqlParameter("@WorkDuration", SqlDbType.Float,8),
					new SqlParameter("@Note", SqlDbType.NVarChar,1000),
                    new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.WorkDate;
            parameters[2].Value = model.WorkDuration;
            parameters[3].Value = model.Note;
            parameters[4].Value = model.ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(long ID, string Comment)
        {
            DiaryEntity diaryEntity = GetEntity(ID);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Diary] set ");
            strSql.Append("Comment=@Comment");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.BigInt),
                    new SqlParameter("@Comment", SqlDbType.NVarChar,500)};
            parameters[0].Value = ID;
            parameters[1].Value = diaryEntity.Comment + Comment;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [OA_Diary] ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DiaryEntity GetEntity(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Title,WorkDate,WorkDuration,Note,OwnerID,Comment,CreateTime from [OA_Diary] ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = ID;

            DiaryEntity model = new DiaryEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["WorkDate"].ToString() != "")
                {
                    model.WorkDate = DateTime.Parse(ds.Tables[0].Rows[0]["WorkDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WorkDuration"].ToString() != "")
                {
                    model.WorkDuration = decimal.Parse(ds.Tables[0].Rows[0]["WorkDuration"].ToString());
                }
                model.Note = ds.Tables[0].Rows[0]["Note"].ToString();
                if (ds.Tables[0].Rows[0]["OwnerID"].ToString() != "")
                {
                    model.OwnerID = int.Parse(ds.Tables[0].Rows[0]["OwnerID"].ToString());
                }
                model.Note = ds.Tables[0].Rows[0]["Note"].ToString();
                model.Comment = ds.Tables[0].Rows[0]["Comment"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
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
            strSql.Append("select ID,Title,WorkDate,WorkDuration,Note,OwnerID ");
            strSql.Append(" FROM [OA_Diary] ");
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
            strSql.Append(" ID,Title,WorkDate,WorkDuration,Note,OwnerID ");
            strSql.Append(" FROM [OA_Diary] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        public DataSet GetListData(int ownerID, DateTime dtBegin, DateTime dtEnd)
        {
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append("Select * FROM [OA_Diary] ");
            sbSQL.Append(" Where OwnerID=" + ownerID);
            sbSQL.Append(" and WorkDate>=convert(datetime,'" + dtBegin.ToString("yyyy-MM-dd") + "',21) ");
            sbSQL.Append(" and WorkDate<convert(datetime,'" + dtEnd.AddDays(1).ToString("yyyy-MM-dd") + "',21) ");
            sbSQL.Append(" Order by WorkDate");
            return DbHelperSQL.Query(sbSQL.ToString());
        }

        public DataSet GetListData(int ownerID, DateTime dtBegin, DateTime dtEnd, string note, int pageSize, int currentPageIndex, string orderByField, string sort)
        {
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append("Select * FROM [OA_Diary] ");
            sbSQL.Append(" Where OwnerID=" + ownerID);
            sbSQL.Append(" and WorkDate>=convert(datetime,'" + dtBegin.ToString("yyyy-MM-dd") + "',21) ");
            sbSQL.Append(" and WorkDate<convert(datetime,'" + dtEnd.AddDays(1).ToString("yyyy-MM-dd") + "',21) ");
            sbSQL.Append(" and Note like '%" + note + "%'");
            sbSQL.Append(" Order by " + orderByField + " " + sort);
            SqlConnection sqlconn = new SqlConnection(PubConstant.GetConnectionString("ConnectionString"));
            SqlCommand sqlcmd = new SqlCommand(sbSQL.ToString(), sqlconn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
            //OleDbDataAdapter da = new OleDbDataAdapter(sql, myConn);
            DataSet ds = new DataSet();
            sda.Fill(ds, pageSize * (currentPageIndex - 1), pageSize, "[OA_Diary]");
            return ds;
        }

        public bool JudgePosition(int AccountID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [OA_Power] p,[OA_User] u ");
            strSql.Append(" where p.pid=u.pid and (p.pname='部门主管' or p.pname='主管') and u.UID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = AccountID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);

        }

        #endregion  成员方法
    }
}
