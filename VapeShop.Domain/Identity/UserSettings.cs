using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain.Identity
{
    public class UserSettings : IEntityWithOwnId
    {
        public required User User { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public required bool DarkThemeEnabled { get; set; }
    }
}
