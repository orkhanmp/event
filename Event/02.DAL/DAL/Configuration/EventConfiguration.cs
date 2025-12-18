using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    internal class EventConfiguration: IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(250);
            builder.Property(x => x.Type).HasColumnType("nvarchar").HasMaxLength(250);
            builder.Property(x => x.Description).HasColumnType("nvarchar").HasMaxLength(250);
            builder.HasKey(x => x.Id);
        }
    }
}
