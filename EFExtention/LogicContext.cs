using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EFExtention
{
    public class LogicContext : DbContext
    {

        public LogicContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public override int SaveChanges()
        {
            BeforeSave();
            return base.SaveChanges();
        }
        private void BeforeSave()
        {
            var objectStateEntries = ChangeTracker.Entries()
           .Where(e => e.Entity is LogicEntity && (e.State == EntityState.Modified || e.State == EntityState.Added)).ToList();
            var currentTime = DateTime.UtcNow;
            foreach (var entry in objectStateEntries)
            {
                var entityBase = entry.Entity as LogicEntity;
                if (entityBase == null) continue;
                if (entry.State == EntityState.Added)
                {
                    entityBase.CreatedTime = currentTime;
                    if (entityBase.Id == Guid.Empty) entityBase.Id = Guid.NewGuid();
                }
                entityBase.UpdatedTime = currentTime;
            }
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            BeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}