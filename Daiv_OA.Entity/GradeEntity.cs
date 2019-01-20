namespace Daiv_OA.Entity
{
    public class GradeEntity
    {
        public GradeEntity()
        { }

        private int _gid;
        private string _gname;
        private string _gdescription;
        private int _gsnumber;
        private int _isdeleted;
        private string _ggradename;
        private int _methid;
        private string _mphone;
        private int _ggradeid;

        /// <summary>
        /// 班级ID
        /// </summary>
        public int Gid
        {
            set { _gid = value; }
            get { return _gid; }
        }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string Gname
        {
            set { _gname = value; }
            get { return _gname; }
        }
        /// <summary>
        /// 班级人数
        /// </summary>
        public int Gsnumber
        {
            set { _gsnumber = value; }
            get { return _gsnumber; }
        }
        /// <summary>
        /// 班级描述
        /// </summary>
        public string Gdescription
        {
            set { _gdescription = value; }
            get { return _gdescription; }
        }
        /// <summary>
        /// 删除标志
        /// </summary>
        public int IsDeleted
        {
            set { _isdeleted = value; }
            get { return _isdeleted; }
        }
        /// <summary>
        /// 年级名称
        /// </summary>
        public string GgradeName
        {
            set { _ggradename = value; }
            get { return _ggradename; }
        }
        /// <summary>
        /// 设备电话号码
        /// </summary>
        public string Mphone
        {
            set { _mphone = value; }
            get { return _mphone; }
        }
        /// <summary>
        /// 删除标志
        /// </summary>
        public int MechID
        {
            set { _methid = value; }
            get { return _methid; }
        }
        /// <summary>
        /// 班级ID
        /// </summary>
        public int GgradeID
        {
            set { _ggradeid = value; }
            get { return _ggradeid; }
        }
    }
}