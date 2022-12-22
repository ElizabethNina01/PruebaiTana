using System.Threading.Tasks;
using BackendData.Domain.Repositories;


namespace BackendData.Persistence
{
    public class UnitOfWork : BackendData.Domain.Repositories.IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompletedAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
