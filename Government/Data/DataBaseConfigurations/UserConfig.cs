using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
          builder.HasKey(x=>x.UserID);
            builder.Property(x=>x.UserID).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired();


            builder.Property(x => x.NationalId)
              .HasMaxLength(250)
              .IsRequired();

            builder.Property(x => x.Email)
             .HasMaxLength(250)
             .IsRequired();

            builder.Property(x => x.PhoneNumber)
             .HasMaxLength(250)
             .IsRequired();

            builder.ToTable("Users");

        }
    }
}
