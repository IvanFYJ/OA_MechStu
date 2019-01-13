using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daiv_OA.Entity
{
    public class WXUserEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public System.Int32 ID { set; get; }
        /// <summary>
        /// 微信用户OpenId
        /// </summary>
        public System.String OpenId { set; get; }
        /// <summary>
        /// 微信用户手机号
        /// </summary>
        public System.String WXUserPhone { set; get; }
        /// <summary>
        /// OA系统ID
        /// </summary>
        public System.Int32 OAUserID { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { set; get; }
        /// <summary>
        /// 删除标志
        /// </summary>
        public System.Int32 IsDeleted { set; get; }
    }
}
