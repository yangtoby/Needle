using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Application.DTO.Common;
using YY.Needle.Application.Interfaces.Common;
using YY.Needle.Domain.DTO.Average3D;
using YY.Needle.Domain.Entities;

namespace YY.Needle.Application.Interfaces
{
    public interface IAverage3DAppService: IAppService<Average3D>
    {
        PageOutput<Average3D> GetPage(int pageSize, int pageIndex, out int total);
        void RunAverage();
        GetEchartsBarOutput GetEchartsBarTwo();
        List<AvgStepDto> GetStepList(StepEnum stepName);
    }
}
