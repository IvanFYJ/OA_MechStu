using Daiv_OA.Entity;
using Daiv_OA.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
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
            string action = HttpContext.Current.Request["action"];  // .QueryString("action");
            ResponeDataEntity entity = new ResponeDataEntity();
            JObject ob = StreamToString(HttpContext.Current.Request.InputStream);
            action = ob["action"].ToString();

            #region 验证token
            //验证token
            if ("login" != action && "checklogin" != action && !HasToken(context))
            {
                entity.Msg = "您未授权，请联系相关负责人!";
                ResponseData(context, entity);
                return;
            } 
            #endregion

            #region 业务流转
            //业务流转
            switch (action)
            {
                case "student": //加载频道管理菜单
                    entity = GetStudentData(context, ob);
                    break;
                case "grade":
                    entity = GetGradeData(context, ob);
                    break;
                case "pwd":
                    entity = SetPwd(context, ob);
                    break;
                case "setcontact":
                    entity = SetContact(context, ob);
                    break;
                case "login":
                    entity = LoginIn(context, ob);
                    break;
                case "getcontact":
                    entity = getContactBySnum(context, ob);
                    break;
                case "addstudent":
                    entity = AddStudent(context, ob);
                    break;
                case "checklogin":
                    entity = CheckLogin(context, ob);
                    break;
            } 
            #endregion

            ResponseData(context, entity);
        }

        #region 判断请求头是否有token
        /// <summary>
        /// 判断请求头是否有token
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool HasToken(HttpContext context)
        {
            string token = "3fe686907939d07097f6c87f08025422";
            string retoken = context.Request.Headers["api-token"];
            return token == retoken;
        } 
        #endregion

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private ResponeDataEntity AddStudent(HttpContext context, JObject ob)
        {
            //Entity.StudentEntity studentEntity = new Entity.StudentEntity();
            //Entity.UserEntity parent = new Entity.UserEntity();
            //Entity.ContactEntity contactEnitty = new Entity.ContactEntity();
            ////请求参数
            //string gname = "";
            //string 
            ////学生实体相关信息保存
            //studentEntity.Gname = this.ddlGid.SelectedItem.Text;
            //studentEntity.Gid = int.Parse(this.ddlGid.SelectedValue);
            //studentEntity.Snumber = this.Snumber.Text;
            //studentEntity.Sname = this.Sname.Text;
            //studentEntity.Sbirthday = Convert.ToDateTime(this.Sbirthday.Text);
            ////家长实体相关信息保存
            //parent.Uname = studentEntity.Snumber;
            //string pwd = studentEntity.Sbirthday.ToString("yy") + studentEntity.Sbirthday.ToString("MM") + studentEntity.Sbirthday.ToString("dd");
            //parent.Upwd = Daiv_OA.Utils.MD5.Lower32(pwd);
            //parent.Pid = 4;
            //parent.Did = 0;
            //parent.Position = "家长";
            //parent.Mphone = "";
            //Entity.PowerEntity powerEntity = new BLL.PowerBLL().GetEntity(parent.Pid);
            //parent.Setting = powerEntity.Setting;
            ////联系电话实体相关信息保存
            //contactEnitty.Cphone = this.Cphone.Text;
            //contactEnitty.Cphone2 = this.Cphone2.Text;
            //contactEnitty.Cphone3 = this.Cphone3.Text;
            //contactEnitty.Cphone4 = this.Cphone4.Text;
            ////当前操作人对象
            //Entity.UserEntity opera = new Daiv_OA.BLL.UserBLL().GetEntity(UserId);
            //保存数据
            try
            {
                int results = 0;// new Daiv_OA.BLL.StudentBLL().Add(studentEntity, parent, contactEnitty, opera);
                if(results > 0)
                {
                    return new ResponeDataEntity() { Status = 1, Msg = "添加成功！" };
                }
                else
                {
                    return new ResponeDataEntity() { Status = 0, Msg = "添加失败，请重新添加!" };
                }
            }
            catch (Exception ex)
            {
                return new ResponeDataEntity() { Status = 0, Msg = ex.Message };
            }
        }



        #region 获取学生数据
        /// <summary>
        /// 获取学生数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ResponeDataEntity GetStudentData(HttpContext context, JObject ob)
        {
            string user = Convert.ToString(context.Session["UserName"]);
            string pagesize = ob["pageSize"].ToString();
            string pageindex = ob["pageIndex"].ToString();
            string mPhone = ob["mPhone"].ToString();

            ResponeDataEntity entity = new ResponeDataEntity();
            entity.Status = 1;
            try
            {
                logHelper.logInfo(" GetStudentData params：pagesize：" + pagesize+ " pageindex:"+pageindex+" mPhone:"+mPhone);
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
        public ResponeDataEntity GetGradeData(HttpContext context, JObject ob)
        {
            string user = Convert.ToString(context.Session["UserName"]);
            string pagesize = ob["pageSize"].ToString();
            string pageindex = ob["pageIndex"].ToString();

            ResponeDataEntity entity = new ResponeDataEntity();
            entity.Status = 1;
            try
            {
                logHelper.logInfo(" GetGradeData params：pagesize：" + pagesize + " pageindex:" + pageindex );
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
        public ResponeDataEntity SetPwd(HttpContext context, JObject ob)
        {
            string user = Convert.ToString(context.Session["UserName"]);
            string userID = ob["userID"].ToString();
            string oldPwd = ob["oldPwd"].ToString();
            string newPwd = ob["newPwd"].ToString();

            logHelper.logInfo(" SetPwd params：userID：" + userID + " oldPwd:" + oldPwd+ " newPwd:"+ newPwd);
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
        private ResponeDataEntity SetContact(HttpContext context, JObject ob)
        {
            string snumber = ob["sNumber"].ToString();
            string cPhone = ob["cPhone"].ToString();
            string cPhone2 = ob["cPhone2"].ToString();
            string cPhone3 = ob["cPhone3"].ToString();
            string cPhone4 = ob["cPhone4"].ToString();
            ResponeDataEntity resultEntity = new ResponeDataEntity();

            logHelper.logInfo(" SetContact params：sNumber：" + snumber + " cPhone:" + cPhone + " cPhone2:" + cPhone2+ "cPhone3:" + cPhone3+ " cPhone4:" + cPhone4);
            //获取学生对象
            Daiv_OA.Entity.StudentEntity stuEntity =  stubll.GetEntityByNumber(snumber);
            if(stuEntity == null)
                return new ResponeDataEntity() { Status = 0, Msg = snumber + "学生学号无效!" };
            Daiv_OA.Entity.ContactEntity ctEntity = ctbll.GetEntityBySid(stuEntity.Sid);

            //电话号码验证
            if (!string.IsNullOrEmpty(cPhone) && !Validator.IsMobileNum(cPhone)) { resultEntity.Msg = cPhone+"电话号码无效！"; return resultEntity; };
            if (!string.IsNullOrEmpty(cPhone2) && !Validator.IsMobileNum(cPhone2)) { resultEntity.Msg = cPhone2 + "电话号码无效！"; return resultEntity; };
            if (!string.IsNullOrEmpty(cPhone3) && !Validator.IsMobileNum(cPhone3)) { resultEntity.Msg = cPhone3 + "电话号码无效！"; return resultEntity; };
            if (!string.IsNullOrEmpty(cPhone4) && !Validator.IsMobileNum(cPhone4)) { resultEntity.Msg = cPhone4 + "电话号码无效！"; return resultEntity; };
            //保存数据
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
        private ResponeDataEntity LoginIn(HttpContext context, JObject ob)
        {
            string uname = ob["uname"].ToString();
            string pwd = ob["pwd"].ToString();
            int iExpires = 0;

            logHelper.logInfo(" LoginIn params：uname：" + uname + " pwd:" + pwd );
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

        /// <summary>
        /// 检查登录情况(用于自动登录)
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ob"></param>
        /// <returns></returns>
        private ResponeDataEntity CheckLogin(HttpContext context, JObject ob)
        {
            if (Daiv_OA.Utils.Cookie.GetValue("oa_user") != null)
            {
                if (Daiv_OA.Utils.Cookie.GetValue("oa_user", "ip") == context.Request.UserHostAddress)
                {
                    Daiv_OA.Entity.UserEntity model = new Daiv_OA.Entity.UserEntity();
                    model = new Daiv_OA.BLL.UserBLL().GetEntity(Convert.ToInt32(Daiv_OA.Utils.Cookie.GetValue("oa_user", "id")));
                    return new ResponeDataEntity() { Status = 1, Msg = "登录成功！", Data = model };
                }
            }
            return new ResponeDataEntity() { Status = 0, Msg = "未成功！", Data = null };
        }
        
        /// <summary>
        /// 根据学生序号获取联系电话
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private ResponeDataEntity getContactBySnum(HttpContext context, JObject ob)
        {
            string snumber = ob["sNumber"].ToString();
            logHelper.logInfo(" getContactBySnum params中文：sNumber：" + snumber);
            //获取学生对象
            Daiv_OA.Entity.StudentEntity stuEntity = stubll.GetEntityByNumber(snumber);
            if (stuEntity == null)
                return new ResponeDataEntity() { Status = 0, Msg = snumber + "学生学号无效!" };
            Daiv_OA.Entity.ContactEntity ctEntity = ctbll.GetEntityBySid(stuEntity.Sid);
            return new ResponeDataEntity() { Status = 1, Data = ctEntity };
        }

        public void ResponseData(HttpContext context, object entity)
        {
            context.Response.ContentType = "application/json";
           //context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(entity));
        }


        /// <summary>
        /// 字符流转换成Jsno对象
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static JObject StreamToString(Stream s)
        {
            //创建流的对象
            var sr = new StreamReader(s);
            //读取request的流：Json字符
            var stream = sr.ReadToEnd().ToString();
            //讲读取到的字符用字典存储
            Dictionary<string, object> str = (Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(stream);

            JObject jo = new JObject();

            foreach (var item in str)
            {
                //把字典转换成Json对象
                jo.Add(item.Key, item.Value.ToString());

            }
            return jo;
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