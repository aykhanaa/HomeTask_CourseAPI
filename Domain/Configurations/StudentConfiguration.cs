using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Surname).IsRequired() .HasMaxLength(50);
            builder.Property(m => m.Adress).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Email).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Age).IsRequired();
        }
    }
}
