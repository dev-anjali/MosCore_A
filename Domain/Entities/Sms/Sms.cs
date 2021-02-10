using MosCore.Domain.Common;
using MosCore.Domain.Entities.Device;

namespace Domain.Entities.Sms
{
   public class Sms : AuditableEntity
    {
        public string SenderNumber { get; set; }
        public string SenderText { get; set; }
        public int DeviceId { get; set; }
        public virtual Device Device { get; set; }
    }
}
