using System;
using System.Collections.Generic;
using System.Text;

namespace Daiv_OA.Entity
{
    public class StudentEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public System.Int32 Sid { set; get; }
        /// <summary>
        /// 学生学号
        /// </summary>
        public System.String Snumber { set; get; }
        /// <summary>
        /// 学生名称
        /// </summary>
        public System.String Sname { set; get; }
        /// <summary>
        /// 班级ID
        /// </summary>
        public System.Int32 Gid { set; get; }
        /// <summary>
        /// 家长账号
        /// </summary>
        public System.Int32 Uid { set; get; }
        /// <summary>
        /// 出生时间
        /// </summary>
        public System.DateTime Sbirthday { set; get; }
        /// <summary>
        /// 删除标志
        /// </summary>
        public System.Int32 IsDeleted { set; get; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public System.String Gname { set; get; }
        /// <summary>
        /// 设备管理员账号
        /// 对应添加改学生信息的人员账号
        /// </summary>
        public System.Int32 MechID { set; get; }
    }
}
