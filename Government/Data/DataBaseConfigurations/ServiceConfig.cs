using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {


            builder.Property(x => x.ServiceName)
                .HasMaxLength(250)
                .IsRequired();

            builder.HasIndex(x => x.ServiceName).IsUnique();


            builder.Property(x => x.ServiceDescription)
               .HasMaxLength(1500)
               .IsRequired();

            builder.Property(x => x.category)
                .HasMaxLength(250);


            builder.HasIndex(x => x.ServiceDescription).IsUnique();


            builder.Property(x => x.ProcessingTime)
           .HasMaxLength(250)
           .IsRequired();

            builder.Property(x => x.ContactInfo)
           .HasMaxLength(1500)
           .IsRequired();


            builder.Property(p => p.Fee)
           .HasColumnType("decimal(10,2)");


            builder.HasMany(x => x.RequiredDocuments)
              .WithOne(x => x.Service)
              .HasForeignKey(x => x.ServiceId);

            builder.HasMany(x => x.Field)
             .WithMany(x => x.Services)
             .UsingEntity<ServiceField >();

            builder.HasData
             ([

                new Service { Id = 1, ServiceName = "تجديد جواز السفر", ServiceDescription = "تجديد جواز السفر المصري بسهولة وسرعة.", IsAvailable = true, Fee = 1000.00m, ProcessingTime = "5 أيام عمل", ContactInfo = "passports@moe.gov.eg" },
                new Service { Id = 2, ServiceName = "إصدار رخصة قيادة", ServiceDescription = "التقديم للحصول على رخصة قيادة جديدة.", IsAvailable = true, Fee = 300.00m, ProcessingTime = "7 أيام عمل", ContactInfo = "traffic@moi.gov.eg" },
                new Service { Id = 3, ServiceName = "تسجيل مركبة", ServiceDescription = "تسجيل مركبتك لدى إدارة المرور.", IsAvailable = true, Fee = 500.00m, ProcessingTime = "3 أيام عمل", ContactInfo = "vehicles@moi.gov.eg" },
                new Service { Id = 4, ServiceName = "إصدار شهادة زواج", ServiceDescription = "طلب شهادة زواج رسمية من السجل المدني.", IsAvailable = true, Fee = 150.00m, ProcessingTime = "4 أيام عمل", ContactInfo = "civil@moj.gov.eg" },
                new Service { Id = 5, ServiceName = "إصدار شهادة ميلاد", ServiceDescription = "استخراج شهادة ميلاد رسمية.", IsAvailable = true, Fee = 100.00m, ProcessingTime = "2 يوم عمل", ContactInfo = "birth@moj.gov.eg" },
                new Service { Id = 6, ServiceName = "التقديم لبطاقة الرقم القومي", ServiceDescription = "طلب إصدار بطاقة رقم قومي جديدة.", IsAvailable = true, Fee = 150.00m, ProcessingTime = "6 أيام عمل", ContactInfo = "id@moe.gov.eg" },
                new Service { Id = 7, ServiceName = "تسجيل رخصة تجارية", ServiceDescription = "تسجيل عملك التجاري بشكل قانوني.", IsAvailable = true, Fee = 2000.00m, ProcessingTime = "10 أيام عمل", ContactInfo = "commerce@mit.gov.eg" },
                new Service { Id = 8, ServiceName = "إصدار تصريح عمل", ServiceDescription = "التقديم لتصريح عمل للأجانب.", IsAvailable = true, Fee = 1500.00m, ProcessingTime = "8 أيام عمل", ContactInfo = "labor@mol.gov.eg" },
                new Service { Id = 9, ServiceName = "تجديد تصريح الإقامة", ServiceDescription = "تجديد تصريح الإقامة للمقيمين.", IsAvailable = true, Fee = 1200.00m, ProcessingTime = "7 أيام عمل", ContactInfo = "immigration@moe.gov.eg" },
                new Service { Id = 10, ServiceName = "التسجيل الضريبي", ServiceDescription = "التسجيل لأغراض الضرائب.", IsAvailable = true, Fee = 400.00m, ProcessingTime = "5 أيام عمل", ContactInfo = "tax@mof.gov.eg" },
                new Service { Id = 11, ServiceName = "استخراج شهادة وفاة", ServiceDescription = "طلب شهادة وفاة رسمية.", IsAvailable = true, Fee = 100.00m, ProcessingTime = "2 يوم عمل", ContactInfo = "death@moj.gov.eg" },
                new Service { Id = 12, ServiceName = "تجديد السجل التجاري", ServiceDescription = "تجديد السجل التجاري للشركات.", IsAvailable = true, Fee = 1000.00m, ProcessingTime = "7 أيام عمل", ContactInfo = "registry@mit.gov.eg" },
                new Service { Id = 13, ServiceName = "إصدار شهادة حسن سير وسلوك", ServiceDescription = "استخراج شهادة حسن سير وسلوك.", IsAvailable = true, Fee = 200.00m, ProcessingTime = "3 أيام عمل", ContactInfo = "cert@moi.gov.eg" },
                new Service { Id = 14, ServiceName = "تسجيل عقار", ServiceDescription = "تسجيل ملكية عقار في الشهر العقاري.", IsAvailable = true, Fee = 1500.00m, ProcessingTime = "10 أيام عمل", ContactInfo = "property@moj.gov.eg" },
                new Service { Id = 15, ServiceName = "التقديم للحصول على دعم تمويني", ServiceDescription = "التسجيل للحصول على بطاقة تموين.", IsAvailable = true, Fee = 50.00m, ProcessingTime = "5 أيام عمل", ContactInfo = "supply@moss.gov.eg" }

             ]);

            builder.ToTable("Services");


        }
    }
}
