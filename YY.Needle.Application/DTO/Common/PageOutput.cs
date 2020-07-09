using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YY.Needle.Application.DTO.Common
{
    public class PageOutput<TEntity>
    {
        public IEnumerable<TEntity> PageList;
        public int Total;
    }
}
