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
/*
  builder.HasData([
    new Request { Id = 1, RequestStatus = "Pending", ResponseStatus = "No Response", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 1 },
    new Request { Id = 2, RequestStatus = "Completed", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 1 },
    new Request { Id = 3, RequestStatus = "Rejected", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 1 },
    new Request { Id = 4, RequestStatus = "Pending", ResponseStatus = "No Response", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 1 },
    new Request { Id = 5, RequestStatus = "Completed", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 2 },
    new Request { Id = 6, RequestStatus = "Rejected", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 3 },
    new Request { Id = 7, RequestStatus = "Pending", ResponseStatus = "No Response", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 2 },
    new Request { Id = 8, RequestStatus = "Completed", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 4 },
    new Request { Id = 9, RequestStatus = "Rejected", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 5 },
    new Request { Id = 10, RequestStatus = "Pending", ResponseStatus = "No Response", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 6 },
    new Request { Id = 11, RequestStatus = "Completed", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 7 },
    new Request { Id = 12, RequestStatus = "Rejected", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 7 },
    new Request { Id = 13, RequestStatus = "Pending", ResponseStatus = "No Response", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 9 },
    new Request { Id = 14, RequestStatus = "Completed", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 10 },
    new Request { Id = 15, RequestStatus = "Pending", ResponseStatus = "No Response", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 5 },
    new Request { Id = 16, RequestStatus = "Completed", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 6 },
    new Request { Id = 17, RequestStatus = "Rejected", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 7 },
    new Request { Id = 18, RequestStatus = "Pending", ResponseStatus = "No Response", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 8 },
    new Request { Id = 19, RequestStatus = "Completed", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 9 },
    new Request { Id = 20, RequestStatus = "Rejected", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 10 },
    new Request { Id = 21, RequestStatus = "Rejected", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 2 },
    new Request { Id = 22, RequestStatus = "Rejected", ResponseStatus = "Responded", UserId = "8e47b701-f1f3-4e68-b02a-090aba0eccbc", ServiceId = 1 },
]);

 */