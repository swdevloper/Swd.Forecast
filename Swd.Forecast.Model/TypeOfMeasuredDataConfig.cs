using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Model
{
    public class TypeOfMeasuredDataConfig : IEntityTypeConfiguration<TypeOfMeasuredData>
    {

        public void Configure(EntityTypeBuilder<TypeOfMeasuredData> entity)
        {
            entity.HasKey(x => x.Id).IsClustered(true);
            entity.Property(x => x.Id).IsRequired().HasColumnType("nvarchar(50)");
            entity.HasIndex(x => x.Id).HasDatabaseName("idx_TypeOfMeasuredData");

        }

    }
}
