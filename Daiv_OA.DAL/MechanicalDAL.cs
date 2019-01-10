using Daiv_OA.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Daiv_OA.DAL
{
    public class MechanicalDAL
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("MechanicalDAL");

        public MechanicalDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "[OA_Mechanical]");
        }

        /// <summary>
        /// 是否存在该记录(根据学生ID来添加)
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_Mechanical]");
            strSql.Append(" where ID=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string imei)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_Mechanical]");
            strSql.Append(" where MechIMEI=@MechIMEI");
            SqlParameter[] parameters = {
                    new SqlParameter("@MechIMEI", SqlDbType.NVarChar,512)};
            parameters[0].Value = imei;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.MechanicalEntity model)
        {
            if (model.ID > 0 && Exists(model.MechIMEI))//已经存在该设备
                return 0;
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            model.IsDeleted = 0;
            
            if (model.MechName != null)
            {
                strSql1.Append("MechName,");
                strSql2.Append("'" + model.MechName + "',");
            }
            if (model.MechIMEI != null)
            {
                strSql1.Append("MechIMEI,");
                strSql2.Append("'" + model.MechIMEI + "',");
            }
            if (model.MechPhone != null)
            {
                strSql1.Append("MechPhone,");
                strSql2.Append("'" + model.MechPhone + "',");
            }
            if (model.ClassName != null)
            {
                strSql1.Append("ClassName,");
                strSql2.Append("'" + model.ClassName + "',");
            }
            if (model.Gid > 0)
            {
                strSql1.Append("Gid,");
                strSql2.Append("" + model.Gid + ",");
            }
            if (model.IsDeleted >= 0)
            {
                strSql1.Append("IsDeleted,");
                strSql2.Append("0,");
            }
            strSql.Append("insert into [OA_Mechanical](");
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
        public void Update(Daiv_OA.Entity.MechanicalEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Mechanical] set ");
            strSql.Append("MechName='" + model.MechName + "',");
            strSql.Append("MechIMEI='" + model.MechIMEI + "',");
            strSql.Append("ClassName='" + model.ClassName + "',");
            strSql.Append("Gid=" + model.Gid + ",");
            strSql.Append("MechPhone='" + model.MechPhone + "'");//注意： 最后不需要加逗号
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM [OA_Mechanical] ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByImei(string imei)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update [OA_Mechanical] ");
            strSql.Append(" set IsDeleted=@IsDeleted ");
            strSql.Append(" where MechIMEI=@MechIMEI ");
            SqlParameter[] parameters = {
                    new SqlParameter("@IsDeleted", SqlDbType.Int,4),
                    new SqlParameter("@MechIMEI", SqlDbType.NVarChar,512)
            };
            parameters[0].Value = 1;
            parameters[1].Value = imei;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.MechanicalEntity GetEntity(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" ID,MechName ,MechIMEI ,MechPhone,ClassName,Gid ,IsDeleted  ");
            strSql.Append(" FROM [OA_Mechanical] ");
            strSql.Append(" where ID=" + ID + " ");
            Daiv_OA.Entity.MechanicalEntity model = new Daiv_OA.Entity.MechanicalEntity();
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
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.MechanicalEntity GetEntityByImei(string imei)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" ID,MechName ,MechIMEI ,MechPhone,ClassName,Gid ,IsDeleted   ");
            strSql.Append(" FROM [OA_Mechanical] ");
            strSql.Append(" where IsDeleted = 0 and MechIMEI='" + imei + "' ");
            Daiv_OA.Entity.MechanicalEntity model = new Daiv_OA.Entity.MechanicalEntity();
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
        public Daiv_OA.Entity.MechanicalEntity ConvertModel(DataTable dt, int rowindex)
        {
            Daiv_OA.Entity.MechanicalEntity model = new Daiv_OA.Entity.MechanicalEntity();
            try
            {
                if (dt.Rows[rowindex]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[rowindex]["ID"].ToString());
                }
                model.MechName = dt.Rows[rowindex]["MechName"].ToString();
                model.MechIMEI = dt.Rows[rowindex]["MechIMEI"].ToString();
                model.MechPhone = dt.Rows[rowindex]["MechPhone"].ToString();
                model.ClassName = dt.Rows[rowindex]["ClassName"].ToString();
                if (dt.Rows[rowindex]["Gid"].ToString() != "")
                {
                    model.Gid = int.Parse(dt.Rows[rowindex]["Gid"].ToString());
                }
                if (dt.Rows[rowindex]["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(dt.Rows[rowindex]["IsDeleted"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Info("转换成用户对象失败！原因：" + ex.Message);
                return new Entity.MechanicalEntity();
            }
            return model;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ID,MechName ,MechIMEI ,MechPhone,ClassName,Gid ,IsDeleted   ");
            strSql.Append(" FROM [OA_Mechanical] ");
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
            strSql.Append("  ID,MechName ,MechIMEI ,MechPhone ,ClassName,Gid,IsDeleted   ");
            strSql.Append(" FROM [OA_Mechanical] ");
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
