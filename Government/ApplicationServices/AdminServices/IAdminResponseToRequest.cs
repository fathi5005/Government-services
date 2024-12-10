using Government.Contracts.Admin;

namespace Government.ApplicationServices.AdminServices
{
    public interface IAdminResponseToRequest
    {

        Task<Result<AdminReplyResult>> GetAdminResponseAsync(AdminReply adminReplyToREquest, CancellationToken cancellationToken = default!);
    }
}
