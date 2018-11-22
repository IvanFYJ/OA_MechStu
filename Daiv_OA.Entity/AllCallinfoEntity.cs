using System;
using System.Collections.Generic;
using System.Text;

namespace Daiv_OA.Entity
{
    /// <summary>
    /// 实体类AllCallinfo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class AllCallinfoEntity
    {
        public AllCallinfoEntity()
        { }
        #region Model
        private int _id;
        private DateTime _addtime;
        private string _title;
        private string _unit;
        private string _userinfo;
        private string _uname;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Userinfo
        {
            set { _userinfo = value; }
            get { return _userinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Uname
        {
            set { _uname = value; }
            get { return _uname; }
        }
        #endregion Model

    }
}
