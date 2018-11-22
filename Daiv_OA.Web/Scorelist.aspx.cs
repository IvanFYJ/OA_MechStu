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
using System.Text.RegularExpressions;
namespace Daiv_OA.Web
{
    public partial class Scorelist : Daiv_OA.UI.BasicPage
    {
        
        #region Initialzling
        Daiv_OA.BLL.UserBLL user = new Daiv_OA.BLL.UserBLL();
        Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
        System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
        int pids = 0;DataTable Opposes = new DataTable();string intime = DateTime.Now.Year.ToString() + (DateTime.Now.Month-1).ToString();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("login");
            pids =Convert.ToInt32(getvalue(4));
            Checkgvlist0();
            if (!IsPostBack)
            {
                dropuser(); year(); mouth(); showqi(); GetList(); SHgvlist();
                if (pids == 1)//验证设置打分公式
                    dafen.Visible = true;
                else
                    dafen.Visible = false; 
                 DataTable dt = com.COM_Proc_Sel1("PC_SelOpenTB", "1");
                    if (dt.Rows.Count != 0)
                    {
                        gvlist.Enabled = true;
                        Button3.Enabled = true;
                    }
                    else
                    { //打分表格隐藏
                        gvlist.Enabled = false;
                        Button3.Enabled = false;
                    }
            }
        }
        
