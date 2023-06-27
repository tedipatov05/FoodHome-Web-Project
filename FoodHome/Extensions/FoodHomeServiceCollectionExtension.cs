using FoodHome.Core.Contracts;
using FoodHome.Core.Services;
using FoodHome.Infrastructure.Data.Common;

namespace FoodHome.Extensions
{
    public static class FoodHomeServiceCollectionExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IImageService, ImageService>();
            


            return services;
        }
    }
}
