using System;
using System.Data;
using System.Collections.Generic;
using Daiv_OA.Entity;
namespace Daiv_OA.BLL
{
    /// <summary>
    /// 业务逻辑类Task 的摘要说明。
    /// </summary>
    public class TaskBLL
    {
        private readonly Daiv_OA.DAL.TaskDAL dal = new Daiv_OA.DAL.TaskDAL();
        public TaskBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Tlid)
        {
            return dal.Exists(Tlid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Daiv_OA.Entity.TaskEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Daiv_OA.Entity.TaskEntity model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Tlid)
        {

            dal.Delete(Tlid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Daiv_OA.Entity.TaskEntity GetEntity(int Tlid)
        {

            return dal.GetEntity(Tlid);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Daiv_OA.Entity.TaskEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Daiv_OA.Entity.TaskEntity> modelList = new List<Daiv_OA.Entity.TaskEntity>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Daiv_OA.Entity.TaskEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Daiv_OA.Entity.TaskEntity();
					if(ds.Tables[0].Rows[n]["Tlid"].ToString()!="")
					{
						model.Tlid=int.Parse(ds.Tables[0].Rows[n]["Tlid"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Uid"].ToString()!="")
					{
						model.Uid=int.Parse(ds.Tables[0].Rows[n]["Uid"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Manager"].ToString()!="")
					{
						model.Manager=ds.Tables[0].Rows[n]["Manager"].ToString();
					}
					model.Tasktitle=ds.Tables[0].Rows[n]["Tasktitle"].ToString();
					model.Content=ds.Tables[0].Rows[n]["Content"].ToString();
					if(ds.Tables[0].Rows[n]["Nowtime"].ToString()!="")
					{
						model.Nowtime=DateTime.Parse(ds.Tables[0].Rows[n]["Nowtime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Plantime"].ToString()!="")
					{
						model.Plantime=DateTime.Parse(ds.Tables[0].Rows[n]["Plantime"].ToString());
					}
					model.Ttype=ds.Tables[0].Rows[n]["Ttype"].ToString();
                    if (ds.Tables[0].Rows[n]["Worktime"].ToString() != "")
                    {
                        model.Worktime = DateTime.Parse(ds.Tables[0].Rows[n]["Worktime"].ToString());
                    }
                    model.Workprogress = int.Parse(ds.Tables[0].Rows[n]["Workprogress"].ToString());
                    model.Workstate = ds.Tables[0].Rows[n]["Workstate"].ToString();

                    model.Sumtime = int.Parse(ds.Tables[0].Rows[n]["sumtime"].ToString());
                    model.Progresstime = int.Parse(ds.Tables[0].Rows[n]["progresstime"].ToString());
                    model.Classse = ds.Tables[0].Rows[n]["classse"].ToString();
                    model.Remark = ds.Tables[0].Rows[n]["remark"].ToString();
                    model.Newnote = ds.Tables[0].Rows[n]["newnote"].ToString();

                    model.Filepath = ds.Tables[0].Rows[n]["filepath"].ToString();
                    model.Question = ds.Tables[0].Rows[n]["question"].ToString();
                    
                    
                    modelList.Add(model);
				}
			}
			return modelList;
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        public List<Entity.TaskEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            return dal.getpage(pageSize, pageNum, out count, str);
        }
        /// <summary>
        /// 更新状态
        /// 1=新任务 2=工作中 5=提交：提前完成   6=提交：按时完成  7=提交：未完成
///    8=提交：重新申请时间     9=拒收
///3=完成并归档 （★）--发布者确认    4=验收任务未完成
        
        /// </summary>
        /// <param name="i">状态编号</param>
        /// <param name="Tlid"></param>
        public void Upworkprogress(int i,int Tlid)
        {
            dal.Updatewrokprogress(i,Tlid);
        }
        public void Updatebytitle(string title)
        {
            dal.Updatebytitle(title);
        }

        public  void UpworkprogressTs(string i, string n, string note, int Tlid)
        {
           dal.UpworkprogressTN(i,n,note,Tlid);
        }
        /// <summary>
        /// 计算两个时间差
        /// </summary>
        /// <param name="t1">开始时间</param>
        /// <param name="t2">结束时间</param>
        /// <returns></returns>
        public static int timespans(DateTime t1,DateTime t2)
        {
            TimeSpan a = new TimeSpan ( t1.Ticks);
            TimeSpan b =new TimeSpan ( t2.Ticks);
            TimeSpan c = t1.Subtract(t2).Duration();
            return (c.Days*24+c.Hours);
        }
        #endregion  成员方法
    }
}

