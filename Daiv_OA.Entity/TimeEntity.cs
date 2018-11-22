using System;
namespace Daiv_OA.Entity
{
    /// <summary>
    /// 实体类Time 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class TimeEntity
    {
        public TimeEntity()
        { }
        #region Model
        private int _tid;
        private int _uid;
        private DateTime _retime;
        private DateTime _nowtime;
        private string _timetype;
        private string _ipaddress;
        private string _timeinfo;
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
        public int Uid
        {
            set { _uid = value; }
            get { return _uid; }
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
        #endregion Model

    }
}

