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
    public partial class Placard_Add : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("placard-add");

        }
        //添加信息
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.PlacardEntity model = new Entity.PlacardEntity();
            model.Pauthor = UserName;
            model.Ptitle = this.txtTitle.Text;
            model.Pdate = DateTime.Now;
            model.Ptext = this.kindeditor.Value;
            int i = new Daiv_OA.BLL.PlacardBLL().Add(model);
            if (i > 0)
            {
                Daiv_OA.BLL.UserBLL user = new Daiv_OA.BLL.UserBLL();
                DataTable dt=user.GetList("").Tables[0];
                string aa = "";
                for (int j = 0; j <dt.Rows.Count ; j++)
                {
                    aa += dt.Rows[j]["Uid"].ToString()+",";
                }
                Daiv_OA.BLL.OA_SysMessageIn.ADDsysMessage(1, "," + aa, "[新通知]" + txtTitle.Text, Daiv_OA.Utils.Strings.Left(Daiv_OA.Utils.Strings.delhtml(kindeditor.Value.ToString()), 53), "My_Placard_Show.aspx?id=" + i.ToString());
                aa = "";
                string addtype = "添加通知公告";
                Addlog(addtype);
            }
        }

        //往操作日志添加信息
        void Addlog(string type)
        {
            Entity.OperatelogEntity model = new Entity.OperatelogEntity();
            model.Uid = UserId;
            model.Eupdatetitle = this.txtTitle.Text;
            model.Eupdatetype = type;
            model.Eupadatetime = DateTime.Now;
            int i = new Daiv_OA.BLL.OperatelogBLL().Add(model);
            if (i > 0)
            {
                Daiv_OA.Utils.QQRoHelp.SendClusterMessage("OA平台消息：" + UserName + "发表了新的通知公告《" + this.txtTitle.Text + "》");
                FinalMessage("添加成功", "Placard_List.aspx", 0);
            }
            else
                FinalMessage("添加失败", "Placard_List.aspx", 0);
        }
    }
}
