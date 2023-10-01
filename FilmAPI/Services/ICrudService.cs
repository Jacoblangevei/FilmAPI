namespace FilmAPI.Services
{
    public interface ICrudService<TEntity, TID>
    {
        public interface ICrudService<TKey>
        {
            Task<IEnumerable<TEntity>> GetAllAsync();
            Task<TEntity> GetByIdAsync(TKey id);
            Task CreateAsync(TEntity entity);
            Task UpdateAsync(TEntity entity);
            Task DeleteAsync(TKey id);
        }
    }
}/*
namespace FilmAPI.Services
{
    public interface ICrudService<TEntity, TKey, TID>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey id);
    }
}*/
