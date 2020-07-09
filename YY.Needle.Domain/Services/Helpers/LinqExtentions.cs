using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YY.Needle.Domain.Services.Helpers
{
    public static class LinqExtentions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }
    }
}
