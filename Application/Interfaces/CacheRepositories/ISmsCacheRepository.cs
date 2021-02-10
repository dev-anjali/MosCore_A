using Domain.Entities.Sms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MosCore.Application.Interfaces.CacheRepositories
{
    public interface ISmsCacheRepository
    {
        Task<List<Sms>> GetCachedListAsync();

        Task<Sms> GetByIdAsync(int smsId);
    }
}
