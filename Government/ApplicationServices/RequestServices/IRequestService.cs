using Government.Contracts.Fields;
using Government.Contracts.Request;
using Government.Contracts.Request.Submiting;

namespace Government.ApplicationServices.RequestServices
{
    public interface IRequestService
    {

       // Task<Result<RequestDetailsResponse>> GetRequestAsync(int requestId, CancellationToken cancellationToken);
       // Task<Result<RequestDetailsResponse>> GetRequestByIdAsync(int requestId, CancellationToken cancellationToken);
        Task<Result<IEnumerable<RequestsDetailstoUser>>> GetUserRequests(CancellationToken cancellationToken);
        Task<Result<IEnumerable<UpdateFields>>> GetUserRequestsDetails(int RequestId, CancellationToken cancellationToken);
        Task<Result<IEnumerable<RequestsDetailstoUser>>> GetRequestByStatusAsync(string request, CancellationToken cancellationToken);
        Task<Result <SubmitResponseDto>> SubmitRequestAsync(SubmitRequestDto requestDto, CancellationToken cancellationToken);

        Task<Result> UpdateRequestAsync(int requestId,IEnumerable< UpdateRequest> requestDto, CancellationToken cancellationToken);

    }
}
