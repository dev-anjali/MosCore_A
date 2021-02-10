using MosCore.Application.Interfaces.CacheRepositories;
using MosCore.Application.Interfaces.Repositories;
using MosCore.Domain.Entities.Catalog;
using MosCore.Infrastructure.CacheKeys;
using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using MosCore.Domain.Entities.Device;

namespace MosCore.Infrastructure.CacheRepositories
{
    public class DeviceCacheRepository : IDeviceCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IDeviceRepository _deviceRepository;

        public DeviceCacheRepository(IDistributedCache distributedCache, IDeviceRepository deviceRepository)
        {
            _distributedCache = distributedCache;
            _deviceRepository = deviceRepository;
        }

        public async Task<Device> GetByIdAsync(int productId)
        {
            string cacheKey = DeviceCacheKeys.GetKey(productId);
            var device = await _distributedCache.GetAsync<Device>(cacheKey);
            if (device == null)
            {
                device = await _deviceRepository.GetByIdAsync(productId);
                Throw.Exception.IfNull(device, "Device", "No Device Found");
                await _distributedCache.SetAsync(cacheKey, device);
            }
            return device;
        }

        public async Task<List<Device>> GetCachedListAsync()
        {
            string cacheKey = DeviceCacheKeys.ListKey;
            var deviceList = await _distributedCache.GetAsync<List<Device>>(cacheKey);
            if (deviceList == null)
            {
                deviceList = await _deviceRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, deviceList);
            }
            return deviceList;
        }
    }
}
