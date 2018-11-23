using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DTcms.Web.tools;
namespace Daiv_OA.Web
{
    public partial class Login : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            if (!this.Page.IsPostBack)
            {
                Autologin();
            }
        }

        //判断是否自动登录
        void Autologin()
        {
            if (Daiv_OA.Utils.Cookie.GetValue("oa_user") != null)
            {
                if (Daiv_OA.Utils.Cookie.GetValue("oa_user", "ip") == Request.UserHostAddress)
                {
                    Daiv_OA.Entity.UserEntity model = new Daiv_OA.Entity.UserEntity();
                    model = new Daiv_OA.BLL.UserBLL().GetEntity(Convert.ToInt32(Daiv_OA.Utils.Cookie.GetValue("oa_user", "id")));
                    int pid = model.Pid;
                    new BLL.UserBLL().UpdateTime(model.Uid);
                    switch (pid)
                    {
                        case 1:
                            Session["UserName"] = model.Uname;
                            Response.Redirect("Index.aspx");
                            break;
                        case 2:
                            Session["UserName"] = model.Uname;
                            Response.Redirect("Index.aspx");
                            break;
                        case 3:
                            Session["UserName"] = model.Uname;
                            Response.Redirect("Index.aspx");
                            break;
                        case 4:
                            Session["UserName"] = model.Uname;
                            Response.Redirect("Index.aspx");
                            break;
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            // 记录其IP地址，下次登录时验证，IP为空则记录，IP不为空则验证
            string uname = this.txtUserName.Text.Trim();
            string upwd = this.txtUserPwd.Text.Trim();
            string code = txtCode.Text.Trim();

            if (uname.Equals("") || upwd.Equals(""))
            {
                lblTip.Visible = true;
                lblTip.Text = "请输入用户名或密码";
                return;
            }
            if (code.Equals(""))
            {
                lblTip.Visible = true;
                lblTip.Text = "请输入验证码";
                return;
            }
            if (Session[verify_code.SESSION_CODE] == null)
            {
                lblTip.Visible = true;
                lblTip.Text = "系统找不到验证码";
                return;
            }
            if (code.ToLower() != Session[verify_code.SESSION_CODE].ToString().ToLower())
            {
                lblTip.Visible = true;
                lblTip.Text = "验证码输入不正确";
                return;        }


            string uid = new Daiv_OA.BLL.UserBLL().Existslongin(uname, Daiv_OA.Utils.MD5.Lower32(upwd));
            if (uid != "")
            {
                Daiv_OA.Entity.UserEntity model = new Daiv_OA.Entity.UserEntity();
                model = new Daiv_OA.BLL.UserBLL().GetEntity(int.Parse(uid));
                if (model.Uipaddress != "")
                {
                    if (model.Uipaddress != Page.Request.UserHostAddress)
                    {
                        Response.Write("<script>alert('非法IP，请在本机登陆！');</script>");
                        Response.End();
                    }
                }
                int iExpires = 0;
                //设置Cookies
                System.Collections.Specialized.NameValueCollection myCol = new System.Collections.Specialized.NameValueCollection();
                myCol.Add("id", uid.ToString());
                myCol.Add("name", uname);
                myCol.Add("ip", Request.UserHostAddress);
                new BLL.UserBLL().UpdateTime(model.Uid);
                int pid = model.Pid;
                myCol.Add("Powerid", pid.ToString());
                Daiv_OA.Utils.Cookie.SetObj("oa_user", 60 * 60 * 15 * iExpires, myCol, "", "/");

                switch (pid)
                {
                        
                
                    case 1:
                        Session["UserName"] = uname;
                        Response.Redirect("Index.aspx");//管理员
                        break;
                    case 2:
                        Session["UserName"] = uname;
                        Response.Redirect("Index.aspx");//管理组织层
                        break;
                    case 3:
                        Session["UserName"] = uname;
                        Response.Redirect("Index.aspx");//网站编辑
                        break;
                    case 4:
                        Session["UserName"] = uname;
                        Response.Redirect("Index.aspx");//美工和程序员
                        break;
                }
            }
            else
            {
                this.txtUserName.Text = "";
                this.txtUserPwd.Text = "";
                System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('请正确填写用户名和密码！');</script>");
            }
        }
        //FORM验证
        public static void SetLoginCookie(string roles)
        {
            //建立身份验证票对象
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "admin", DateTime.Now, DateTime.Now.AddMinutes(10), false, roles);
            //加密序列化验证票为字符串
            string hashTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket);
            HttpContext.Current.Response.Cookies.Add(userCookie);
        }
    }
}