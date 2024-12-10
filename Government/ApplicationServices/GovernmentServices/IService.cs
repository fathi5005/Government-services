using Government.Contracts.Services;

namespace Government.ApplicationServices.GovernmentServices
{
    public interface IService
    {

        Task<IEnumerable<ServiceResponse>> GetServicesAsync(CancellationToken cancellationToken = default);

    }
}
