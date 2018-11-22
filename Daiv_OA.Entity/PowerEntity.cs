using System;
namespace Daiv_OA.Entity
{
    /// <summary>
    /// 实体类Power。(属性说明自动提取数据库字段的描述信息)
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
        /// 角色ID，用于区分等级
        /// </summary>
        public int Pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 角色
        /// </summary>
        public string PName
        {
            set { _pname = value; }
            get { return _pname; }
        }
        /// <summary>
        /// 权限列表
        /// </summary>
        public string Setting
        {
            set { _setting = value; }
            get { return _setting; }
        }
        #endregion Model

    }
}

