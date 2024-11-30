using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class ServiceFieldConfig : IEntityTypeConfiguration<ServiceField>
    {

        public void Configure(EntityTypeBuilder<ServiceField> builder)
        {
            builder.HasKey(x => new { x.ServiceID, x.FieldID });

            builder.ToTable("ServiceFields");

        }
    }
}
