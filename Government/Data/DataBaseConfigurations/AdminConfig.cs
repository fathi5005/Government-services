using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class AdminConfig : IEntityTypeConfiguration<Admin>
    {

        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.AdminID);
            builder.Property(x => x.AdminID).ValueGeneratedOnAdd();



            builder.Property(x => x.AdminName)
               .HasMaxLength(500)
               .IsRequired();


            builder.Property(x => x.Email)
               .HasMaxLength(1500)
               .IsRequired();

            builder.ToTable("Admins");


        }
    }
}
