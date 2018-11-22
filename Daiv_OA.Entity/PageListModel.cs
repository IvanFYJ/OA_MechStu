using System;
using System.Collections.Generic;
using System.Text;

namespace Daiv_OA.Entity
{
    /// <summary>
    /// 分页model
    /// </summary>
    public class PageListModel
    {
        private string _selectList;
        private string _tables;
        private string _strWhere;
        private string _priKey;
        private string _orderByField;
        private int _pageSize;
        private int _pageIndex;
        private int _blPage;
        private int _flag;


        /// <summary>
        /// 构造函数，默认不分页
        /// </summary>
        public PageListModel()
        {
            _selectList = " ";
            _tables = " ";
            _strWhere = "";
            _priKey = " ";
            _orderByField = " ";
            _pageSize = 10;
            _pageIndex = 1;
            _blPage = 0;
            _flag = 0;
        }


        /// <summary>
        /// 待检索的字段
        /// </summary>
        public string SelectList
        {
            get { return _selectList; }
            set { _selectList = value; }
        }
        /// <summary>
        /// 检索的表名，多表以逗号分割
        /// </summary>
        public string Tables
        {
            get { return _tables; }
            set { _tables = value; }
        }

        /// <summary>
        /// 检索的where条件，不加"where"
        /// </summary>
        public string StrWhere
        {
            get { return _strWhere; }
            set { _strWhere = value; }
        }

        /// <summary>
        /// 检索的主键
        /// </summary>
        public string PriKey
        {
            get { return _priKey; }
            set { _priKey = value; }
        }

        /// <summary>
        /// 排序字段,多个排序以逗号分割，不加" order by "
        /// </summary>
        public string OrderByField
        {
            get { return _orderByField; }
            set { _orderByField = value; }
        }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// 当前页索引
        /// </summary>
        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        /// <summary>
        /// 是否分页 1、分页；0、不分页
        /// </summary>
        public int BlPage
        {
            get { return _blPage; }
            set { _blPage = value; }
        }
        /// <summary>
        /// 标记（groupby 1）
        /// </summary>
        public int Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
    }
}
