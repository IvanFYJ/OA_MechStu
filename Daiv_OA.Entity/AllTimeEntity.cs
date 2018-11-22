using System;
using System.Collections.Generic;
using System.Text;

namespace Daiv_OA.Entity
{
    /// <summary>
    /// 实体类Alltime 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class AllTimeEntity
    {
        public AllTimeEntity()
        { }
        #region Model
        private int _tid;
        private DateTime _retime;
        private DateTime _nowtime;
        private string _timetype;
        private string _ipaddress;
        private string _timeinfo;
        private string _uname;
        /// <summary>
        /// 
        /// </summary>
        public int Tid
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Retime
        {
            set { _retime = value; }
            get { return _retime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Nowtime
        {
            set { _nowtime = value; }
            get { return _nowtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Timetype
        {
            set { _timetype = value; }
            get { return _timetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Ipaddress
        {
            set { _ipaddress = value; }
            get { return _ipaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Timeinfo
        {
            set { _timeinfo = value; }
            get { return _timeinfo; }
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
