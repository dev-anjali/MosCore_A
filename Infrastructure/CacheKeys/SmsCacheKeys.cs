namespace MosCore.Infrastructure.CacheKeys
{
    public static class SmsCacheKeys
    {
        public static string ListKey => "SmsList";

        public static string SelectListKey => "SmsSelectList";

        public static string GetKey(int smsId) => $"Sms-{smsId}";

        public static string GetDetailsKey(int smsId) => $"SmsDetails-{smsId}";
    }
}
