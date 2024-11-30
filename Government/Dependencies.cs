using Government.Data;
using Microsoft.Extensions.Configuration;

namespace Government
{
    public static class Dependencies
    {
        public static IServiceCollection AddDependancy(this IServiceCollection services, IConfiguration configuration) {

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwagger()
                .AddConnnectionString(configuration);

            return services;
        }


        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

        public static IServiceCollection AddConnnectionString(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionstring = configuration.GetConnectionString("GovernmentConnection") ??
                throw new InvalidOperationException("Connection String 'GovernmentConnection' Not Found !!");

            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionstring));



            return services;
        }
    }
}
