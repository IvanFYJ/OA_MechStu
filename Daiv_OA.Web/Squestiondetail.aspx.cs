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
    public partial class Squestiondetail : Daiv_OA.UI.BasicPage
    {
        Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("login");
            if (!IsPostBack)
            {
                show();
            
            }

        }
      /// <summary>
      /// 提交
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            string sid = com.getsid("sques");
            DataTable dt = com.COM_Select("OA_QuestionTB", "Id", "", sid, "", 4);
           
            if (sid != "-1")
            {
                string user = getvalue(2);
                string u = dt.Rows[0]["quuser"].ToString();
                if (user != u)
                    antime.Text = DateTime.Now.ToString();
                else
                    uptime.Text = DateTime.Now.ToString();
              DataRow dr=dt.Rows[0];
              DR(dr);
              com.COM_Up(dt, "OA_QuestionTB",Daiv_OA.BLL.Component.UpQuestion, sid);
              FinalMessage("提交成功！", "Squestion.aspx", 0);
            }
            else
            {
                if (getvalue(2) != touser.SelectedValue.ToString())
                {
                    quuser.Text = getvalue(2); inserttime.Text = DateTime.Now.ToString();
                    dt.Rows.Clear();
                    DataRow dr = dt.NewRow();
                    DR(dr);
                    dt.Rows.Add(dr);
                    com.COM_Add(dt, "OA_QuestionTB", Daiv_OA.BLL.Component.InQuestion);
                    FinalMessage("提交成功！", "Squestion.aspx", 0);
                }
                else
                    Tools.Common.JavaScript.MessageBox(this ,"当前解决人和发布人不能同时存在！");
            }
        }
        //提交并继续
        protected void Button1_Click(object sender, EventArgs e)
        {
             if (getvalue(2) != touser.SelectedValue.ToString())
                {
            DataTable dt = com.COM_Select("OA_QuestionTB", "Id", "","", "", 4);
            quuser.Text = getvalue(2); inserttime.Text = DateTime.Now.ToString();
            dt.Rows.Clear();
            DataRow dr = dt.NewRow();
            DR(dr);
            dt.Rows.Add(dr);
            com.COM_Add(dt, "OA_QuestionTB", Daiv_OA.BLL.Component.InQuestion);
            //titels.Text = remark.Value = pages.Text = inserttime.Text = "";
            Tools.Common.JavaScript.MessageBox(this,"提交成功！");
                }
             else
                 Tools.Common.JavaScript.MessageBox(this, "当前解决人和发布人不能同时存在！");
        }
        //返回
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Squestion.aspx");
        }
        protected void show()
        {
            string sid = com.getsid("sques");
            drop();
            dropuser();
            if (sid != "-1")
            {
                Panel1.Enabled = false;
                Button1.Visible = false;
                string user = getvalue(2);
                DataTable dt = com.COM_Select("OA_QuestionTB", "Id", "", sid, "", 4);
                if (dt.Rows.Count != 0)
                {
                    Itemid.Enabled = false; touser.Enabled = false; types.Enabled = false;
                    classe.Enabled = false;
                    Itemid.SelectedValue = dt.Rows[0]["Itemid"].ToString();
                    touser.SelectedValue = dt.Rows[0]["touser"].ToString();
                    types.SelectedValue = dt.Rows[0]["types"].ToString();
                    titels.Text = dt.Rows[0]["titels"].ToString();
                    //remark.Value = dt.Rows[0]["remark"].ToString();
                    pages.Text = dt.Rows[0]["pages"].ToString();
                    inserttime.Text = dt.Rows[0]["inserttime"].ToString();
                    answer.Text = dt.Rows[0]["answer"].ToString();
                    antime.Text = dt.Rows[0]["antime"].ToString();
                    if(dt.Rows[0]["rescue"].ToString()!="请求复测")
                    {
                        rescue.SelectedValue = dt.Rows[0]["rescue"].ToString();
                    }
                    okuser.Text = dt.Rows[0]["okuser"].ToString();
                    if (dt.Rows[0]["uptime"].ToString() != "1900-1-1 0:00:00" && dt.Rows[0]["uptime"].ToString() != "")
                        uptime.Text = dt.Rows[0]["uptime"].ToString();
                    quuser.Text = dt.Rows[0]["quuser"].ToString();
                    classe.SelectedValue = dt.Rows[0]["class"].ToString();
                    if (user.Trim() == touser.SelectedValue.ToString())
                    {
                        panelChu.Visible = true;
                        panelChu.Enabled = true;
                        panelFu.Visible = true;
                        panelFu.Enabled = false;
                    }
                    else
                    {
                        if (user.Trim() == quuser.Text.Trim())
                        {
                            panelFu.Visible = true;
                            panelFu.Enabled = true;
                            panelChu.Visible = true;
                            panelChu.Enabled = false;
                        }
                        else
                            Button2.Visible = false;
                    }
                }
            }
            else
            {
                Button1.Visible = true;
                quuser.Text = getvalue(2);
                panelChu.Visible = false;
                panelFu.Visible=false;
                Panel1.Enabled = true;
             
            }
          
        }
        protected void drop()
        {
            Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
            Itemid.DataSource = com.COM_Select("OA_ItemTB", "typeid", "parentid", "1", "0", 8);
            Itemid.DataTextField = "titlename";
            Itemid.DataValueField = "Id";
            Itemid.DataBind();
        }
        protected void dropuser()
        {
            Daiv_OA.BLL.UserBLL user = new Daiv_OA.BLL.UserBLL();
            touser.DataSource = user.GetList("Did in(1,2,3)").Tables[0];
            touser.DataTextField = "Uname";
            touser.DataValueField = "Uname";
            touser.DataBind();
            
           
        }
        protected void DR(DataRow dr)
        {
            dr["Itemid"]= Itemid.SelectedValue;
             dr["touser"]=touser.SelectedValue;
            dr["types"]=  types.SelectedValue.ToString();
             dr["titels"] =titels.Text.Trim();
              //dr["remark"]=remark.Value;
              dr["pages"] = pages.Text.Trim();
              if (inserttime.Text!="")
             dr["inserttime"]=Convert.ToDateTime(inserttime.Text);
            dr["answer"]=answer.Text.Trim();
             if (antime.Text!="")
             dr["antime"]=Convert.ToDateTime(antime.Text);

             string user = getvalue(2);
             if (touser.SelectedValue.ToString() == user)
             {
                 if (rescue.SelectedValue.ToString()=="")
                 dr["rescue"] = "请求复测";
             }
             else
             { dr["rescue"] = rescue.SelectedValue.ToString(); }
          dr["okuser"]=okuser.Text.Trim();
          if (uptime.Text.Trim() != "" && uptime.Text != "1900-1-1 0:00:00")
             dr["uptime"]=Convert.ToDateTime(uptime.Text);
             dr["quuser"]=quuser.Text;
             dr["class"] = classe.SelectedValue;
        
        }
    }
}
