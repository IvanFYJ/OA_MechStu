using Daiv_OA.DBUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Daiv_OA.DAL
{
    public class ContactDAL
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger("ContactDAL");

        public ContactDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Cid", "[OA_Contact]");
        }

        /// <summary>
        /// 是否存在该记录(根据学生ID来添加)
        /// </summary>
        public bool Exists(int Sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_Contact]");
            strSql.Append(" where Sid=@Sid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Sid", SqlDbType.Int,4)};
            parameters[0].Value = Sid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Cphone)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM [OA_Contact]");
            strSql.Append(" where Cphone=@Cphone");
            SqlParameter[] parameters = {
                    new SqlParameter("@Cphone", SqlDbType.VarChar,50)};
            parameters[0].Value = Cphone;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.ContactEntity model)
        {
            if (model.Cid > 0 && Exists(model.Sid))//已经存在该用户
                return 0;
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            model.IsDeleted = 0;
            model.CreatDate = DateTime.Now;

            if (model.Sid > 0)
            {
                strSql1.Append("Sid,");
                strSql2.Append("" + model.Sid + ",");
            }
            if (model.Cphone != null)
            {
                strSql1.Append("Cphone,");
                strSql2.Append("'" + model.Cphone + "',");
            }
            if (model.Cphone2 != null)
            {
                strSql1.Append("Cphone2,");
                strSql2.Append("'" + model.Cphone2 + "',");
            }
            if (model.Cphone3 != null)
            {
                strSql1.Append("Cphone3,");
                strSql2.Append("'" + model.Cphone3 + "',");
            }
            if (model.Cphone4 != null) 
            {
                strSql1.Append("Cphone4,");
                strSql2.Append("'" + model.Cphone4 + "',"); 
            }
            if (model.CPhoneName != null)
            {
                strSql1.Append("CPhoneName,");
                strSql2.Append("'" + model.CPhoneName + "',");
            }
            if (model.CreatDate != null)
            {
                strSql1.Append("CreatDate,");
                strSql2.Append("'" + model.CreatDate + "',");
            }
            if (model.Cblacklistflag >= 0)
            {
                strSql1.Append("Cblacklistflag,");
                strSql2.Append("" + model.Cblacklistflag + ",");
            }
            if (model.IsDeleted >= 0)
            {
                strSql1.Append("IsDeleted,");
                strSql2.Append("0,");
            }
            strSql.Append("insert into [OA_Contact](");
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
        public void Update(Daiv_OA.Entity.ContactEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OA_Contact] set ");
            strSql.Append("Cphone='" + model.Cphone + "',");
            strSql.Append("Cphone2='" + model.Cphone2 + "',"); 
            strSql.Append("Cphone3='" + model.Cphone3 + "',"); 
            strSql.Append("CPhoneName='" + model.CPhoneName + "',");
            strSql.Append("CreatDate='" + model.CreatDate + "',");
            strSql.Append("Cphone4='" + model.Cphone4 + "'");//注意： 最后不需要加逗号
            strSql.Append(" where Cid=" + model.Cid + " ");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Cid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM [OA_Contact] ");
            strSql.Append(" where Cid=@Cid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Cid", SqlDbType.Int,4)};
            parameters[0].Value = Cid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteBySid(int Sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update [OA_Contact] ");
            strSql.Append(" set IsDeleted=@IsDeleted ");
            strSql.Append(" where Sid=@Sid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@IsDeleted", SqlDbType.Int,4),
                    new SqlParameter("@Sid", SqlDbType.Int,4)
            };
            parameters[0].Value = 1;
            parameters[1].Value = Sid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.ContactEntity GetEntity(int Cid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" Cid,Sid ,Cphone ,Cphone2 ,Cphone3 ,Cphone4 ,Cblacklistflag,CPhoneName ,CreatDate,IsDeleted  ");
            strSql.Append(" FROM [OA_Contact] ");
            strSql.Append(" where Cid=" + Cid + " ");
            Daiv_OA.Entity.ContactEntity model = new Daiv_OA.Entity.ContactEntity();
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
        public Daiv_OA.Entity.ContactEntity GetEntityBySid(int Sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" Cid,Sid ,Cphone ,Cphone2 ,Cphone3 ,Cphone4 ,Cblacklistflag ,CPhoneName,CreatDate ,IsDeleted  ");
            strSql.Append(" FROM [OA_Contact] ");
            strSql.Append(" where IsDeleted = 0 and Sid=" + Sid + " ");
            Daiv_OA.Entity.ContactEntity model = new Daiv_OA.Entity.ContactEntity();
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
        /// 得到多个联系电话
        /// </summary>
        public List<Daiv_OA.Entity.ContactEntity> GetEntitysBySid(int Sid)
        {
            return GetEntitysBySid(new int[] { Sid });
        }

        /// <summary>
        /// 得到多个联系电话
        /// </summary>
        public List<Daiv_OA.Entity.ContactEntity> GetEntitysBySid(int[] Sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" Cid,Sid ,Cphone ,Cphone2 ,Cphone3 ,Cphone4 ,Cblacklistflag ,CPhoneName,CreatDate ,IsDeleted  ");
            strSql.Append(" FROM [OA_Contact] ");
            strSql.Append(" where IsDeleted = 0 and Sid in(" +string.Join(",", Sid) + ") ");
            Daiv_OA.Entity.ContactEntity model = new Daiv_OA.Entity.ContactEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<Daiv_OA.Entity.ContactEntity> list = new List<Entity.ContactEntity>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    list.Add(ConvertModel(ds.Tables[0], i));
                }
                return list;
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
        public Daiv_OA.Entity.ContactEntity ConvertModel(DataTable dt, int rowindex)
        {
            Daiv_OA.Entity.ContactEntity model = new Daiv_OA.Entity.ContactEntity();
            try
            {
                if (dt.Rows[rowindex]["Cid"].ToString() != "")
                {
                    model.Cid = int.Parse(dt.Rows[rowindex]["Cid"].ToString());
                }
                if (dt.Rows[rowindex]["Sid"].ToString() != "")
                {
                    model.Sid = int.Parse(dt.Rows[rowindex]["Sid"].ToString());
                }
                if (dt.Rows[rowindex]["Cblacklistflag"].ToString() != "")
                {
                    model.Cblacklistflag = int.Parse(dt.Rows[rowindex]["Cblacklistflag"].ToString());
                }
                model.Cphone = dt.Rows[rowindex]["Cphone"].ToString();
                model.Cphone2 = dt.Rows[rowindex]["Cphone2"].ToString();
                model.Cphone3 = dt.Rows[rowindex]["Cphone3"].ToString();
                model.Cphone4 = dt.Rows[rowindex]["Cphone4"].ToString(); 
                model.CPhoneName = dt.Rows[rowindex]["CPhoneName"].ToString();
                model.CreatDate =Convert.ToDateTime( dt.Rows[rowindex]["CreatDate"]);
                if (dt.Rows[rowindex]["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(dt.Rows[rowindex]["IsDeleted"].ToString());
                }
            }
            catch (Exception ex)
            {
                log.Info("转换成用户对象失败！原因：" + ex.Message);
                return new Entity.ContactEntity();
            }
            return model;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Cid,Sid ,Cphone ,Cphone2 ,Cphone3 ,Cphone4 ,Cblacklistflag ,CPhoneName ,CreatDate ,IsDeleted   ");
            strSql.Append(" FROM [OA_Contact] ");
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
            strSql.Append(" Cid,Sid ,Cphone ,Cphone2 ,Cphone3 ,Cphone4 ,Cblacklistflag ,CPhoneName,CreatDate ,IsDeleted  ");
            strSql.Append(" FROM [OA_Contact] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }



        /// <summary>
        /// 根据学校编号和时间获取亲情号
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public IList<Hashtable> GetPhoneListBySchoolAndDate(string sserie,string datetime, string pageindex,string pagesize)
        {
            StringBuilder sqlPage = new StringBuilder();
            if(!string.IsNullOrEmpty(pageindex) && !string.IsNullOrEmpty(pagesize))
            {
                try
                {
                    int pIndex = Convert.ToInt32(pageindex);
                    int pSize = Convert.ToInt32(pagesize);
                    if(pIndex > 0 && pSize > 0)
                    {
                        sqlPage.Append(string.Format(" and  req >{0} and req <={1}", pSize * (pIndex - 1), pSize * pIndex));
                    }
                }
                catch (Exception ex)
                {

                }
            }
            string sql = @"
declare @total int ;
declare @minDate datetime;
if object_id('tempdb..#temp') is not null begin drop table #temp end
select distinct  oc.Cphone,oc.CreatDate,ROW_NUMBER() over(order by oc.Cphone) as req
into #temp
from Daiv_OA..OA_Contact oc 
join Daiv_OA..OA_Student os on oc.Sid = os.Sid
join Daiv_OA..OA_Grade og on os.Gid = og.Gid
join Daiv_OA..OA_SchoolGrade osg on osg.ID = og.GgradeID
join Daiv_OA..OA_School osc on osc.ID = osg.SchoolID
where osc.SchoolSerie = @ss  and oc.IsDeleted = 0 and ISNULL(oc.Cphone,'') != ''

select @total= COUNT(1) from #temp
select @minDate=MAX(CreatDate) from #temp
select *,@total as Total ,@minDate as MaxDate from #temp where 1=1 "+sqlPage.ToString();
            SqlParameter[] parameters = {
                    new SqlParameter("@ss", SqlDbType.NVarChar,128),
                    new SqlParameter("@dt", SqlDbType.DateTime)
            };
            parameters[0].Value = sserie;
            parameters[1].Value =datetime;
            //分页查询
            return DbHelperSQL.ExecuteReaderHashtable(sql, parameters);
        }


        /// <summary>
        /// 根据学校序列号和电话号码获取数据
        /// </summary>
        /// <returns></returns>
        public Hashtable GetPhoneListBySchoolAndPhonenum(string sserie, string phonenum)
        {
            string sql = @"select distinct  oc.Cphone,osc.SchoolSerie
from Daiv_OA..OA_Contact oc 
join Daiv_OA..OA_Student os on oc.Sid = os.Sid
join Daiv_OA..OA_Grade og on os.Gid = og.Gid
join Daiv_OA..OA_SchoolGrade osg on osg.ID = og.GgradeID
join Daiv_OA..OA_School osc on osc.ID = osg.SchoolID
where oc.Cphone = @phone and osc.SchoolSerie =@ss  and oc.IsDeleted = 0 and ISNULL(oc.Cphone,'') != ''
";
            SqlParameter[] parameters = {
                    new SqlParameter("@ss", SqlDbType.NVarChar,128),
                    new SqlParameter("@phone", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = sserie;
            parameters[1].Value = phonenum;
            //查询结果
            IList<Hashtable> resultList = DbHelperSQL.ExecuteReaderHashtable(sql, parameters);
            if (resultList != null && resultList.Count > 0)
                return resultList[0];
            return null;
        }

        /// <summary>
        /// 获取亲情号最大的修改时间
        /// </summary>
        /// <returns></returns>
        public Hashtable GetMaxCreatTime()
        {
            string sql = @"
select MAX(CreatDate) as CreatDate from OA_Contact oc where oc.IsDeleted = 0  and ISNULL(oc.Cphone,'') != ''
";
            SqlParameter[] parameters = {
            };
            //分页查询
            return DbHelperSQL.ExecuteReaderHashtable(sql, parameters)[0];
        }

        


        /// <summary>
        /// 多表连接查询
        /// </summary>
        /// <param name="kls_Cid"></param>
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
        /// <param name="kls_Cid"></param>
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
