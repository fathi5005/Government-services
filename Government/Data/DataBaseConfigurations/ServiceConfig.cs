using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {

            builder.HasKey(x => x.ServiceID);
            builder.Property(x => x.ServiceID).ValueGeneratedOnAdd();

            builder.Property(x => x.ServiceName)
                .HasMaxLength(250)
                .IsRequired();

            builder.HasIndex(x => x.ServiceName).IsUnique();


            builder.Property(x => x.ServiceDescription)
               .HasMaxLength(1500)
               .IsRequired();

            builder.HasIndex(x => x.ServiceDescription).IsUnique();



            builder.HasMany(x => x.RequiredDocuments)
              .WithOne(x => x.service)
              .HasForeignKey(x => x.ServiceId);

            builder.HasMany(x => x.Field)
             .WithMany(x => x.Services)
             .UsingEntity<ServiceField >();

            builder.ToTable("Services");


        }
    }
}
