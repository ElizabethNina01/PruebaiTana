using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendData.Domain.Model;
using BackendData.Domain.Repositories;
using BackendData.Domain.Services.Communication;
using BackendData.Domain.Services;

namespace BackendData.Services
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;
        private readonly Domain.Repositories.IUnitOfWork _unitOfWork;
        
        public RecordService(IRecordRepository recordRepository, Domain.Repositories.IUnitOfWork unitOfWork)
        {
            _recordRepository = recordRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Record>> ListAsync()
        {
            return await _recordRepository.ListAsync();
        }
        
        public async Task<RecordResponse> SaveAsync(Record record)
        {
            try
            {
                await _recordRepository.AddAsync(record);
                await _unitOfWork.CompletedAsync();

                return new RecordResponse(record);
            }
            catch (Exception e)
            {
                return new RecordResponse($"An error ocurred while saving the record: {e.Message}");
            }
        }

        public async Task<RecordResponse> UpdateAsync(int id, Record record)
        {
            var existingRecord = await _recordRepository.FindByIdAsync(id);

            if (existingRecord == null)
                return new RecordResponse("record not found.");
            //
            existingRecord.year = record.year;
            existingRecord.area = record.area;
            existingRecord.rank = record.rank;
            existingRecord.domestic_exports = record.domestic_exports;
            
            try
            {
                _recordRepository.Update(existingRecord);
                await _unitOfWork.CompletedAsync();

                return new RecordResponse(existingRecord);
            }
            catch (Exception e)
            {
                return new RecordResponse($"An error ocurred while saving the record: {e.Message}");
            }
        }

        public async Task<RecordResponse> DeleteAsync(int id)
        {
            var existingRecord = await _recordRepository.FindByIdAsync(id);
            
            if(existingRecord == null)
                return new RecordResponse("record not found.");

            try
            {
                _recordRepository.Delete(existingRecord);
                await _unitOfWork.CompletedAsync();

                return new RecordResponse(existingRecord);
            }
            catch (Exception e)
            {
                return new RecordResponse($"An error ocurred while deleting the record: {e.Message}");

            }
        }
    }
}