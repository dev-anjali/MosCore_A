using MosCore.Application.Features.Products.Commands.Create;
using MosCore.Application.Features.Products.Commands.Update;
using MosCore.Application.Features.Products.Queries.GetAllCached;
using MosCore.Application.Features.Products.Queries.GetById;
using MosCore.Web.Areas.Catalog.Models;
using AutoMapper;

namespace MosCore.Web.Areas.Catalog.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<GetAllProductsCachedResponse, ProductViewModel>().ReverseMap();
            CreateMap<GetProductByIdResponse, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductViewModel>().ReverseMap();
        }
    }
}