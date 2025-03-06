using Government.Contracts.Request.Submiting;

namespace Government.Contracts.Request.Submiting
{
    public class ServiceDataDtoValidator :AbstractValidator<ServiceDataDto>
    {

        public ServiceDataDtoValidator()
        {
            RuleFor(x => x.FieldId)
               .GreaterThan(0).WithMessage("معرف الحقل يجب أن يكون أكبر من 0");

            // التحقق من أن واحد على الأقل من القيم موجود
            RuleFor(x => x)
                .Must(x => x.FieldValueString != null || x.FieldValueInt.HasValue ||
                          x.FieldValueFloat.HasValue || x.FieldValueDate.HasValue)
                .WithMessage("يجب إدخال قيمة واحدة على الأقل (نص، عدد، عشري، تاريخ)");

            RuleFor(x => x.FieldValueString)
                .MaximumLength(500).When(x => x.FieldValueString != null)
                .WithMessage("القيمة النصية يجب ألا تتجاوز 500 حرف");

            RuleFor(x => x.FieldValueInt)
                .GreaterThanOrEqualTo(0).When(x => x.FieldValueInt.HasValue)
                .WithMessage("القيمة العددية يجب ألا تكون سالبة");

            RuleFor(x => x.FieldValueFloat)
                .GreaterThanOrEqualTo(0).When(x => x.FieldValueFloat.HasValue)
                .WithMessage("القيمة العشرية يجب ألا تكون سالبة");

            RuleFor(x => x.FieldValueDate)
                .LessThanOrEqualTo(DateTime.UtcNow).When(x => x.FieldValueDate.HasValue)
                .WithMessage("تاريخ الحقل يجب ألا يكون في المستقبل");
        }
    }
    }

