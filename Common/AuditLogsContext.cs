using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class AuditLogsContext : DbContext
    {
        public AuditLogsContext(DbContextOptions<AuditLogsContext> options) : base(options)
        {

        }
        public virtual DbSet<AuditLog> AuditLogs { get; set; }
    }
}
