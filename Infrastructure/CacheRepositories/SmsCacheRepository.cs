using MosCore.Application.Interfaces.CacheRepositories;
using MosCore.Application.Interfaces.Repositories;
using MosCore.Domain.Entities.Catalog;
using MosCore.Infrastructure.CacheKeys;
using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Sms;

namespace MosCore.Infrastructure.CacheRepositories
{
    public class SmsCacheRepository : ISmsCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ISmsRepository _smsRepository;

        public SmsCacheRepository(IDistributedCache distributedCache, ISmsRepository smsRepository)
        {
            _distributedCache = distributedCache;
            _smsRepository = smsRepository;
        }

        public async Task<Sms> GetByIdAsync(int smsId)
        {
            string cacheKey = SmsCacheKeys.GetKey(smsId);
            var sms = await _distributedCache.GetAsync<Sms>(cacheKey);
            if (sms == null)
            {
                sms = await _smsRepository.GetByIdAsync(smsId);
                Throw.Exception.IfNull(sms, "Sms", "No Sms Found");
                await _distributedCache.SetAsync(cacheKey, sms);
            }
            return sms;
        }

        public async Task<List<Sms>> GetCachedListAsync()
        {
            string cacheKey = SmsCacheKeys.ListKey;
            var smsList = await _distributedCache.GetAsync<List<Sms>>(cacheKey);
            if (smsList == null)
            {
                smsList = await _smsRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, smsList);
            }
            return smsList;
        }
    }
}
