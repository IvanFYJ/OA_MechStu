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

namespace Daiv_OA.Web
{
    public partial class Message_Add : Daiv_OA.UI.BasicPage
    {
        Daiv_OA.BLL.UserBLL user = new Daiv_OA.BLL.UserBLL();
        protected string wherestr2 = "";
        public int _uid = 0;
        public int mes = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("message-add");
            mes = Str2Int(q("mesid"));
            _uid = Str2Int(q("toid"));

            //if (UserPowerId == 2)
            //{//表示主管
            //    wherestr2 = " pid>1 and uid<>" + UserId;
            //}
            //else if (UserPowerId == 3)
            //{//表示部门主管
            //    wherestr2 = " uid<>" + UserId + " and did=" + UserDepartmentId;
            //}
            //else if (UserPowerId == 4)//表示员工
            //    wherestr2 = " uid<>" + UserId + " and did=" + UserDepartmentId;
            if (!this.Page.IsPostBack)
            {
                show();
                showdp();
            }
        }

       

      
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Daiv_OA.Entity.UserEntity userEntity = new Daiv_OA.Entity.UserEntity();
           
                //可以添加
                Daiv_OA.Entity.MessageEntity message = new Daiv_OA.Entity.MessageEntity();
                message.Content = this.kindeditor.Value;
                message.FromUid = UserId;
                message.Addtime = System.DateTime.Now;
                message.Mtitle = this.txtTitle.Text;
                if (mes != 0)
                {
                    message.ToUid = _uid; 
                }
                else
                {
                 if (DropDownList1.SelectedValue =="-1")
                   {
                     System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
                     page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script language='javascript'>alert('请选择收信人！');</script>");
                     return; 
                   }else
                     message.ToUid = Convert.ToInt32(DropDownList2.SelectedValue.ToString());
                }
            int i = new Daiv_OA.BLL.MessageBLL().Add(message);
                if (i > 0)
                {
                    Daiv_OA.BLL.OA_SysMessageIn.ADDsysMessage(0, "," + message.ToUid + ",", "新短信", Daiv_OA.Utils.Strings.Left(Daiv_OA.Utils.Strings.delhtml(txtTitle.Text.Trim()), 53), "Message_Show.aspx?id=" + i.ToString());
                    FinalMessage("短信发送成功", "Message_MySend.aspx", 0);
                }
                else
                {
                    FinalMessage("短信发送失败", "Message_MySend.aspx", 0);
                }
        }

        void drop()
        {
            Daiv_OA.BLL.DepartmentBLL dp = new Daiv_OA.BLL.DepartmentBLL();
                DropDownList1.DataSource = dp.GetList("").Tables[0];
                DropDownList1.DataTextField = "DName";
                DropDownList1.DataValueField = "Did";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(1, new ListItem("组织管理部", "0"));
                DropDownList1.Items.Insert(0, new ListItem("请选择部门", "-1"));
        }
        void show()
        {
            Daiv_OA.BLL.COMDLL com=new Daiv_OA.BLL.COMDLL ();
            DataTable table = com.COM_Select("OA_Message", "Mid", "", mes.ToString(), "", 4);
            if (table.Rows.Count != 0)
            {
                ren.Visible = false;
            }
            else
            {
                ren.Visible = true;
                drop();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "-1")
            {
                this.DropDownList2.DataSource = new Daiv_OA.BLL.UserBLL().GetList("Did=" + DropDownList1.SelectedValue.ToString());
                this.DropDownList2.DataTextField = "Uname";
                this.DropDownList2.DataValueField = "Uid";
                this.DropDownList2.DataBind();
            }
        }
        void showdp()
        {
            Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
            int uid = Convert.ToInt32(com.getsid("fid"));
            if (uid != -1)
            {
                int dpid = new Daiv_OA.BLL.UserBLL().GetEntity(uid).Did;
                DropDownList1.SelectedValue = dpid.ToString();
                DropDownList1.Enabled = false;
                this.DropDownList2.DataSource = new Daiv_OA.BLL.UserBLL().GetList("Did=" + DropDownList1.SelectedValue.ToString());
                this.DropDownList2.DataTextField = "Uname";
                this.DropDownList2.DataValueField = "Uid";
                this.DropDownList2.DataBind();
                DropDownList2.SelectedValue = uid.ToString();
                DropDownList2.Enabled = false;

            }
            else
            {
                DropDownList1.Enabled = true;
                DropDownList2.Enabled = true;
            }
        
        }

    }
}
