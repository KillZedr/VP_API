using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop_BLL.Services.SystemSettings
{
    internal class SettingsUpdateException : Exception
    {
        public SettingsUpdateException(string? message) : base(message)
        {

        }
    }
}
