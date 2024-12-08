using Government.Contracts.Services;

namespace Government.ApplicationServices
{
    public interface IService
    {

        Task <IEnumerable<ServiceResponse>> GetServicesAsync (CancellationToken cancellationToken = default);

    }
}
