using Government.Contracts.Admin;

namespace Government.ApplicationServices.AdminServices
{
    public interface IAdminResponseToRequest
    {

        Task<Result<AdminReplyResult>> AddAdminResponseAsync(AdminReply adminReplyToREquest, CancellationToken cancellationToken = default!);
    }
}
