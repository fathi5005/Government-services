using Government.Contracts.Services;
using Mapster;

namespace Government.ApplicationServices.GovernmentServices
{

    public class service : IService
    {
        private readonly AppDbContext _context;

        public service(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ServiceResponse>> GetServicesAsync(CancellationToken cancellationToken = default)
        {
            var services = await _context.Services.AsNoTracking().ToListAsync(cancellationToken);
            var serviceResponse = services.Adapt<IEnumerable<ServiceResponse>>();
            return serviceResponse;
        }
    }
}
