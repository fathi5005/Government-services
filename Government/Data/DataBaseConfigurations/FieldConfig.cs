using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class FieldConfig : IEntityTypeConfiguration<Field>
    {

        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.HasKey(x => x.FieldID);
            builder.Property(x => x.FieldID).ValueGeneratedOnAdd();



            builder.Property(x => x.FiledName)
               .HasMaxLength(500)
               .IsRequired();

            builder.HasIndex(x => x.FiledName).IsUnique();


            builder.Property(x => x.Description)
              .HasMaxLength(1500)
              .IsRequired();


            builder.HasMany(x => x.ServiceData)
             .WithOne(x => x.Field)
             .HasForeignKey(x => x.FieldID);

            builder.ToTable("Fields");


        }
    }
}

