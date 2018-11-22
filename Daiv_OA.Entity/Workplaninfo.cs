using System;
namespace Daiv_OA.Entity
{
	/// <summary>
	/// 实体类Workplaninfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Workplaninfo
	{
		public Workplaninfo()
		{}
		#region Model
		private int _wid;
		private int _uid;
		private DateTime _wdate;
		private string _wtext;
		/// <summary>
		/// 
		/// </summary>
		public int Wid
		{
			set{ _wid=value;}
			get{return _wid;}
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
		public DateTime Wdate
		{
			set{ _wdate=value;}
			get{return _wdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wtext
		{
			set{ _wtext=value;}
			get{return _wtext;}
		}
		#endregion Model

	}
}

