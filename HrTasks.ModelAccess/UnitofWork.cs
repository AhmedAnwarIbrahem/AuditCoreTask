using HrTasks.Model;
using HrTasks.Model.Audit;
using HrTasks.ModelAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Common;

namespace HrTasks.ModelAccess
{
  public  class UnitofWork:IUnitofWork
    {
        private readonly HrTasksContext _context;
        private readonly AuditLogsContext _auditContext;


        public UnitofWork(HrTasksContext Context, AuditLogsContext auditContext)
        {
            _context = Context;
            _auditContext = auditContext;
        }

        public EmployeeRepository EmployeeRepository
        {
            get
            {
                return new EmployeeRepository(_context, _auditContext);
            }
        }
        public DepartmentRepository DepartmentRepository
        {
            get
            {
                return new DepartmentRepository(_context, _auditContext);
            }
        }

        public EmployeeTaskRepository EmployeeTaskRepository
        {
            get
            {
                return new EmployeeTaskRepository(_context, _auditContext);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
