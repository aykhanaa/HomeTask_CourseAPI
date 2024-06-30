using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Capacity).IsRequired();
            builder.HasCheckConstraint("CK_Group_Capacity_MinLength", "[Capacity] >= 0 AND [Capacity] <=22 ");


        }
    }
}
