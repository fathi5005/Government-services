using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class AttachedDocumentConfig : IEntityTypeConfiguration<AttachedDocument>
    {

        public void Configure(EntityTypeBuilder<AttachedDocument> builder)
        {

            builder.Property(x => x.FileName)
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(x => x.FileUrl)
          .HasMaxLength(5000)
          .IsRequired();


            builder.Property(x => x.DocumentType)
              .HasMaxLength(5000)
              .IsRequired();

        builder.ToTable("AttachedDocuments");

        }
    }
}
