using MosCore.Application.Interfaces.Shared;
using System;

namespace MosCore.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
