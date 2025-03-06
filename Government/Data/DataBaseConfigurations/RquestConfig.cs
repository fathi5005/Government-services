using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class RquestConfig : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
       

            builder.Property(x => x.RequestStatus)
               .HasMaxLength(500)
               .HasDefaultValue("Pending");

            builder.Property(x => x.ResponseStatus)
             .HasMaxLength(500)
             .HasDefaultValue("No Response");

            builder.HasOne(x => x.service)
             .WithMany(x => x.Requests)
             .HasForeignKey(x => x.ServiceId);

            builder.HasMany(x => x.Payments)
              .WithOne(x => x.Request)
              .HasForeignKey(x => x.RequestId);

            builder.HasMany(x => x.AttachedDocuments)
              .WithOne(x => x.Request)
              .HasForeignKey(x => x.RequestId);


            builder.HasMany(x => x.serviceData)
              .WithOne(x => x.Request)
              .HasForeignKey(x => x.RequestId);



            builder.ToTable("Requests");

        }
    }
}
