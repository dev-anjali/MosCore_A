using MosCore.Application.DTOs.Mail;
using System.Threading.Tasks;

namespace MosCore.Application.Interfaces.Shared
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}
