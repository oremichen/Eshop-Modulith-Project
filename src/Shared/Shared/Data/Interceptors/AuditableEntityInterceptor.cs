using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.DDD;

namespace Shared.Data.Interceptors
{
    public class AuditableEntityInterceptor: SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEtities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEtities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEtities(DbContext? context)
        {
            if (context == null) return;

            var entries = context.ChangeTracker.Entries<IEntity>();
            foreach (var entry in entries) 
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = "System";
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified || entry.State == EntityState.Modified || entry.HasChangedOwnedEntites())
                {
                    entry.Entity.LastModifiedBy = "system";
                }   entry.Entity.LastModified = DateTime.UtcNow;
            }
        }
    }

    public static class Extensions
    {
        public static bool HasChangedOwnedEntites(this EntityEntry entry) =>
            entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
    }
}
