using MosCore.Application.Interfaces.Repositories;
using MosCore.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Sms;

namespace MosCore.Infrastructure.Repositories
{
    public class SmsRepository : ISmsRepository
    {
        private readonly IRepositoryAsync<Sms> _repository;
        private readonly IDistributedCache _distributedCache;

        public SmsRepository(IDistributedCache distributedCache, IRepositoryAsync<Sms> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Sms> Sms => _repository.Entities;

        public async Task DeleteAsync(Sms sms)
        {
            await _repository.DeleteAsync(sms);
            await _distributedCache.RemoveAsync(CacheKeys.SmsCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.SmsCacheKeys.GetKey(sms.Id));
        }

        public async Task<Sms> GetByIdAsync(int smsId)
        {
            return await _repository.Entities.Where(p => p.Id == smsId).FirstOrDefaultAsync();
        }

        public async Task<List<Sms>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Sms sms)
        {
            await _repository.AddAsync(sms);
            await _distributedCache.RemoveAsync(CacheKeys.SmsCacheKeys.ListKey);
            return sms.Id;
        }

        public async Task UpdateAsync(Sms sms)
        {
            await _repository.UpdateAsync(sms);
            await _distributedCache.RemoveAsync(CacheKeys.SmsCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.SmsCacheKeys.GetKey(sms.Id));
        }
    }
}