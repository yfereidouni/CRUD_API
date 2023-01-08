using CRUD_API.Models.Common;
using CRUD_API.SQL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUD_API.Repositories.Common;

public abstract class BaseEntityRepository<TEntity> : IBaseEntityRepository<TEntity> where TEntity : BaseEntity, new()
{
    protected readonly AppDbContext AppDbContext;

    protected BaseEntityRepository(AppDbContext appDbContext)
    {
        this.AppDbContext = appDbContext;
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        await this.AppDbContext.Set<TEntity>().AddAsync(entity);
        await this.AppDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task Update(TEntity entity)
    {
        this.AppDbContext.Set<TEntity>().Update(entity);
        await this.AppDbContext.SaveChangesAsync();
    }

    public async Task Delete(TEntity entity)
    {
        this.AppDbContext.Set<TEntity>().Remove(entity);
        await this.AppDbContext.SaveChangesAsync();
    }

    public async Task<TEntity?> FindById(int id)
    {
        return await this.AppDbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await this.AppDbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllWithOptionalDependenciesAsync(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = AppDbContext.Set<TEntity>();
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return await query.ToListAsync();
    }

}