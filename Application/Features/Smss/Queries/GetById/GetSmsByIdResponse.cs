
namespace MosCore.Application.Features.Smss.Queries.GetById
{
    public class GetSmsByIdResponse
    {
        public int Id { get; set; }
        public string SenderNumber { get; set; }
        public string SenderText { get; set; }
        public int DeviceId { get; set; }
    }
}
