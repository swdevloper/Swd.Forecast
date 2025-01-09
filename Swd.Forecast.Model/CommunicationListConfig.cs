using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Model
{
    public class CommunicationListConfig : IEntityTypeConfiguration<CommunicationList>
    {

        public void Configure(EntityTypeBuilder<CommunicationList> entity)
        {
            entity.HasKey(x => x.Id).IsClustered(true);
            entity.Property(x => x.Id).IsRequired().HasColumnType("int");
            entity.HasIndex(x => x.Id).HasDatabaseName("idx_CommunicationList");

            entity.Property(x => x.CommunicationType).IsRequired().HasColumnType("nvarchar(100)");
            entity.Property(x => x.CommunicationIdentifier).IsRequired().HasColumnType("nvarchar(100)");
            entity.Property(x => x.Headline).IsRequired().HasColumnType("nvarchar(100)");
            entity.Property(x => x.Text).IsRequired().HasColumnType("nvarchar(1000)");
            entity.Property(x => x.IsSent).IsRequired().HasColumnType("bit").HasDefaultValue(0);
            entity.Property(x => x.SentDateTime).IsRequired().HasColumnType("datetime");

        }

    }
}
