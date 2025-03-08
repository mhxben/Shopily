using Microsoft.EntityFrameworkCore;
using Shopily.Api.Data;

namespace Shopily.Api.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;         
        }
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
