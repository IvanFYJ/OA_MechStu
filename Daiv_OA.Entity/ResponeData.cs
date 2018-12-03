using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daiv_OA.Entity
{
    public class ResponeData
    {
        /// <summary>
        /// 数据状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 操作信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 查询数据
        /// </summary>
        public object Data { get; set; }
    }
}
