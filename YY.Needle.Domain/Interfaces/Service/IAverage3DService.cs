using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Domain.DTO.Average3D;
using YY.Needle.Domain.Entities;
using YY.Needle.Domain.Interfaces.Service.Common;

namespace YY.Needle.Domain.Interfaces.Service
{
    public interface IAverage3DService:IService<Average3D>
    {
        IEnumerable<Average3D> GetPage(int pageSize, int pageIndex, out int total);

        void RunAverage();
        GetEchartsBarOutput GetEchartsBarTwo();
        List<AvgStepDto> GetStepList(StepEnum stepName);
    }
}
