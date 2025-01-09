using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Model
{
    public class RecipientConfig : IEntityTypeConfiguration<Recipient>
    {

        public void Configure(EntityTypeBuilder<Recipient> entity)
        {
            entity.HasKey(x => x.Id).IsClustered(true);
            entity.Property(x => x.Id).IsRequired().HasColumnType("int");
            entity.HasIndex(x => x.Id).HasDatabaseName("idx_Recipient");

            entity.Property(x => x.Salutation).IsRequired().HasColumnType("nvarchar(50)");
            entity.Property(x => x.Lastname).IsRequired().HasColumnType("nvarchar(50)");
            entity.Property(x => x.Firstname).IsRequired().HasColumnType("nvarchar(50)");
            entity.Property(x => x.Notice).IsRequired(false).HasColumnType("nvarchar(max)");
            entity.Property(x => x.IsActive).IsRequired().HasColumnType("bit").HasDefaultValue(0);
            entity.Property(x => x.CommunicationData).IsRequired(false).HasColumnType("nvarchar(1000)");
            entity.Property(x => x.GeoInformation).IsRequired(false).HasColumnType("nvarchar(1000)");


        }

    }
}