        #region 绑定下拉列表
        protected void dropuser()
        {
            if (pids == 2 || pids == 1)
            ddlUname.DataSource = user.GetList("Did>0").Tables[0];
            else if (pids == 3)
            {
                string did=user.GetList("Uid=" + getvalue(1)).Tables[0].Rows[0]["Did"].ToString();
                ddlUname.DataSource = user.GetList("Did=" + did).Tables[0];
            }
            else
                ddlUname.DataSource = user.GetList("Uid=" + getvalue(1)).Tables[0];
            ddlUname.DataTextField = "Uname";
            ddlUname.DataValueField = "Uid";
            ddlUname.DataBind();
            if (pids == 2 || pids == 1)
            ddlUname.Items.Insert(0, new ListItem("==全部人员==", "0"));
        }
        protected void year()
        {
            int year=DateTime.Now.Year;
            for (int i = year-1; i < year + 1;i++ )
            {   
                ListItem item = new ListItem();
                item.Text=i.ToString();
                item.Value = i.ToString();
                if (i == year)
                    item.Selected = true;
                DropDyeah.Items.Add(item);
            }
        }
        protected void mouth()
        {
            int mouth = DateTime.Now.Month;
            for (int i = 1; i <13; i++)
            {
                ListItem item = new ListItem();
                item.Text = i.ToString();
                item.Value = i.ToString();
                if (i == mouth)
                    item.Selected = true;
                DropDmouth.Items.Add(item);
               
            }
            DropDmouth.Items.Insert(0, new ListItem("==全年==", "0"));

        }
        #endregion
        //查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            GetList();
        }
        #region 设置公式、是否启用打分
        //保存设置
        protected void Button1_Click(object sender, EventArgs e)
        {
           
                if (m_blnIsNUmber(TextBox1.Text.Trim()) == false || m_blnIsNUmber(TextBox2.Text.Trim()) == false || m_blnIsNUmber(TextBox3.Text.Trim()) == false || m_blnIsNUmber(TextBox4.Text.Trim()) == false)
                   Tools.Common.JavaScript.MessageBox(this,"在设置用户最终分公式中须填写数字！");
                else
                {
                    string sum = TextBox1.Text.Trim() + "," + TextBox2.Text.Trim() + "," + TextBox3.Text.Trim() + "," + TextBox4.Text.Trim();
                    string Isdel = "";
                    if (Isdelete.Checked == true)
                        Isdel = "1";
                    else
                        Isdel = "0";
                    bool b = com.COM_Proc_DelorUp_2("PC_upOpenTB",sum, Isdel);
                    if (b)
                    {
                        FinalMessage("保存成功!", "Scorelist.aspx", 0);
                    }
                    else
                        Tools.Common.JavaScript.MessageBox(this, "操作失败！");
                }
           
        }
        protected void showqi()
        {
          DataTable dt=com.COM_Proc_Sel1("PC_SelOpenTB","2");
          if (dt.Rows.Count != 0)
          {
              string[] str = dt.Rows[0]["formula"].ToString().Split(",".ToCharArray());
              TextBox1.Text=str[0].ToString();
              TextBox2.Text = str[1].ToString();
              TextBox3.Text = str[2].ToString();
              TextBox4.Text = str[3].ToString();
              string isdel = dt.Rows[0]["Isdelete"].ToString();
              if (isdel == "1")
                  Isdelete.Checked = true;
              else
                  Isdelete.Checked = false;
          }
        
        }

        bool m_blnIsNUmber(string p_strVaule)
        {
            if (p_strVaule == "")
            {
                return false;
            }
            else
            {
                Regex m_regex = new System.Text.RegularExpressions.Regex("^(-?[0-9]*[.]*[0-9]{0,3})$");
                return m_regex.IsMatch(p_strVaule);
            }
        }
        #endregion 
       
        //提交打分
       protected void Button3_Click(object sender, EventArgs e)
       {
           
           Opposes = com.COM_Proc_Sel3("PC_CheckOpposes", ddlUname.SelectedValue.ToString(), intime, "1");
           //1验证是否存在打分记录
           if (ddlUname.SelectedValue != "0")
           {
               if (Opposes.Rows.Count != 0)//判读同周期下是否存在某角色已打分
               {
                   string statuis=Opposes.Rows[0]["statuis"].ToString();
                   #region 更新角色打分，统计
                   Opposes = com.COM_Proc_Sel3("PC_CheckOpposes",ddlUname.SelectedValue.ToString(), pids.ToString(),intime);
                   if (Opposes.Rows.Count == 0)
                   {
                       //更新打分
                       int c = 0;
                       for (int i = 0; i < gvlist.Rows.Count; i++)
                       {
                           GridView gvlist2 = (GridView)gvlist.Rows[i].FindControl("GridView2");
                           string sid = gvlist.DataKeys[i].Value.ToString();//考核大栏目编号
                           DataTable table = com.COM_Proc_Sel3("PC_GetOpposes", ddlUname.SelectedValue.ToString(), sid, intime);
                           for (int j = 0; j < table.Rows.Count; j++)
                           {
                               #region up  Opposes data
                               RadioButtonList rbl = (RadioButtonList)gvlist2.Rows[j].FindControl("Radio");
                               string ords = ((TextBox)(gvlist2.Rows[j].Cells[4].Controls[1])).Text.Trim();
                               if (rbl.SelectedValue.ToString() == "")
                               {
                                   com.COM_Proc_DelorUp_3("PC_Upall0pposes", ddlUname.SelectedValue.ToString(), intime, statuis);
                                   Tools.Common.JavaScript.MessageBox(this, "第 " + (i + 1) + " 模块下的第" + (j + 1) + "行的具体考核因素未选择，请重新选择！");
                                   return;
                               }
                               if (rbl.SelectedValue.ToString() == "20" || rbl.SelectedValue.ToString() == "0")
                               {
                                   if (ords == "")
                                   {
                                       com.COM_Proc_DelorUp_3("PC_Upall0pposes", ddlUname.SelectedValue.ToString(), intime, statuis);
                                       Tools.Common.JavaScript.MessageBox(this, "第 " + (i + 1) + " 模块下的第" + (j + 1) + "行的备注不能为空，请重新填写！");
                                       return;
                                   }
                               }
                               string id = table.Rows[j]["Id"].ToString();//考核编号
                               string stsuid = table.Rows[j]["statuis"].ToString();
                               string rem = table.Rows[j]["remrk"].ToString();
                               string column = "";

                               DataRow dr = table.Rows[0];
                               if (ords.Trim() != "")
                                   dr["remrk"] = rem + "|" + ords;
                               else
                                   dr["remrk"] = rem;
                               switch (pids)
                               {
                                   case 1:
                                       dr["threescore"] = rbl.SelectedValue.ToString();
                                       column = "threescore=@threescore";
                                       c += Convert.ToInt32(rbl.SelectedValue);
                                       break;
                                   case 2:
                                       dr["twoscore"] = rbl.SelectedValue.ToString();
                                       column = "twoscore=@twoscore";
                                       c += Convert.ToInt32(rbl.SelectedValue);
                                       break;
                                   case 3:
                                       dr["onescore"] = rbl.SelectedValue.ToString();
                                       column = "onescore=@onescore";
                                       c += Convert.ToInt32(rbl.SelectedValue);
                                       break;
                                   case 4:
                                       dr["custom"] = rbl.SelectedValue.ToString();
                                       column = "custom=@custom";
                                       c += Convert.ToInt32(rbl.SelectedValue);
                                       break;
                               }
                               dr["statuis"] = stsuid + pids.ToString() + ",";
                               com.COM_Up(table, "OA_Opposes", "remrk=@remrk," + column + ",statuis=@statuis", id);
                               #endregion      // com.pkUpdate(Opposes, "OA_Opposes", "orderby=@orderby", gvlsit.DataKeys[jj].Value.ToString());//书卷编号);
                           }

                       }
                       Stats(c);
                       FinalMessage("打分成功！", "Scorelist.aspx", 0);
                   }
                   else
                       Tools.Common.JavaScript.Redirect(this, "您的角色已经打过分了，系统禁用重复打分，谢谢操作！", "Scorelist.aspx");
                   #endregion
               }
               else
               {
                
                   #region 插入打分,统计
                   int c = 0;
                   for (int i = 0; i < gvlist.Rows.Count; i++)
                   {
                       GridView gvlist2 = (GridView)gvlist.Rows[i].FindControl("GridView2");
                       string sid = gvlist.DataKeys[i].Value.ToString();//考核大栏目编号
                       for (int j = 0; j < gvlist2.Rows.Count; j++)
                       {
                           #region add  Opposes data
                           RadioButtonList rbl = (RadioButtonList)gvlist2.Rows[j].FindControl("Radio");
                           string ords = ((TextBox)(gvlist2.Rows[j].Cells[4].Controls[1])).Text.Trim();
                           if (rbl.SelectedValue.ToString() == "")
                           {
                               com.COM_Proc_DelorUp_2("PC_DelAll0pposes", ddlUname.SelectedValue.ToString(), intime);
                               Tools.Common.JavaScript.MessageBox(this, "第 " + (i + 1) + " 模块下的第" + (j + 1) + "行的具体考核因素未选择，请重新选择！");
                               return;
                           }
                           if (rbl.SelectedValue.ToString() == "20" || rbl.SelectedValue.ToString() == "0")
                           {
                               if (ords == "")
                               {
                                   com.COM_Proc_DelorUp_2("PC_DelAll0pposes", ddlUname.SelectedValue.ToString(), intime);
                                   Tools.Common.JavaScript.MessageBox(this, "第 " + (i + 1) + " 模块下的第" + (j + 1) + "行的备注不能为空，请重新填写！");
                                   return;
                               }
                           }
                           string id = gvlist2.DataKeys[j].Value.ToString();//考核栏目编号
                           string column = "";
                           Opposes.Rows.Clear();
                           DataRow dr = Opposes.NewRow();
                           dr["Itemid"] =id;
                               dr["parentid"] =sid;
                               dr["uid"] =getvalue(1);
                               dr["intimes"] =intime;
                               dr["remrk"] =ords;
                               switch(pids)
                               {
                                   case 1:
                                       dr["threescore"] = rbl.SelectedValue.ToString();
                                       column = "@threescore";
                                       c += Convert.ToInt32(rbl.SelectedValue);
                                       break;
                                   case 2:
                                       dr["twoscore"] = rbl.SelectedValue.ToString();
                                       column = "@twoscore";
                                       c += Convert.ToInt32(rbl.SelectedValue);
                                       break;
                                   case 3:
                                       dr["onescore"] = rbl.SelectedValue.ToString();
                                       column = "@onescore";
                                       c += Convert.ToInt32(rbl.SelectedValue);
                                       break;
                                   case 4:
                                       dr["custom"] = rbl.SelectedValue.ToString();
                                       column = "@custom";
                                       c += Convert.ToInt32(rbl.SelectedValue);
                                       break;
                               }
                             dr["touser"]=ddlUname.SelectedValue.ToString();
                             dr["statuis"]=","+pids.ToString()+",";
                             Opposes.Rows.Add(dr);
                             com.COM_Add(Opposes, "OA_Opposes", "@Itemid,@parentid,@uid,@intimes,@remrk," + column + ",@touser,@statuis");
                     #endregion      // com.pkUpdate(Opposes, "OA_Opposes", "orderby=@orderby", gvlsit.DataKeys[jj].Value.ToString());//书卷编号);
                       }

                   }
                   Stats(c);
                // Tools.Common.JavaScript.Redirect(this, "打分成功！", "Scorelist.aspx");
                   FinalMessage("打分成功！", "Scorelist.aspx", 0);
                   #endregion
               }
               
           }
           else
               Tools.Common.JavaScript.MessageBox(this,"禁用同时给所有用户打分！请重新选择用户，谢谢操作！");
       }
