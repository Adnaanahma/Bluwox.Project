using Bluwox.Repository.Cache;
using Bluwox.Repository.CategoryRepo;
using Bluwox.Repository.ServiceManagementRepo;
using Bluwox.Repository.SubCategoryRepo;
using Bluwox.Service.Implementations.CategoryLogic;
using Bluwox.Service.Implementations.ServiceManagementLogic;
using Bluwox.Service.Implementations.SubCategoryLogic;
using Microsoft.Extensions.DependencyInjection;

namespace Bluwox.Service.Helpers
{
    public static class DIExtension
    {
        public static IServiceCollection AddInjectedServices(this IServiceCollection services)
        {
            services.AddTransient<IServiceManagementLogic, ServiceManagementLogic>();
            services.AddTransient<ICategoryLogic, CategoryLogic>();
            services.AddTransient<ISubCategoryLogic, SubCategoryLogic>();

            services.AddTransient<IServiceManagementRepo, ServiceManagementRepo>();
            services.AddTransient<ICategoryRepo, CategoryRepo>();
            services.AddTransient<ISubCategoryRepo, SubCategoryRepo>();

            services.AddTransient<ICacheService, CacheService>();

            return services;
        }
    }
}
