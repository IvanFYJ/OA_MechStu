using System;
namespace Daiv_OA.Entity
{
	/// <summary>
	/// 实体类Callinfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class CallinfoEntity
	{
		public CallinfoEntity()
		{}
		#region Model
		private int _id;
		private int _uid;
		private string _userinfo;
		private string _title;
		private string _unit;
		private DateTime _addtime;
		private string _reply;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
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
        public string Userinfo
		{
			set{ _userinfo=value;}
			get{return _userinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Reply
		{
			set{ _reply=value;}
			get{return _reply;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

