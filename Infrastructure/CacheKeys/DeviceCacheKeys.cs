namespace MosCore.Infrastructure.CacheKeys
{
    public static class DeviceCacheKeys
    {
        public static string ListKey => "DeviceList";

        public static string SelectListKey => "DeviceSelectList";

        public static string GetKey(int deviceId) => $"Device-{deviceId}";

        public static string GetDetailsKey(int deviceId) => $"DeviceDetails-{deviceId}";
    }
}
