using System;
using System.Collections.Generic;
using System.Text;
using Daiv_OA.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Daiv_OA.DAL
{
    public class AllCallinfoDAL
    {
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Entity.AllCallinfoEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " [OA_Callinfo].*,[OA_User].uname ";


            table = "  [OA_Callinfo] left join [OA_User] on [OA_Callinfo].uid = [OA_User].uid ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "Id";

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

            List<Entity.AllCallinfoEntity> list = new List<Entity.AllCallinfoEntity>();
            Entity.AllCallinfoEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.AllCallinfoEntity();

                if (ds.Tables[0].Rows[i]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                }
                model.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                model.Addtime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Addtime"].ToString());
                model.Unit = ds.Tables[0].Rows[i]["Unit"].ToString();
                model.Uname = ds.Tables[0].Rows[i]["Uname"].ToString();
                model.Userinfo = ds.Tables[0].Rows[i]["Userinfo"].ToString();
                list.Add(model);
            }

            return list;
        }
    }
}
