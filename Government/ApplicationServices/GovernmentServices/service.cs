using Government.Contracts.Services;
using Government.Entities;
using Government.Errors;
using Mapster;

namespace Government.ApplicationServices.GovernmentServices
{

    public class service(AppDbContext context) : IService
    {
        private readonly AppDbContext _context = context;

        public async Task<Result<IEnumerable<ServiceResponse>>> GetAllAvailableServicesAsync(string serviceCategory, CancellationToken cancellationToken = default)
        {
            if (serviceCategory == "All")
            {
                var services = await _context.Services
                             .Where(x => x.IsAvailable)
                             .AsNoTracking()
                             .ToListAsync(cancellationToken);

                var serviceResponse = services.Adapt<IEnumerable<ServiceResponse>>();
                return Result.Success(serviceResponse);

            }
            else
            {

                var services = await _context.Services
                                        .Where(x => x.IsAvailable && x.category == serviceCategory)
                                        .AsNoTracking()
                                        .ToListAsync(cancellationToken);

                var serviceResponse = services.Adapt<IEnumerable<ServiceResponse>>();
                return Result.Success(serviceResponse);
            }

           
        }

        public async Task<Result<IEnumerable<ServiceResponse>>> GetAllServicesAsync(CancellationToken cancellationToken = default)
        {
            var services = await _context.Services
                                    .AsNoTracking() 
                                    .ToListAsync(cancellationToken);

            var serviceResponse = services.Adapt<IEnumerable<ServiceResponse>>();

            return Result.Success(serviceResponse);
        }

        public async Task<Result<ServiceResponse>> GetServicesByIdAsync(int serviceId, CancellationToken cancellationToken = default)
        {
            var Specificservice = await _context.Services
                                .Where(x => x.IsAvailable && x.Id == serviceId)
                                .AsNoTracking()
                                .SingleOrDefaultAsync(cancellationToken);

            if (Specificservice is null)
                return Result.Falire<ServiceResponse>(ServiceError.ServiceNotFound);


            var serviceResponse = Specificservice.Adapt<ServiceResponse>();

            return Result.Success(serviceResponse);


        }

        public async Task<Result<ServiceResponse>> AddServiceAsync(AddServiceRequest request, CancellationToken cancellationToken = default)
        {
            var isDuplicate = await _context.Services
                                 .AnyAsync(x => (x.ServiceName == request.ServiceName || x.ServiceDescription == request.ServiceDescription), cancellationToken);
                                       
            if (isDuplicate)
                return Result.Falire<ServiceResponse>(ServiceError.DuplicatingNameOrDescription);

            var newService = request.Adapt<Service>();

            await _context.Services.AddAsync(newService);

            await _context.SaveChangesAsync(cancellationToken);

            var ServiceResponse = newService.Adapt<ServiceResponse>();

            return Result.Success(ServiceResponse);


        }

        public async Task<Result> ToggleServiceAsync(int serviceId, CancellationToken cancellationToken = default)
        {
            var service = await _context.Services
                                 .SingleOrDefaultAsync(x => x.Id == serviceId,cancellationToken);

            if (service is null)
                return Result.Falire(ServiceError.ServiceNotFound);


            service.IsAvailable = !(service.IsAvailable);
            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();

        }

        public async Task<Result> UpdateServiceAsync(int serviceId,AddServiceRequest request, CancellationToken cancellationToken = default)
        {
            var service = await _context.Services.SingleOrDefaultAsync(x => x.Id == serviceId, cancellationToken); // check service id 

            if (service is null)
                return Result.Falire(ServiceError.ServiceNotFound);

            var isDuplicate = await _context.Services
                                 .AnyAsync(x => (x.ServiceName == request.ServiceName || x.ServiceDescription == request.ServiceDescription)
                                        && x.Id != serviceId, cancellationToken);

            if (isDuplicate)
                return Result.Falire(ServiceError.DuplicatingNameOrDescription);

             request.Adapt(service);

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();


        }
       
        public async Task<Result<IEnumerable<MostRequested>>> GetMostRequestedServicesAsync()
        {

            var mostRequestedServices = await _context.Requests
                                             .GroupBy(r => r.ServiceId)
                                             .Select(x => new
                                             {
                                                 ServiceId = x.Key,
                                                 RequestCount = x.Count()
                                             })
                                             .OrderByDescending(u => u.RequestCount)
                                             .Take(5)
                                             .ToListAsync();

                                                    
            var serviceIds = mostRequestedServices.Select(x => x.ServiceId).ToList();


            //var services = await _context.Services
            //                   .Where(s => serviceIds.Contains(s.Id))
            //                   .Select(s => s.ServiceName)
            //                   .ToListAsync();

            var services = await _context.Services
                      .Where(s => serviceIds.Contains(s.Id))
                      .Select(s => new MostRequested(s.ServiceName)) // تحويل مباشرة إلى MostRequested
                      .ToListAsync();

            // var service = new MostRequested(services);



            return Result.Success<IEnumerable<MostRequested>>(services);






        }
    }
}
