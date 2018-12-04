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
        Daiv_OA.BLL.UserBLL userbll = new BLL.UserBLL();
        Daiv_OA.BLL.ContactBLL ctbll = new BLL.ContactBLL();
        /// <summary>
        /// 获取学生数据
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = HttpContext.Current.Request.Form["action"];  // .QueryString("action");
            ResponeDataEntity entity = new ResponeDataEntity();
            switch (action)
            {
                case "student": //加载频道管理菜单
                    entity = GetStudentData(context);
                    break;
                case "grade":
                    entity = GetGradeData(context);
                    break;
                case "pwd":
                    entity = SetPwd(context);
                    break;
                case "setcontact":
                    entity = SetContact(context);
                    break;
                case "login":
                    entity = LoginIn(context);
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
            string pagesize = HttpContext.Current.Request.Form["pagesize"];
            string pageindex = HttpContext.Current.Request.Form["pageindex"];
            string mPhone = HttpContext.Current.Request.Form["mPhone"];

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
            string pagesize = HttpContext.Current.Request.Form["pagesize"];
            string pageindex = HttpContext.Current.Request.Form["pageindex"];

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

        #region 更新密码
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ResponeDataEntity SetPwd(HttpContext context)
        {
            string user = Convert.ToString(context.Session["UserName"]);
            string userID = HttpContext.Current.Request.Form["userID"];
            string oldPwd = HttpContext.Current.Request.Form["oldPwd"];
            string newPwd = HttpContext.Current.Request.Form["newPwd"];
            if (string.IsNullOrEmpty(userID))
                return new ResponeDataEntity() { Status = 0, Msg = "请传入用户ID!" };
            //获取用户对象
            Daiv_OA.Entity.UserEntity entity = userbll.GetEntity(Convert.ToInt32(userID));
            if (entity != null)
            {
                if (entity.Upwd == Daiv_OA.Utils.MD5.Lower32(oldPwd))
                {
                    //更新密码
                    entity.Upwd = Daiv_OA.Utils.MD5.Lower32(newPwd);
                    userbll.Update(entity);
                    return new ResponeDataEntity() { Status = 1, Msg = "更新密码成功!" };
                }
                else
                {
                    return new ResponeDataEntity() { Status = 0, Msg = "旧密码不准确，请重新输入！" };
                }
            }
            else
            {
                return new ResponeDataEntity() { Status = 0, Msg = userID + "用户ID无效!" };
            }
        }
        #endregion


        /// <summary>
        /// 修改联系电话
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private ResponeDataEntity SetContact(HttpContext context)
        {
            string snumber = HttpContext.Current.Request.Form["sNumber"];
            string cPhone = HttpContext.Current.Request.Form["cPhone"];
            string cPhone2 = HttpContext.Current.Request.Form["cPhone2"];
            string cPhone3 = HttpContext.Current.Request.Form["cPhone3"];
            string cPhone4 = HttpContext.Current.Request.Form["cPhone4"];
            //获取学生对象
            Daiv_OA.Entity.StudentEntity stuEntity =  stubll.GetEntityByNumber(snumber);
            if(stuEntity == null)
                return new ResponeDataEntity() { Status = 0, Msg = snumber + "学生学号无效!" };
            Daiv_OA.Entity.ContactEntity ctEntity = ctbll.GetEntityBySid(stuEntity.Sid);
            if (ctEntity == null)
            {
                ctEntity = new ContactEntity() { Sid = stuEntity.Sid };
                ctEntity.Cphone = cPhone;
                ctEntity.Cphone2 = cPhone2;
                ctEntity.Cphone3 = cPhone3;
                ctEntity.Cphone4 = cPhone4;
                ctbll.Add(ctEntity);
                return new ResponeDataEntity() { Status = 1, Msg = snumber + "修改成功!" };
            }
            ctEntity.Cphone = cPhone;
            ctEntity.Cphone2 = cPhone2;
            ctEntity.Cphone3 = cPhone3;
            ctEntity.Cphone4 = cPhone4;
            ctbll.Update(ctEntity);
            return new ResponeDataEntity() { Status = 1, Msg = snumber + "修改成功!" };
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private ResponeDataEntity LoginIn(HttpContext context)
        {
            string uname = HttpContext.Current.Request.Form["uname"];
            string pwd = HttpContext.Current.Request.Form["pwd"];
            int iExpires = 0;

            string uid = new Daiv_OA.BLL.UserBLL().Existslongin(uname, Daiv_OA.Utils.MD5.Lower32(pwd));
            if(uid != "")
            {
                Daiv_OA.Entity.UserEntity model = new Daiv_OA.Entity.UserEntity();
                model = new Daiv_OA.BLL.UserBLL().GetEntity(int.Parse(uid));
                new BLL.UserBLL().SetUserCookies(model, HttpContext.Current.Request.UserHostAddress, iExpires);
                HttpContext.Current.Session["UserName"] = uname;
                return new ResponeDataEntity() { Status = 1, Msg = "登录成功！",Data = model};
            }
            return new ResponeDataEntity() { Status = 0, Msg = "登录失败！" };
        }

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