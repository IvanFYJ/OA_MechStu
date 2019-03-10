using Daiv_OA.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Daiv_OA.DAL
{
    public class GradeUpdateConfigDAL
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("GradeUpdateConfigDAL");

        public GradeUpdateConfigDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "[OA_GradeUpdateConfig]");
        }

        /// <summary>
        /// 是否存在该记录(根据学生ID来添加)
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_GradeUpdateConfig]");
            strSql.Append(" where ID=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int currId, int upId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_GradeUpdateConfig]");
            strSql.Append(" where IsDeleted = 0 and  CurrGradeID=@currId and UpGradeID=@upId");
            SqlParameter[] parameters = {
                    new SqlParameter("@currId", SqlDbType.Int,4),
                    new SqlParameter("@upId", SqlDbType.Int,4)
            };
            parameters[0].Value = currId;
            parameters[1].Value = upId;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.GradeUpdateConfigEntity model)
        {
            if (model.ID > 0 && Exists(model.CurrGradeID, model.UpGradeID))//已经存在该年级配置
                return 0;
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            model.IsDeleted = 0;

            if (model.CurrGradeID >= 0)
            {
                strSql1.Append("CurrGradeID,");
                strSql2.Append("" + model.CurrGradeID + ",");
            }
            if (model.UpGradeID >= 0)
            {
                strSql1.Append("UpGradeID,");
                strSql2.Append("" + model.UpGradeID + ",");
            }

            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.CreateUserID >= 0)
            {
                strSql1.Append("CreateUserID,");
                strSql2.Append("" + model.CreateUserID + ",");
            }

            if (model.ModifyDate != null)
            {
                strSql1.Append("ModifyDate,");
                strSql2.Append("'" + model.ModifyDate + "',");
            }
            if (model.ModifyUserID >= 0)
            {
                strSql1.Append("ModifyUserID,");
                strSql2.Append("" + model.ModifyUserID + ",");
            }

            if (model.DeleteDate != null)
            {
                strSql1.Append("DeleteDate,");
                strSql2.Append("'" + model.DeleteDate + "',");
            }
            if (model.DeleteUserID >= 0)
            {
                strSql1.Append("DeleteUserID,");
                strSql2.Append("" + model.DeleteUserID + ",");
            }


            if (model.IsDeleted >= 0)
            {
                strSql1.Append("IsDeleted,");
                strSql2.Append("0,");
            }
            strSql.Append("insert into [OA_GradeUpdateConfig](");
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
        public void Update(Daiv_OA.Entity.GradeUpdateConfigEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_GradeUpdateConfig] set ");
            strSql.Append("CurrGradeID=" + model.CurrGradeID + ",");
            strSql.Append("UpGradeID=" + model.UpGradeID + ",");

            strSql.Append("CreateDate='" + model.CreateDate + "',");
            strSql.Append("CreateUserID=" + model.CreateUserID + ",");

            strSql.Append("ModifyDate='" + model.ModifyDate + "',");
            strSql.Append("ModifyUserID=" + model.ModifyUserID + ",");

            strSql.Append("DeleteDate='" + model.DeleteDate + "',");
            strSql.Append("DeleteUserID=" + model.DeleteUserID + ",");

            strSql.Append("IsDeleted=" + model.IsDeleted + "");//注意： 最后不需要加逗号
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateGrade()
        {
            StringBuilder strSql = new StringBuilder();
            
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM [OA_GradeUpdateConfig] ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.GradeUpdateConfigEntity GetEntity(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" ID,CurrGradeID ,UpGradeID ,CreateDate,CreateUserID ,ModifyDate,ModifyUserID ,DeleteDate,DeleteUserID,IsDeleted  ");
            strSql.Append(" FROM [OA_GradeUpdateConfig] ");
            strSql.Append(" where ID=" + ID + " ");
            Daiv_OA.Entity.GradeUpdateConfigEntity model = new Daiv_OA.Entity.GradeUpdateConfigEntity();
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
        public Daiv_OA.Entity.GradeUpdateConfigEntity ConvertModel(DataTable dt, int rowindex)
        {
            Daiv_OA.Entity.GradeUpdateConfigEntity model = new Daiv_OA.Entity.GradeUpdateConfigEntity();
            try
            {
                if (dt.Rows[rowindex]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[rowindex]["ID"].ToString());
                }
                if (dt.Rows[rowindex]["CurrGradeID"].ToString() != "")
                {
                    model.CurrGradeID = int.Parse(dt.Rows[rowindex]["CurrGradeID"].ToString());
                }
                if (dt.Rows[rowindex]["CurrGradeID"].ToString() != "")
                {
                    model.UpGradeID = int.Parse(dt.Rows[rowindex]["UpGradeID"].ToString());
                }

                model.CreateDate = Convert.ToDateTime(dt.Rows[rowindex]["CreateDate"]);
                if (dt.Rows[rowindex]["CreateUserID"].ToString() != "")
                {
                    model.CreateUserID = int.Parse(dt.Rows[rowindex]["CreateUserID"].ToString());
                }

                model.ModifyDate = Convert.ToDateTime(dt.Rows[rowindex]["ModifyDate"]);
                if (dt.Rows[rowindex]["ModifyUserID"].ToString() != "")
                {
                    model.ModifyUserID = int.Parse(dt.Rows[rowindex]["ModifyUserID"].ToString());
                }

                model.DeleteDate = Convert.ToDateTime(dt.Rows[rowindex]["DeleteDate"]);
                if (dt.Rows[rowindex]["DeleteUserID"].ToString() != "")
                {
                    model.DeleteUserID = int.Parse(dt.Rows[rowindex]["DeleteUserID"].ToString());
                }

                if (dt.Rows[rowindex]["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(dt.Rows[rowindex]["IsDeleted"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Info("转换成用户对象失败！原因：" + ex.Message);
                return new Entity.GradeUpdateConfigEntity();
            }
            return model;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ID,CurrGradeID ,UpGradeID ,CreateDate,CreateUserID ,ModifyDate,ModifyUserID ,DeleteDate,DeleteUserID,IsDeleted  ");
            strSql.Append(" FROM [OA_GradeUpdateConfig] ");
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
            strSql.Append("  ID,CurrGradeID ,UpGradeID ,CreateDate,CreateUserID ,ModifyDate,ModifyUserID ,DeleteDate,DeleteUserID,IsDeleted   ");
            strSql.Append(" FROM [OA_GradeUpdateConfig] ");
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
        /// <param name="kls_ID"></param>
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
        /// <param name="kls_ID"></param>
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
