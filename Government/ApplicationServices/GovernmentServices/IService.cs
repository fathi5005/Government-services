using Government.Contracts.Services;

namespace Government.ApplicationServices.GovernmentServices
{
    public interface IService
    {

        Task<Result<IEnumerable<ServiceResponse>>> GetAllServicesAsync(CancellationToken cancellationToken = default);
        Task<Result<IEnumerable<ServiceResponse>>> GetAllAvailableServicesAsync(string serviceCategory,CancellationToken cancellationToken = default);
        Task<Result<ServiceResponse>> GetServicesByIdAsync(int serviceId ,CancellationToken cancellationToken = default);
        Task<Result<ServiceResponse>> AddServiceAsync(AddServiceRequest request ,CancellationToken cancellationToken = default);
        Task<Result> UpdateServiceAsync(int serviceId, AddServiceRequest request ,CancellationToken cancellationToken = default);
        Task<Result> ToggleServiceAsync(int serviceId, CancellationToken cancellationToken = default);
        Task<Result<IEnumerable<MostRequested>>> GetMostRequestedServicesAsync();


    }
}
