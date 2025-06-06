using DatabaseContext;
namespace Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected readonly SsoDbContext _context;
        public BaseRepository(SsoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public  virtual T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public virtual T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;  
        }
        public virtual T Read(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
            {
                throw new EntryPointNotFoundException($"Entidade do tipo {typeof(T).Name} com o ID {id} não encontrada.");
            }
            return entity;
        }
        public virtual void Delete(int id)
        {
            var entity = Read(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();

            }
        }
    }
}