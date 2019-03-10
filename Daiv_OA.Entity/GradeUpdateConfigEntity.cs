using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daiv_OA.Entity
{
    public class GradeUpdateConfigEntity
    {

        /// <summary>
        /// 主键ID
        /// </summary>
        public System.Int32 ID { set; get; }
        /// <summary>
        /// 当前年级ID
        /// </summary>
        public System.Int32 CurrGradeID { set; get; }
        /// <summary>
        /// 升级年级ID
        /// </summary>
        public System.Int32 UpGradeID { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateDate { set; get; }
        /// <summary>
        /// 创建人
        /// </summary>
        public System.Int32 CreateUserID { set; get; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public System.DateTime ModifyDate { set; get; }
        /// <summary>
        /// 修改人
        /// </summary>
        public System.Int32 ModifyUserID { set; get; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public System.DateTime DeleteDate { set; get; }
        /// <summary>
        /// 删除人
        /// </summary>
        public System.Int32 DeleteUserID { set; get; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public System.Int32 IsDeleted { set; get; }
    }
}
