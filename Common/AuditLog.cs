using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class AuditLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EventType { get; set; }
        public string MachineName { get; set; }
        public string DomainName { get; set; }
        public string CallingMethodName { get; set; }
        public string OldTarget { get; set; }
        public string NewTarget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ActionId { get; set; }

        //public virtual ICollection<AuditTraget> Tasks { get; set; }

    }
}
