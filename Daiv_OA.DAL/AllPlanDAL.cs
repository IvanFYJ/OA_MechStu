using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Daiv_OA.DBUtility;

namespace Daiv_OA.DAL
{
    public class AllPlanDAL
    {
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// select [OA_Task].tlid,[OA_User].uname,[OA_Task].[OA_Task]title,[OA_Task].content,
        ///[OA_Task].nowtime,[OA_Task].plantime from [OA_Task] left join [OA_User] on
        ///[OA_Task].uid = [OA_User].uid
        public List<Entity.AllPlanEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " [OA_Plan].pwid,[OA_User].uname,[OA_Plan].pwtitle,[OA_Plan].pwdate,[OA_Plan].pwpath,[OA_Plan].locked,[OA_Plan].manager ";


            table = " [OA_Plan] left join [OA_User] on [OA_Plan].uid = [OA_User].uid ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "pwid";

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

            List<Entity.AllPlanEntity> list = new List<Entity.AllPlanEntity>();
            Entity.AllPlanEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.AllPlanEntity();

                if (ds.Tables[0].Rows[i]["Pwid"].ToString() != "")
                {
                    model.Pwid = int.Parse(ds.Tables[0].Rows[i]["Pwid"].ToString());
                }
                model.Uname = ds.Tables[0].Rows[i]["Uname"].ToString();
                model.Pwtitle = ds.Tables[0].Rows[i]["Pwtitle"].ToString();
                model.Pwdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["Pwdate"].ToString());
                model.Locked = ds.Tables[0].Rows[i]["Locked"].ToString();
                model.Pwpath = ds.Tables[0].Rows[i]["Pwpath"].ToString();
                model.Manager = ds.Tables[0].Rows[i]["Manager"].ToString();
                list.Add(model);
            }
            return list;
        }
    }
}
