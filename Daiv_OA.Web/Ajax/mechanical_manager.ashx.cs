using Daiv_OA.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Daiv_OA.Web.Ajax
{
    /// <summary>
    /// mechanical_manager 的摘要说明
    /// </summary>
    public class mechanical_manager : IHttpHandler, IRequiresSessionState
    {
        Daiv_OA.BLL.StudentBLL stubll = new BLL.StudentBLL();
        Daiv_OA.BLL.GradeBLL gradebll = new BLL.GradeBLL();
        /// <summary>
        /// 获取学生数据
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = HttpContext.Current.Request.QueryString["action"];  // .QueryString("action");
            ResponeDataEntity entity = new ResponeDataEntity();
            switch (action)
            {
                case "student": //加载频道管理菜单
                    entity = GetStudentData(context);
                    break;
                case "grade":
                    entity = GetGradeData(context);
                    break;

            }

            ResponseData(context, entity);
        }

        #region 获取学生数据
        /// <summary>
        /// 获取学生数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ResponeDataEntity GetStudentData(HttpContext context)
        {
            string user = Convert.ToString(context.Session["UserName"]);
            string pagesize = HttpContext.Current.Request.QueryString["pagesize"];
            string pageindex = HttpContext.Current.Request.QueryString["pageindex"];
            string mPhone = HttpContext.Current.Request.QueryString["mPhone"];

            ResponeDataEntity entity = new ResponeDataEntity();
            entity.Status = 1;
            try
            {
                IList<Hashtable> list = stubll.List(Convert.ToInt32(pageindex), Convert.ToInt32(pagesize), mPhone);
                entity.Data = list;
            }
            catch (Exception ex)
            {
                entity.Status = 0;
                entity.Msg = ex.Message;
            }
            return entity;
        }
        #endregion

        #region 获取班级数据
        /// <summary>
        /// 获取班级数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ResponeDataEntity GetGradeData(HttpContext context)
        {
            string user = Convert.ToString(context.Session["UserName"]);
            string pagesize = HttpContext.Current.Request.QueryString["pagesize"];
            string pageindex = HttpContext.Current.Request.QueryString["pageindex"];

            ResponeDataEntity entity = new ResponeDataEntity();
            entity.Status = 1;
            try
            {
                IList<Hashtable> list = gradebll.List(Convert.ToInt32(pageindex), Convert.ToInt32(pagesize));
                entity.Data = list;
            }
            catch (Exception ex)
            {
                entity.Status = 0;
                entity.Msg = ex.Message;
            }
            return entity;
        } 
        #endregion

        public void ResponseData(HttpContext context, object entity)
        {
            context.Response.ContentType = "application/json";

            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(entity));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}