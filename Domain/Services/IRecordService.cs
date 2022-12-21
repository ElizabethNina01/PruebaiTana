using System.Collections.Generic;
using System.Threading.Tasks;
using BackendData.Domain.Services.Communication;

namespace BackendData.Domain.Services
{
    public interface IRecordService
    {
        Task<IEnumerable<Model.Record>> ListAsync();
        Task<RecordResponse> SaveAsync(Model.Record record);

        Task<RecordResponse> UpdateAsync(int id, Model.Record record);

        Task<RecordResponse> DeleteAsync(int id);
        
    }
}