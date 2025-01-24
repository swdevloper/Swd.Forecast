using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Model
{
    public class RecommendationConfig : IEntityTypeConfiguration<Recommendation>
    {

        public void Configure(EntityTypeBuilder<Recommendation> entity)
        {
            entity.HasKey(x => x.Id).IsClustered(true);
            entity.Property(x => x.Id).IsRequired().HasColumnType("int");
            entity.HasIndex(x => x.Id).HasDatabaseName("idx_Recommendation");

            entity.Property(x => x.Variable).IsRequired().HasColumnType("nvarchar(50)");
            entity.Property(x => x.Headline).IsRequired().HasColumnType("nvarchar(100)");
            entity.Property(x => x.Text).IsRequired().HasColumnType("nvarchar(max)");
            entity.Property(x => x.IsActive).IsRequired().HasColumnType("bit").HasDefaultValue(0);

        }

    }
}
