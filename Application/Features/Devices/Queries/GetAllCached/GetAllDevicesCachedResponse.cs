namespace MosCore.Application.Features.Devices.Queries.GetAllCached
{
    public class GetAllDevicesCachedResponse
    {
        public string Id { get; set; }
        public string OS { get; set; }
        public string Imei { get; set; }

        public string Phone { get; set; }

        public string PrimaryPhone { get; set; }

        public string Brand { get; set; }

        public string SerialNo { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }
        public string DeviceToken { get; set; }
        public string FCMToken { get; set; }

        public bool Hardware { get; set; }
    }
}