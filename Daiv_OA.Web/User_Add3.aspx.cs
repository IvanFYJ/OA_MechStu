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
    public partial class User_Add3 : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("user-add");
            if (!this.IsPostBack)
            {
                string sql = "";
                Daiv_OA.BLL.DepartmentBLL dp = new Daiv_OA.BLL.DepartmentBLL();
                DataSet ds = dp.GetList(sql);
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    ListItem listItem = new ListItem();
                    listItem.Text = ds.Tables[0].Rows[j]["DName"].ToString();
                    listItem.Value = ds.Tables[0].Rows[j]["Did"].ToString();
                   // this.ddlDid.Items.Add(listItem);
                }
                ds.Clear();
            }
        }
        //添加
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            int PId = 3;
            Entity.UserEntity userEntity = new Entity.UserEntity();
            Entity.PowerEntity powerEntity = new BLL.PowerBLL().GetEntity(PId);
            userEntity.Pid = PId;
            userEntity.Uname = this.txtUname.Text;
          //  userEntity.Position = this.txtPosition.Text;
            userEntity.Setting = powerEntity.Setting;
           // userEntity.Did = Str2Int(this.ddlDid.SelectedValue, 0);
            userEntity.Upwd = Daiv_OA.Utils.MD5.Lower32(this.txtPwd.Text.Trim());
            if (this.txtIpaddress.Text != "")
            {
                userEntity.Uipaddress = this.txtIpaddress.Text;
            }
            int i = new Daiv_OA.BLL.UserBLL().Add(userEntity);
            if (i > 0)
            {
                Addadminlog("添加用户");
            }
            else
            {
                FinalMessage("相同的用户已经存在", "", 1);
            }
        }

        //重置
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            this.txtUname.Text = "";
            this.txtPwd.Text = "";
            this.txtPwdagain.Text = "";
            this.txtUname.Focus();
        }

        //添加管理员操作记录
        void Addadminlog(string type)
        {
            Entity.AdminlogEntity model = new Entity.AdminlogEntity();
            model.Uid = UserId;
            model.Updatetime = DateTime.Now;
            model.Updatetitle = this.txtUname.Text;
            model.Updatetype = type;
            int i = new Daiv_OA.BLL.AdminlogBLL().Add(model);
            if (i > 0)
                FinalMessage("用户添加成功", "User_List.aspx", 0);
            else
                FinalMessage("用户添加失败", "User_List.aspx", 0);
        }
    }
}
