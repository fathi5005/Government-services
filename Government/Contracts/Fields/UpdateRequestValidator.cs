using Government.Contracts.Fields;

public class UpdateRequestValidator : AbstractValidator<UpdateRequest>
{
    public UpdateRequestValidator()
    {


        RuleFor(x => x.FieldId)
            .NotEmpty().WithMessage("FieldId مطلوب")
            .GreaterThan(0).WithMessage("يجب أن يكون FieldId أكبر من 0");

        RuleFor(x => x.FieldDataId)
            .NotEmpty().WithMessage("FieldDataId مطلوب")
            .GreaterThan(0).WithMessage("يجب أن يكون FieldDataId أكبر من 0");
    }
}
