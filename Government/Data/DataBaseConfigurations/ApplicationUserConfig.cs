using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
 
            builder.Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired();


            builder.Property(x => x.NationalId)
              .HasMaxLength(250)
              .IsRequired();

            builder.Property(x => x.PhoneNumber)
             .HasMaxLength(250)
             .IsRequired();

        }
    }
}
