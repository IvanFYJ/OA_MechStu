using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daiv_OA.Entity
{
    public class SchoolEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public System.Int32 ID { set; get; }
        /// <summary>
        /// 学校名称
        /// </summary>
        public System.String Name { set; get; }
        /// <summary>
        /// 地址
        /// </summary>
        public System.String Address { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateDate { set; get; }

        /// <summary>
        /// 学校编号
        /// </summary>
        public System.String SchoolSerie { set; get; }
        /// <summary>
        /// 删除标志
        /// </summary>
        public System.Int32 IsDeleted { set; get; }
    }
}
