using MosCore.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MosCore.Application.Features.Smss.Queries.GetById
{
    public class GetSmsByIdQuery : IRequest<Result<GetSmsByIdResponse>>
    {
        public int Id { get; set; }

        public class GetSmsByIdQueryHandler : IRequestHandler<GetSmsByIdQuery, Result<GetSmsByIdResponse>>
        {
            private readonly ISmsCacheRepository _smsCache;
            private readonly IMapper _mapper;

            public GetSmsByIdQueryHandler(ISmsCacheRepository smsCache, IMapper mapper)
            {
                _smsCache = smsCache;
                _mapper = mapper;
            }

            public async Task<Result<GetSmsByIdResponse>> Handle(GetSmsByIdQuery query, CancellationToken cancellationToken)
            {
                var sms = await _smsCache.GetByIdAsync(query.Id);
                var mappedSms = _mapper.Map<GetSmsByIdResponse>(sms);
                return Result<GetSmsByIdResponse>.Success(mappedSms,"success");
            }
        }
    }
}