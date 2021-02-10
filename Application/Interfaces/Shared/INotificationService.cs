using Application.DTOs.Notifications;
using System.Threading.Tasks;

namespace MosCore.Application.Interfaces.Shared
{
    public interface INotificationService
    {
        Task SendAsync(NotificationRequest request);
    }
}
