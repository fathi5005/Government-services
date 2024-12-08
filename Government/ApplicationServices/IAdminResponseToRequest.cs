using Government.Contracts.Admin;

namespace Government.ApplicationServices
{
    public interface IAdminResponseToRequest
    {

        Task<AdminReplyResult> GetAdminResponseAsync( AdminReply  adminReplyToREquest , CancellationToken cancellationToken=default!  );
    }
}
