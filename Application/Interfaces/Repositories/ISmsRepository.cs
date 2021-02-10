using Domain.Entities.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosCore.Application.Interfaces.Repositories
{
    public interface ISmsRepository
    {
        IQueryable<Sms> Sms { get; }

        Task<List<Sms>> GetListAsync();

        Task<Sms> GetByIdAsync(int smsId);

        Task<int> InsertAsync(Sms sms);

        Task UpdateAsync(Sms sms);

        Task DeleteAsync(Sms sms);
    }
}
