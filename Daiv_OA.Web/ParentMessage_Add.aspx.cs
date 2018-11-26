using Daiv_OA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class ParentMessage_Add : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("pm-add");
        }

        //添加
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.ParentMessageEntity parentMessageEntity = new Entity.ParentMessageEntity();
            parentMessageEntity.Mtitle = this.Mtitle.Text;
            parentMessageEntity.Content = this.Content.Text;
            parentMessageEntity.ToUid = UserId;
            parentMessageEntity.FromUid = UserId;
            parentMessageEntity.Addtime = DateTime.Now;
            //获取用户实体
            Entity.UserEntity userEntity = new Daiv_OA.BLL.UserBLL().GetEntity(UserId);
            //获取学生信息
            Entity.StudentEntity stuEntity = new Daiv_OA.BLL.StudentBLL().GetEntityByNumber(userEntity.Uname);
            if(stuEntity != null)
            {
                parentMessageEntity.Touser = stuEntity.Sname;
            }
            int i = new Daiv_OA.BLL.ParentMessageBLL().Add(parentMessageEntity);
            if (i > 0)
            {
                logHelper.logInfo("添加留言成功！");
                FinalMessage("操作成功", "ParentMessage_List.aspx", 0);
            }
        }
        //重置
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            this.Mtitle.Text = "";
            this.Content.Text = "";
        }
    }
}