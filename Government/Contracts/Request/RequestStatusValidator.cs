using FluentValidation;

namespace Government.Contracts.Request
{
    public class RequestStatusValidator:AbstractValidator<RequestStatus>
    {
        public RequestStatusValidator()
        {
            RuleFor(x => x.requestStatus)
                .NotEmpty();
        }
    }
}
