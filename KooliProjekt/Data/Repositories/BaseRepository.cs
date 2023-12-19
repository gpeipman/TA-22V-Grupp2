namespace KooliProjekt.Data.Repositories
{
    public abstract class BaseRepository<T> where T : Entity
    {
        protected ApplicationDbContext Context { get; }

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public virtual async Task<PagedResult<T>> List(int page, int pageSize)
        {
            var result = await Context.Set<T>().GetPagedAsync(page, pageSize);

            return result;
        }

        public virtual async Task<T> GetById(int id)
        {
            var result = await Context.Set<T>().FindAsync(id);

            return result;
        }

        public virtual async Task Save(T entity)
        {
            if (entity.Id == 0)
            {
                await Context.AddAsync(entity);
            }
            else
            {
                Context.Update(entity);
            }
        }

        public virtual async Task Delete(int id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                Context.Set<T>().Remove(entity);
            }
        }
    }
}
