using Government.Contracts.Request;

namespace Government.Services
{
    public interface IRequestService
    {

        Task<ReqResponseDto> AddAsync(RequestDto requestDto, CancellationToken cancellationToken);
        Task<IEnumerable<RequestsDetailstoUser>> GetUserRequestsDetails( CancellationToken cancellationToken);
   
    }
}
