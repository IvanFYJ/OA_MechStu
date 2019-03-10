using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class SchoolGrade_Add : Daiv_OA.UI.BasicPage
    {
        protected int schId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            User_Load("schgrade-list");

            //学校ID
            string shid = Request["shid"];
            if (!string.IsNullOrEmpty(shid))
            {
                try
                {
                    schId = Convert.ToInt32(shid);
                }
                catch (Exception)
                {
                }
            }

            if (!this.IsPostBack)
            {
                string sql = "";
                if(schId > 0)
                {
                    sql = " ID=" + schId;
                }
                Daiv_OA.BLL.SchoolBLL dp = new Daiv_OA.BLL.SchoolBLL();
                DataSet ds = dp.GetList(sql);
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    ListItem listItem = new ListItem();
                    listItem.Text = ds.Tables[0].Rows[j]["Name"].ToString();
                    listItem.Value = ds.Tables[0].Rows[j]["ID"].ToString();
                    this.ddlGid.Items.Add(listItem);
                }
                ds.Clear();
            }
        }


        //添加
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.SchoolGradeEntity SchoolGradeEntity = new Entity.SchoolGradeEntity();
            Entity.UserEntity parent = new Entity.UserEntity();
            Entity.ContactEntity contactEnitty = new Entity.ContactEntity();
            //年级实体相关信息保存
            SchoolGradeEntity.SchoolID = int.Parse(this.ddlGid.SelectedValue);
            SchoolGradeEntity.Name = this.Name.Text;
            SchoolGradeEntity.CreateDate = DateTime.Now;
            //保存数据
            try
            {
                new Daiv_OA.BLL.SchoolGradeBLL().Add(SchoolGradeEntity);
            }
            catch (Exception ex)
            {
                FinalMessage("操作失败！" + ex.Message, "SchoolGrade_List.aspx?shid="+schId, 1);
                return;
            }

            FinalMessage("操作成功", "SchoolGrade_List.aspx?shid=" + schId, 0);
        }
    }
}