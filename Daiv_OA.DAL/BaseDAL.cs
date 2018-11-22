using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Daiv_OA.Entity;
namespace Daiv_OA.DAL
{
    public class BaseDAL
    {
        private SqlCommand sqlCmd = null;
        private SqlTransaction sqlTrans = null;

        public BaseDAL()
        {

        }

        /// <summary>
        /// 取记录列表（不返回记录数）
        /// </summary>
        /// <param name="pageListModel"></param>
        /// <returns></returns>
        public DataSet GetList(PageListModel pageListModel)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@select_list", SqlDbType.VarChar, 1000),
                    new SqlParameter("@table_name",SqlDbType.VarChar,3000),
                    new SqlParameter("@where", SqlDbType.VarChar,8000),
					new SqlParameter("@primary_key", SqlDbType.VarChar,100),
                	new SqlParameter("@order_by", SqlDbType.VarChar,100),
					new SqlParameter("@page_size", SqlDbType.Int),
					new SqlParameter("@page_index", SqlDbType.Int),
					new SqlParameter("@bl_page", SqlDbType.Int),
                    new SqlParameter("@flag", SqlDbType.Int),
					};
            parameters[0].Value = pageListModel.SelectList;
            parameters[1].Value = pageListModel.Tables;
            parameters[2].Value = pageListModel.StrWhere;
            parameters[3].Value = pageListModel.PriKey;
            parameters[4].Value = pageListModel.OrderByField;
            parameters[5].Value = pageListModel.PageSize;
            parameters[6].Value = pageListModel.PageIndex;
            parameters[7].Value = pageListModel.BlPage;
            parameters[8].Value = pageListModel.Flag;
            return Itemsql.RunProcedure("UP_Common_PageList", parameters, "ds");
        }

        /// <summary>
        ///  取记录列表（返回记录数）
        /// </summary>
        /// <param name="pageListModel"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public DataSet GetList(PageListModel pageListModel, ref int rowCount)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@select_list", SqlDbType.VarChar, 1000),
                    new SqlParameter("@table_name",SqlDbType.VarChar,3000),
                    new SqlParameter("@where", SqlDbType.VarChar,8000),
					new SqlParameter("@primary_key", SqlDbType.VarChar,100),
                	new SqlParameter("@order_by", SqlDbType.VarChar,100),
					new SqlParameter("@page_size", SqlDbType.Int),
					new SqlParameter("@page_index", SqlDbType.Int),
					new SqlParameter("@bl_page", SqlDbType.Int),
                    new SqlParameter("@flag", SqlDbType.Int),
	                new SqlParameter("@return_Value", SqlDbType.Int),	
					};
            parameters[0].Value = pageListModel.SelectList;
            parameters[1].Value = pageListModel.Tables;
            parameters[2].Value = pageListModel.StrWhere;
            parameters[3].Value = pageListModel.PriKey;
            parameters[4].Value = pageListModel.OrderByField;
            parameters[5].Value = pageListModel.PageSize;
            parameters[6].Value = pageListModel.PageIndex;
            parameters[7].Value = pageListModel.BlPage;
            parameters[8].Value = pageListModel.Flag;
            parameters[9].Direction = ParameterDirection.ReturnValue;
            return Itemsql.RunProcedure("UP_Common_PageList", parameters, "ds", out rowCount);
        }
        /// <summary>
        /// 更新所有的视图
        /// </summary>
        public void UpdateAllView()
        {
            int rowsAffected;
            SqlParameter[] parameters = { };
            Itemsql.RunProcedure("UP_UpdateAllView", parameters, out rowsAffected);
        }
        /// <summary>
        /// 执行存储过程SP_PlanKC
        /// </summary>
        /// <param name="PlanID"></param>
        /// <param name="KcID"></param>
        /// <param name="Other"></param>
        /// <param name="OtherID"></param>
        public void RunPlanKc(string PlanID, string KcID, string Other, string OtherID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@PlanID",PlanID),
                    new SqlParameter("@KcID",KcID),
                    new SqlParameter("@Other",Other),
                	new SqlParameter("@OtherID",OtherID),			
					};
            Itemsql.RunProcedureVoid("SP_PlanKC", parameters);
        }

    }
}
