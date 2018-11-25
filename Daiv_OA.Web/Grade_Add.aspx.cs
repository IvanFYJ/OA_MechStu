using Daiv_OA.Utils;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class Grade_Add : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("grade-add");
        }


        //添加
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.GradeEntity gradeEntity = new Entity.GradeEntity();
            gradeEntity.Gname = this.Gname.Text;
            gradeEntity.GgradeName = this.GgradeName.Text;
            gradeEntity.Mphone = this.Mphone.Text;
            try
            {
                gradeEntity.Gsnumber = int.Parse(this.Gsnumber.Text);
            }
            catch (Exception) { }
            if (this.Gdescription.Text != "")
            {
                gradeEntity.Gdescription = this.Gdescription.Text;
            }
            gradeEntity.MechID = UserId;
            int i = new Daiv_OA.BLL.GradeBLL().Add(gradeEntity);
            if (i > 0)
            {
                logHelper.logInfo("添加班级成功！");
                FinalMessage("操作成功", "Grade_List.aspx", 0);
            }
            else if(i == 0)
            {
                FinalMessage("相同的班级已经存在", "", 1);
            }else if(i == -1)
            {
                FinalMessage("相同的年级已经存在", "", 1);
            }
        }
        //重置
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            this.Gname.Text = "";
            this.Gsnumber.Text = "";
            this.Gdescription.Text = "";
            this.Gname.Focus();
        }
    }
}