namespace MosCore.Application.Features.Devices.Queries.GetById
{
    public class GetDeviceByIdResponse
    {
        public string DeviceId { get; set; }
        public string OS { get; set; }
        public string Imei { get; set; }

        public string Phone { get; set; }

        public string PrimaryPhone { get; set; }

        public string Brand { get; set; }

        public string SerialNo { get; set; }

        public string AssignedOperator { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }
        public string DeviceToken { get; set; }
        public string FCMToken { get; set; }

        public bool Hardware { get; set; }

    }
}