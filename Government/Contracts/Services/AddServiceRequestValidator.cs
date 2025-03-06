using FluentValidation;

namespace Government.Contracts.Services
{
    public class AddServiceRequestValidator:AbstractValidator<AddServiceRequest>
    {

        public AddServiceRequestValidator()
        {
            RuleFor(x => x.ServiceName)
             .NotEmpty()
                 .WithMessage("Service Name is required.")
             .MaximumLength(250)
                 .WithMessage("Service Name must not exceed 250 characters.");

            RuleFor(x => x.ServiceDescription)
                .NotEmpty()
                    .WithMessage("Service Description is required.")
                .MaximumLength(1500)
                    .WithMessage("Service Description must not exceed 1500 characters.");

            RuleFor(x => x.Fee)
                .NotEmpty()
                    .WithMessage("Fee is required.")
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Fee must be a positive number."); 

            RuleFor(x => x.ProcessingTime)
                .NotEmpty().WithMessage("Processing Time is required.")
                .MaximumLength(250).WithMessage("Processing Time must not exceed 250 characters.");

            RuleFor(x => x.ContactInfo)
                .NotEmpty()
                    .WithMessage("Contact Info is required.")
                .MaximumLength(1500)
                    .WithMessage("Contact Info must not exceed 1500 characters.");


        }

    }
}

