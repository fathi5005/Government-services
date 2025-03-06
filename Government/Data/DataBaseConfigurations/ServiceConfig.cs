using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {


            builder.Property(x => x.ServiceName)
                .HasMaxLength(250)
                .IsRequired();

            builder.HasIndex(x => x.ServiceName).IsUnique();


            builder.Property(x => x.ServiceDescription)
               .HasMaxLength(1500)
               .IsRequired();

            builder.HasIndex(x => x.ServiceDescription).IsUnique();


            builder.Property(x => x.ProcessingTime)
           .HasMaxLength(250)
           .IsRequired();

            builder.Property(x => x.ContactInfo)
           .HasMaxLength(1500)
           .IsRequired();


            builder.Property(p => p.Fee)
           .HasColumnType("decimal(10,2)");


            builder.HasMany(x => x.RequiredDocuments)
              .WithOne(x => x.Service)
              .HasForeignKey(x => x.ServiceId);

            builder.HasMany(x => x.Field)
             .WithMany(x => x.Services)
             .UsingEntity<ServiceField >();

            builder.HasData([

                new Service { Id = 1, ServiceName = "Passport Renewal", ServiceDescription = "Renew your passport quickly and easily.", IsAvailable = true, Fee = 50.00m, ProcessingTime = "5 business days", ContactInfo = "support@gov.com" },
                new Service { Id = 2, ServiceName = "Driver’s License Issuance", ServiceDescription = "Apply for a new driver’s license.", IsAvailable = true, Fee = 30.00m, ProcessingTime = "7 business days", ContactInfo = "dmv@gov.com" },
                new Service { Id = 3, ServiceName = "Vehicle Registration", ServiceDescription = "Register your vehicle with the transport department.", IsAvailable = true, Fee = 40.00m, ProcessingTime = "3 business days", ContactInfo = "transport@gov.com" },
                new Service { Id = 4, ServiceName = "Marriage Certificate Issuance", ServiceDescription = "Request an official marriage certificate.", IsAvailable = true, Fee = 20.00m, ProcessingTime = "4 business days", ContactInfo = "civilstatus@gov.com" },
                new Service { Id = 5, ServiceName = "Birth Certificate Issuance", ServiceDescription = "Obtain an official birth certificate.", IsAvailable = true, Fee = 15.00m, ProcessingTime = "2 business days", ContactInfo = "registry@gov.com" },
                new Service { Id = 6, ServiceName = "National ID Card Application", ServiceDescription = "Apply for a new national ID card.", IsAvailable = true, Fee = 10.00m, ProcessingTime = "6 business days", ContactInfo = "nid@gov.com" },
                new Service { Id = 7, ServiceName = "Business License Registration", ServiceDescription = "Register your new business legally.", IsAvailable = true, Fee = 100.00m, ProcessingTime = "10 business days", ContactInfo = "business@gov.com" },
                new Service { Id = 8, ServiceName = "Work Permit Issuance", ServiceDescription = "Apply for a work permit for foreign employees.", IsAvailable = true, Fee = 70.00m, ProcessingTime = "8 business days", ContactInfo = "labor@gov.com" },
                new Service { Id = 9, ServiceName = "Residency Permit Renewal", ServiceDescription = "Renew your residency permit.", IsAvailable = true, Fee = 60.00m, ProcessingTime = "7 business days", ContactInfo = "immigration@gov.com" },
                new Service { Id = 10, ServiceName = "Tax Registration", ServiceDescription = "Register for tax purposes.", IsAvailable = true, Fee = 25.00m, ProcessingTime = "5 business days", ContactInfo = "tax@gov.com" }

                ]);

            builder.ToTable("Services");


        }
    }
}
