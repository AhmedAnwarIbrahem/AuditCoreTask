using Audit.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class CustomAuditEvent : AuditEvent
    {
        public int UserId { get; set; } = 0;
        public string UserName { get; set; }
        public string Comment { get; set; }
        public string Action { get; set; }

        
    }
}
