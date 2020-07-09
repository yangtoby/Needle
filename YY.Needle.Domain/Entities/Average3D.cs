using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YY.Needle.Domain.Entities
{
    public class Average3D
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
        /// 开奖日期
        /// </summary>
        public DateTime DrawDate { get; set; }

        /// <summary>
        /// 2分法value 1:0~459,2:500~999
        /// </summary>
        public int TwoAvG { get; set; }
        /// <summary>
        /// 距离下一次出现的次数
        /// </summary>
        public int TwoStep { get; set; }
        /// <summary>
        /// 4分法Value 1:0~249,2:250~499,3:500~749,4:750~999
        /// </summary>
        public int FourAvg { get; set; }
        public int FourStep { get; set; }
        /// <summary>
        /// 8分法 1:0~124,1:125~249,2:250~374,3:375~499,5:500~624,6:625~749,7:750~874,8:875~999
        /// </summary>
        public int EightAvg { get; set; }
        public int EightStep { get; set; }
    }
}
