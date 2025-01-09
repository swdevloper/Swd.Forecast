using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Model
{
    public class MeasuredDataConfig : IEntityTypeConfiguration<MeasuredData>
    {

        public void Configure(EntityTypeBuilder<MeasuredData> entity)
        {
            entity.HasKey(x => x.Id).IsClustered(true);
            entity.Property(x => x.Id).IsRequired().HasColumnType("int");
            entity.HasIndex(x => x.Id).HasDatabaseName("idx_MeasuredData");

            entity.Property(x => x.MeasuredDateTime).IsRequired().HasColumnType("datetime");
            entity.Property(x => x.MeasuredValue).IsRequired().HasColumnType("nvarchar(50)");
            

        }

    }
}
