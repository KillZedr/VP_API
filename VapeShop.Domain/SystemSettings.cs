using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain
{
    public class SystemSettings
    {
        public required string Name { get; set; }
        public required string Value { get; set; }
    }
}
