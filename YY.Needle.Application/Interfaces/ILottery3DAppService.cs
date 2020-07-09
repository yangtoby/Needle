using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Application.DTO.Common;
using YY.Needle.Application.Interfaces.Common;
using YY.Needle.Domain.Entities;

namespace YY.Needle.Application.Interfaces
{
    public interface ILottery3DAppService : IAppService<Lottery3D>
    {
        PageOutput<Lottery3D> GetPage(int pageSize, int pageIndex, out int total);
    }
}
