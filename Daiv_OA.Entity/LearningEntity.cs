using System;
namespace Daiv_OA.Entity
{
	/// <summary>
	/// 实体类StudyInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class LearningEntity
	{
		public LearningEntity()
		{}
		#region Model
		private int _sid;
		private string _stitle;
		private string _sauthor;
		private DateTime _sdate;
		private string _spath;
        private int _did;
		/// <summary>
		/// 
		/// </summary>
		public int Sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Stitle
		{
			set{ _stitle=value;}
			get{return _stitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sauthor
		{
			set{ _sauthor=value;}
			get{return _sauthor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Sdate
		{
			set{ _sdate=value;}
			get{return _sdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Spath
		{
			set{ _spath=value;}
			get{return _spath;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int Did
        {
            set { _did = value; }
            get { return _did; }
        }
		#endregion Model

	}
}

