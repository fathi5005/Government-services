using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class ServiceDataConfig : IEntityTypeConfiguration<ServiceData>
    {
        public void Configure(EntityTypeBuilder<ServiceData> builder)
        {

            builder.Property(x => x.FieldValueString)
                    .HasMaxLength(250)
                    .IsRequired(false);

            builder.Property(x => x.FieldValueInt)
                    .IsRequired(false);

            builder.Property(x => x.FieldValueFloat) 
                    .IsRequired(false);

            builder.Property(x => x.FieldValueDate)
                    .IsRequired(false);



            builder.ToTable("ServiceData");

        }
    }
}
