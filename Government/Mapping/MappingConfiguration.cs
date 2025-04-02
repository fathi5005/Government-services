using Government.Contracts.Request;
using Government.Contracts.Services;
using Mapster;

namespace Government.Mapping
{
    public class MappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<Request, AddRequestResponseDto>()
            // .Map(dest => dest.RequestID, src => src.Id)
            //    .Map(dest => dest.ServiceName, src => src.service.ServiceName);

            // config.NewConfig<Request, RequestsDetailstoUser>()
            //.Map(dest => dest.RequestID, src => src.Id)
            //   .Map(dest => dest.ServiceName, src => src.service.ServiceName)
            //   .Map(dest => dest.ResponseText,
            //                src => src.AdminResponse != null ? src.AdminResponse.ResponseText : "No response yet");



            // config.NewConfig<Service, ServiceResponse>()
            //   .Map(dest => dest.ServiceID, src => src.Id);

            config.NewConfig<Service, ServiceResponse>()
             .Map(dest => dest.category, src => src.category);
               

        }
    }
}
