using System;
namespace Daiv_OA.Entity
{
    /// <summary>
    /// ʵ����Message ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PlacardEntity
    {
        public PlacardEntity()
        { }
        #region Model
        private int _pid;
        private string _ptitle;
        private string _pauthor;
        private DateTime _pdate;
        private string _ptext;
        /// <summary>
        /// 
        /// </summary>
        public int Pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Ptitle
        {
            set { _ptitle = value; }
            get { return _ptitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pauthor
        {
            set { _pauthor = value; }
            get { return _pauthor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Pdate
        {
            set { _pdate = value; }
            get { return _pdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Ptext
        {
            set { _ptext = value; }
            get { return _ptext; }
        }
        #endregion Model

    }
}

