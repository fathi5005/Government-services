using Government.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Government.Data.DataBaseConfigurations
{
    public class FieldConfig : IEntityTypeConfiguration<Field>
    {

        public void Configure(EntityTypeBuilder<Field> builder)
        {

            builder.Property(x => x.FieldName)
               .HasMaxLength(500)
               .IsRequired();

           


            builder.Property(x => x.Description)
              .HasMaxLength(1500)
              .IsRequired();


            builder.HasMany(x => x.ServiceData)
             .WithOne(x => x.Field)
             .HasForeignKey(x => x.FieldId);

            builder.HasData([
                   
    // 🔹 Fields for تجديد جواز السفر (ServiceId = 1)
    new() { Id = 1, FieldName = "رقم جواز السفر الحالي", Description = "أدخل رقم جواز السفر الحالي.", HtmlType = "text" },
    new() { Id = 2, FieldName = "رقم جواز السفر السابق", Description = "أدخل رقم جواز السفر السابق (إن وجد).", HtmlType = "text" },
    new() { Id = 3, FieldName = "تاريخ إصدار الجواز", Description = "أدخل تاريخ إصدار الجواز الحالي.", HtmlType = "date" },
    new() { Id = 4, FieldName = "تاريخ انتهاء الجواز", Description = "أدخل تاريخ انتهاء الجواز الحالي.", HtmlType = "date" },
    new() { Id = 5, FieldName = "جهة إصدار الجواز", Description = "أدخل مكان إصدار الجواز.", HtmlType = "text" },
    new() { Id = 6, FieldName = "الاسم باللغة الإنجليزية", Description = "أدخل اسمك باللغة الإنجليزية كما في الجواز.", HtmlType = "text" },
    new() { Id = 7, FieldName = "رقم تأكيد الدفع", Description = "أدخل رقم إيصال دفع رسوم التجديد.", HtmlType = "text" },
    new() { Id = 8, FieldName = "الجنس", Description = "أدخل جنسك (ذكر/أنثى).", HtmlType = "text" },
    new() { Id = 9, FieldName = "المهنة", Description = "أدخل مهنتك الحالية.", HtmlType = "text" },
    new() { Id = 10, FieldName = "رقم الموعد", Description = "أدخل رقم الموعد لاستلام الجواز.", HtmlType = "text" },

    // 🔹 Fields for إصدار رخصة قيادة (ServiceId = 2)
    new() { Id = 11, FieldName = "نوع رخصة القيادة", Description = "أدخل نوع الرخصة (خاصة/تجارية).", HtmlType = "text" },
    new() { Id = 12, FieldName = "رقم الملف المروري", Description = "أدخل رقم ملفك المروري (إن وجد).", HtmlType = "text" },
    new() { Id = 13, FieldName = "تاريخ اجتياز الاختبار", Description = "أدخل تاريخ اجتياز اختبار القيادة.", HtmlType = "date" },
    new() { Id = 14, FieldName = "اسم مدرسة القيادة", Description = "أدخل اسم مدرسة تدريب القيادة.", HtmlType = "text" },
    new() { Id = 15, FieldName = "رقم شهادة اللياقة", Description = "أدخل رقم شهادة اللياقة الطبية.", HtmlType = "text" },
    new() { Id = 16, FieldName = "المحافظة المصدرة", Description = "أدخل المحافظة التي ستصدر منها الرخصة.", HtmlType = "text" },
    new() { Id = 17, FieldName = "تاريخ التقديم للرخصة", Description = "أدخل تاريخ تقديم طلب الرخصة.", HtmlType = "date" },
    new() { Id = 18, FieldName = "رقم إيصال الرسوم", Description = "أدخل رقم إيصال دفع رسوم الرخصة.", HtmlType = "text" },
    new() { Id = 19, FieldName = "نوع المركبة المطلوبة", Description = "أدخل نوع المركبة (سيارة/دراجة).", HtmlType = "text" },
    new() { Id = 20, FieldName = "حالة الرخصة السابقة", Description = "أدخل حالة رخصتك السابقة (إن وجدت).", HtmlType = "text" },

    // 🔹 Fields for تسجيل مركبة (ServiceId = 3)
    new() { Id = 21, FieldName = "رقم لوحة المركبة", Description = "أدخل رقم لوحة المركبة.", HtmlType = "text" },
    new() { Id = 22, FieldName = "رقم الشاسيه", Description = "أدخل رقم الشاسيه الخاص بالمركبة.", HtmlType = "text" },
    new() { Id = 23, FieldName = "رقم الموتور", Description = "أدخل رقم الموتور الخاص بالمركبة.", HtmlType = "text" },
    new() { Id = 24, FieldName = "نوع المركبة", Description = "أدخل نوع المركبة (سيارة/شاحنة).", HtmlType = "text" },
    new() { Id = 25, FieldName = "سنة الصنع", Description = "أدخل سنة تصنيع المركبة.", HtmlType = "number" },
    new() { Id = 26, FieldName = "رقم التأمين", Description = "أدخل رقم وثيقة التأمين على المركبة.", HtmlType = "text" },
    new() { Id = 27, FieldName = "تاريخ التسجيل", Description = "أدخل تاريخ تسجيل المركبة.", HtmlType = "date" },
    new() { Id = 28, FieldName = "اسم الوكيل", Description = "أدخل اسم الوكيل أو البائع.", HtmlType = "text" },
    new() { Id = 29, FieldName = "رقم الفاتورة", Description = "أدخل رقم فاتورة شراء المركبة.", HtmlType = "text" },
    new() { Id = 30, FieldName = "لون المركبة", Description = "أدخل لون المركبة.", HtmlType = "text" },

    // 🔹 Fields for إصدار شهادة زواج (ServiceId = 4)
    new() { Id = 31, FieldName = "اسم الزوج", Description = "أدخل اسم الزوج الكامل.", HtmlType = "text" },
    new() { Id = 32, FieldName = "اسم الزوجة", Description = "أدخل اسم الزوجة الكامل.", HtmlType = "text" },
    new() { Id = 33, FieldName = "تاريخ الزواج", Description = "أدخل تاريخ عقد الزواج.", HtmlType = "date" },
    new() { Id = 34, FieldName = "مكان الزواج", Description = "أدخل مكان عقد الزواج.", HtmlType = "text" },
    new() { Id = 35, FieldName = "رقم عقد الزواج", Description = "أدخل رقم عقد الزواج.", HtmlType = "text" },
    new() { Id = 36, FieldName = "اسم المأذون", Description = "أدخل اسم المأذون الذي أجرى العقد.", HtmlType = "text" },
    new() { Id = 37, FieldName = "عدد الشهود", Description = "أدخل عدد الشهود على العقد.", HtmlType = "number" },
    new() { Id = 38, FieldName = "تاريخ التسجيل", Description = "أدخل تاريخ تسجيل العقد رسميًا.", HtmlType = "date" },
    new() { Id = 39, FieldName = "رقم إيصال الرسوم", Description = "أدخل رقم إيصال دفع رسوم الشهادة.", HtmlType = "text" },
    new() { Id = 40, FieldName = "محل إقامة الزوجين", Description = "أدخل محل إقامة الزوجين.", HtmlType = "text" },

    // 🔹 Fields for إصدار شهادة ميلاد (ServiceId = 5)
    new() { Id = 41, FieldName = "اسم المولود", Description = "أدخل اسم المولود الكامل.", HtmlType = "text" },
    new() { Id = 42, FieldName = "تاريخ الميلاد", Description = "أدخل تاريخ ميلاد المولود.", HtmlType = "date" },
    new() { Id = 43, FieldName = "محل الميلاد", Description = "أدخل مكان ميلاد المولود.", HtmlType = "text" },
    new() { Id = 44, FieldName = "اسم المستشفى", Description = "أدخل اسم المستشفى أو مكان الولادة.", HtmlType = "text" },
    new() { Id = 45, FieldName = "رقم تسجيل الميلاد", Description = "أدخل رقم تسجيل الميلاد.", HtmlType = "text" },
    new() { Id = 46, FieldName = "جنس المولود", Description = "أدخل جنس المولود (ذكر/أنثى).", HtmlType = "text" },
    new() { Id = 47, FieldName = "اسم الطبيب", Description = "أدخل اسم الطبيب المشرف على الولادة.", HtmlType = "text" },
    new() { Id = 48, FieldName = "تاريخ الإصدار", Description = "أدخل تاريخ إصدار الشهادة.", HtmlType = "date" },
    new() { Id = 49, FieldName = "رقم إيصال الرسوم", Description = "أدخل رقم إيصال دفع رسوم الشهادة.", HtmlType = "text" },
    new() { Id = 50, FieldName = "اسم مقدم الطلب", Description = "أدخل اسم مقدم طلب الشهادة.", HtmlType = "text" },

    // 🔹 Fields for التقديم لبطاقة الرقم القومي (ServiceId = 6)
    new() { Id = 51, FieldName = "رقم شهادة الميلاد", Description = "أدخل رقم شهادة الميلاد.", HtmlType = "text" },
    new() { Id = 52, FieldName = "تاريخ تقديم الطلب", Description = "أدخل تاريخ تقديم طلب البطاقة.", HtmlType = "date" },
    new() { Id = 53, FieldName = "رقم الموعد", Description = "أدخل رقم الموعد لاستلام البطاقة.", HtmlType = "text" },
    new() { Id = 54, FieldName = "محل الإصدار", Description = "أدخل مكان إصدار البطاقة.", HtmlType = "text" },
    new() { Id = 55, FieldName = "رقم البصمة", Description = "أدخل رقم تسجيل البصمة (إن وجد).", HtmlType = "text" },
    new() { Id = 56, FieldName = "اسم الأب", Description = "أدخل اسم الأب الكامل.", HtmlType = "text" },
    new() { Id = 57, FieldName = "اسم الأم", Description = "أدخل اسم الأم الكامل.", HtmlType = "text" },
    new() { Id = 58, FieldName = "الجنس", Description = "أدخل جنسك (ذكر/أنثى).", HtmlType = "text" },
    new() { Id = 59, FieldName = "رقم إيصال الرسوم", Description = "أدخل رقم إيصال دفع رسوم البطاقة.", HtmlType = "text" },
    new() { Id = 60, FieldName = "الحالة الاجتماعية", Description = "أدخل حالتك الاجتماعية.", HtmlType = "text" },

    // 🔹 Fields for تسجيل رخصة تجارية (ServiceId = 7)
    new() { Id = 61, FieldName = "اسم النشاط التجاري", Description = "أدخل اسم النشاط التجاري.", HtmlType = "text" },
    new() { Id = 62, FieldName = "نوع النشاط", Description = "أدخل نوع النشاط (تجاري/صناعي).", HtmlType = "text" },
    new() { Id = 63, FieldName = "رأس المال", Description = "أدخل قيمة رأس المال المسجل.", HtmlType = "number" },
    new() { Id = 64, FieldName = "رقم التسجيل الضريبي", Description = "أدخل رقم التسجيل الضريبي.", HtmlType = "text" },
    new() { Id = 65, FieldName = "عدد الموظفين", Description = "أدخل عدد الموظفين في النشاط.", HtmlType = "number" },
    new() { Id = 66, FieldName = "تاريخ بدء النشاط", Description = "أدخل تاريخ بدء النشاط التجاري.", HtmlType = "date" },
    new() { Id = 67, FieldName = "عنوان المقر", Description = "أدخل عنوان المقر التجاري.", HtmlType = "text" },
    new() { Id = 68, FieldName = "رقم السجل التجاري", Description = "أدخل رقم السجل التجاري (إن وجد).", HtmlType = "text" },
    new() { Id = 69, FieldName = "اسم المالك", Description = "أدخل اسم مالك النشاط.", HtmlType = "text" },
    new() { Id = 70, FieldName = "رقم إيصال الرسوم", Description = "أدخل رقم إيصال دفع رسوم التسجيل.", HtmlType = "text" },

    // 🔹 Fields for إصدار تصريح عمل (ServiceId = 8)
    new() { Id = 71, FieldName = "رقم جواز السفر", Description = "أدخل رقم جواز السفر.", HtmlType = "text" },
    new() { Id = 72, FieldName = "الجنسية", Description = "أدخل جنسيتك.", HtmlType = "text" },
    new() { Id = 73, FieldName = "اسم جهة العمل", Description = "أدخل اسم جهة العمل في مصر.", HtmlType = "text" },
    new() { Id = 74, FieldName = "عنوان جهة العمل", Description = "أدخل عنوان جهة العمل.", HtmlType = "text" },
    new() { Id = 75, FieldName = "مدة العقد", Description = "أدخل مدة عقد العمل (بالأشهر).", HtmlType = "number" },
    new() { Id = 76, FieldName = "المؤهل الدراسي", Description = "أدخل أعلى مؤهل دراسي حصلت عليه.", HtmlType = "text" },
    new() { Id = 77, FieldName = "تاريخ بدء العمل", Description = "أدخل تاريخ بدء العمل.", HtmlType = "date" },
    new() { Id = 78, FieldName = "رقم التأشيرة", Description = "أدخل رقم التأشيرة (إن وجد).", HtmlType = "text" },
    new() { Id = 79, FieldName = "اسم المسؤول", Description = "أدخل اسم المسؤول في جهة العمل.", HtmlType = "text" },
    new() { Id = 80, FieldName = "رقم إيصال الرسوم", Description = "أدخل رقم إيصال دفع رسوم التصريح.", HtmlType = "text" },

    // 🔹 Fields for تجديد تصريح الإقامة (ServiceId = 9)
    new() { Id = 81, FieldName = "رقم تصريح الإقامة الحالي", Description = "أدخل رقم تصريح الإقامة الحالي.", HtmlType = "text" },
    new() { Id = 82, FieldName = "تاريخ انتهاء الإقامة", Description = "أدخل تاريخ انتهاء الإقامة الحالية.", HtmlType = "date" },
    new() { Id = 83, FieldName = "سبب الإقامة", Description = "أدخل سبب الإقامة (عمل/دراسة).", HtmlType = "text" },
    new() { Id = 84, FieldName = "مدة الإقامة المطلوبة", Description = "أدخل مدة الإقامة المطلوبة (بالأشهر).", HtmlType = "number" },
    new() { Id = 85, FieldName = "اسم الكفيل", Description = "أدخل اسم الكفيل (إن وجد).", HtmlType = "text" },
    new() { Id = 86, FieldName = "عنوان السكن", Description = "أدخل عنوان السكن في مصر.", HtmlType = "text" },
    new() { Id = 87, FieldName = "رقم جواز السفر", Description = "أدخل رقم جواز السفر.", HtmlType = "text" },
    new() { Id = 88, FieldName = "تاريخ التقديم", Description = "أدخل تاريخ تقديم طلب التجديد.", HtmlType = "date" },
    new() { Id = 89, FieldName = "رقم إيصال الرسوم", Description = "أدخل رقم إيصال دفع رسوم التجديد.", HtmlType = "text" },
    new() { Id = 90, FieldName = "الجنسية", Description = "أدخل جنسيتك.", HtmlType = "text" },

    // 🔹 Fields for التسجيل الضريبي (ServiceId = 10)
    new() { Id = 91, FieldName = "نوع الضريبة", Description = "أدخل نوع الضريبة (دخل/قيمة مضافة).", HtmlType = "text" },
    new() { Id = 92, FieldName = "الدخل السنوي", Description = "أدخل تقدير دخلك السنوي.", HtmlType = "number" },
    new() { Id = 93, FieldName = "رقم الحساب البنكي", Description = "أدخل رقم حسابك البنكي.", HtmlType = "text" },
    new() { Id = 94, FieldName = "اسم النشاط التجاري", Description = "أدخل اسم النشاط التجاري.", HtmlType = "text" },
    new() { Id = 95, FieldName = "رقم السجل التجاري", Description = "أدخل رقم السجل التجاري.", HtmlType = "text" },
    new() { Id = 96, FieldName = "تاريخ التسجيل", Description = "أدخل تاريخ التسجيل الضريبي.", HtmlType = "date" },
    new() { Id = 97, FieldName = "عنوان النشاط", Description = "أدخل عنوان النشاط الضريبي.", HtmlType = "text" },
    new() { Id = 98, FieldName = "رقم إيصال الرسوم", Description = "أدخل رقم إيصال دفع رسوم التسجيل.", HtmlType = "text" },
    new() { Id = 99, FieldName = "اسم المحاسب", Description = "أدخل اسم المحاسب القانوني (إن وجد).", HtmlType = "text" },
    new() { Id = 100, FieldName = "رقم التسجيل السابق", Description = "أدخل رقم التسجيل الضريبي السابق (إن وجد).", HtmlType = "text" },

    // 🔹 Fields for استخراج شهادة وفاة (ServiceId = 11)
    new() { Id = 101, FieldName = "اسم المتوفى", Description = "أدخل اسم المتوفى الكامل.", HtmlType = "text" },
    new() { Id = 102, FieldName = "تاريخ الوفاة", Description = "أدخل تاريخ الوفاة.", HtmlType = "date" },
    new() { Id = 103, FieldName = "مكان الوفاة", Description = "أدخل مكان الوفاة.", HtmlType = "text" },
    new() { Id = 104, FieldName = "رقم تسجيل الوفاة", Description = "أدخل رقم تسجيل الوفاة.", HtmlType = "text" },
    new() { Id = 105, FieldName = "العلاقة بالمتوفى", Description = "أدخل علاقتك بالمتوفى.", HtmlType = "text" },
    new() { Id = 106, FieldName = "اسم المقبرة", Description = "أدخل اسم المقبرة أو مكان الدفن.", HtmlType = "text" },
    new() { Id = 107, FieldName = "تاريخ الدفن", Description = "أدخل تاريخ الدفن.", HtmlType = "date" },
    new() { Id = 108, FieldName = "رقم إيصال الرسوم", Description = "أدخل رقم إيصال دفع رسوم الشهادة.", HtmlType = "text" },
    new() { Id = 109, FieldName = "اسم مقدم الطلب", Description = "أدخل اسم مقدم الطلب.", HtmlType = "text" },
    new() { Id = 110, FieldName = "سبب الوفاة", Description = "أدخل سبب الوفاة (إن وجد).", HtmlType = "text" },

    // 🔹 Fields for تجديد السجل التجاري (ServiceId = 12)
    new() { Id = 111, FieldName = "رقم السجل التجاري الحالي", Description = "أدخل رقم السجل التجاري الحالي.", HtmlType = "text" },
    new() { Id = 112, FieldName = "تاريخ انتهاء السجل", Description = "أدخل تاريخ انتهاء السجل الحالي.", HtmlType = "date" },
    new() { Id = 113, FieldName = "رأس المال المحدث", Description = "أدخل قيمة رأس المال المحدث.", HtmlType = "number" },
    new() { Id = 114, FieldName = "عدد الموظفين المحدث", Description = "أدخل عدد الموظفين الحالي.", HtmlType = "number" },
    new() { Id = 115, FieldName = "اسم النشاط التجاري", Description = "أدخل اسم النشاط التجاري.", HtmlType = "text" },
    new() { Id = 116, FieldName = "عنوان المقر المحدث", Description = "أدخل عنوان المقر التجاري المحدث.", HtmlType = "text" },
    new() { Id = 117, FieldName = "رقم التسجيل الضريبي", Description = "أدخل رقم التسجيل الضريبي.", HtmlType = "text" },
    new() { Id = 118, FieldName = "تاريخ التجديد", Description = "أدخل تاريخ تقديم طلب التجديد.", HtmlType = "date" },
    new() { Id = 119, FieldName = "رقم إيصال الرسوم", Description = "أدخل رقم إيصال دفع رسوم التجديد.", HtmlType = "text" },
    new() { Id = 120, FieldName = "اسم المالك", Description = "أدخل اسم مالك النشاط.", HtmlType = "text" },

    // 🔹 Fields for إصدار شهادة حسن سير وسلوك (ServiceId = 13)
    new() { Id = 121, FieldName = "الغرض من الشهادة", Description = "أدخل الغرض من استخراج الشهادة.", HtmlType = "text" },
    new() { Id = 122, FieldName = "تاريخ التقديم", Description = "أدخل تاريخ تقديم طلب الشهادة.", HtmlType = "date" },
    new() { Id = 123, FieldName = "محل الإصدار", Description = "أدخل مكان إصدار الشهادة.", HtmlType = "text" },
    new() { Id = 124, FieldName = "رقم الموعد", Description = "أدخل رقم الموعد لاستلام الشهادة.", HtmlType = "text" },
    new() { Id = 125, FieldName = "اسم الأب", Description = "أدخل اسم الأب الكامل.", HtmlType = "text" },
    new() { Id = 126, FieldName = "اسم الأم", Description = "أدخل اسم الأم الكامل.", HtmlType = "text" },
    new() { Id = 127, FieldName = "رقم إيصال الرسوم", Description = "أدخل رقم إيصال دفع رسوم الشهادة.", HtmlType = "text" },
    new() { Id = 128, FieldName = "الجنس", Description = "أدخل جنسك (ذكر/أنثى).", HtmlType = "text" },
    new() { Id = 129, FieldName = "تاريخ الميلاد", Description = "أدخل تاريخ ميلادك.", HtmlType = "date" },
    new() { Id = 130, FieldName = "محل الميلاد", Description = "أدخل مكان ميلادك.", HtmlType = "text" },

    // 🔹 Fields for تسجيل عقار (ServiceId = 14)
    new() { Id = 131, FieldName = "عنوان العقار", Description = "أدخل عنوان العقار بالتفصيل.", HtmlType = "text" },
    new() { Id = 132, FieldName = "رقم العقد", Description = "أدخل رقم عقد الملكية.", HtmlType = "text" },
    new() { Id = 133, FieldName = "نوع العقار", Description = "أدخل نوع العقار (شقة/أرض).", HtmlType = "text" },
    new() { Id = 134, FieldName = "مساحة العقار", Description = "أدخل مساحة العقار بالمتر المربع.", HtmlType = "number" },
    new() { Id = 135, FieldName = "تاريخ الشراء", Description = "أدخل تاريخ شراء العقار.", HtmlType = "date" },
    new() { Id = 136, FieldName = "اسم البائع", Description = "أدخل اسم البائع في العقد.", HtmlType = "text" },
    new() { Id = 137, FieldName = "رقم الخريطة المساحية", Description = "أدخل رقم الخريطة المساحية.", HtmlType = "text" },
    new() { Id = 138, FieldName = "رقم إيصال الرسوم", Description = "أدخل رقم إيصال دفع رسوم التسجيل.", HtmlType = "text" },
    new() { Id = 139, FieldName = "اسم المالك", Description = "أدخل اسم مالك العقار.", HtmlType = "text" },
    new() { Id = 140, FieldName = "قيمة العقار", Description = "أدخل القيمة المالية للعقار.", HtmlType = "number" },

    // 🔹 Fields for التقديم للحصول على دعم تمويني (ServiceId = 15)
    new() { Id = 141, FieldName = "عدد أفراد الأسرة", Description = "أدخل عدد أفراد الأسرة.", HtmlType = "number" },
    new() { Id = 142, FieldName = "الدخل الشهري", Description = "أدخل تقدير دخلك الشهري.", HtmlType = "number" },
    new() { Id = 143, FieldName = "رقم بطاقة التموين الحالية", Description = "أدخل رقم بطاقة التموين (إن وجد).", HtmlType = "text" },
    new() { Id = 144, FieldName = "اسم المخبز المفضل", Description = "أدخل اسم المخبز المفضل للتوزيع.", HtmlType = "text" },
    new() { Id = 145, FieldName = "تاريخ التقديم", Description = "أدخل تاريخ تقديم طلب الدعم.", HtmlType = "date" },
    new() { Id = 146, FieldName = "رقم إيصال الرسوم", Description = "أدخل رقم إيصال دفع رسوم التقديم.", HtmlType = "text" },
    new() { Id = 147, FieldName = "اسم مقدم الطلب", Description = "أدخل اسم مقدم الطلب.", HtmlType = "text" },
    new() { Id = 148, FieldName = "الحالة الاجتماعية", Description = "أدخل حالتك الاجتماعية.", HtmlType = "text" },
    new() { Id = 149, FieldName = "عنوان السكن", Description = "أدخل عنوان السكن الحالي.", HtmlType = "text" },
    new() { Id = 150, FieldName = "رقم الحساب البنكي", Description = "أدخل رقم الحساب البنكي (إن وجد).", HtmlType = "text" }
]);

            builder.ToTable("Fields");


        }
    }
}

