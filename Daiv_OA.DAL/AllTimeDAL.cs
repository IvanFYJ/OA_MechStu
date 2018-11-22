using System;
using System.Collections.Generic;
using System.Text;
using Daiv_OA.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Daiv_OA.DAL
{
    public class AllTimeDAL
    {
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Entity.AllTimeEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " [OA_Time].tid, [OA_Time].retime,[OA_Time].nowtime,[OA_Time].timetype,[OA_Time].ipaddress,IsNUll([OA_Time].timeinfo,'') as timeinfo,[OA_User].uname ";


            table = "  [OA_Time] left join [OA_User] on [OA_Time].uid = [OA_User].uid ";

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

            List<Entity.AllTimeEntity> list = new List<Entity.AllTimeEntity>();
            Entity.AllTimeEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.AllTimeEntity();

                if (ds.Tables[0].Rows[i]["Tid"].ToString() != "")
                {
                    model.Tid = int.Parse(ds.Tables[0].Rows[i]["Tid"].ToString());
                }
                model.Ipaddress = ds.Tables[0].Rows[i]["Ipaddress"].ToString();
                model.Nowtime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Nowtime"].ToString());
                model.Retime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Retime"].ToString());
                model.Timeinfo = ds.Tables[0].Rows[i]["Timeinfo"].ToString();
                model.Timetype = ds.Tables[0].Rows[i]["Timetype"].ToString();
                model.Uname = ds.Tables[0].Rows[i]["Uname"].ToString();

                list.Add(model);
            }

            return list;
        }
    }
}
