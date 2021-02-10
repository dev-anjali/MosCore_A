using MosCore.Domain.Entities.Catalog;
using MosCore.Domain.Entities.Device;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MosCore.Application.Interfaces.CacheRepositories
{
    public interface IDeviceCacheRepository
    {
        Task<List<Device>> GetCachedListAsync();

        Task<Device> GetByIdAsync(int deviceId);
    }
}
