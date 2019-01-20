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
    public partial class Mechanical_List : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            User_Load("mech-list");
            if (!this.Page.IsPostBack)
            {
                this.user_repeater.DataSource = pds();
                this.user_repeater.DataBind();
            }
        }

        //删除数据
        protected void lbDel_Click(object sender, CommandEventArgs e)
        {
            User_Load("mech-list");
            string oname = Getoname();
            Daiv_OA.BLL.MechanicalBLL MechanicalBll = new Daiv_OA.BLL.MechanicalBLL();
            Daiv_OA.BLL.UserBLL userBll = new BLL.UserBLL();
            int sid = Convert.ToInt32(e.CommandArgument);
            Entity.MechanicalEntity MechanicalEntity = MechanicalBll.GetEntity(sid);
            MechanicalBll.Delete(sid);
            logHelper.logInfo("删除设备成功！操作人：" + oname);
            string stuStr = Newtonsoft.Json.JsonConvert.SerializeObject(MechanicalEntity);
            logHelper.logInfo("删除设备：" + stuStr);
            Adminlogadd(oname);
            Bind();
        }


        //数据绑定
        void Bind()
        {
            string sql = string.Format(@"select * from OA_Mechanical where IsDeleted = 0", UserId);
            this.user_repeater.DataSource = new Daiv_OA.BLL.GradeBLL().Getall(sql);
            this.user_repeater.DataBind();
        }


        void Adminlogadd(string name)
        {
            Entity.AdminlogEntity model = new Entity.AdminlogEntity();
            model.Uid = UserId;
            model.Updatetitle = name;
            model.Updatetime = DateTime.Now;
            model.Updatetype = "删除设备";
            int i = new Daiv_OA.BLL.AdminlogBLL().Add(model);
            if (i > 0)
                FinalMessage("设备删除成功", "Mechanical_List.aspx", 0);
            else
                FinalMessage("设备删除失败", "Mechanical_List.aspx", 0);
        }


        //通过参数获取被更改的用户名
        string Getoname()
        {
            Entity.UserEntity model = new Entity.UserEntity();
            model = new Daiv_OA.BLL.UserBLL().GetEntity(UserId);
            return model.Uname;
        }


        private PagedDataSource pds()
        {
            string sql = string.Format(@"
select om.*,g.Gname as 'GClassName',schg.Name as 'GradeName',sch.Name as 'SchoolName',schg.SchoolID
from OA_Mechanical om
JOIN Daiv_OA..OA_Grade(NOLOCK) g ON g.Gid = om.Gid
left join OA_SchoolGrade schg on g.GgradeID = schg.ID
left join OA_School sch on sch.ID = schg.SchoolID
where om.IsDeleted = 0
", UserId);
            DataSet ds = new Daiv_OA.BLL.GradeBLL().Getall(sql);
            //this.user_repeater.DataBind();
            //this.user_repeater.DataSource = new Daiv_OA.BLL.UserBLL().Getall(sql);
            //this.user_repeater.DataBind();

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = ds.Tables[0].DefaultView;
            pds.AllowPaging = true;//允许分页
            pds.PageSize = 8;//单页显示项数
            pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);
            return pds;
        }

        protected void user_repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                DropDownList ddlp = (DropDownList)e.Item.FindControl("ddlp");

                HyperLink lpfirst = (HyperLink)e.Item.FindControl("hlfir");
                HyperLink lpprev = (HyperLink)e.Item.FindControl("hlp");
                HyperLink lpnext = (HyperLink)e.Item.FindControl("hln");
                HyperLink lplast = (HyperLink)e.Item.FindControl("hlla");

                pds().CurrentPageIndex = ddlp.SelectedIndex;

                int n = Convert.ToInt32(pds().PageCount);//n为分页数
                int i = Convert.ToInt32(pds().CurrentPageIndex);//i为当前页

                Label lblpc = (Label)e.Item.FindControl("lblpc");
                lblpc.Text = n.ToString();
                Label lblp = (Label)e.Item.FindControl("lblp");
                lblp.Text = Convert.ToString(pds().CurrentPageIndex + 1);

                if (!IsPostBack)
                {
                    for (int j = 0; j < n; j++)
                    {
                        ddlp.Items.Add(Convert.ToString(j + 1));
                    }
                }

                if (i <= 0)
                {
                    lpfirst.Enabled = false;
                    lpprev.Enabled = false;
                    lplast.Enabled = true;
                    lpnext.Enabled = true;
                }
                else
                {
                    lpprev.NavigateUrl = "?page=" + (i - 1);
                }
                if (i >= n - 1)
                {
                    lpfirst.Enabled = true;
                    lplast.Enabled = false;
                    lpnext.Enabled = false;
                    lpprev.Enabled = true;
                }
                else
                {
                    lpnext.NavigateUrl = "?page=" + (i + 1);
                }

                lpfirst.NavigateUrl = "?page=0";//向本页传递参数page
                lplast.NavigateUrl = "?page=" + (n - 1);

                ddlp.SelectedIndex = Convert.ToInt32(pds().CurrentPageIndex);//更新下拉列表框中的当前选中页序号
            }

        }

        protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
        {//脚模板中的下拉列表框更改时激发
            string pg = Convert.ToString((Convert.ToInt32(((DropDownList)sender).SelectedValue) - 1));//获取列表框当前选中项
            Response.Redirect("Mechanical_List.aspx?page=" + pg);//页面转向
        }
    }
}