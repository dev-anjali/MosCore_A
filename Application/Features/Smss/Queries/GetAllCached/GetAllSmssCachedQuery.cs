using MosCore.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MosCore.Application.Features.Smss.Queries.GetAllCached
{
    public class GetAllSmssCachedQuery : IRequest<Result<List<GetAllSmssCachedResponse>>>
    {
        public GetAllSmssCachedQuery()
        {
        }
    }

    public class GetAllSmsCachedQueryHandler : IRequestHandler<GetAllSmssCachedQuery, Result<List<GetAllSmssCachedResponse>>>
    {
        private readonly ISmsCacheRepository _smsCache;
        private readonly IMapper _mapper;

        public GetAllSmsCachedQueryHandler(ISmsCacheRepository smsCache, IMapper mapper)
        {
            _smsCache = smsCache;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllSmssCachedResponse>>> Handle(GetAllSmssCachedQuery request, CancellationToken cancellationToken)
        {
            var smsList = await _smsCache.GetCachedListAsync();
            var mappedSms = _mapper.Map<List<GetAllSmssCachedResponse>>(smsList);
            return Result<List<GetAllSmssCachedResponse>>.Success(mappedSms, "success");
        }
    }
}