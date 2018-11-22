using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;
using System.Collections.Generic;//请先添加引用
namespace Daiv_OA.DAL
{
    /// <summary>
    /// 数据访问类Task。
    /// </summary>
    public class TaskDAL
    {
        public TaskDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Tlid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [OA_Task]");
            strSql.Append(" where Tlid=@Tlid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Tlid", SqlDbType.Int,4)};
            parameters[0].Value = Tlid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.TaskEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            strSql1.Append("Uid,");
            strSql2.Append("" + model.Uid + ",");
            if (model.Manager != null)
            {
                strSql1.Append("Manager,");
                strSql2.Append("'" + model.Manager + "',");
            }
            if (model.Tasktitle != null)
            {
                strSql1.Append("Tasktitle,");
                strSql2.Append("'" + model.Tasktitle + "',");
            }
            if (model.Content != null)
            {
                strSql1.Append("Content,");
                strSql2.Append("'" + model.Content + "',");
            }
            if (model.Nowtime != null)
            {
                strSql1.Append("Nowtime,");
                strSql2.Append("'" + model.Nowtime + "',");
            }
            if (model.Plantime != null)
            {
                strSql1.Append("Plantime,");
                strSql2.Append("'" + model.Plantime + "',");
            }
            if (model.Ttype != null)
            {
                strSql1.Append("Ttype,");
                strSql2.Append("'" + model.Ttype + "',");
            }
            if (model.Worktime != null)
            {
                strSql1.Append("Worktime,");
                strSql2.Append("'" + model.Worktime + "',");
            }
            if (model.Workprogress != 0)
            {
                strSql1.Append("Workprogress,");
                strSql2.Append("'" + model.Workprogress + "',");
            }
            if (model.Sumtime != 0)
            {
                strSql1.Append("sumtime,");
                strSql2.Append("'"+model.Sumtime+"',");
            }
            if (model.Progresstime != 0)
            {
                strSql1.Append("progresstime,");
                strSql2.Append("'" + model.Progresstime + "',");
            }

