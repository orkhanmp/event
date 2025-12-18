
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    internal class AttendeeConfiguration: IEntityTypeConfiguration<Attendee>
    {
        public void Configure(EntityTypeBuilder<Attendee> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(250);
            builder.Property(x => x.Surname).HasColumnType("nvarchar").HasMaxLength(250);
            builder.Property(x => x.Email).HasColumnType("nvarchar").HasMaxLength(250);
            builder.Property(x => x.Age).HasColumnType("int");
            builder.HasKey(x => x.Id);
        }
    }
}
