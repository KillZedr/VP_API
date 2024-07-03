using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShop.Domain.ECommerce;

namespace VapeShop.Application.VapeShop_DAL.EntityTypeConfigurations.ECommerce
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasOne(feed => feed.Product).WithMany(prod => prod.Feedbacks);
            builder.HasOne(feed => feed.User).WithMany(u =>  u.Feedbacks);
        }
    }
}
