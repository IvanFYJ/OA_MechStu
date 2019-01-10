using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daiv_OA.Entity
{
    public class MechanicalEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public System.Int32 ID { set; get; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public System.String MechName { set; get; }
        /// <summary>
        /// 设备序列号
        /// </summary>
        public System.String MechIMEI { set; get; }
        /// <summary>
        /// 设备电话号码
        /// </summary>
        public System.String MechPhone { set; get; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public System.String ClassName { set; get; }
        /// <summary>
        /// 班级ID
        /// </summary>
        public System.Int32 Gid { set; get; }
        /// <summary>
        /// 删除标志
        /// </summary>
        public System.Int32 IsDeleted { set; get; }
    }
    
}
