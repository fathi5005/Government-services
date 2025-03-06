using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class FieldConfig : IEntityTypeConfiguration<Field>
    {

        public void Configure(EntityTypeBuilder<Field> builder)
        {

            builder.Property(x => x.FiledName)
               .HasMaxLength(500)
               .IsRequired();

            builder.HasIndex(x => x.FiledName).IsUnique();


            builder.Property(x => x.Description)
              .HasMaxLength(1500)
              .IsRequired();


            builder.HasMany(x => x.ServiceData)
             .WithOne(x => x.Field)
             .HasForeignKey(x => x.FieldId);

            builder.HasData([

                new() { Id = 1, FiledName = "Full Name", Description = "Enter your full name as per official records." },
                new() { Id = 2, FiledName = "Date of Birth", Description = "Select your date of birth." },
                new() { Id = 3, FiledName = "National ID Number", Description = "Provide your national ID number." },
                new() { Id = 4, FiledName = "Passport Number", Description = "Enter your passport number." },
                new() { Id = 5, FiledName = "Address", Description = "Enter your residential address." },
                new() { Id = 6, FiledName = "Phone Number", Description = "Provide a valid phone number." },
                new() { Id = 7, FiledName = "Email Address", Description = "Provide your email for notifications." },
                new() { Id = 8, FiledName = "Marital Status", Description = "Select your marital status." },
                new() { Id = 9, FiledName = "Spouse Name", Description = "Enter your spouse’s full name (if married)." },
                new() { Id = 10, FiledName = "Vehicle Registration Number", Description = "Enter your vehicle registration number." },
                new() { Id = 11, FiledName = "Driving License Number", Description = "Enter your driver’s license number." },
                new() { Id = 12, FiledName = "Employment Status", Description = "Specify your employment status." },
                new() { Id = 13, FiledName = "Company Name", Description = "Enter the name of your employer or company." },
                new() { Id = 14, FiledName = "Annual Income", Description = "Provide your estimated annual income." },
                new() { Id = 15, FiledName = "Tax Identification Number", Description = "Enter your tax ID number." },
                new() { Id = 16, FiledName = "Nationality", Description = "Select your nationality." },
                new() { Id = 17, FiledName = "Place of Birth", Description = "Enter your place of birth." },
                new() { Id = 18, FiledName = "Education Level", Description = "Select your highest level of education." },
                new() { Id = 19, FiledName = "Medical Insurance Number", Description = "Provide your medical insurance number." },
                new() { Id = 20, FiledName = "Blood Type", Description = "Select your blood type." },
                new() { Id = 21, FiledName = "Emergency Contact Name", Description = "Enter the name of your emergency contact." },
                new() { Id = 22, FiledName = "Emergency Contact Phone", Description = "Provide the phone number of your emergency contact." },
                new() { Id = 23, FiledName = "Property Ownership Number", Description = "Enter your property ownership certificate number." },
                new() { Id = 24, FiledName = "Work Permit Number", Description = "Provide your work permit number (if applicable)." },
                new() { Id = 25, FiledName = "Residency Permit Number", Description = "Enter your residency permit number." },
                new() { Id = 26, FiledName = "Business License Number", Description = "Enter your business license registration number." },
                new() { Id = 27, FiledName = "Number of Dependents", Description = "Specify the number of dependents you have." },
                new() { Id = 28, FiledName = "Bank Account Number", Description = "Enter your bank account number." },
                new() { Id = 29, FiledName = "Preferred Language", Description = "Select your preferred language for communication." },
                new() { Id = 30, FiledName = "Previous Passport Number", Description = "Enter your previous passport number (if applicable)." }

                ]);

            builder.ToTable("Fields");


        }
    }
}

