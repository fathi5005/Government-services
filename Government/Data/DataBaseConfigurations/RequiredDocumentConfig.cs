using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class RequiredDocumentConfig : IEntityTypeConfiguration<RequiredDocument>
    {
        public void Configure(EntityTypeBuilder<RequiredDocument> builder)
        {

            builder.Property(x => x.FileName)
               .HasMaxLength(500)
               .IsRequired();

            builder.HasIndex(x => x.FileName).IsUnique();

            builder.Property(x => x.FileUrl)
             .HasMaxLength(5000)
             .IsRequired();

            builder.Property(x => x.DocumentType)
             .HasMaxLength(5000)
             .IsRequired();


            builder.HasData([

                new RequiredDocument { Id = 1, FileName = "Passport Copy", FileUrl = "https://gov.com/docs/passport_copy.pdf", DocumentType = "Identification", Description = "A copy of a valid passport to verify identity.", IsMandatory = true, ServiceId = 1 },
                new RequiredDocument { Id = 2, FileName = "Old Passport", FileUrl = "https://gov.com/docs/old_passport.pdf", DocumentType = "Previous Document", Description = "A copy of the previous passport, if applicable, for verification.", IsMandatory = true, ServiceId = 1 },

                new RequiredDocument { Id = 3, FileName = "National ID Copy", FileUrl = "https://gov.com/docs/national_id.pdf", DocumentType = "Identification", Description = "A scanned copy of the national ID card for identity confirmation.", IsMandatory = true, ServiceId = 2 },
                new RequiredDocument { Id = 4, FileName = "Medical Certificate", FileUrl = "https://gov.com/docs/medical_certificate.pdf", DocumentType = "Health", Description = "A medical certificate proving health status, issued by an authorized medical institution.", IsMandatory = true, ServiceId = 2 },

                new RequiredDocument { Id = 5, FileName = "Vehicle Title", FileUrl = "https://gov.com/docs/vehicle_title.pdf", DocumentType = "Ownership Proof", Description = "An official document proving ownership of the vehicle.", IsMandatory = true, ServiceId = 3 },
                new RequiredDocument { Id = 6, FileName = "Insurance Certificate", FileUrl = "https://gov.com/docs/insurance.pdf", DocumentType = "Insurance", Description = "A valid insurance certificate covering the vehicle.", IsMandatory = true, ServiceId = 3 },

                new RequiredDocument { Id = 7, FileName = "Marriage Contract", FileUrl = "https://gov.com/docs/marriage_contract.pdf", DocumentType = "Legal", Description = "A certified copy of the marriage contract for legal purposes.", IsMandatory = true, ServiceId = 4 },
                new RequiredDocument { Id = 8, FileName = "National ID Copies", FileUrl = "https://gov.com/docs/nid_copies.pdf", DocumentType = "Identification", Description = "Copies of the national ID cards of both spouses for verification.", IsMandatory = true, ServiceId = 4 },

                new RequiredDocument { Id = 9, FileName = "Hospital Birth Record", FileUrl = "https://gov.com/docs/birth_record.pdf", DocumentType = "Medical", Description = "An official hospital birth record confirming birth details.", IsMandatory = true, ServiceId = 5 },
                new RequiredDocument { Id = 10, FileName = "Parents ID Copies", FileUrl = "https://gov.com/docs/parents_id.pdf", DocumentType = "Identification", Description = "Copies of both parents' national ID cards for identity verification.", IsMandatory = true, ServiceId = 5 },

                new RequiredDocument { Id = 11, FileName = "Birth Certificate", FileUrl = "https://gov.com/docs/birth_certificate.pdf", DocumentType = "Identification", Description = "A certified copy of the birth certificate for identity confirmation.", IsMandatory = true, ServiceId = 6 },
                new RequiredDocument { Id = 12, FileName = "Proof of Residence", FileUrl = "https://gov.com/docs/proof_residence.pdf", DocumentType = "Address Verification", Description = "An official document verifying the applicant's residential address.", IsMandatory = true, ServiceId = 6 },

                new RequiredDocument { Id = 13, FileName = "Business Registration Form", FileUrl = "https://gov.com/docs/business_registration.pdf", DocumentType = "Legal", Description = "An official business registration document confirming legal status.", IsMandatory = true, ServiceId = 7 },
                new RequiredDocument { Id = 14, FileName = "Tax Clearance Certificate", FileUrl = "https://gov.com/docs/tax_clearance.pdf", DocumentType = "Tax", Description = "A tax clearance certificate proving tax compliance.", IsMandatory = true, ServiceId = 7 },

                new RequiredDocument { Id = 15, FileName = "Employment Contract", FileUrl = "https://gov.com/docs/employment_contract.pdf", DocumentType = "Legal", Description = "A signed employment contract detailing job terms and conditions.", IsMandatory = true, ServiceId = 8 },
                new RequiredDocument { Id = 16, FileName = "Company License", FileUrl = "https://gov.com/docs/company_license.pdf", DocumentType = "Business", Description = "An official company license issued by the regulatory authority.", IsMandatory = true, ServiceId = 8 },

                new RequiredDocument { Id = 17, FileName = "Residency Card Copy", FileUrl = "https://gov.com/docs/residency_card.pdf", DocumentType = "Identification", Description = "A copy of the residency card confirming residency status.", IsMandatory = true, ServiceId = 9 },
                new RequiredDocument { Id = 18, FileName = "Rental Agreement", FileUrl = "https://gov.com/docs/rental_agreement.pdf", DocumentType = "Proof of Address", Description = "A valid rental agreement proving residency at the stated address.", IsMandatory = true, ServiceId = 9 },

                new RequiredDocument { Id = 19, FileName = "Tax Application Form", FileUrl = "https://gov.com/docs/tax_application.pdf", DocumentType = "Tax", Description = "A completed tax application form for tax registration.", IsMandatory = true, ServiceId = 10 },
                new RequiredDocument { Id = 20, FileName = "Proof of Income", FileUrl = "https://gov.com/docs/proof_income.pdf", DocumentType = "Financial", Description = "An official document proving the applicant's income source.", IsMandatory = true, ServiceId = 10 }

             ]);


            builder.ToTable("RequiredDocuments");


        }

    }
}
