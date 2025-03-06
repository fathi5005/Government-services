using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class ServiceFieldConfig : IEntityTypeConfiguration<ServiceField>
    {

        public void Configure(EntityTypeBuilder<ServiceField> builder)
        {
            builder.HasData([
                
                // 🔹 تجديد جواز السفر
                new() { Id = 1, ServiceId = 1, FieldId = 1 },  // Full Name
                new() { Id = 2, ServiceId = 1, FieldId = 2 },  // Date of Birth
                new() { Id = 3, ServiceId = 1, FieldId = 4 },  // Passport Number
                new() { Id = 4, ServiceId = 1, FieldId = 16 }, // Nationality
                new() { Id = 5, ServiceId = 1, FieldId = 30 }, // Previous Passport Number
                new() { Id = 6, ServiceId = 1, FieldId = 6 },  // Phone Number

                // 🔹 إصدار رخصة قيادة
                new() { Id = 7, ServiceId = 2, FieldId = 1 },  // Full Name
                new() { Id = 8, ServiceId = 2, FieldId = 2 },  // Date of Birth
                new() { Id = 9, ServiceId = 2, FieldId = 3 },  // National ID Number
                new() { Id = 10, ServiceId = 2, FieldId = 6 }, // Phone Number
                new() { Id = 11, ServiceId = 2, FieldId = 10 }, // Vehicle Registration Number
                new() { Id = 12, ServiceId = 2, FieldId = 11 }, // Driving License Number

                // 🔹 تسجيل المركبات
                new() { Id = 13, ServiceId = 3, FieldId = 1 },  // Full Name
                new() { Id = 14, ServiceId = 3, FieldId = 3 },  // National ID Number
                new() { Id = 15, ServiceId = 3, FieldId = 6 },  // Phone Number
                new() { Id = 16, ServiceId = 3, FieldId = 10 }, // Vehicle Registration Number
                new() { Id = 17, ServiceId = 3, FieldId = 15 }, // Tax Identification Number
                new() { Id = 18, ServiceId = 3, FieldId = 23 }, // Property Ownership Number

                // 🔹 إصدار شهادة ميلاد
                new() { Id = 19, ServiceId = 4, FieldId = 1 },  // Full Name
                new() { Id = 20, ServiceId = 4, FieldId = 2 },  // Date of Birth
                new() { Id = 21, ServiceId = 4, FieldId = 17 }, // Place of Birth
                new() { Id = 22, ServiceId = 4, FieldId = 16 }, // Nationality
                new() { Id = 23, ServiceId = 4, FieldId = 21 }, // Emergency Contact Name
                new() { Id = 24, ServiceId = 4, FieldId = 22 }, // Emergency Contact Phone

                // 🔹 إصدار بطاقة هوية وطنية
                new() { Id = 25, ServiceId = 5, FieldId = 1 },  // Full Name
                new() { Id = 26, ServiceId = 5, FieldId = 2 },  // Date of Birth
                new() { Id = 27, ServiceId = 5, FieldId = 3 },  // National ID Number
                new() { Id = 28, ServiceId = 5, FieldId = 5 },  // Address
                new() { Id = 29, ServiceId = 5, FieldId = 6 },  // Phone Number
                new() { Id = 30, ServiceId = 5, FieldId = 7 },  // Email Address
                new() { Id = 31, ServiceId = 5, FieldId = 16 }, // Nationality

                // 🔹 تسجيل الشركات
                new() { Id = 32, ServiceId = 6, FieldId = 1 },  // Full Name
                new() { Id = 33, ServiceId = 6, FieldId = 6 },  // Phone Number
                new() { Id = 34, ServiceId = 6, FieldId = 7 },  // Email Address
                new() { Id = 35, ServiceId = 6, FieldId = 13 }, // Company Name
                new() { Id = 36, ServiceId = 6, FieldId = 15 }, // Tax Identification Number
                new() { Id = 37, ServiceId = 6, FieldId = 26 }, // Business License Number

                // 🔹 إصدار تصريح العمل
                new() { Id = 38, ServiceId = 7, FieldId = 1 },  // Full Name
                new() { Id = 39, ServiceId = 7, FieldId = 3 },  // National ID Number
                new() { Id = 40, ServiceId = 7, FieldId = 6 },  // Phone Number
                new() { Id = 41, ServiceId = 7, FieldId = 8 },  // Employer Name
                new() { Id = 42, ServiceId = 7, FieldId = 9 },  // Employer Contact
                new() { Id = 43, ServiceId = 7, FieldId = 16 }, // Nationality

                // 🔹 تجديد تصريح الإقامة
                new() { Id = 44, ServiceId = 8, FieldId = 1 },  // Full Name
                new() { Id = 45, ServiceId = 8, FieldId = 3 },  // National ID Number
                new() { Id = 46, ServiceId = 8, FieldId = 4 },  // Passport Number
                new() { Id = 47, ServiceId = 8, FieldId = 6 },  // Phone Number
                new() { Id = 48, ServiceId = 8, FieldId = 10 }, // Residency Card Number
                new() { Id = 49, ServiceId = 8, FieldId = 16 }, // Nationality

                // 🔹 تسجيل الضرائب
                new() { Id = 50, ServiceId = 9, FieldId = 1 },  // Full Name
                new() { Id = 51, ServiceId = 9, FieldId = 3 },  // National ID Number
                new() { Id = 52, ServiceId = 9, FieldId = 6 },  // Phone Number
                new() { Id = 53, ServiceId = 9, FieldId = 7 },  // Email Address
                new() { Id = 54, ServiceId = 9, FieldId = 15 }, // Tax Identification Number
                new() { Id = 55, ServiceId = 9, FieldId = 26 }, // Business License Number

                // 🔹 إصدار شهادة ملكية العقار
                new() { Id = 56, ServiceId = 10, FieldId = 1 },  // Full Name
                new() { Id = 57, ServiceId = 10, FieldId = 3 },  // National ID Number
                new() { Id = 58, ServiceId = 10, FieldId = 6 },  // Phone Number
                new() { Id = 59, ServiceId = 10, FieldId = 7 },  // Email Address
                new() { Id = 60, ServiceId = 10, FieldId = 23 }, // Property Ownership Number
                new() { Id = 61, ServiceId = 10, FieldId = 27 }, // Address of the Propertyss of the Property

                ]);

            builder.ToTable("ServiceFields");

        }
    }
}