            if (model.Classse != null)
            {
                strSql1.Append("classse,");
                strSql2.Append("'" + model.Classse + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.Newnote != null)
            {
                strSql1.Append("newnote,");
                strSql2.Append("'" + model.Newnote + "',");
            }
            if (model.Filepath != null)
            {
                strSql1.Append("filepath,");
                strSql2.Append("'" + model.Filepath + "',");
            }
            if (model.Question != null)
            {
                strSql1.Append("question,");
                strSql2.Append("'" + model.Question + "',");
            }
            strSql.Append("insert into [OA_Task](");
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
        public void Update(Daiv_OA.Entity.TaskEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Task] set ");
            if (model.Uid !=0)
            {
                strSql.Append("Uid=" + model.Uid + ",");
            }
            if (model.Manager != null)
            {
                strSql.Append("Manager='" + model.Manager + "',");
            }
            if (model.Tasktitle != null)
            {
                strSql.Append("Tasktitle='" + model.Tasktitle + "',");
            }
            if (model.Content != null)
            {
                strSql.Append("Content='" + model.Content + "',");
            }
            if (model.Nowtime != null)
            {
                strSql.Append("Nowtime='" + model.Nowtime + "',");
            }
            if (model.Plantime != null)
            {
                strSql.Append("Plantime='" + model.Plantime + "',");
            }
            if (model.Ttype != null)
            {
                strSql.Append("Ttype='" + model.Ttype + "',");
            }
            if (model.Worktime != null)
            {
                strSql.Append("Worktime='" + model.Worktime + "',");
            }
            if (model.Workprogress != 0)
            {
                strSql.Append("Workprogress='" + model.Workprogress + "',");
            }
            if (model.Sumtime != 0)
            {
                strSql.Append("sumtime='" + model.Sumtime + "',");
            }
            if (model.Progresstime != 0)
            {
                strSql.Append("progresstime='" + model.Progresstime + "',");
            }
            if (model.Classse != null)
            {
                strSql.Append("classse='" + model.Classse + "',");
            }
            if (model.Remark != null)
            {
                strSql.Append("remark='" + model.Remark + "',");
            }
            if (model.Question != null)
            {
                strSql.Append("question='" + model.Question + "',");
            }
            strSql.Append("newnote='" + model.Newnote + "'");

            strSql.Append(" where Tlid=" + model.Tlid);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void UpworkprogressTN(string i, string n, string note, int Tlid)
        {
          string sql = "update [OA_Task] set Workprogress=" + "'" + i + "'" + ",Worktime=" + "'" + n + "'" + ",remark=" + "'"+note + "'" + " where Tlid = '" + Tlid + "'";
          DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Tlid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [OA_Task] ");
            strSql.Append(" where Tlid=@Tlid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Tlid", SqlDbType.Int,4)};
            parameters[0].Value = Tlid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.TaskEntity GetEntity(int Tlid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" *,(case when (Workprogress= 1) then '新的任务' when (Workprogress= 2) then '正在办理' when (Workprogress= 3) then '已经完成' when (Workprogress= 4) then '验收未完成' when (Workprogress= 5) then '提前完成' when (Workprogress= 6) then '按时完成' when (Workprogress= 7) then '未完成' when (Workprogress= 8) then '重新申请时间' when (Workprogress= 9) then '拒收' end) as Workstate ");
            strSql.Append(" from [OA_Task] ");
            strSql.Append(" where Tlid=" + Tlid + " ");
            Daiv_OA.Entity.TaskEntity model = new Daiv_OA.Entity.TaskEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Tlid"].ToString() != "")
                {
                    model.Tlid = int.Parse(ds.Tables[0].Rows[0]["Tlid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(ds.Tables[0].Rows[0]["Uid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Manager"].ToString() != "")
                {
                    model.Manager = ds.Tables[0].Rows[0]["Manager"].ToString();
                }
                model.Tasktitle = ds.Tables[0].Rows[0]["Tasktitle"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["Nowtime"].ToString() != "")
                {
                    model.Nowtime = DateTime.Parse(ds.Tables[0].Rows[0]["Nowtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Plantime"].ToString() != "")
                {
                    model.Plantime = DateTime.Parse(ds.Tables[0].Rows[0]["Plantime"].ToString());
                }
                model.Ttype = ds.Tables[0].Rows[0]["Ttype"].ToString();
                if (ds.Tables[0].Rows[0]["Worktime"].ToString() != "")
                {
                    model.Worktime = DateTime.Parse(ds.Tables[0].Rows[0]["Worktime"].ToString());
                }
                model.Workprogress = int.Parse(ds.Tables[0].Rows[0]["Workprogress"].ToString());
                model.Workstate = ds.Tables[0].Rows[0]["Workstate"].ToString();
                if (ds.Tables[0].Rows[0]["sumtime"].ToString() != "")
                {
                    model.Sumtime = int.Parse(ds.Tables[0].Rows[0]["sumtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["progresstime"].ToString()!="")
                {
                    model.Progresstime = int.Parse(ds.Tables[0].Rows[0]["progresstime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["classse"].ToString() != "")
                {
                    model.Classse = ds.Tables[0].Rows[0]["classse"].ToString();
                }
                if (ds.Tables[0].Rows[0]["remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["newnote"].ToString() != "")
                {
                    model.Newnote = ds.Tables[0].Rows[0]["newnote"].ToString();
                }
                if (ds.Tables[0].Rows[0]["filepath"].ToString() != "")
                {
                    model.Filepath = ds.Tables[0].Rows[0]["filepath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["question"].ToString() != "")
                {
                    model.Question = ds.Tables[0].Rows[0]["question"].ToString();
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
            strSql.Append("Select *,(case when (Workprogress= 1) then '新的任务' when (Workprogress= 2) then '正在办理' when (Workprogress= 3) then '已经完成' when (Workprogress= 4) then '验收未完成' when (Workprogress= 5) then '提前完成' when (Workprogress= 6) then '按时完成' when (Workprogress= 7) then '未完成' when (Workprogress= 8) then '重新申请时间' when (Workprogress= 9) then '拒收' end) as Workstate ");
            strSql.Append(" FROM [OA_Task] ");
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
            strSql.Append(" *,(case when (Workprogress= 1) then '新的任务' when (Workprogress= 2) then '正在办理' when (Workprogress= 3) then '已经完成' when (Workprogress= 4) then '验收未完成' when (Workprogress= 5) then '提前完成' when (Workprogress= 6) then '按时完成' when (Workprogress= 7) then '未完成' when (Workprogress= 8) then '重新申请时间' when (Workprogress= 9) then '拒收' end) as Workstate ");
            strSql.Append(" FROM [OA_Task] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<Entity.TaskEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            string select, table, where, order;

            select = " *,(case when (Workprogress= 1) then '新的任务' when (Workprogress= 2) then '正在办理' when (Workprogress= 3) then '已经完成' when (Workprogress= 4) then '验收未完成' when (Workprogress= 5) then '提前完成' when (Workprogress= 6) then '按时完成' when (Workprogress= 7) then '未完成' when (Workprogress= 8) then '重新申请时间' when (Workprogress= 9) then '拒收' end) as Workstate ";

            table = "[OA_Task] ";

            StringBuilder sb = new StringBuilder();
            sb.Append(" ( 1 = 1 ) " + str);

            where = sb.ToString();

            order = "Tlid";

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

            List<Entity.TaskEntity> list = new List<Entity.TaskEntity>();
            Entity.TaskEntity model;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                model = new Entity.TaskEntity();

                if (ds.Tables[0].Rows[i]["Tlid"].ToString() != "")
                {
                    model.Tlid = int.Parse(ds.Tables[0].Rows[i]["Tlid"].ToString());
                }
                model.Nowtime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Nowtime"].ToString());
                model.Manager = ds.Tables[0].Rows[i]["Manager"].ToString();
                model.Plantime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Plantime"].ToString());
                model.Tasktitle = ds.Tables[0].Rows[i]["Tasktitle"].ToString();
                model.Uid = Convert.ToInt32(ds.Tables[0].Rows[i]["Uid"].ToString());
                model.Worktime = Convert.ToDateTime(ds.Tables[0].Rows[i]["Worktime"].ToString());
                model.Workprogress = int.Parse(ds.Tables[0].Rows[i]["Workprogress"].ToString());
                model.Workstate = ds.Tables[0].Rows[i]["Workstate"].ToString();
                if (ds.Tables[0].Rows[i]["sumtime"].ToString() == "")
                    model.Sumtime = 0;
                  else
                    model.Sumtime = int.Parse(ds.Tables[0].Rows[i]["sumtime"].ToString());
                if (ds.Tables[0].Rows[i]["progresstime"].ToString() == "")
                    model.Progresstime = 0;
                else
                model.Progresstime = int.Parse(ds.Tables[0].Rows[i]["progresstime"].ToString());
                model.Classse = ds.Tables[0].Rows[i]["classse"].ToString(); 
                model.Remark = ds.Tables[0].Rows[i]["remark"].ToString();
                model.Newnote = ds.Tables[0].Rows[i]["newnote"].ToString();
                model.Filepath = ds.Tables[0].Rows[0]["filepath"].ToString();
                model.Question = ds.Tables[0].Rows[0]["Question"].ToString();

                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Updatebytitle(string title)
        {
           
           
            string sql = "update [OA_Task] set Ttype = '锁定' where Tasktitle = '" + title + "'";
            DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="i">状态号</param>
        /// <param name="Tlid">编号</param>
        public void Updatewrokprogress(int i,int Tlid)
        {
            string sql = "update [OA_Task] set Workprogress = '" + i + "' where Tlid="+"'"+Tlid+"'";
            DbHelperSQL.ExecuteSql(sql);
        }

        #endregion  成员方法
    }
}

