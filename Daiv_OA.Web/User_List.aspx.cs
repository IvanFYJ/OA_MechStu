using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Daiv_OA.Web
{
    public partial class User_List : Daiv_OA.UI.BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("user-show");
            if (!this.Page.IsPostBack)
            {
                this.user_repeater.DataSource = pds();
                this.user_repeater.DataBind();
                //Bind();
            }
        }
        //数据绑定
        void Bind()
        {
            string sql = "select [OA_User].uid,[OA_User].uname,[OA_User].upwd,[OA_User].PID,Position,IsNull((select DName from [OA_Department] where [OA_Department].Did=[OA_User].did),'管理部') as Dname,[OA_Power].pname FROM [OA_User] left join [OA_Power] on [OA_User].pid = [OA_Power].pid where [OA_User].uid <> 1 ";
            this.user_repeater.DataSource = new Daiv_OA.BLL.UserBLL().Getall(sql);
            this.user_repeater.DataBind();
        }

        //删除数据
        protected void lbDel_Click(object sender, CommandEventArgs e)
        {
            User_Load("user-del");
            string oname = Getoname(Convert.ToInt32(e.CommandArgument));
            new Daiv_OA.BLL.UserBLL().Delete(Convert.ToInt32(e.CommandArgument));
            Adminlogadd(oname);
            Bind();
        }

        //通过参数获取被更改的用户名
        string Getoname(int id)
        {
            Entity.UserEntity model = new Entity.UserEntity();
            model = new Daiv_OA.BLL.UserBLL().GetEntity(id);
            return model.Uname;
        }

        //添加到管理员操作日志
        void Adminlogadd(string name)
        {
            Entity.AdminlogEntity model = new Entity.AdminlogEntity();
            model.Uid = UserId;
            model.Updatetitle = name;
            model.Updatetime = DateTime.Now;
            model.Updatetype = "删除用户";
            int i = new Daiv_OA.BLL.AdminlogBLL().Add(model);
            if (i > 0)
                FinalMessage("用户删除成功", "User_List.aspx", 0);
            else
                FinalMessage("用户删除失败", "User_List.aspx", 0);
        }

        private PagedDataSource pds()
        {
            string sql = "select [OA_User].uid,[OA_User].uname,[OA_User].upwd,[OA_User].PID,Position,IsNull((select DName from [OA_Department] where [OA_Department].Did=[OA_User].did),'管理部') as Dname,[OA_Power].pname FROM [OA_User] left join [OA_Power] on [OA_User].pid = [OA_Power].pid where [OA_User].uid <> 1 ";
            DataSet ds = new Daiv_OA.BLL.UserBLL().Getall(sql);
            //this.user_repeater.DataBind();
            //this.user_repeater.DataSource = new Daiv_OA.BLL.UserBLL().Getall(sql);
            //this.user_repeater.DataBind();

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = ds.Tables[0].DefaultView;
            pds.AllowPaging = true;//允许分页
            pds.PageSize = 4;//单页显示项数
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
            Response.Redirect("User_List.aspx?page=" + pg);//页面转向
        }
    }
}
