using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YY.Needle.Domain.Entities
{
    public class Lottery3D
    {
        public int Id { get; set; }
        /// <summary>
        /// 期号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 中奖号码
        /// </summary>
        public string AllChar { get; set; }
        /// <summary>
        /// 百位
        /// </summary>
        public string FirstChar { get; set; }
        /// <summary>
        /// 十位
        /// </summary>
        public string SecondChar { get; set; }
        /// <summary>
        /// 个位
        /// </summary>
        public string ThirdChar { get; set; }
        /// <summary>
        /// 开奖日期
        /// </summary>
        public DateTime DrawDate { get; set; }
    }
}
