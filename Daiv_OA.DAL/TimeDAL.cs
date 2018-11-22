using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;
using System.Collections.Generic;//请先添加引用
namespace Daiv_OA.DAL
{
	/// <summary>
	/// 数据访问类Time。
	/// </summary>
	public class TimeDAL
	{
		public TimeDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Tid", "[OA_Time]"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Tid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [OA_Time]");
			strSql.Append(" where Tid=@Tid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4)};
			parameters[0].Value = Tid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Entity.TimeEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [OA_Time](");
			strSql.Append("Uid,Retime,Nowtime,Timetype,Ipaddress,Timeinfo)");
			strSql.Append(" values (");
			strSql.Append("@Uid,@Retime,@Nowtime,@Timetype,@Ipaddress,@Timeinfo)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4),
					new SqlParameter("@Retime", SqlDbType.DateTime),
					new SqlParameter("@Nowtime", SqlDbType.DateTime),
					new SqlParameter("@Timetype", SqlDbType.VarChar,10),
					new SqlParameter("@Ipaddress", SqlDbType.VarChar,30),
					new SqlParameter("@Timeinfo", SqlDbType.VarChar,30)};
			parameters[0].Value = model.Uid;
			parameters[1].Value = model.Retime;
			parameters[2].Value = model.Nowtime;
			parameters[3].Value = model.Timetype;
			parameters[4].Value = model.Ipaddress;
			parameters[5].Value = model.Timeinfo;

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
		public void Update(Entity.TimeEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [OA_Time] set ");
			strSql.Append("Uid=@Uid,");
			strSql.Append("Retime=@Retime,");
			strSql.Append("Nowtime=@Nowtime,");
			strSql.Append("Timetype=@Timetype,");
			strSql.Append("Ipaddress=@Ipaddress,");
			strSql.Append("Timeinfo=@Timeinfo");
			strSql.Append(" where Tid=@Tid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@Uid", SqlDbType.Int,4),
					new SqlParameter("@Retime", SqlDbType.DateTime),
					new SqlParameter("@Nowtime", SqlDbType.DateTime),
					new SqlParameter("@Timetype", SqlDbType.VarChar,10),
					new SqlParameter("@Ipaddress", SqlDbType.VarChar,30),
					new SqlParameter("@Timeinfo", SqlDbType.VarChar,30)};
			parameters[0].Value = model.Tid;
			parameters[1].Value = model.Uid;
			parameters[2].Value = model.Retime;
			parameters[3].Value = model.Nowtime;
			parameters[4].Value = model.Timetype;
			parameters[5].Value = model.Ipaddress;
			parameters[6].Value = model.Timeinfo;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Tid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [OA_Time] ");
			strSql.Append(" where Tid=@Tid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4)};
			parameters[0].Value = Tid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.TimeEntity GetEntity(int Tid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Tid,Uid,Retime,Nowtime,Timetype,Ipaddress,Timeinfo from [OA_Time] ");
			strSql.Append(" where Tid=@Tid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4)};
			parameters[0].Value = Tid;

			Entity.TimeEntity model=new Entity.TimeEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Tid"].ToString()!="")
				{
					model.Tid=int.Parse(ds.Tables[0].Rows[0]["Tid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Uid"].ToString()!="")
				{
					model.Uid=int.Parse(ds.Tables[0].Rows[0]["Uid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Retime"].ToString()!="")
				{
					model.Retime=DateTime.Parse(ds.Tables[0].Rows[0]["Retime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Nowtime"].ToString()!="")
				{
					model.Nowtime=DateTime.Parse(ds.Tables[0].Rows[0]["Nowtime"].ToString());
				}
				model.Timetype=ds.Tables[0].Rows[0]["Timetype"].ToString();
				model.Ipaddress=ds.Tables[0].Rows[0]["Ipaddress"].ToString();
				model.Timeinfo=ds.Tables[0].Rows[0]["Timeinfo"].ToString();
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
			strSql.Append("select Tid,Uid,Retime,Nowtime,Timetype,Ipaddress,Timeinfo ");
			strSql.Append(" FROM [OA_Time] ");
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
			strSql.Append(" Tid,Uid,Retime,Nowtime,Timetype,Ipaddress,Timeinfo ");
			strSql.Append(" FROM [OA_Time] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Entity.TimeEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " * ";

            table = "[OA_Time] ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "Tid";

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

            List<Entity.TimeEntity> list = new List<Entity.TimeEntity>();
            Entity.TimeEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.TimeEntity();

                if (ds.Tables[0].Rows[i]["Tid"].ToString() != "")
                {
                    model.Tid = int.Parse(ds.Tables[0].Rows[i]["Tid"].ToString());
                }
                if (ds.Tables[0].Rows[i]["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(ds.Tables[0].Rows[i]["Uid"].ToString());
                }
                model.Nowtime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Nowtime"].ToString());
                model.Retime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Retime"].ToString());
                model.Ipaddress = ds.Tables[0].Rows[i]["Ipaddress"].ToString();
                model.Timeinfo = ds.Tables[0].Rows[i]["Timeinfo"].ToString();
                model.Timetype = ds.Tables[0].Rows[i]["Timetype"].ToString();

                list.Add(model);
            }

            return list;
        }

        /// <summary>
        /// 是否已进行上下班登记
        /// </summary>
        public bool Isfirst(int uid,string type,string nowtime)
        {
            string sql = "select * from [OA_Time] where uid = " + uid + " and timetype = '" + type + "' and Nowtime > '" + nowtime + "'";
            SqlDataReader dr = DbHelperSQL.ExecuteReader(sql);
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
		#endregion  成员方法
	}
}

