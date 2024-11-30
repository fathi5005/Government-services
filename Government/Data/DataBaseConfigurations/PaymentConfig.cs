using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {

        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.PaymentID);
            builder.Property(x => x.PaymentID).ValueGeneratedOnAdd();



            builder.Property(x => x.PaymentStatus)
               .HasMaxLength(500)
               .IsRequired();
            builder.ToTable("Payments");


        }
    }
}
