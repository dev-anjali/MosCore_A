using MosCore.Application.Features.Products.Commands.Create;
using MosCore.Application.Features.Products.Queries.GetAllCached;
using MosCore.Application.Features.Products.Queries.GetAllPaged;
using MosCore.Application.Features.Products.Queries.GetById;
using MosCore.Domain.Entities.Catalog;
using AutoMapper;

namespace MosCore.Application.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsCachedResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsResponse, Product>().ReverseMap();
        }
    }
}
