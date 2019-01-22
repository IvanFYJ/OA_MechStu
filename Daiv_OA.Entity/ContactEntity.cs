using System;
using System.Collections.Generic;
using System.Text;

namespace Daiv_OA.Entity
{
    /// <summary>
    /// 家长联系电话类
    /// </summary>
    public class ContactEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public System.Int32 Cid { set; get; }
        /// <summary>
        /// 学生ID
        /// </summary>
        public System.Int32 Sid { set; get; }
        /// <summary>
        /// 联系电话1
        /// </summary>
        public System.String Cphone { set; get; }
        /// <summary>
        /// 联系电话2
        /// </summary>
        public System.String Cphone2 { set; get; }
        /// <summary>
        /// 联系电话3
        /// </summary>
        public System.String Cphone3 { set; get; }
        /// <summary>
        /// 联系电话4
        /// </summary>
        public System.String Cphone4 { set; get; }
        /// <summary>
        /// 黑名单标志
        /// </summary>
        public System.Int32? Cblacklistflag { set; get; }
        /// <summary>
        /// 删除标志
        /// </summary>
        public System.Int32? IsDeleted { set; get; }

        /// <summary>
        /// 联系人名称
        /// </summary>
        public System.String CPhoneName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreatDate { get; set; }
    }
}
