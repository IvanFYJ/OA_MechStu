using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;//�����������
namespace Daiv_OA.DAL
{
    /// <summary>
    /// ���ݷ�����Department��
    /// </summary>
    public class DepartmentDAL
    {
        public DepartmentDAL()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Did", "OA_Department");
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int Did)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [OA_Department]");
            strSql.Append(" where Did=@Did ");
            SqlParameter[] parameters = {
					new SqlParameter("@Did", SqlDbType.Int,4)};
            parameters[0].Value = Did;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Entity.DepartmentEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [OA_Department](");
            strSql.Append("DName)");
            strSql.Append(" values (");
            strSql.Append("@DName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DName", SqlDbType.VarChar,20)};
            parameters[0].Value = model.DName;

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
        /// ����һ������
        /// </summary>
        public void Update(Entity.DepartmentEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Department] set ");
            strSql.Append("DName=@DName");
            strSql.Append(" where Did=@Did ");
            SqlParameter[] parameters = {
					new SqlParameter("@Did", SqlDbType.Int,4),
					new SqlParameter("@DName", SqlDbType.VarChar,20)};
            parameters[0].Value = model.Did;
            parameters[1].Value = model.DName;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int Did)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [OA_Department] ");
            strSql.Append(" where Did=@Did ");
            SqlParameter[] parameters = {
					new SqlParameter("@Did", SqlDbType.Int,4)};
            parameters[0].Value = Did;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Entity.DepartmentEntity GetEntity(int Did)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Did,DName from [OA_Department] ");
            strSql.Append(" where Did=@Did ");
            SqlParameter[] parameters = {
					new SqlParameter("@Did", SqlDbType.Int,4)};
            parameters[0].Value = Did;

            Entity.DepartmentEntity model = new Entity.DepartmentEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Did"].ToString() != "")
                {
                    model.Did = int.Parse(ds.Tables[0].Rows[0]["Did"].ToString());
                }
                model.DName = ds.Tables[0].Rows[0]["DName"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Did,DName ");
            strSql.Append(" from [OA_Department] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Did,DName ");
            strSql.Append(" from [OA_Department] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  ��Ա����
    }
}

