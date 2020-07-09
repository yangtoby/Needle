using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Domain.Entities;
using YY.Needle.Domain.Interfaces.Service.Common;

namespace YY.Needle.Domain.Interfaces.Service
{
    public interface ILottery3DService : IService<Lottery3D>
    {
        IEnumerable<Lottery3D> GetPage(int pageSize, int pageIndex, out int total);

    }
}
