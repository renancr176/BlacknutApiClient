using BlacknutApiClient.Interfaces;
using BlacknutApiClient.Interfaces.Services;
using BlacknutApiClient.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BlacknutApiClient
{
    public static class NativeInjectorBootStrapper
    {
        public static void BlacknutApiClientRegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IBlacknutApiClient, BlacknutApiClientOptionsConfiguration>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IStreamService, StreamService>();
            services.AddScoped<IGameService, GameService>();
        }
    }

    public class BlacknutApiClientOptionsConfiguration : BlacknutApiClient
    {
        public BlacknutApiClientOptionsConfiguration(IOptions<BlacknutCredentials> options) 
            : base(options?.Value ?? new BlacknutCredentials())
        {
        }
    }
}