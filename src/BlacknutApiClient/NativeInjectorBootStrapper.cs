using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BlacknutApiClient
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
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