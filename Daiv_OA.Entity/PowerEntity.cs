using System;
namespace Daiv_OA.Entity
{
    /// <summary>
    /// ʵ����Power��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PowerEntity
    {
        public PowerEntity()
        { }
        #region Model
        private int _pid;
        private string _pname;
        private string _setting;
        /// <summary>
        /// ��ɫID���������ֵȼ�
        /// </summary>
        public int Pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// ��ɫ
        /// </summary>
        public string PName
        {
            set { _pname = value; }
            get { return _pname; }
        }
        /// <summary>
        /// Ȩ���б�
        /// </summary>
        public string Setting
        {
            set { _setting = value; }
            get { return _setting; }
        }
        #endregion Model

    }
}

