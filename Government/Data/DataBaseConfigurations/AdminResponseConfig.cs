using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class AdminResponseConfig : IEntityTypeConfiguration<AdminResponse>
    {

        public void Configure(EntityTypeBuilder<AdminResponse> builder)
        {
            builder.HasKey(x => x.AdminResponseId);
            builder.Property(x => x.AdminResponseId).ValueGeneratedOnAdd();

            builder.Property(x => x.ResponseText)
               .HasMaxLength(500)
               .IsRequired();
               

            builder.HasOne(x => x.Request)
            .WithOne(x => x.AdminResponse)
            .HasForeignKey<AdminResponse>(x => x.RequestId);

            builder.HasOne(x => x.Admin)
                .WithMany(x => x.AdminResponses)
                .HasForeignKey(x => x.AdminId);

            

            builder.ToTable("AdminResponses");

        }
    }
}
