using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daiv_OA.Entity
{
    /// <summary>
    /// 家长留言类
    /// </summary>
    public class ParentMessageEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public System.Int32 Mid { set; get; }
        /// <summary>
        /// 接收方ID
        /// </summary>
        public System.Int32 ToUid { set; get; }
        /// <summary>
        /// 发送方ID
        /// </summary>
        public System.Int32 FromUid { set; get; }
        /// <summary>
        /// 标题
        public System.String Mtitle { set; get; }
        /// <summary>
        /// 内容
        /// </summary>
        public System.String Content { set; get; }
        /// <summary>
        /// 是否读取
        /// </summary>
        public System.Int32? IsRead { set; get; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime? Addtime { set; get; }
        /// <summary>
        /// 接收方名称
        /// </summary>
        public System.String Touser { set; get; }
        /// <summary>
        /// 删除标志
        /// </summary>
        public System.Int32? IsDeleted { set; get; }
    }
}
