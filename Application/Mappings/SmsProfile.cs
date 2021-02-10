using MosCore.Application.Features.Smss.Queries.GetAllCached;
using MosCore.Application.Features.Smss.Queries.GetById;
using MosCore.Domain.Entities.Catalog;
using AutoMapper;
using Domain.Entities.Sms;
using Application.Features.Smss.Command.Create;

namespace MosCore.Application.Mappings
{
    internal class SmsProfile : Profile
    {
        public SmsProfile()
        {
            CreateMap<CreateSmsCommand, Sms>().ReverseMap();
            CreateMap<GetSmsByIdResponse, Sms>().ReverseMap();
            CreateMap<GetAllSmssCachedResponse, Sms>().ReverseMap();
           // CreateMap<GetAllSmsResponse, Sms>().ReverseMap();
        }
    }
}
