using Government.Contracts.Request;
using Government.Contracts.Services;
using Mapster;

namespace Government.Mapping
{
    public class MappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Request, ReqResponseDto>()
             . Map(dest => dest.RequestID, src => src.RequestID)
                .Map(dest => dest.ServiceName, src => src.service.ServiceName);

            config.NewConfig<Request, RequestsDetailstoUser>()
           .Map(dest => dest.RequestID, src => src.RequestID)
              .Map(dest => dest.ServiceName, src => src.service.ServiceName)
              .Map(dest => dest.ResponseToThisRequestFromAdmin, src => src.AdminResponse != null ? src.AdminResponse.ResponseText : "No response yet");



            config.NewConfig<Service, ServiceResponse>()
              .Map(dest => dest.ServiceID, src => src.ServiceID);
            
        }
    }
}
