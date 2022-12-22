using System.Collections.Generic;
using System.Threading.Tasks;
using BackendData.Domain.Model;
using BackendData.Domain.Repositories;
using BackendData.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BackendData.Persistence{
    public class RecordRepository : BaseRepository, BackendData.Domain.Repositories.IRecordRepository
    {
        public RecordRepository(AppDbContext context) : base(context)
        {
        }  
        
        public async Task<IEnumerable<Record>> ListAsync()
        {
            return await _context.Records.ToListAsync();
        }

        public async Task AddAsync(Record record)
        {
            await _context.Records.AddAsync(record);
        }

        public async Task<Record> FindByIdAsync(int id)
        {
            return await _context.Records.FindAsync(id);
        }
        
        public void Update(Record record)
        {
            _context.Records.Update(record);
        }

        public void Delete(Record record)
        {
            _context.Records.Remove(record);
        }
    }
}