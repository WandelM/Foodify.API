using Foodify.Domain.Models.CategoryDomain;
using Foodify.Infrastructures.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Foodify.API.Configurations
{
    public static class RepositoriesConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IProductCategoryRepository), typeof(ProductCategoryRepository));
        }
    }
}
