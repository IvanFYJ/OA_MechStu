using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Daiv_OA.DBUtility;
namespace Daiv_OA.DAL
{
   public  class FilenameDAL
    {
       DBUtility.DbHelperSQLP sql = new DbHelperSQLP();
       public  DataTable Select(int uid,int i)
       {
           DataTable dt = sql.Query("select * from [OA_filepath] where uid=" + uid + " and isdelete="+i+" order by Id desc").Tables[0];
           return dt;
       }
     public  int Add(int uid,string names,string side)
       {
           return sql.ExecuteSql("insert into [OA_filepath](names,uid,side)values('" + names + "'," + uid + ",'"+side+"')");
       }
     public int Del(int uid, int Id)
       {
           return sql.ExecuteSql("delete from [OA_filepath] where uid="+uid+" and id="+Id+"");

       }
     public int Up(int uid,int i)
     {
         return sql.ExecuteSql("update [OA_filepath] set isdelete=" + i + " where uid=" + uid + " and isdelete=0");

     }


    }
}
