using Government.Contracts.Request;

namespace Government.ApplicationServices.RequestServices
{
    public interface IRequestService
    {

        Task<Result <ReqResponseDto>> AddRequestAsync(RequestDto requestDto, CancellationToken cancellationToken);
        Task<Result<IEnumerable<RequestsDetailstoUser>>> GetUserRequestsDetails(CancellationToken cancellationToken);

    }
}
