using CRUD_API.Models.Common;
using System.Linq.Expressions;

namespace CRUD_API.Repositories.Common;

public interface IBaseEntityRepository<TEntity> where TEntity : BaseEntity, new()
{
    Task<TEntity> Add(TEntity entity);
    Task Delete(TEntity entity);
    Task Update(TEntity entity);
    Task<TEntity?> FindById(int id);
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> GetAllWithOptionalDependenciesAsync(params Expression<Func<TEntity, object>>[] includeProperties);
}
