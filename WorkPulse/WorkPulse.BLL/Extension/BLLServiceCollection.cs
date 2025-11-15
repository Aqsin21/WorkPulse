using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkPulse.BLL.Services.Concrete;

namespace WorkPulse.BLL.Extension
{
    public static class BLLServiceCollection
    {
        public static IServiceCollection AddBll(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddScoped<TokenService>();
            return services;
        }
    }
}
