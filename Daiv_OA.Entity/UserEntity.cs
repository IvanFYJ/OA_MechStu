using System;
namespace Daiv_OA.Entity
{

    /// <summary>
    /// ʵ����User ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class UserEntity
    {
        public UserEntity()
        { }
        #region Model
        private int _uid;
        private int _pid;
        private int _did;
        private string _uname;
        private string _upwd;
        private string _uipaddress;
        private string _position;
        private string _setting;
        private int _uclassid;
        private string _uclassname;
        private string _mphone;
        private int _isdeleted;
        private string _ulongname;
        /// <summary>
        /// �û�ID
        /// </summary>
        public int Uid
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// ��ɫID
        /// </summary>
        public int Pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// ����ID
        /// </summary>
        public int Did
        {
            set { _did = value; }
            get { return _did; }
        }
        /// <summary>
        /// �û���
        /// </summary>
        public string Uname
        {
            set { _uname = value; }
            get { return _uname; }
        }
        /// <summary>
        /// 32λ��������
        /// </summary>
        public string Upwd
        {
            set { _upwd = value; }
            get { return _upwd; }
        }
        /// <summary>
        /// ����IP
        /// </summary>
        public string Uipaddress
        {
            set { _uipaddress = value; }
            get { return _uipaddress; }
        }
        /// <summary>
        /// ְλ
        /// </summary>
        public string Position
        {
            set { _position = value; }
            get { return _position; }
        }
        /// <summary>
        /// Ȩ���б�
        /// </summary>
        public string Setting
        {
            set { _setting = value; }
            get { return _setting; }
        }
        /// <summary>
        /// �༶ID
        /// </summary>
        public int UClassID
        {
            set { _uclassid = value; }
            get { return _uclassid; }
        }
        /// <summary>
        /// �༶����
        /// </summary>
        public string UClassName
        {
            set { _uclassname = value; }
            get { return _uclassname; }
        }
        /// <summary>
        /// �豸�绰����
        /// </summary>
        public string Mphone
        {
            set { _mphone = value; }
            get { return _mphone; }
        }
        /// <summary>
        /// �û�����
        /// </summary>
        public string ULongName
        {
            set { _ulongname = value; }
            get { return _ulongname; }
        }
        /// <summary>
        /// ɾ����־
        /// </summary>
        public int IsDeleted
        {
            set { _isdeleted = value; }
            get { return _isdeleted; }
        }
        #endregion Model

    }
}

