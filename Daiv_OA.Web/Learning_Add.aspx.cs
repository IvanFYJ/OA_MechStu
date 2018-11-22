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
    public partial class Learning_Add : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("learning-add");

        }
        //添加信息
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.LearningEntity model = new Entity.LearningEntity();
            
            model.Sauthor = UserName;
            model.Stitle = this.txtTitle.Text;
            model.Sdate = DateTime.Now;
            model.Spath = this.kindeditor.Value;
            model.Did = UserDepartmentId;
            int i = new Daiv_OA.BLL.LearningBLL().Add(model);
            if (i > 0)
            {
                Daiv_OA.BLL.UserBLL user = new Daiv_OA.BLL.UserBLL();
                DataTable dt=new DataTable ();
                string aa = "";
                if(UserPowerId<=3)
                 dt=user.GetList("").Tables[0];
                else
                    dt= user.GetList("Did=" + UserDepartmentId).Tables[0];
                for(int j=0;j<dt.Rows.Count;j++)
                {
                      aa +=dt.Rows[j]["Uid"].ToString()+",";
                }
                Daiv_OA.BLL.OA_SysMessageIn.ADDsysMessage(2, "," + aa, "[新资料]" + txtTitle.Text, Daiv_OA.Utils.Strings.Left(Daiv_OA.Utils.Strings.delhtml(kindeditor.Value.ToString()),53), "My_Learning_Show.aspx?id=" + i.ToString());
                string addtype = "添加学习资料";
                Addlog(addtype);
                aa = "";
            }
        }

        //操作日志添加信息
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
                Daiv_OA.Utils.QQRoHelp.SendClusterMessage("OA平台消息：" + UserName + "发表了新的学习资料《" + this.txtTitle.Text + "》");
                FinalMessage("添加成功", "Learning_List.aspx", 0);
            }
            else
                FinalMessage("添加失败", "Learning_List.aspx", 0);
        }
    
    }
}
