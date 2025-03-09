using Microsoft.EntityFrameworkCore;
using Shopily.Api.Data;
using System.Reflection.Metadata.Ecma335;

namespace Shopily.Api.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet= _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()=> await _dbSet.AsNoTracking().ToListAsync();
        //ToDo: impliment clase base

        public async Task<T> GetByIdAsync(int id) => await _dbSet.AsNoTracking().FirstOrDefaultAsync();
        public async Task CreateAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);
        
    }
}
