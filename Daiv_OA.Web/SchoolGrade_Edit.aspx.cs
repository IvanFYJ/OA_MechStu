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
    public partial class SchoolGrade_Edit : Daiv_OA.UI.BasicPage
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

            if (!this.Page.IsPostBack)
            {
                Bind();
            }
        }


        //数据绑定
        void Bind()
        {
            int gid = Str2Int(q("id"), 0);
            Daiv_OA.Entity.SchoolGradeEntity model = new Daiv_OA.Entity.SchoolGradeEntity();
            model = new Daiv_OA.BLL.SchoolGradeBLL().GetEntity(gid);
            this.Name.Text = model.Name;


            string sql = "";
            if (schId > 0)
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
            this.ddlGid.SelectedValue = model.SchoolID.ToString();
            ds.Clear();
        }



        //更新
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.SchoolGradeEntity model = new Entity.SchoolGradeEntity();
            Daiv_OA.BLL.ContactBLL contactBll = new Daiv_OA.BLL.ContactBLL();
            Daiv_OA.BLL.SchoolGradeBLL SchoolGradeBll = new Daiv_OA.BLL.SchoolGradeBLL();
            model = SchoolGradeBll.GetEntity(Str2Int(q("id"), 0));
            model.SchoolID = int.Parse(this.ddlGid.SelectedValue);
            model.Name = this.Name.Text;
            Entity.SchoolGradeEntity sgEntity = SchoolGradeBll.GetEntityByNameAndScId(model.Name, model.SchoolID);
            if(sgEntity != null && sgEntity.ID != model.ID)
            {
                FinalMessage("已经存在：此学校的班级："+model.Name, "SchoolGrade_Edit.aspx?id="+model.ID+ "&shid="+schId, 0);
                return;
            }
            SchoolGradeBll.Update(model);
            logHelper.logInfo("修改设备成功！操作人：" + UserId);
            FinalMessage("操作成功", "SchoolGrade_List.aspx?shid="+schId, 0);
        }
    }
}