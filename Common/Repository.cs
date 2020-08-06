using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Audit.Core;


namespace Common
{
    public class Repository<T>  where T : class
    {
        protected readonly DbContext Context;
        protected readonly AuditLogsContext _auditContext;
        private readonly DbSet<T> dbSet;
        private readonly DbSet<AuditLog> dbSet2;


        private readonly IHttpContextAccessor httpContextAccessor;
        public Repository(DbContext context, AuditLogsContext auditContext)
        {
            Context = context;
            dbSet = Context.Set<T>();
            httpContextAccessor = new HttpContextAccessor();
            _auditContext = auditContext;
            dbSet2 = _auditContext.Set<AuditLog>();
        }

        public void Add(T entity)
        {
            var scopeName = entity.GetType().Name.ToString();
            var eventType = "Add " + scopeName;
            var options = new AuditScopeOptions()
            {
                EventType = eventType,
                TargetGetter = () => entity,
                ExtraFields = new { Action = "Add" },
                AuditEvent = new CustomAuditEvent() { UserId = 29, UserName = "Anwar", Comment = scopeName + " Added By User" },
            };
            using (var scope = AuditScope.Create(options))
            {
                scope.Event.Target.Old = null;
            }
            var test = new AuditLog()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                ActionId = 1,
                UserName = "Anwar ",
                EventType = eventType,
                UserId = 33
            };
            dbSet2.Add(test);
            dbSet.Add(entity);
        }
  
        public void Update(T entityNew, T entityOld)
       {
            var scopeName = entityNew.GetType().Name.ToString();
            var eventType = "Update " + scopeName;
            var options = new AuditScopeOptions()
            {
                EventType = "Update departments",
                TargetGetter = () => entityNew,
                ExtraFields = new { Action = "Update" },
                AuditEvent = new CustomAuditEvent() { UserId = 330, UserName = "Anwar", Comment = "Department Updated By User" },
            };
            using (var scope = AuditScope.Create(options))
            {
                scope.Event.Target.Old = entityOld;
            }
            //dbSet.AsNoTracking();
            Context.Entry(entityOld).State = EntityState.Detached; // exception when trying to change the state
            Context.Entry(entityNew).State = EntityState.Modified; // exception when trying to change the state
            dbSet.Update(entityNew);
        }

        public T Get(params object[] id)
        {
            return dbSet.Find(id);
        }



        public IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = dbSet;

            if (include != null)
            {
                query = include(query);
            }
            return query.ToList();
        }

       
        public void Remove(T entity)
        {
            var scopeName = entity.GetType().Name.ToString();
            var eventType = "Delete " + scopeName;
            var options = new AuditScopeOptions()
            {
                EventType = eventType,
                TargetGetter = () => null,
                ExtraFields = new { Action = "Add" },
                AuditEvent = new CustomAuditEvent() { UserId = 29, UserName = "Anwar", Comment = scopeName + " Deleted By User" },
            };
            using (var scope = AuditScope.Create(options))
            {
                scope.Event.Target.Old = entity;
            }
            dbSet.Remove(entity);
        }

        
    }
}
