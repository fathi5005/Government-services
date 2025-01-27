using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(x=>x.UserId);


            builder.Property(x => x.FirstName)
                .HasMaxLength(250)
                .IsRequired();


            builder.Property(x => x.LastName)
                .HasMaxLength(250)
                .IsRequired();


            builder.Property(x => x.NationalId)
              .HasMaxLength(250)
              .IsRequired();

            builder.Property(x => x.PhoneNumber)
             .HasMaxLength(250)
             .IsRequired();


            builder.Property(x => x.Email)
                .HasMaxLength(500)
                .IsRequired();

        }
    }
}
