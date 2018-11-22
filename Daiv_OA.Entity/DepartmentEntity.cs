using System;
namespace Daiv_OA.Entity
{
    /// <summary>
    /// 实体类Department 。(属性说明自动提取数据库字段的描述信息)
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
        /// 部门ID，用于区分权限
        /// </summary>
        public int Did
        {
            set { _did = value; }
            get { return _did; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string DName
        {
            set { _dname = value; }
            get { return _dname; }
        }
        #endregion Model

    }
}

