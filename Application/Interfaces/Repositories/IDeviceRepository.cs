using MosCore.Domain.Entities.Catalog;
using MosCore.Domain.Entities.Device;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MosCore.Application.Interfaces.Repositories
{
    public interface IDeviceRepository
    {
        IQueryable<Device> Devices { get; }

        Task<List<Device>> GetListAsync();

        Task<Device> GetByIdAsync(int deviceId);

        Task<int> InsertAsync(Device device);

        Task UpdateAsync(Device device);

        Task DeleteAsync(Device device);
    }
}
