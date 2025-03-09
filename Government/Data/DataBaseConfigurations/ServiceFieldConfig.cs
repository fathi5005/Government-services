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
     // 🔹 تجديد جواز السفر (ServiceId = 1)
     new() { Id = 1, ServiceId = 1, FieldId = 1 },   // رقم جواز السفر الحالي
    new() { Id = 2, ServiceId = 1, FieldId = 2 },   // رقم جواز السفر السابق
    new() { Id = 3, ServiceId = 1, FieldId = 3 },   // تاريخ إصدار الجواز
    new() { Id = 4, ServiceId = 1, FieldId = 4 },   // تاريخ انتهاء الجواز
    new() { Id = 5, ServiceId = 1, FieldId = 5 },   // جهة إصدار الجواز
    new() { Id = 6, ServiceId = 1, FieldId = 6 },   // الاسم باللغة الإنجليزية
    new() { Id = 7, ServiceId = 1, FieldId = 7 },   // رقم تأكيد الدفع
    new() { Id = 8, ServiceId = 1, FieldId = 8 },   // الجنس
    new() { Id = 9, ServiceId = 1, FieldId = 9 },   // المهنة
    new() { Id = 10, ServiceId = 1, FieldId = 10 }, // رقم الموعد

    // 🔹 إصدار رخصة قيادة (ServiceId = 2)
    new() { Id = 11, ServiceId = 2, FieldId = 11 }, // نوع رخصة القيادة
    new() { Id = 12, ServiceId = 2, FieldId = 12 }, // رقم الملف المروري
    new() { Id = 13, ServiceId = 2, FieldId = 13 }, // تاريخ اجتياز الاختبار
    new() { Id = 14, ServiceId = 2, FieldId = 14 }, // اسم مدرسة القيادة
    new() { Id = 15, ServiceId = 2, FieldId = 15 }, // رقم شهادة اللياقة
    new() { Id = 16, ServiceId = 2, FieldId = 16 }, // المحافظة المصدرة
    new() { Id = 17, ServiceId = 2, FieldId = 17 }, // تاريخ التقديم للرخصة
    new() { Id = 18, ServiceId = 2, FieldId = 18 }, // رقم إيصال الرسوم
    new() { Id = 19, ServiceId = 2, FieldId = 19 }, // نوع المركبة المطلوبة
    new() { Id = 20, ServiceId = 2, FieldId = 20 }, // حالة الرخصة السابقة

    // 🔹 تسجيل مركبة (ServiceId = 3)
    new() { Id = 21, ServiceId = 3, FieldId = 21 }, // رقم لوحة المركبة
    new() { Id = 22, ServiceId = 3, FieldId = 22 }, // رقم الشاسيه
    new() { Id = 23, ServiceId = 3, FieldId = 23 }, // رقم الموتور
    new() { Id = 24, ServiceId = 3, FieldId = 24 }, // نوع المركبة
    new() { Id = 25, ServiceId = 3, FieldId = 25 }, // سنة الصنع
    new() { Id = 26, ServiceId = 3, FieldId = 26 }, // رقم التأمين
    new() { Id = 27, ServiceId = 3, FieldId = 27 }, // تاريخ التسجيل
    new() { Id = 28, ServiceId = 3, FieldId = 28 }, // اسم الوكيل
    new() { Id = 29, ServiceId = 3, FieldId = 29 }, // رقم الفاتورة
    new() { Id = 30, ServiceId = 3, FieldId = 30 }, // لون المركبة

    // 🔹 إصدار شهادة زواج (ServiceId = 4)
    new() { Id = 31, ServiceId = 4, FieldId = 31 }, // اسم الزوج
    new() { Id = 32, ServiceId = 4, FieldId = 32 }, // اسم الزوجة
    new() { Id = 33, ServiceId = 4, FieldId = 33 }, // تاريخ الزواج
    new() { Id = 34, ServiceId = 4, FieldId = 34 }, // مكان الزواج
    new() { Id = 35, ServiceId = 4, FieldId = 35 }, // رقم عقد الزواج
    new() { Id = 36, ServiceId = 4, FieldId = 36 }, // اسم المأذون
    new() { Id = 37, ServiceId = 4, FieldId = 37 }, // عدد الشهود
    new() { Id = 38, ServiceId = 4, FieldId = 38 }, // تاريخ التسجيل
    new() { Id = 39, ServiceId = 4, FieldId = 39 }, // رقم إيصال الرسوم
    new() { Id = 40, ServiceId = 4, FieldId = 40 }, // محل إقامة الزوجين

    // 🔹 إصدار شهادة ميلاد (ServiceId = 5)
    new() { Id = 41, ServiceId = 5, FieldId = 41 }, // اسم المولود
    new() { Id = 42, ServiceId = 5, FieldId = 42 }, // تاريخ الميلاد
    new() { Id = 43, ServiceId = 5, FieldId = 43 }, // محل الميلاد
    new() { Id = 44, ServiceId = 5, FieldId = 44 }, // اسم المستشفى
    new() { Id = 45, ServiceId = 5, FieldId = 45 }, // رقم تسجيل الميلاد
    new() { Id = 46, ServiceId = 5, FieldId = 46 }, // جنس المولود
    new() { Id = 47, ServiceId = 5, FieldId = 47 }, // اسم الطبيب
    new() { Id = 48, ServiceId = 5, FieldId = 48 }, // تاريخ الإصدار
    new() { Id = 49, ServiceId = 5, FieldId = 49 }, // رقم إيصال الرسوم
    new() { Id = 50, ServiceId = 5, FieldId = 50 }, // اسم مقدم الطلب

    // 🔹 التقديم لبطاقة الرقم القومي (ServiceId = 6)
    new() { Id = 51, ServiceId = 6, FieldId = 51 }, // رقم شهادة الميلاد
    new() { Id = 52, ServiceId = 6, FieldId = 52 }, // تاريخ تقديم الطلب
    new() { Id = 53, ServiceId = 6, FieldId = 53 }, // رقم الموعد
    new() { Id = 54, ServiceId = 6, FieldId = 54 }, // محل الإصدار
    new() { Id = 55, ServiceId = 6, FieldId = 55 }, // رقم البصمة
    new() { Id = 56, ServiceId = 6, FieldId = 56 }, // اسم الأب
    new() { Id = 57, ServiceId = 6, FieldId = 57 }, // اسم الأم
    new() { Id = 58, ServiceId = 6, FieldId = 58 }, // الجنس
    new() { Id = 59, ServiceId = 6, FieldId = 59 }, // رقم إيصال الرسوم
    new() { Id = 60, ServiceId = 6, FieldId = 60 }, // الحالة الاجتماعية

    // 🔹 تسجيل رخصة تجارية (ServiceId = 7)
    new() { Id = 61, ServiceId = 7, FieldId = 61 }, // اسم النشاط التجاري
    new() { Id = 62, ServiceId = 7, FieldId = 62 }, // نوع النشاط
    new() { Id = 63, ServiceId = 7, FieldId = 63 }, // رأس المال
    new() { Id = 64, ServiceId = 7, FieldId = 64 }, // رقم التسجيل الضريبي
    new() { Id = 65, ServiceId = 7, FieldId = 65 }, // عدد الموظفين
    new() { Id = 66, ServiceId = 7, FieldId = 66 }, // تاريخ بدء النشاط
    new() { Id = 67, ServiceId = 7, FieldId = 67 }, // عنوان المقر
    new() { Id = 68, ServiceId = 7, FieldId = 68 }, // رقم السجل التجاري
    new() { Id = 69, ServiceId = 7, FieldId = 69 }, // اسم المالك
    new() { Id = 70, ServiceId = 7, FieldId = 70 }, // رقم إيصال الرسوم

    // 🔹 إصدار تصريح عمل (ServiceId = 8)
    new() { Id = 71, ServiceId = 8, FieldId = 71 }, // رقم جواز السفر
    new() { Id = 72, ServiceId = 8, FieldId = 72 }, // الجنسية
    new() { Id = 73, ServiceId = 8, FieldId = 73 }, // اسم جهة العمل
    new() { Id = 74, ServiceId = 8, FieldId = 74 }, // عنوان جهة العمل
    new() { Id = 75, ServiceId = 8, FieldId = 75 }, // مدة العقد
    new() { Id = 76, ServiceId = 8, FieldId = 76 }, // المؤهل الدراسي
    new() { Id = 77, ServiceId = 8, FieldId = 77 }, // تاريخ بدء العمل
    new() { Id = 78, ServiceId = 8, FieldId = 78 }, // رقم التأشيرة
    new() { Id = 79, ServiceId = 8, FieldId = 79 }, // اسم المسؤول
    new() { Id = 80, ServiceId = 8, FieldId = 80 }, // رقم إيصال الرسوم

    // 🔹 تجديد تصريح الإقامة (ServiceId = 9)
    new() { Id = 81, ServiceId = 9, FieldId = 81 }, // رقم تصريح الإقامة الحالي
    new() { Id = 82, ServiceId = 9, FieldId = 82 }, // تاريخ انتهاء الإقامة
    new() { Id = 83, ServiceId = 9, FieldId = 83 }, // سبب الإقامة
    new() { Id = 84, ServiceId = 9, FieldId = 84 }, // مدة الإقامة المطلوبة
    new() { Id = 85, ServiceId = 9, FieldId = 85 }, // اسم الكفيل
    new() { Id = 86, ServiceId = 9, FieldId = 86 }, // عنوان السكن
    new() { Id = 87, ServiceId = 9, FieldId = 87 }, // رقم جواز السفر
    new() { Id = 88, ServiceId = 9, FieldId = 88 }, // تاريخ التقديم
    new() { Id = 89, ServiceId = 9, FieldId = 89 }, // رقم إيصال الرسوم
    new() { Id = 90, ServiceId = 9, FieldId = 90 }, // الجنسية

    // 🔹 التسجيل الضريبي (ServiceId = 10)
    new() { Id = 91, ServiceId = 10, FieldId = 91 },  // نوع الضريبة
    new() { Id = 92, ServiceId = 10, FieldId = 92 },  // الدخل السنوي
    new() { Id = 93, ServiceId = 10, FieldId = 93 },  // رقم الحساب البنكي
    new() { Id = 94, ServiceId = 10, FieldId = 94 },  // اسم النشاط التجاري
    new() { Id = 95, ServiceId = 10, FieldId = 95 },  // رقم السجل التجاري
    new() { Id = 96, ServiceId = 10, FieldId = 96 },  // تاريخ التسجيل
    new() { Id = 97, ServiceId = 10, FieldId = 97 },  // عنوان النشاط
    new() { Id = 98, ServiceId = 10, FieldId = 98 },  // رقم إيصال الرسوم
    new() { Id = 99, ServiceId = 10, FieldId = 99 },  // اسم المحاسب
    new() { Id = 100, ServiceId = 10, FieldId = 100 }, // رقم التسجيل السابق

    // 🔹 استخراج شهادة وفاة (ServiceId = 11)
    new() { Id = 101, ServiceId = 11, FieldId = 101 }, // اسم المتوفى
    new() { Id = 102, ServiceId = 11, FieldId = 102 }, // تاريخ الوفاة
    new() { Id = 103, ServiceId = 11, FieldId = 103 }, // مكان الوفاة
    new() { Id = 104, ServiceId = 11, FieldId = 104 }, // رقم تسجيل الوفاة
    new() { Id = 105, ServiceId = 11, FieldId = 105 }, // العلاقة بالمتوفى
    new() { Id = 106, ServiceId = 11, FieldId = 106 }, // اسم المقبرة
    new() { Id = 107, ServiceId = 11, FieldId = 107 }, // تاريخ الدفن
    new() { Id = 108, ServiceId = 11, FieldId = 108 }, // رقم إيصال الرسوم
    new() { Id = 109, ServiceId = 11, FieldId = 109 }, // اسم مقدم الطلب
    new() { Id = 110, ServiceId = 11, FieldId = 110 }, // سبب الوفاة

    // 🔹 تجديد السجل التجاري (ServiceId = 12)
    new() { Id = 111, ServiceId = 12, FieldId = 111 }, // رقم السجل التجاري الحالي
    new() { Id = 112, ServiceId = 12, FieldId = 112 }, // تاريخ انتهاء السجل
    new() { Id = 113, ServiceId = 12, FieldId = 113 }, // رأس المال المحدث
    new() { Id = 114, ServiceId = 12, FieldId = 114 }, // عدد الموظفين المحدث
    new() { Id = 115, ServiceId = 12, FieldId = 115 }, // اسم النشاط التجاري
    new() { Id = 116, ServiceId = 12, FieldId = 116 }, // عنوان المقر المحدث
    new() { Id = 117, ServiceId = 12, FieldId = 117 }, // رقم التسجيل الضريبي
    new() { Id = 118, ServiceId = 12, FieldId = 118 }, // تاريخ التجديد
    new() { Id = 119, ServiceId = 12, FieldId = 119 }, // رقم إيصال الرسوم
    new() { Id = 120, ServiceId = 12, FieldId = 120 }, // اسم المالك

    // 🔹 إصدار شهادة حسن سير وسلوك (ServiceId = 13)
    new() { Id = 121, ServiceId = 13, FieldId = 121 }, // الغرض من الشهادة
    new() { Id = 122, ServiceId = 13, FieldId = 122 }, // تاريخ التقديم
    new() { Id = 123, ServiceId = 13, FieldId = 123 }, // محل الإصدار
    new() { Id = 124, ServiceId = 13, FieldId = 124 }, // رقم الموعد
    new() { Id = 125, ServiceId = 13, FieldId = 125 }, // اسم الأب
    new() { Id = 126, ServiceId = 13, FieldId = 126 }, // اسم الأم
    new() { Id = 127, ServiceId = 13, FieldId = 127 }, // رقم إيصال الرسوم
    new() { Id = 128, ServiceId = 13, FieldId = 128 }, // الجنس
    new() { Id = 129, ServiceId = 13, FieldId = 129 }, // تاريخ الميلاد
    new() { Id = 130, ServiceId = 13, FieldId = 130 }, // محل الميلاد

    // 🔹 تسجيل عقار (ServiceId = 14)
    new() { Id = 131, ServiceId = 14, FieldId = 131 }, // عنوان العقار
    new() { Id = 132, ServiceId = 14, FieldId = 132 }, // رقم العقد
    new() { Id = 133, ServiceId = 14, FieldId = 133 }, // نوع العقار
    new() { Id = 134, ServiceId = 14, FieldId = 134 }, // مساحة العقار
    new() { Id = 135, ServiceId = 14, FieldId = 135 }, // تاريخ الشراء
    new() { Id = 136, ServiceId = 14, FieldId = 136 }, // اسم البائع
    new() { Id = 137, ServiceId = 14, FieldId = 137 }, // رقم الخريطة المساحية
    new() { Id = 138, ServiceId = 14, FieldId = 138 }, // رقم إيصال الرسوم
    new() { Id = 139, ServiceId = 14, FieldId = 139 }, // اسم المالك
    new() { Id = 140, ServiceId = 14, FieldId = 140 }, // قيمة العقار

    // 🔹 التقديم للحصول على دعم تمويني (ServiceId = 15)
    new() { Id = 141, ServiceId = 15, FieldId = 141 }, // عدد أفراد الأسرة
    new() { Id = 142, ServiceId = 15, FieldId = 142 }, // الدخل الشهري
    new() { Id = 143, ServiceId = 15, FieldId = 143 }, // رقم بطاقة التموين الحالية
    new() { Id = 144, ServiceId = 15, FieldId = 144 }, // اسم المخبز المفضل
    new() { Id = 145, ServiceId = 15, FieldId = 145 }, // تاريخ التقديم
    new() { Id = 146, ServiceId = 15, FieldId = 146 }, // رقم إيصال الرسوم
    new() { Id = 147, ServiceId = 15, FieldId = 147 }, // اسم مقدم الطلب
    new() { Id = 148, ServiceId = 15, FieldId = 148 }, // الحالة الاجتماعية
    new() { Id = 149, ServiceId = 15, FieldId = 149 }, // عنوان السكن
    new() { Id = 150, ServiceId = 15, FieldId = 150 }  // رقم الحساب البنكي
 ]);
            builder.ToTable("ServiceFields");

        }
    }
}
