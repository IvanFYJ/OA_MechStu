using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Daiv_OA.BLL
{
   public static class PersonalBLL
    {
   
       /// 添加个人便签
       public static void ADDPersonal(string Uname, string note, string inserttime)
       {
           COMDLL com = new COMDLL();
           DataTable dt = com.COM_Select("OA_PersonalTB", "", "", "", "", 3);
           dt.Rows.Clear();
           DataRow dr = dt.NewRow();
           dr["Uname"] = Uname;
           dr["note"] = note;
           dr["inserttime"] = inserttime;
           dt.Rows.Add(dr);
           com.COM_Add(dt, "OA_PersonalTB", "@Uname,@note,@inserttime");
       }
       public static void UpPersonal(string Id, string note, string inserttime)
       {
           COMDLL com = new COMDLL();
           DataTable dt = com.COM_Select("OA_PersonalTB", "Id", "",Id, "",4);
           DataRow dr=dt.Rows[0];
           dr["note"] = note;
           dr["inserttime"] = inserttime;
           com.COM_Up(dt, "OA_PersonalTB", "note=@note,inserttime=@inserttime", Id);
       }
       public static DataTable GetPersonal(string Uname,string inserttime)
       {
           COMDLL com = new COMDLL();
           DataTable dt = com.COM_Select("OA_PersonalTB", "Uname", "inserttime", Uname, inserttime,8);
           return dt;
       }
       public static void DelPersonal(string sid)
       {
           COMDLL com = new COMDLL();
           com.COM_Del("OA_PersonalTB",sid,1);
       }

    }
}
