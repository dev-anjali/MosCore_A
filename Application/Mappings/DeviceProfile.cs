using MosCore.Application.Features.Devices.Commands.Create;
using MosCore.Application.Features.Devices.Queries.GetAllCached;
using MosCore.Application.Features.Products.Queries.GetAllPaged;
using MosCore.Application.Features.Devices.Queries.GetById;
using MosCore.Domain.Entities.Catalog;
using AutoMapper;
using MosCore.Domain.Entities.Device;

namespace MosCore.Application.Mappings
{
    internal class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<CreateDeviceCommand, Device>().ReverseMap();
            CreateMap<GetDeviceByIdResponse, Device>().ReverseMap();
            CreateMap<GetAllDevicesCachedResponse, Device>().ReverseMap();
            //CreateMap<GetAllDevicesResponse, Device>().ReverseMap();
        }
    }
}
