using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BlacknutApiClient
{
    public static class BlacknutNativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IBlacknutApiClient, BlacknutApiClientOptionsConfiguration>();
            services.AddScoped<IUserService, UserService>();
        }
    }

    public class BlacknutApiClientOptionsConfiguration : BlacknutApiClient
    {
        public BlacknutApiClientOptionsConfiguration(IOptions<BlacknutCredentials> options) 
            : base(options.Value)
        {
        }
    }
}