/// <summary>
/// 统计打分
/// </summary>
/// <param name="c">当前角色打的总分</param>
       protected void Stats(int c)
       {
            DataTable dt=com.COM_Proc_Sel1("PC_SelOpenTB","2");
          if (dt.Rows.Count == 0)
              Tools.Common.JavaScript.MessageBox(this,"统计最终分的公式设置有误！请联系管理员");
          else
          {
           string[] str = dt.Rows[0]["formula"].ToString().Split(",".ToCharArray());
            dt = com.COM_Select("OA_StatsTB","uid","statstime",ddlUname.SelectedValue.ToString(),intime,9);
           if (dt.Rows.Count!=0)
           { string sid=dt.Rows[0]["Id"].ToString();
           double sum =Convert.ToDouble(dt.Rows[0]["Sendscore"].ToString());
             DataRow dr=dt.Rows[0];
             string column = ""; double d = sum;
             switch (pids)
             {
                 case 1:
                     dr["Sthreescore"] = c;
                     column = "Sthreescore=@Sthreescore";
                     d += (Convert.ToInt32(str[2].ToString()) * c * 0.01);
                     break;
                 case 2:
                     dr["Stwoscore"] = c;
                     column = "Stwoscore=@Stwoscore";
                     d += (Convert.ToInt32(str[2].ToString()) * c * 0.01);
                     break;
                 case 3:
                     dr["Sonescore"] = c;
                     column = "Sonescore=@Sonescore";
                     d += (Convert.ToInt32(str[2].ToString()) * c * 0.01);
                     break;
                 case 4:
                     dr["Scustom"] = c;
                     column = "Scustom=@Scustom";
                     d +=(Convert.ToInt32(str[2].ToString()) * c * 0.01);
                     break;
             }
             dr["Sendscore"] = d;
             com.COM_Up(dt, "OA_StatsTB", column + ",Sendscore=@Sendscore", sid);
           }
           else
           {
               dt.Rows.Clear();
               DataRow dr = dt.NewRow();
               dr["Openid"] = 1;
               dr["uid"]=ddlUname.SelectedValue;
                   dr["statstime"]=intime;
                   string column = "";  double d = 0;
                     switch(pids)
                               {
                                   case 1:
                                       dr["Sthreescore"] =c;
                                       column = "@Sthreescore";
                                       d = (Convert.ToInt32(str[3].ToString())*c*0.01);
                                       break;
                                   case 2:
                                       dr["Stwoscore"] = c;
                                       column = "@Stwoscore";
                                       d = (Convert.ToInt32(str[2].ToString())*c*0.01);
                                       break;
                                   case 3:
                                       dr["Sonescore"] = c;
                                       column = "@Sonescore";
                                       d = (Convert.ToInt32(str[2].ToString()) * c * 0.01); break;
                                   case 4:
                                      dr["Scustom"]=c;
                                       column = "@Scustom";
                                       d = (Convert.ToInt32(str[2].ToString()) * c * 0.01); break;
                               }
                     dr["Sendscore"] = d;
                     dt.Rows.Add(dr);
                     com.COM_Add(dt, "OA_StatsTB", "@Openid,@uid,@statstime," + column + ",@Sendscore");
           }
           }
       }
       private void GetList()
       {
           Daiv_OA.DAL.BaseDAL BLL = new Daiv_OA.DAL.BaseDAL();
           int rowCount = 0;
           Daiv_OA.Entity.PageListModel pageModel = new Daiv_OA.Entity.PageListModel();
           pageModel.SelectList = "*";
           pageModel.Tables = "OA_ViewStats";
           pageModel.PriKey = "Id";
           pageModel.BlPage = 1;
           pageModel.PageSize = AspNetPager1.PageSize;
           pageModel.StrWhere = GetWhere();
           pageModel.PageIndex = AspNetPager1.CurrentPageIndex;
           pageModel.OrderByField = "Sendscore desc";  //Id desc
           DataTable dt = BLL.GetList(pageModel, ref rowCount).Tables[0];
           AspNetPager1.RecordCount = rowCount;
           gvlist0.DataSource = dt;
           gvlist0.DataBind();

       }
        /// <summary>
        /// 获得查询where
        /// </summary>
        /// <returns></returns>
        string GetWhere()
        {
            string str = "1=1";
            if (ddlUname.SelectedValue.ToString() != "")
            {
                if (ddlUname.SelectedValue.ToString() != "0")
                    str += " and uid=" + ddlUname.SelectedValue.ToString();
            }
                if (DropDmouth.SelectedValue.ToString() == "0")
                str +=" and (statstime like " + "'" + DropDyeah.SelectedValue.ToString() + "%')";
            else
                str +=" and statstime="+"'"+DropDyeah.SelectedValue.ToString() + DropDmouth.SelectedValue.ToString()+"'";
             return str;
        }
       public  string getstrobj(object name,int i)
        {  
           Daiv_OA.BLL.DepartmentBLL dp=new Daiv_OA.BLL.DepartmentBLL ();
           string str="";
          switch(i)
          {
              case 1:
                 str= user.GetList("Uid="+name.ToString()).Tables[0].Rows[0]["Uname"].ToString();
                  break;
              case 2:
                  if (name.ToString() == "0")
                      str = "管理部";
                  else
                  str = dp.GetList("Did=" + name.ToString()).Tables[0].Rows[0]["DName"].ToString();
                  break;
          }
          return str;
       
       }
       protected void AspNetPager1_PageChanged1(object src, Sisans.AspNetPager.PageChangedEventArgs e)
       {
           AspNetPager1.CurrentPageIndex = e.NewPageIndex;
           GetList();
       }
       protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
       {
           if (e.Row.RowIndex != -1)
           {
               int id = e.Row.RowIndex + 1;
               e.Row.Cells[0].Text = id.ToString();
           }
           if (e.Row.RowType == DataControlRowType.DataRow)
           {
               string fid = gvlist.DataKeys[e.Row.RowIndex].Value.ToString().Trim();
               GridView gvlist3 = (GridView)e.Row.FindControl("GridView2");
               if (fid != "")
               {
                   DataTable dt = com.COM_Select("OA_ItemTB", "parentid", "Isdelete", fid, "1", 8);
                   gvlist3.DataSource = dt; gvlist3.DataBind();
               }
           }
       }

       protected void SHgvlist()
       {
           gvlist.DataSource = com.COM_Select("OA_ItemTB", "typeid", "", "0", "",7);
           gvlist.DataBind();
       }
       protected void Checkgvlist0()
       {
           switch (pids)
           {
               case 1:
                   break;
               case 2:
                   gvlist0.Columns[4].Visible = false; gvlist0.Columns[7].Visible = false; gvlist0.Columns[8].Visible = false; gvlist0.Columns[9].Visible = false;
                   break;
               case 3:
                   gvlist0.Columns[4].Visible = false; gvlist0.Columns[7].Visible = false; gvlist0.Columns[8].Visible = false; gvlist0.Columns[9].Visible = false;
                   break;
               case 4:
                   gvlist0.Columns[7].Visible = false; gvlist0.Columns[8].Visible = false; gvlist0.Columns[9].Visible = false;
                   break;
               default:
                   gvlist0.Visible = false;
                   break;
              }
       }
       protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
       {

       }

       protected void gvlist0_RowDataBound(object sender, GridViewRowEventArgs e)
       {
           if (e.Row.RowIndex != -1)
           {
               int id = e.Row.RowIndex + 1;
               e.Row.Cells[0].Text = id.ToString();
           }
       }

       

      
    }
}
