using FluentValidation;

namespace Government.Contracts.Admin
{
    public class AdminReplyValidation:AbstractValidator<AdminReply>
    {

        public AdminReplyValidation()
        {
            RuleFor(x => x.RequestId).NotEmpty();

            RuleFor(x => x.RequestId)
             .GreaterThan(0)
             .WithMessage("ServiceId must be greater than zero.");

            RuleFor(x => x.ResponseText).NotEmpty();

            RuleFor(x => x.Action)
                 .NotEmpty()
                 .Must(action => action == "Approve" || action == "Reject")
                 .WithMessage("Action must be either 'Approve' or 'Reject'.");



        }
    }
}
