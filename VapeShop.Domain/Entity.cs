using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Domain
{
    public class Entity <TIdentifier> : IEntity
    {
        public TIdentifier? Id { get; set; }
    }
}
