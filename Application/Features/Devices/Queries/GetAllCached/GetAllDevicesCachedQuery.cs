using MosCore.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MosCore.Application.Features.Devices.Queries.GetAllCached
{
    public class GetAllDevicesCachedQuery : IRequest<Result<List<GetAllDevicesCachedResponse>>>
    {
        public GetAllDevicesCachedQuery()
        {
        }
    }

    public class GetAllDevicesCachedQueryHandler : IRequestHandler<GetAllDevicesCachedQuery, Result<List<GetAllDevicesCachedResponse>>>
    {
        private readonly IDeviceCacheRepository _deviceCacheRepository;
        private readonly IMapper _mapper;

        public GetAllDevicesCachedQueryHandler(IDeviceCacheRepository deviceCacheRepository, IMapper mapper)
        {
            _deviceCacheRepository = deviceCacheRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllDevicesCachedResponse>>> Handle(GetAllDevicesCachedQuery request, CancellationToken cancellationToken)
        {
            var brandList = await _deviceCacheRepository.GetCachedListAsync();
            var mappedBrands = _mapper.Map<List<GetAllDevicesCachedResponse>>(brandList);
            return Result<List<GetAllDevicesCachedResponse>>.Success(mappedBrands, "success");
        }
    }
}