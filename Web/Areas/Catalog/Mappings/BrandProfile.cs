using MosCore.Application.Features.Brands.Commands.Create;
using MosCore.Application.Features.Brands.Commands.Update;
using MosCore.Application.Features.Brands.Queries.GetAllCached;
using MosCore.Application.Features.Brands.Queries.GetById;
using MosCore.Web.Areas.Catalog.Models;
using AutoMapper;

namespace MosCore.Web.Areas.Catalog.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<GetAllBrandsCachedResponse, BrandViewModel>().ReverseMap();
            CreateMap<GetBrandByIdResponse, BrandViewModel>().ReverseMap();
            CreateMap<CreateBrandCommand, BrandViewModel>().ReverseMap();
            CreateMap<UpdateBrandCommand, BrandViewModel>().ReverseMap();
        }
    }
}