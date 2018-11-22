using System;
using System.Collections.Generic;
using System.Text;

namespace Daiv_OA.BLL
{
    public class AllTimeBLL
    {
        private readonly DAL.AllTimeDAL dal = new DAL.AllTimeDAL();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        public List<Entity.AllTimeEntity> getpage(int pageSize, int pageNum, out int count, string str)
        {
            return dal.getpage(pageSize, pageNum, out count, str);
        }
    }
}
