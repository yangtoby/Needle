using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YY.Needle.Domain.DTO.Average3D
{
    public class GetEchartsBarOutput
    {
        public List<EChartsBarDto> TwoEchartsBar { get; set; } = new List<EChartsBarDto>();
        public List<EChartsBarDto> FourEchartsBar { get; set; } = new List<EChartsBarDto>();
        public List<EChartsBarDto> EightEchartsBar { get; set; } = new List<EChartsBarDto>();
    }
}
