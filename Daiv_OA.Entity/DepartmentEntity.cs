using System;
namespace Daiv_OA.Entity
{
    /// <summary>
    /// ʵ����Department ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class DepartmentEntity
    {
        public DepartmentEntity()
        { }
        #region Model
        private int _did;
        private string _dname;
        /// <summary>
        /// ����ID����������Ȩ��
        /// </summary>
        public int Did
        {
            set { _did = value; }
            get { return _did; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string DName
        {
            set { _dname = value; }
            get { return _dname; }
        }
        #endregion Model

    }
}

