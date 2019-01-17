using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class School_Add : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("sch-list");
        }


        //添加
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.SchoolEntity SchoolEntity = new Entity.SchoolEntity();
            Entity.UserEntity parent = new Entity.UserEntity();
            Entity.ContactEntity contactEnitty = new Entity.ContactEntity();
            //学校实体相关信息保存
            SchoolEntity.Address = this.Address.Text;
            SchoolEntity.Name = this.Name.Text;
            SchoolEntity.CreateDate = DateTime.Now;
            //保存数据
            try
            {
                new Daiv_OA.BLL.SchoolBLL().Add(SchoolEntity);
            }
            catch (Exception ex)
            {
                FinalMessage("操作失败！" + ex.Message, "School_List.aspx", 1);
                return;
            }

            FinalMessage("操作成功", "School_List.aspx", 0);
        }
    }
}