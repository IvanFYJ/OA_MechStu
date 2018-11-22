using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;//�����������
namespace Daiv_OA.DAL
{
	/// <summary>
    /// ���ݷ�����Power��
	/// </summary>
	public class PowerDAL
	{
		public PowerDAL()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID("Pid", "[OA_Power]"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Pid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from [OA_Power]");
			strSql.Append(" where Pid=@Pid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4)};
			parameters[0].Value = Pid;
			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Entity.PowerEntity model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into [OA_Power](");
			strSql.Append("PName)");
			strSql.Append(" values (");
			strSql.Append("@PName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PName", SqlDbType.VarChar,20)};
			parameters[0].Value = model.PName;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public void Update(Entity.PowerEntity model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update [OA_Power] set ");
			strSql.Append("PName=@PName");
			strSql.Append(" where Pid=@Pid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4),
					new SqlParameter("@PName", SqlDbType.VarChar,20)};
			parameters[0].Value = model.Pid;
			parameters[1].Value = model.PName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int Pid)
		{

            StringBuilder strSql = new StringBuilder();
            
			strSql.Append("delete from [OA_Power] ");
			strSql.Append(" where Pid=@Pid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4)};
			parameters[0].Value = Pid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Entity.PowerEntity GetEntity(int Pid)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 Pid,PName,Setting from [OA_Power] ");
			strSql.Append(" where Pid=@Pid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4)};
			parameters[0].Value = Pid;

			Entity.PowerEntity model=new Entity.PowerEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Pid"].ToString()!="")
				{
					model.Pid=int.Parse(ds.Tables[0].Rows[0]["Pid"].ToString());
				}
				model.PName=ds.Tables[0].Rows[0]["PName"].ToString();
                model.Setting = ds.Tables[0].Rows[0]["Setting"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Pid,PName,Setting ");
			strSql.Append(" from [OA_Power] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" Pid,PName,Setting ");
			strSql.Append(" from [OA_Power] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        #endregion  ��Ա����
    }
}

