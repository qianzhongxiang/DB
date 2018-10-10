using System;

namespace EFExtention
{
    public class LogicEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        /// <value></value>
        public Guid Id { get; set; }
        /// <summary>
        /// 创建的时间
        /// </summary>
        /// <value></value>
        public DateTime? CreatedTime { get; set; }
        /// <summary>
        /// 修改的时间
        /// </summary>
        /// <value></value>
        public DateTime? UpdatedTime { get; set; }
    }
}