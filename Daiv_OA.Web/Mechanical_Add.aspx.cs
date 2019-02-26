using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class Mechanical_Add : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            User_Load("mech-add");
            if (!this.IsPostBack)
            {
                //string sql = "";
                //Daiv_OA.BLL.GradeBLL dp = new Daiv_OA.BLL.GradeBLL();
                //DataSet ds = dp.GetList(sql);
                //for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                //{
                //    ListItem listItem = new ListItem();
                //    listItem.Text = ds.Tables[0].Rows[j]["Gname"].ToString();
                //    listItem.Value = ds.Tables[0].Rows[j]["Gid"].ToString();
                //    this.ddlGid.Items.Add(listItem);
                //}
                //ds.Clear();
            }
        }

        //添加
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.MechanicalEntity MechanicalEntity = new Entity.MechanicalEntity();
            Entity.UserEntity parent = new Entity.UserEntity();
            Entity.ContactEntity contactEnitty = new Entity.ContactEntity();
            if (Request["schClassgcid"] == null || string.IsNullOrEmpty(Request["schClassgcid"].ToString()))
            {
                FinalMessage("班级无效!", "Mechanical_Add.aspx", 0);
                return;
            }
            //学生实体相关信息保存
            MechanicalEntity.ClassName = "";
            MechanicalEntity.Gid = int.Parse(Request["schClassgcid"]);
            MechanicalEntity.MechIMEI = this.MechIMEI.Text;
            MechanicalEntity.MechName = this.MechName.Text;
            MechanicalEntity.MechPhone = this.MechPhone.Text;
            //保存数据
            try
            {
                new Daiv_OA.BLL.MechanicalBLL().Add(MechanicalEntity);
            }
            catch (Exception ex)
            {
                FinalMessage("操作失败！" + ex.Message, "Mechanical_Add.aspx", 1);
                return;
            }

            FinalMessage("操作成功", "Mechanical_List.aspx", 0);
        }
    }
}