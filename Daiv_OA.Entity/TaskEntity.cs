using System;
namespace Daiv_OA.Entity
{
	/// <summary>
	/// 实体类Task 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class TaskEntity
	{
		public TaskEntity()
		{}
		#region Model
		private int _tlid;
		private int _uid;
		private string _manager;
		private string _tasktitle;
		private string _content;
		private DateTime _nowtime;
		private DateTime _plantime;
		private string _ttype;
        private DateTime _worktime;
        private int _workprogress;
        private string _workstate;
        private int _sumtime;//
        private int _progresstime;
        private string _classse;
        private string _remark;
        private string _newnote;
        private string _filepath;//附件
        private string _question;//要求

        public string Filepath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        public string Question
        {
            set { _question = value; }
            get { return _question; }
        }

        public int Sumtime
        {
            set { _sumtime = value; }
            get { return _sumtime; }
        }
        public int Progresstime
        {
            set { _progresstime = value; }
            get { return _progresstime; }
        }
        public string Classse
        {
            set { _classse = value; }
            get { return _classse; }
        }
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        public string Newnote
        {
            set { _newnote = value; }
            get { return _newnote; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int Tlid
		{
			set{ _tlid=value;}
			get{return _tlid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string Manager
		{
			set{ _manager=value;}
			get{return _manager;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tasktitle
		{
			set{ _tasktitle=value;}
			get{return _tasktitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Nowtime
		{
			set{ _nowtime=value;}
			get{return _nowtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Plantime
		{
			set{ _plantime=value;}
			get{return _plantime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ttype
		{
			set{ _ttype=value;}
			get{return _ttype;}
		}
        public DateTime Worktime
        {
            set { _worktime = value; }
            get { return _worktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Workprogress
        {
            set { _workprogress = value; }
            get { return _workprogress; }
        }
        public string Workstate
        {
            set { _workstate = value; }
            get { return _workstate; }
        }
		#endregion Model

	}
}

