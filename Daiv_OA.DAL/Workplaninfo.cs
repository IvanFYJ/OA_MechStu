using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;
using System.Collections.Generic;//请先添加引用
namespace Daiv_OA.DAL
{
	/// <summary>
	/// 数据访问类Workplaninfo。
	/// </summary>
	public class Workplaninfo
	{
		public Workplaninfo()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Wid", "Workplaninfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Wid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Workplaninfo");
			strSql.Append(" where Wid=@Wid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Wid", SqlDbType.Int,4)};
			parameters[0].Value = Wid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Entity.Workplaninfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Workplaninfo(");
			strSql.Append("Uid,Wdate,Wtext)");
			strSql.Append(" values (");
			strSql.Append("@Uid,@Wdate,@Wtext)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4),
					new SqlParameter("@Wdate", SqlDbType.DateTime),
					new SqlParameter("@Wtext", SqlDbType.VarChar,1000)};
			parameters[0].Value = model.Uid;
			parameters[1].Value = model.Wdate;
			parameters[2].Value = model.Wtext;

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
		/// 更新一条数据
		/// </summary>
		public void Update(Entity.Workplaninfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Workplaninfo set ");
			strSql.Append("Uid=@Uid,");
			strSql.Append("Wdate=@Wdate,");
			strSql.Append("Wtext=@Wtext");
			strSql.Append(" where Wid=@Wid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Wid", SqlDbType.Int,4),
					new SqlParameter("@Uid", SqlDbType.Int,4),
					new SqlParameter("@Wdate", SqlDbType.DateTime),
					new SqlParameter("@Wtext", SqlDbType.VarChar,1000)};
			parameters[0].Value = model.Wid;
			parameters[1].Value = model.Uid;
			parameters[2].Value = model.Wdate;
			parameters[3].Value = model.Wtext;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Wid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Workplaninfo ");
			strSql.Append(" where Wid=@Wid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Wid", SqlDbType.Int,4)};
			parameters[0].Value = Wid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.Workplaninfo GetEntity(int Wid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Wid,Uid,Wdate,Wtext from Workplaninfo ");
			strSql.Append(" where Wid=@Wid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Wid", SqlDbType.Int,4)};
			parameters[0].Value = Wid;

			Entity.Workplaninfo model=new Entity.Workplaninfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Wid"].ToString()!="")
				{
					model.Wid=int.Parse(ds.Tables[0].Rows[0]["Wid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Uid"].ToString()!="")
				{
					model.Uid=int.Parse(ds.Tables[0].Rows[0]["Uid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Wdate"].ToString()!="")
				{
					model.Wdate=DateTime.Parse(ds.Tables[0].Rows[0]["Wdate"].ToString());
				}
				model.Wtext=ds.Tables[0].Rows[0]["Wtext"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Wid,Uid,Wdate,Wtext ");
			strSql.Append(" FROM Workplaninfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Wid,Uid,Wdate,Wtext ");
			strSql.Append(" FROM Workplaninfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Workplaninfo";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        public List<Entity.Workplaninfo> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " * ";

            table = "workplaninfo ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "Wid";

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

            List<Entity.Workplaninfo> list = new List<Entity.Workplaninfo>();
            Entity.Workplaninfo model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.Workplaninfo();

                if (ds.Tables[0].Rows[i]["Wid"].ToString() != "")
                {
                    model.Wid = int.Parse(ds.Tables[0].Rows[i]["Wid"].ToString());
                }
                if (ds.Tables[0].Rows[i]["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(ds.Tables[0].Rows[i]["Uid"].ToString());
                }
                model.Wdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Wdate"].ToString());
                model.Wtext = ds.Tables[0].Rows[i]["Wtext"].ToString();

                list.Add(model);
            }

            return list;
        }


		#endregion  成员方法
	}
}

