using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class AdminConfig : IEntityTypeConfiguration<Admin>
    {

        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(x => x.FirstName)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(500)
                .IsRequired();





            builder.ToTable("Admins");


        }
    }
}
