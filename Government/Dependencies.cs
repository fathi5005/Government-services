using Government.Authentication;
using Government.Data;
using Government.Entities;
using Government.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Government
{
    public static class Dependencies
    {
        public static IServiceCollection AddDependancy(this IServiceCollection services, IConfiguration configuration) {

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();


            services.AddSwagger()
                .AddConnnectionString(configuration)
            .AddAuthConfig(configuration);

            services.AddScoped<IAuthService, AuthService>();


       
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


            services.AddSingleton<IJwtProvider, JwtProvider>();

            // services.Configure<Jwtoptions>(configuration.GetSection(nameof(Jwtoptions)));



            // the same like the injection of jwtoptions


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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("J7MfAb4WcAIMkkigVtIepIILOVJEjAcB")),
                    ValidIssuer = "_JwtoptionsIssuer",
                    ValidAudience = "_JwtoptionsAudience"
                };
            });

            return services;


            return services;
        }
    }
}
