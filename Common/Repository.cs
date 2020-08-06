using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Audit.Core;
using Audit.SqlServer.Providers;
using Audit.SqlServer;
using Newtonsoft.Json;

namespace Common
{
    public class Repository<T>  where T : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<T> dbSet;


        private readonly IHttpContextAccessor httpContextAccessor;
        public Repository(DbContext context)
        {
            Context = context;
            dbSet = Context.Set<T>();
            httpContextAccessor = new HttpContextAccessor();
            //Audit.Core.Configuration.Setup().UseFileLogProvider(config => config
            //    .DirectoryBuilder(_ => $@"C:\Logs\{DateTime.Now:yyyy-MM-dd}")
            //    .FilenameBuilder(auditEvent => $"{auditEvent.Environment.UserName}_{DateTime.Now.Ticks}.json"));
            Audit.Core.Configuration.DataProvider = new SqlDataProvider()
            {

                ConnectionString = "data source=.;initial catalog=AuditLogs;integrated security=true;",
                Schema = "dbo",
                TableName = "Audits",
                IdColumnName = "Id",
                //JsonColumnName = "EventType",
                CustomColumns = new List<CustomColumn>()
                {
                    new CustomColumn("UserNameDomain", ev => ev.Environment.UserName),
                    new CustomColumn("EventType", ev => ev.EventType),
                    new CustomColumn("StartDate", ev => ev.StartDate),
                    new CustomColumn("EndDate", ev => ev.EndDate),
                    new CustomColumn("MachineName", ev => ev.Environment.MachineName),
                    new CustomColumn("CallingMethodName", ev => ev.Environment.CallingMethodName),
                    new CustomColumn("DomainName", ev => ev.Environment.DomainName),
                    new CustomColumn("OldTarget", ev => TargetString(ev.Target.Old)),
                    new CustomColumn("NewTarget", ev => TargetString(ev.Target.New)),
                    new CustomColumn("ChangedBy", ev => CustomString(ev).UserName),
                    new CustomColumn("UserId", ev => CustomString(ev).UserId),
                    new CustomColumn("Comment", ev => CustomString(ev).Comment),
                    new CustomColumn("Action", ev => CustomString(ev).Action)
                }
            };

        }

        private CustomAuditEvent CustomString(object auditEvent)
        {
            auditEvent = JsonConvert.SerializeObject(auditEvent);
            CustomAuditEvent deserializedEvent = JsonConvert.DeserializeObject<CustomAuditEvent>(auditEvent.ToString());
            return deserializedEvent;
        }
        private string TargetString(object value)
        {
            value = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            var result = "";
            if (value != null && value.ToString() != "null")
            {
                result = value.ToString();
            }
            return result;
        }

        public void Add(T entity)
        {
            var scopeName = entity.GetType().Name.ToString();
            var eventType = "Add " + scopeName;
            var options = new AuditScopeOptions()
            {
                EventType = eventType,
                TargetGetter = () => entity,
                AuditEvent = new CustomAuditEvent() { Action = "Add", UserId = 29, UserName = "Anwar", Comment = scopeName + " Added By User" },
            };
            using (var scope = AuditScope.Create(options))
            {
                scope.Event.Target.Old = null;
            }
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
                AuditEvent = new CustomAuditEvent() { Action = "Update", UserId = 330, UserName = "Anwar", Comment = "Department Updated By User" },
            };
            using (var scope = AuditScope.Create(options))
            {
                scope.Event.Target.Old = entityOld;
            }
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
                AuditEvent = new CustomAuditEvent() { Action = "Delete", UserId = 29, UserName = "Anwar", Comment = scopeName + " Deleted By User" },
            };
            using (var scope = AuditScope.Create(options))
            {
                //scope.Event.Target.New = null;
                scope.Event.Target.Old = entity;
            }
            dbSet.Remove(entity);
        }

        
    }
}
