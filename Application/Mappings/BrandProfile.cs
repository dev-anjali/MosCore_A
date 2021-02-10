using MosCore.Application.Features.Brands.Queries.GetAllCached;
using MosCore.Domain.Entities.Catalog;
using AutoMapper;
using MosCore.Application.Features.Brands.Commands.Create;
using MosCore.Application.Features.Brands.Queries.GetById;

namespace MosCore.Application.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsCachedResponse, Brand>().ReverseMap();
        }
    }
}
