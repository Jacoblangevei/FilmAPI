namespace FilmAPI.Services
{
    public interface ICrudService<TEntity, TID>
    {
        public interface ICrudService<TEntity, TKey>
        {
            Task<IEnumerable<TEntity>> GetAllAsync();
            Task<TEntity> GetByIdAsync(TKey id);
            Task CreateAsync(TEntity entity);
            Task UpdateAsync(TEntity entity);
            Task DeleteAsync(TKey id);
        }

    }

}
