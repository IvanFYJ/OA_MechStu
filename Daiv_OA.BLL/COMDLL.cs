using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Daiv_OA.BLL
{
    public class COMDLL
    {
       
        #region 连接数据库
        public SqlConnection getconn()
        {
            string conn = Daiv_OA.DBUtility.PubConstant.ConnectionString;
            return new SqlConnection(conn);
        }
        #endregion
        #region 基本的查看、添加、修改、删除操作方法

        /// <summary>
        /// 查看数据
        /// </summary>
        /// <param name="objtable">表名</param>
        /// <param name="oneparameter">字段1</param>
        /// <param name="twoparameter">字段2</param>
        /// <param name="sId">值1</param>
        /// <param name="other">值2</param>
        /// <param name="type">0://查询所有；1://查询所有按编号排降序；2://查询所有按更新时间排降序；3://根据Isdelete=0 得到表格信息；4://根据一个条件得到信息；5://根据一个条件得到表格降序的信息； 6://对某列的模糊查询；7://根据某一条件和Isdelete=0的数据；8://两个字段得到信息；9://两个字段+Isdelete=0得到信息；10://前面字段一致后面字段模糊得到表格信息</param>
        /// <returns>datatable</returns>
        public DataTable COM_Select(string objtable, string oneparameter, string twoparameter, string sId, string other, int type)
        {
            using (SqlConnection conn = getconn())
            {
                conn.Open();
                DataTable table = new DataTable();
                string sql = "";
                try
                {
                    #region 定义SQL语句
                    switch (type)
                    {
                        case 0:
                            sql = "select * from " + objtable;
                            break;//查询所有
                        case 1:
                            sql = "select * from " + objtable + " order by Id desc";
                            break;//查询所有按编号排降序
                        case 2:
                            sql = "select * from " + objtable + " order by Uptime desc";
                            break;//查询所有按更新时间排降序
                        case 3:
                            sql = "select * from " + objtable + " where Isdelete =0  order by Id desc";
                            break;//根据Isdelete=0 得到表格信息
                        case 4:
                            sql = "select * from " + objtable + " where " + oneparameter + "=" + "@Id";
                            break;//根据一个条件得到信息
                        case 5:
                            sql = "select * from " + objtable + " where " + oneparameter + "=" + " @Id" + " order by Id desc";
                            break;//根据一个条件得到表格降序的信息
                        case 6:
                            sql = "select * from " + objtable + " where " + oneparameter + " like '%" + sId + "%'";
                            break;//对某列的模糊查询
                        case 7:
                            sql = "select * from " + objtable + " where " + oneparameter + "=" + " @Id" + " and Isdelete=0";
                            break;//根据某一条件和Isdelete=0的数据

                        case 8:
                            sql = "select * from " + objtable + " where " + oneparameter + "=" + "@Id" + " and " + twoparameter + "=" + "@otherId";
                            break;//两个字段得到信息
                        case 9:
                            sql = "select * from " + objtable + " where " + oneparameter + "=" + "@Id" + " and " + twoparameter + "=" + "@otherId" + " and Isdelete=0";
                            break;//两个字段+Isdelete=0得到信息
                        case 10:
                            sql = "select * from " + objtable + " where " + oneparameter + "=" + "@Id" + " and " + twoparameter + " like '%" + other + "%'";
                            break;//前面字段一致后面字段模糊得到表格信息
                    }
                    #endregion
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        if (oneparameter != "" && twoparameter != "")
                        {
                            comm.Parameters.AddWithValue("@Id", sId);
                            comm.Parameters.AddWithValue("@otherId", other);
                        }
                        else if (oneparameter != "" && twoparameter == "")
                        {
                            comm.Parameters.AddWithValue("@Id", sId);
                        }
                        SqlDataAdapter sda = new SqlDataAdapter(comm);
                        sda.Fill(table);
                    }

                }
                catch (System.Exception ex)
                {
                   ErroLog(ex.Message);
                }
                conn.Close();
                return table;
            }


        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="objtable">表名称</param>
        /// <param name="sId">编号</param>
        /// <param name="type">1=(Id删除)
        /// 2=(Id且Isdelete=0删除)
        /// 3=(Isdelete=1)</param>
        /// <returns>ture</returns>
        public bool COM_Del(string objtable,string sId, int type)
        {
            using (SqlConnection conn = getconn())
            {
                bool b = false;
                string sql = "";
                conn.Open();
                try
                {
                    switch (type)
                    {
                        case 1:
                            sql = "delete from " + objtable + " where Id=@Id";
                            break;
                        case 2:
                            sql = "delete from " + objtable + " where Id=@Id and Isdelete=0";
                            break;
                        case 3:
                            sql = "update " + objtable + " set Isdelete=1 where Id=@Id";
                            break;
                    }
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        comm.Parameters.AddWithValue("@Id", sId);
                        comm.ExecuteNonQuery();
                    }
                    b = true;

                }
                catch (System.Exception dx)
                {
                   ErroLog(dx.Message);
                }
                conn.Close();
                return b;
            }

        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="table">datatable对象</param>
        /// <param name="objtable">表名</param>
        /// <param name="colume1">字段列表@id,@username...</param>
        /// <returns>true</returns>
        public bool COM_Add(DataTable table, string objtable, string colume1)
        {
            using (SqlConnection conn = getconn())
            {
                bool b = false;
                conn.Open();
                try
                {
                    string start = colume1.Replace("@", "");//输入值替换成字段
                    string sql = "";
                    sql = "insert into " + objtable + "(" + start + ")values(" + colume1 + ")";

                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        string[] newstr = start.Split(",".ToCharArray());//拆分字符串后构成新数组
                        for (int i = 0; i < newstr.Length; i++)//循环数组
                        {
                            comm.Parameters.AddWithValue("@" + newstr[i] + "", table.Rows[0][newstr[i]].ToString());
                        }
                        comm.ExecuteNonQuery();
                    }
                    b = true;
                }
                catch (System.Exception ix)
                {
                   ErroLog(ix.Message);
                }
                conn.Close();
                return b;
            }

        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="table">datatable对象</param>
        /// <param name="objtable">表名</param>
        /// <param name="columer">username=@username</param>
        /// <param name="sId">Id</param>
        /// <returns></returns>
        public bool COM_Up(DataTable table, string objtable, string columer, string sId)
        {
            using (SqlConnection conn = getconn())
            {
                bool b = false;
                conn.Open();
                string sql = "";
                try
                {
                    sql = "update " + objtable + " set " + columer + " where Id=@Id";
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        string newstr = columer.Replace("=@", ",");
                        string[] newstrs = (filtering(newstr)).Split(",".ToCharArray());
                        for (int i = 0; i < newstrs.Length; i++)//循环数组
                        {
                            comm.Parameters.AddWithValue("@" + newstrs[i] + "", table.Rows[0][newstrs[i]].ToString());

                        }
                        comm.Parameters.AddWithValue("@Id", sId);
                        comm.ExecuteNonQuery();
                    }
                    b = true;

                }
                catch (System.Exception up)
                {
                    ErroLog(up.Message);
                }
               conn.Close();
                return b;
            }

        }
        #endregion
        #region 存储过程——查询得到数据
        public DataTable COM_Proc_Sel0(string proname)
        {
            using (SqlConnection conn = getconn())
            {
                DataTable table = new DataTable();
                conn.Open();
                using (SqlCommand comm = new SqlCommand(proname, conn))
                {
                    try
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(comm);
                        da.Fill(table);
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
                conn.Close();
                return table;
            }
        }
        public DataTable COM_Proc_Sel1(string proname, string num)
        {
            using (SqlConnection conn = getconn())
            {
                DataTable table = new DataTable();
                conn.Open();
                using (SqlCommand comm = new SqlCommand(proname, conn))
                {
                    try
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@n", num);
                        SqlDataAdapter da = new SqlDataAdapter(comm);
                        da.Fill(table);
                    }
                    catch (System.Exception ex)
                    {
                        ErroLog(ex.Message);
                    }
                }
                conn.Close();
                return table;
            }
        }
        public DataTable COM_Proc_Sel2(string proname, string num, string num2)
        {
            using (SqlConnection conn = getconn())
            {
                DataTable table = new DataTable();
                conn.Open();
                using (SqlCommand comm = new SqlCommand(proname, conn))
                {
                    try
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@n", num);
                        comm.Parameters.AddWithValue("@m", num2);
                        SqlDataAdapter da = new SqlDataAdapter(comm);
                        da.Fill(table);
                    }
                    catch (System.Exception ex)
                    {
                        ErroLog(ex.Message);
                    }
                }
                conn.Close();
                return table;
            }
        }
        public DataTable COM_Proc_Sel3(string proname, string num, string num2, string num3)
        {
            using (SqlConnection conn = getconn())
            {
                DataTable table = new DataTable();
                conn.Open();
                using (SqlCommand comm = new SqlCommand(proname, conn))
                {
                    try
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@n", num);
                        comm.Parameters.AddWithValue("@m", num2);
                        comm.Parameters.AddWithValue("@f", num3);
                        SqlDataAdapter da = new SqlDataAdapter(comm);

                        da.Fill(table);
                    }
                    catch (System.Exception ext)
                    {
                       ErroLog(ext.Message);
                    }

                }
                conn.Close();
                return table;
            }
        }
       
        #endregion
        #region 存储过程——删除或修改
        public bool COM_Proc_DelorUp_1(string proname, string num)
        {
            bool b = false;
            using (SqlConnection conn = getconn())
            {

                conn.Open();
                using (SqlCommand comm = new SqlCommand(proname, conn))
                {

                    try
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@n", num);
                        comm.ExecuteNonQuery();
                        b = true;
                    }
                    catch (System.Exception pro)
                    {
                       ErroLog(pro.Message);
                    }
                }
                conn.Close();
            }
            return b;

        }
        public bool COM_Proc_DelorUp_2(string proname, string num, string num2)
        {
            bool b = false;
            using (SqlConnection conn = getconn())
            {

                conn.Open();
                using (SqlCommand comm = new SqlCommand(proname, conn))
                {
                    try
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@n", num);
                        comm.Parameters.AddWithValue("@m", num2);
                        comm.ExecuteNonQuery();
                        b = true;
                    }
                    catch (System.Exception pro)
                    {
                       ErroLog(pro.Message);
                    }
                }
                conn.Close();
            }
            return b;

        }
        public bool COM_Proc_DelorUp_3(string proname, string num, string num2, string num3)
        {
            bool b = false;
            using (SqlConnection conn = getconn())
            {

                conn.Open();
                using (SqlCommand comm = new SqlCommand(proname, conn))
                {
                    try
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@n", num);
                        comm.Parameters.AddWithValue("@m", num2);
                        comm.Parameters.AddWithValue("@f", num3);
                        comm.ExecuteNonQuery();
                        b = true;
                    }
                    catch (System.Exception pro)
                    {
                       ErroLog(pro.Message);
                    }
                }
                conn.Close();
            }
            return b;
        }
        #endregion
            
        #region 过滤重复字符串，以“,”为割
        public static string filtering(string str0)
        {
            string _str = string.Empty;
            string[] strArray = str0.Split(',');

            for (int i = 0; i < strArray.Length; i++)
            {
                for (int j = i + 1; j < strArray.Length; j++)
                {
                    if (strArray[j] == strArray[i])
                    {
                        strArray[i] = string.Empty;
                    }
                }
                if (strArray[i] != string.Empty)
                    _str += strArray[i] + ",";
            }
            if (_str.LastIndexOf(",") > -1)
            {
                _str = _str.Substring(0, _str.Length - 1);
            }
            return _str;
        }
        #endregion
        public void ErroLog(string message)
        {
            string filepath = System.Web.HttpContext.Current.Server.MapPath("/_log/errolog.txt");
            if (File.Exists(filepath))
            {
                StreamWriter sr = File.AppendText(filepath);

                sr.WriteLine("\t" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t");
                sr.WriteLine(message);
                sr.WriteLine("---------------------------------------------------------------------------------------------------");
                sr.Close();
                sr.Dispose();
            }
            else
            {
                StreamWriter sr = File.CreateText(filepath);
                sr.Close();
                sr.Dispose();
            }
        }

        public  string getsid(string _params)
        {
            string id = "-1";
            if (System.Web.HttpContext.Current.Request.QueryString[_params] != null && System.Web.HttpContext.Current.Request.QueryString[_params].ToString().Length != 0)
                {
                    id = System.Web.HttpContext.Current.Request.QueryString[_params].ToString();
                }
            return id;
        }
    }
}
