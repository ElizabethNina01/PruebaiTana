using AutoMapper;
using BackendData.Domain.Model;
using BackendData.Resources;


namespace BackendData.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {

            CreateMap<Record, RecordResource>();
         
        }
    }
}