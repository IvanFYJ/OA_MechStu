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
            Entity.GradeEntity GradeEntity = new Entity.GradeEntity();
            GradeEntity.Gname = this.Gname.Text;
            try
            {
                GradeEntity.Gsnumber = int.Parse(this.Gsnumber.Text);
            }
            catch (Exception) { }
            if (this.Gdescription.Text != "")
            {
                GradeEntity.Gdescription = this.Gdescription.Text;
            }
            int i = new Daiv_OA.BLL.GradeBLL().Add(GradeEntity);
            if (i > 0)
            {
                logHelper.logInfo("添加班级成功！");
                FinalMessage("操作成功", "Grade_List.aspx", 0);
            }
            else
            {
                FinalMessage("相同的班级已经存在", "", 1);
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