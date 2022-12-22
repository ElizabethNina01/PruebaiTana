using System.Net.Mail;
using AutoMapper;
using BackendData.Domain.Model;
using BackendData.Resources;


namespace BackendData.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            
            CreateMap<SaveRecordResource, Record>();
          
        }
    }
}
