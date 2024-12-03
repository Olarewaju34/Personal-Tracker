using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Abstraction;

public interface IRepository<T> where T : BaseEntity, new()
{
    Task<T> CreateAsync(T entity);
    Task<T> GetAsync(string id,CancellationToken cancellation = default);
    Task<T> GetAsync(Expression<Func<T, bool>> expression,CancellationToken cancellationToken=default);
    Task<T> UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    Task<List<T>> GetAllByIdsAsync(List<string> ids);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> SelectAll();
    Task<IEnumerable<T>> SelectAll(Expression<Func<T, bool>> expression = null);
}

