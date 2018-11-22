using System;
namespace Daiv_OA.Entity
{
    /// <summary>
    /// 实体类Message 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MessageEntity
    {
        public MessageEntity()
        { }
        #region Model
        private int _mid;
        private int _touid;
        private string _touname;
        private int _fromuid;
        private string _fromuname;
        private string _mtitle;
        private string _content;
        private DateTime _addtime;
        private int _isread;
        private string _touser;
        /// <summary>
        /// 
        /// </summary>
        public int Mid
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ToUid
        {
            set { _touid = value; }
            get { return _touid; }
        }
        public string ToUname
        {
            set { _touname = value; }
            get { return _touname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FromUid
        {
            set { _fromuid = value; }
            get { return _fromuid; }
        }
        public string FromUname
        {
            set { _fromuname = value; }
            get { return _fromuname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mtitle
        {
            set { _mtitle = value; }
            get { return _mtitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsRead
        {
            set { _isread = value; }
            get { return _isread; }
        }

        /// <summary>
        /// 信息接接收者
        /// </summary>
        public string Touser
        {
            set { _touser = value; }
            get { return _touser; }
        }
        #endregion Model

    }
}

