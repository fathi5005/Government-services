using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class AttachedDocumentConfig : IEntityTypeConfiguration<AttachedDocument>
    {

        public void Configure(EntityTypeBuilder<AttachedDocument> builder)
        {
            builder.HasKey(x => x.AttachedDocumentID);
            builder.Property(x => x.AttachedDocumentID).ValueGeneratedOnAdd();

            builder.Property(x => x.FileName)
               .HasMaxLength(500)
               .IsRequired();

            builder.Property(x => x.FilePath)
             .HasMaxLength(5000)
             .IsRequired();

            builder.ToTable("AttachedDocuments");

        }
    }
}
