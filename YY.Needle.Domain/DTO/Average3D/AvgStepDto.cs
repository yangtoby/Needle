using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YY.Needle.Domain.DTO.Average3D
{
    public class AvgStepDto
    {
        /// <summary>
        /// 步长的值
        /// </summary>
        public int AverageStep { get; set; }
        /// <summary>
        /// 步长统计数量
        /// </summary>
        public int AvgStepCount { get; set; }

        /// <summary>
        /// 每个步长所占比例
        /// </summary>
        public double Percent { get; set; }

        public string PercentStr { get { return Percent.ToString("p4"); } }
    }
}
