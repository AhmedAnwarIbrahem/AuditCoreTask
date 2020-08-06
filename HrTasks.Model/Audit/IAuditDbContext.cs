using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrTasks.Model.Audit
{
    public interface IAuditDbContext
    {
        DbSet<Audit> Audit { get; set; }
        ChangeTracker ChangeTracker { get; }
    }
}
