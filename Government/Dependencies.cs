using FluentValidation;
using FluentValidation.AspNetCore;
using Government.ApplicationServices.AdminServices;
using Government.ApplicationServices.GovernmentServices;
using Government.ApplicationServices.RequestServices;
using Government.Authentication;
using Government.Data;
using Government.Entities;
using Government.Errors;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Government
{
    public static class Dependencies
    {
        public static IServiceCollection AddDependancy(this IServiceCollection services, IConfiguration configuration) {

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            // services.AddControllers();
            services.AddControllers();

      

            // using identity
            services.AddIdentity<Admin, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IAdminAuthService, AdminAuthService>();
            services.AddScoped<IService, service>();
            services.AddScoped<IAdminResponseToRequest, AdminResponseToRequest>();

            // Exception Handler
            services.AddExceptionHandler<GlobalExceptionHandler>()
                    .AddProblemDetails();

            //Swagger
            services.AddSwagger()
                    .AddConnnectionString(configuration)
                    .AddAuthConfig(configuration)
                    .AddMapster();
             
            // fluent validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();

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

        public static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration configuration)
        {


      
            services.AddSingleton<IAdminJwtProvider, AdminJwtProvider>();


            services.Configure<JwtOption>(configuration.GetSection(nameof(JwtOption)));
            var settings = configuration.GetSection(nameof(JwtOption)).Get<JwtOption>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings!.Key)),
                    ValidIssuer = settings.Issuer,
                    ValidAudience = settings.Audience
                };
            });

            return services;

        }

        private static IServiceCollection AddMapster(this IServiceCollection service)
        {

            //mapster
            var mappingconfig = TypeAdapterConfig.GlobalSettings;
            mappingconfig.Scan(Assembly.GetExecutingAssembly());
            service.AddSingleton<IMapper>(new Mapper(mappingconfig));

            return service;
        }
    }
}
