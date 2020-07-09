using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YY.Needle.Domain.Entities;

namespace YY.Needle.Data.Context.Mapping
{
    public class Average3DMap: EntityTypeConfiguration<Average3D>
    {
       public Average3DMap()
        {
            HasKey(t => t.Id);
        }
    }
}
