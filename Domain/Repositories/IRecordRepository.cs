using System.Collections.Generic;
using System.Threading.Tasks;
using BackendData.Domain.Model;

namespace BackendData.Domain.Repositories
{
    public interface IRecordRepository
    {
        
        Task<IEnumerable<Record>> ListAsync();
        Task AddAsync(Record record);

        Task<Record> FindByIdAsync(int id);

        void Update(Record record);

        void Delete(Record record);
    }
}