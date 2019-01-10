using Daiv_OA.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class Mechanical_Edit : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("mech-edit");
            if (!this.Page.IsPostBack)
            {
                Bind();
            }
        }


        //数据绑定
        void Bind()
        {
            int gid = Str2Int(q("id"), 0);
            Daiv_OA.Entity.MechanicalEntity model = new Daiv_OA.Entity.MechanicalEntity();
            model = new Daiv_OA.BLL.MechanicalBLL().GetEntity(gid);
            this.MechIMEI.Text = model.MechIMEI;
            this.MechName.Text = model.MechName;
            this.MechPhone.Text = model.MechPhone;

            string sql = "";
            Daiv_OA.BLL.GradeBLL dp = new Daiv_OA.BLL.GradeBLL();
            DataSet ds = dp.GetList(sql);
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                ListItem listItem = new ListItem();
                listItem.Text = ds.Tables[0].Rows[j]["Gname"].ToString();
                listItem.Value = ds.Tables[0].Rows[j]["Gid"].ToString();
                this.ddlGid.Items.Add(listItem);
            }
            this.ddlGid.SelectedValue = model.Gid.ToString();
            ds.Clear();
        }


        //更新
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.MechanicalEntity model = new Entity.MechanicalEntity();
            Daiv_OA.BLL.ContactBLL contactBll = new Daiv_OA.BLL.ContactBLL();
            Daiv_OA.BLL.MechanicalBLL mechanicalBll = new Daiv_OA.BLL.MechanicalBLL();
            model = mechanicalBll.GetEntity(Str2Int(q("id"), 0));
            model.ClassName = this.ddlGid.SelectedItem.Text;
            model.Gid = int.Parse(this.ddlGid.SelectedValue);
            model.MechIMEI = this.MechIMEI.Text;
            model.MechName = this.MechName.Text;
            model.MechPhone = this.MechPhone.Text;
            mechanicalBll.Update(model);
            logHelper.logInfo("修改班级成功！操作人：" + UserId);
            FinalMessage("操作成功", "Mechanical_List.aspx", 0);
        }
    }
}