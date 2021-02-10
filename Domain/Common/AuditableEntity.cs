using System;
using System.Collections.Generic;
using System.Text;

namespace MosCore.Domain.Common
{
    public abstract class AuditableEntity
    {
        public virtual int Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }
    }
}
