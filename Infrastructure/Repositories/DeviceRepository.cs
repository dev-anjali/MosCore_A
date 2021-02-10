using MosCore.Application.Interfaces.Repositories;
using MosCore.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MosCore.Domain.Entities.Device;

namespace MosCore.Infrastructure.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IRepositoryAsync<Device> _repository;
        private readonly IDistributedCache _distributedCache;

        public DeviceRepository(IDistributedCache distributedCache, IRepositoryAsync<Device> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Device> Devices => _repository.Entities;

       

        public async Task DeleteAsync(Device product)
        {
            await _repository.DeleteAsync(product);
            await _distributedCache.RemoveAsync(CacheKeys.DeviceCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.DeviceCacheKeys.GetKey(product.Id));
        }

      

        public async Task<Device> GetByIdAsync(int deviceId)
        {
            return await _repository.Entities.Where(d => d.Id == deviceId).FirstOrDefaultAsync();
        }

        public async Task<List<Device>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Device device)
        {
            await _repository.AddAsync(device);
            await _distributedCache.RemoveAsync(CacheKeys.DeviceCacheKeys.ListKey);
            return device.Id;
        }

      

        public async Task UpdateAsync(Device device)
        {
            await _repository.UpdateAsync(device);
            await _distributedCache.RemoveAsync(CacheKeys.DeviceCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.DeviceCacheKeys.GetKey(device.Id));
        }

       

       
    }
}