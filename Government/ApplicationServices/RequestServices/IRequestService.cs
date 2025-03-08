using Government.Contracts.Request;
using Government.Contracts.Request.Submiting;

namespace Government.ApplicationServices.RequestServices
{
    public interface IRequestService
    {

       // Task<Result <AddRequestResponseDto>> AddRequestAsync(AddRequestDto requestDto, CancellationToken cancellationToken);
        Task<Result<IEnumerable<RequestsDetailstoUser>>> GetUserRequestsDetails(CancellationToken cancellationToken);
        Task<Result<RequestDetailsResponse>> GetRequestAsync(int requestId, CancellationToken cancellationToken);
        Task<Result<IEnumerable<RequestsDetailstoUser>>> GetRequestByStatusAsync(string request, CancellationToken cancellationToken);
        Task<Result <SubmitResponseDto>> SubmitRequestAsync(SubmitRequestDto requestDto, CancellationToken cancellationToken);

    }
}
