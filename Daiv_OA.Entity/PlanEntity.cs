using System;
namespace Daiv_OA.Entity
{
    /// <summary>
    /// 实体类Plan。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PlanEntity
    {
        public PlanEntity()
        { }
        #region Model
        private int _pwid;
        private int _uid;
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
        public int Uid
        {
            set { _uid = value; }
            get { return _uid; }
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

