using System;
namespace Daiv_OA.Entity
{
    /// <summary>
    /// 实体类Summarize 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class SummarizeEntity
    {
        public SummarizeEntity()
        { }
        #region Model
        private int _suid;
        private string _sutitle;
        private int _uid;
        private string _sutext;
        private DateTime _sutime;
        private int _locked;
        /// <summary>
        /// 
        /// </summary>
        public int Suid
        {
            set { _suid = value; }
            get { return _suid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sutitle
        {
            set { _sutitle = value; }
            get { return _sutitle; }
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
        public string Sutext
        {
            set { _sutext = value; }
            get { return _sutext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Sutime
        {
            set { _sutime = value; }
            get { return _sutime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Locked
        {
            set { _locked = value; }
            get { return _locked; }
        }
        #endregion Model

    }
}

