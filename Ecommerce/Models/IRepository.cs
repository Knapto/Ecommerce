using Microsoft.Build.Locator;
using System.Linq.Expressions;


namespace Ecommerce.Models
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id, QueryOptions<T> options);
        Task AddAsync(T enitty);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
