using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Domain.Entities;
using YY.Needle.Domain.Interfaces.Repository;
using YY.Needle.Domain.Interfaces.Repository.ReadOnly;
using YY.Needle.Domain.Interfaces.Service;
using YY.Needle.Domain.Services.Common;

namespace YY.Needle.Domain.Services
{
    public class Lottery3DService : Service<Lottery3D>, ILottery3DService
    {
        public Lottery3DService(ILottery3DRepository repository)
            : base(repository)
        {
        }
        public IEnumerable<Lottery3D> GetPage(int pageSize, int pageIndex, out int total)
        {
            var result = this.All().OrderByDescending(m => m.DrawDate)
                 .Skip((pageIndex - 1) * pageSize)
                 .Take(pageSize).ToList();
            total = this.All().Count();
            return result;
        }
    }
}
