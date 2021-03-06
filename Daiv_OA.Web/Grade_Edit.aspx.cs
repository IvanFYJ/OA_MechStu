﻿using Daiv_OA.Utils;
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class Grade_Edit : Daiv_OA.UI.BasicPage
    {
        protected int gradeId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            User_Load("grade-edit");
            // 年级ID
            string gid = Request["gid"];
            if (!string.IsNullOrEmpty(gid))
            {
                try
                {
                    gradeId = Convert.ToInt32(gid);
                }
                catch (Exception)
                {
                }
            }
            if (!this.Page.IsPostBack)
            {
                Bind();
                //this.Gname.ReadOnly = true;
                //this.GgradeName.ReadOnly = true;
            }
        }

        //数据绑定
        void Bind()
        {
            int gid = Str2Int(q("id"), 0);
            Daiv_OA.Entity.GradeEntity model = new Daiv_OA.Entity.GradeEntity();
            model = new Daiv_OA.BLL.GradeBLL().GetEntity(gid);
            this.Gname.Text = model.Gname;
            this.Gsnumber.Text = model.Gsnumber.ToString();
            this.Gdescription.Text = model.Gdescription;
            //this.GgradeName.Text = model.GgradeName;
            this.Mphone.Text = model.Mphone;


            //设置年级ID
            SchGradeId = model.GgradeID;
            //设置学校ID
            Entity.SchoolGradeEntity scEntity = new BLL.SchoolGradeBLL().GetEntity(SchGradeId);
            if(scEntity != null)
            {
                SchID = scEntity.SchoolID;
            }
        }


        //更新
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Entity.GradeEntity model = new Entity.GradeEntity();
            model = new Daiv_OA.BLL.GradeBLL().GetEntity(Str2Int(q("id"), 0));
            model.Gdescription = this.Gdescription.Text;
            model.Mphone = this.Mphone.Text;
            model.GgradeName = "";
            model.Gname = this.Gname.Text;
            try
            {
                model.GgradeID = Convert.ToInt32(Request["schGradeGid"]);
                model.Gsnumber = Convert.ToInt32(this.Gsnumber.Text);
            }
            catch (Exception)
            {
                logHelper.logInfo("班级人数转换失败！操作人：" + UserId);
            }
            new Daiv_OA.BLL.GradeBLL().Update(model);
            logHelper.logInfo("修改班级成功！操作人："+UserId);
            FinalMessage("操作成功", "Grade_List.aspx?gid="+gradeId, 0);
        }

    }
}