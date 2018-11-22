using System;
using System.Collections.Generic;
using System.Text;

namespace Daiv_OA.Entity
{
    public class AllPlanEntity
    {
        public AllPlanEntity()
        { }
        #region Model
        private int _pwid;
        private string _uname;
        private string _pwtitle;
        private DateTime _pwdate;
        private string _pwpath;
        private string _locked;
        private string _manager;
        /// <summary>
        /// 
        /// </summary>
        public int Pwid
        {
            set { _pwid = value; }
            get { return _pwid; }
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
        public string Pwtitle
        {
            set { _pwtitle = value; }
            get { return _pwtitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Pwdate
        {
            set { _pwdate = value; }
            get { return _pwdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pwpath
        {
            set { _pwpath = value; }
            get { return _pwpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Locked
        {
            set { _locked = value; }
            get { return _locked; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Manager
        {
            set { _manager = value; }
            get { return _manager; }
        }
        #endregion Model
    }
}
