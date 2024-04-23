using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeShop.Application.VapeShop_DAL.RealisationInterfaces
{
    public class VapeShop_DbContext : DbContext
    {
        public VapeShop_DbContext(DbContextOptions<VapeShop_DbContext> options) : base (options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

    }
}
