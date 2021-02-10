namespace MosCore.Application.Features.Smss.Queries.GetAllCached
{
    public class GetAllSmssCachedResponse
    {
        public int Id { get; set; }
        public string SenderNumber { get; set; }
        public string SenderText { get; set; }
        public int DeviceId { get; set; }
    }
}