using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodify.Domain.Models
{
    /// <summary>
    /// Base repository contract
    /// </summary>
    /// <typeparam name="TModel">Model used by repository</typeparam>
    public interface IRepository<TModel> where TModel : class
    {
        Task<ICollection<TModel>> GetAllAsync();
        Task<TModel> GetAsync(Guid modelId);
        void Add(TModel model);
        void Remove(TModel model);
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
