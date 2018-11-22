using System;
using System.Collections.Generic;
using System.Text;

namespace Daiv_OA.Entity
{
    /// <summary>
    /// 实体类Operatelog 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class OperatelogEntity
    {
        public OperatelogEntity()
        { }
        #region Model
        private int _elselogid;
        private string _eupdatetitle;
        private DateTime _eupadatetime;
        private string _eupdatetype;
        private int _uid;
        private string _uname;
        /// <summary>
        /// 
        /// </summary>
        public int Operatelogid
        {
            set { _elselogid = value; }
            get { return _elselogid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Eupdatetitle
        {
            set { _eupdatetitle = value; }
            get { return _eupdatetitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Eupadatetime
        {
            set { _eupadatetime = value; }
            get { return _eupadatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Eupdatetype
        {
            set { _eupdatetype = value; }
            get { return _eupdatetype; }
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
        public string Uname
        {
            set { _uname = value; }
            get { return _uname; }
        }
        #endregion Model
    }
}
