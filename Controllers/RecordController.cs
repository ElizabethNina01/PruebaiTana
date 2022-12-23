using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BackendData.Domain.Model;
using BackendData.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using BackendData.Extensions;
using BackendData.Resources;

namespace BackendData.Controllers
{
    [Route("[controller]")]
    public class RecordController : ControllerBase
    {
        private readonly IRecordService _recordService;
        private readonly IMapper _mapper;

        public RecordController(IRecordService recordService, IMapper mapper)
        {
            _recordService = recordService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RecordResource>> GetAllAsync()
        {
            var records = await _recordService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Record>, IEnumerable<RecordResource>>(records);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveRecordResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var record = _mapper.Map<SaveRecordResource, Record>(resource);
            var result = await _recordService.SaveAsync(record);

            if (!result.Success)
                return BadRequest(result.Message);
            var recordResource = _mapper.Map<Record, RecordResource>(result.Resource);
            return Ok(recordResource);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRecordResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var record = _mapper.Map<SaveRecordResource, Record>(resource);
            var result = await _recordService.UpdateAsync(id, record);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var recordResource = _mapper.Map<Record, RecordResource>(result.Resource);
            return Ok(recordResource);
        } 
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _recordService.DeleteAsync(id);
               
            if (!result.Success)
                return BadRequest(result.Message);

            var recordResource = _mapper.Map<Record, RecordResource>(result.Resource);
            return Ok(recordResource);
        
        }

        

    }
}