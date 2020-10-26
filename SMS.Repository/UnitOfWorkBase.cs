using Microsoft.EntityFrameworkCore;
using SMS.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Repository
{
    public abstract class UnitOfWorkBase<TContext> : IDisposable, IUnitOfWorkBase<TContext> where TContext : DbContext
    {
        public TContext Context { get; }

        public UnitOfWorkBase(TContext context)
        {
            Context = context;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }


        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    // Get all the entities that inherit from AuditableEntity
        //    // and have a state of Added or Modified
        //    var entries = ChangeTracker
        //        .Entries()
        //        .Where(e => e.Entity is AuditableEntity && (
        //                e.State == EntityState.Added
        //                || e.State == EntityState.Modified));

        //    // For each entity we will set the Audit properties
        //    foreach (var entityEntry in entries)
        //    {
        //        // If the entity state is Added let's set
        //        // the CreatedAt and CreatedBy properties
        //        if (entityEntry.State == EntityState.Added)
        //        {
        //            ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
        //            ((AuditableEntity)entityEntry.Entity).CreatedBy = this.httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "MyApp";
        //        }
        //        else
        //        {
        //            // If the state is Modified then we don't want
        //            // to modify the CreatedAt and CreatedBy properties
        //            // so we set their state as IsModified to false
        //            Entry((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
        //            Entry((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
        //        }

        //        // In any case we always want to set the properties
        //        // ModifiedAt and ModifiedBy
        //        ((AuditableEntity)entityEntry.Entity).ModifiedAt = DateTime.UtcNow;
        //        ((AuditableEntity)entityEntry.Entity).ModifiedBy = this.httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "MyApp";
        //    }

        //    // After we set all the needed properties
        //    // we call the base implementation of SaveChangesAsync
        //    // to actually save our entities in the database
        //    return await base.SaveChangesAsync(cancellationToken);
        //}

        #region Dispose

        //https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application

        private bool disposed = false;

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
