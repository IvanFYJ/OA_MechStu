using System;
using System.Collections.Generic;
using System.Text;

namespace Daiv_OA.Entity
{
    public class AllSummarizeEntity
    {
        public AllSummarizeEntity()
        { }
        #region Model
        private int _suid;
        private string _sutitle;
        private string _uname;
        private string _sutext;
        private DateTime _sutime;
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
        public string Uname
        {
            set { _uname = value; }
            get { return _uname; }
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
        #endregion Model
    }
}
