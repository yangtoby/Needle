using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YY.Needle.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string AccountName { get; set; }
        public string Pwd { get; set; }
    }
}
