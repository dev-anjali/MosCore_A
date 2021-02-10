using MosCore.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MosCore.Application.Features.Devices.Queries.GetById
{
    public class GetDeviceByIdQuery : IRequest<Result<GetDeviceByIdResponse>>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetDeviceByIdQuery, Result<GetDeviceByIdResponse>>
        {
            private readonly IDeviceCacheRepository _deviceCacheRepository;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(IDeviceCacheRepository deviceCacheRepository, IMapper mapper)
            {
                _deviceCacheRepository = deviceCacheRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetDeviceByIdResponse>> Handle(GetDeviceByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _deviceCacheRepository.GetByIdAsync(query.Id);
                var mappedProduct = _mapper.Map<GetDeviceByIdResponse>(product);
                return Result<GetDeviceByIdResponse>.Success(mappedProduct, "success");
            }
        }
    }
}