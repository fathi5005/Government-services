using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class RequiredDocumentConfig : IEntityTypeConfiguration<RequiredDocument>
    {
        public void Configure(EntityTypeBuilder<RequiredDocument> builder)
        {
            builder.HasKey(x => x.RequiredDocumentId);
            builder.Property(x => x.RequiredDocumentId).ValueGeneratedOnAdd();

           

            builder.Property(x => x.FileName)
               .HasMaxLength(500)
               .IsRequired();

            builder.HasIndex(x => x.FileName).IsUnique();

            builder.Property(x => x.FilePath)
             .HasMaxLength(5000)
             .IsRequired();
            builder.ToTable("RequiredDocuments");


        }
    }
}
