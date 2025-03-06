using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {

        public void Configure(EntityTypeBuilder<Payment> builder)
        {

            builder.Property(x => x.PaymentStatus)
               .HasMaxLength(500)
               .IsRequired();


            builder.Property(p => p.Amount)
           .HasColumnType("decimal(10,2)");

            builder.ToTable("Payments");



        }
    }
}
