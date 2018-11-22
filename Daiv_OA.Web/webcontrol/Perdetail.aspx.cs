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
    public partial class Perdetail : System.Web.UI.Page
    {
        Daiv_OA.UI.BasicPage ps= new Daiv_OA.UI.BasicPage();
        Daiv_OA.BLL.COMDLL com = new Daiv_OA.BLL.COMDLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {DataDp();
                string id = com.getsid("Ponid");
                if (id != "-1")
                {
                    DataTable table = com.COM_Select("OA_PersonalTB", "Id", "", id, "", 4);
                    if (table.Rows.Count != 0)
                    {
                        titlename.Text = table.Rows[0]["note"].ToString();
                        string[] str = table.Rows[0]["inserttime"].ToString().Split("-".ToCharArray());
                        //txtBegintime.Text=table.Rows[0]["inserttime"].ToString();
                        DropY.SelectedValue=str[0].ToString();
                        DropM.SelectedValue=str[1].ToString();
                        DropD.SelectedValue=str[2].ToString();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = com.getsid("Ponid");
            DataTable table = com.COM_Select("OA_PersonalTB", "Id", "", id, "", 4);
            string times = DropY.SelectedValue.ToString()+"-"+DropM.SelectedValue.ToString()+"-"+DropD.SelectedValue.ToString();
            if (table.Rows.Count != 0)
            {
                Daiv_OA.BLL.PersonalBLL.UpPersonal(id, titlename.Text.Trim(), times); go();
            }
            else
            {
                table = Daiv_OA.BLL.PersonalBLL.GetPersonal(ps.getvalue(2), times);
                if (table.Rows.Count < 3)
                {
                    Daiv_OA.BLL.PersonalBLL.ADDPersonal(ps.getvalue(2), titlename.Text.Trim(), times);
                    go();
                }
                else
                    Tools.Common.JavaScript.MessageBox(this,"当日个人便签不能超出3条！");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            go();
        }
        void go()
        {
            int i =Convert.ToInt32(ps.getvalue(4));
            switch (i)
            {
                case 1:
                    Response.Write("<script>parent.location.href='./../User_List.aspx'</script>");//刷新父窗体，也可传参数
                    break;
                case 2:
                    Response.Write("<script>parent.location.href='./../DeskTop2.aspx'</script>");//刷新父窗体，也可传参数
                    break;
                case 3:
                    Response.Write("<script>parent.location.href='./../DeskTop3.aspx'</script>");//刷新父窗体，也可传参数
                    break;
                case 4:
                    Response.Write("<script>parent.location.href='./../DeskTop4.aspx'</script>");//刷新父窗体，也可传参数
                    break;
            }
        }
        //绑定日期年
        protected void DataDp()
        {
            for (int i = DateTime.Now.Year; i < DateTime.Now.Year + 2; i++)
            {
                ListItem item = new ListItem(i.ToString(), i.ToString());
                if (item.Value.ToString() == DateTime.Now.Year.ToString())
                    item.Selected = true;
                DropY.Items.Add(item);
            }

            int y = Convert.ToInt32(DropY.SelectedValue.ToString());
            int m = DateTime.Now.Month;
            if (y != DateTime.Now.Year)
                m = 1;
            for (int i = m; i < 13; i++)
            {
                DropM.ClearSelection();
                ListItem item = new ListItem(i.ToString(), i.ToString());
                if (item.Value.ToString() == DateTime.Now.Month.ToString())
                    item.Selected = true;
                DropM.Items.Add(item);
            }

            int ms = Convert.ToInt32(DropM.SelectedValue.ToString());
            int Dsum = 31;
            switch (ms)
            {
                case 1:
                    Dsum = 31;
                    break;
                case 2:
                    if ((((y % 4) == 0) && ((y % 100) != 0)) || ((y % 400) == 0))
                        Dsum = 29;
                    else
                        Dsum = 28;
                    break;
                case 3:
                    Dsum = 31;
                    break;
                case 4:
                    Dsum = 30;
                    break;
                case 5:
                    Dsum = 31;
                    break;
                case 6:
                    Dsum = 30;
                    break;
                case 7:
                    Dsum = 31;
                    break;
                case 8:
                    Dsum = 31;
                    break;
                case 9:
                    Dsum = 30;
                    break;
                case 10:
                    Dsum = 31;
                    break;
                case 11:
                    Dsum = 30;
                    break;
                case 12:
                    Dsum = 31;
                    break;
            }
            //日
            for (int i = 1; i <= Dsum; i++)
            {

                ListItem item = new ListItem(i.ToString(), i.ToString());
                if (item.Value.ToString() == DateTime.Now.Day.ToString())
                    item.Selected = true;
                DropD.Items.Add(item);
            }
        }

        protected void DropM_SelectedIndexChanged(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(DropY.SelectedValue.ToString());
            int ms = Convert.ToInt32(DropM.SelectedValue.ToString());
            int Dsum = 31;
            switch (ms)
            {
                case 1:
                    Dsum = 31;
                    break;
                case 2:
                    if ((((y % 4) == 0) && ((y % 100) != 0)) || ((y % 400) == 0))
                        Dsum = 29;
                    else
                        Dsum = 28;
                    break;
                case 3:
                    Dsum = 31;
                    break;
                case 4:
                    Dsum = 30;
                    break;
                case 5:
                    Dsum = 31;
                    break;
                case 6:
                    Dsum = 30;
                    break;
                case 7:
                    Dsum = 31;
                    break;
                case 8:
                    Dsum = 31;
                    break;
                case 9:
                    Dsum = 30;
                    break;
                case 10:
                    Dsum = 31;
                    break;
                case 11:
                    Dsum = 30;
                    break;
                case 12:
                    Dsum = 31;
                    break;
            }
            //日
            DropD.Items.Clear();
            for (int i = 1; i <= Dsum; i++)
            {
                //DropD.ClearSelection();
                ListItem item = new ListItem(i.ToString(), i.ToString());
                if (item.Value.ToString() == DateTime.Now.Day.ToString())
                    item.Selected = true;
                DropD.Items.Add(item);
            }

        }

        protected void DropY_SelectedIndexChanged(object sender, EventArgs e)
        {
            int m = DateTime.Now.Month;
            int y =Convert.ToInt32(DropY.SelectedValue.ToString());
            DropM.Items.Clear();
            if (y != DateTime.Now.Year)
                m = 1;
            for (int i = m; i < 13; i++)
            {
                DropM.ClearSelection();
                ListItem item = new ListItem(i.ToString(), i.ToString());
                if (item.Value.ToString() == DateTime.Now.Month.ToString())
                    item.Selected = true;
                DropM.Items.Add(item);
            }
        }

       
    }
}
