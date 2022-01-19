using API.Entities;
using API.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<BoundingBox> BoundingBoxes { get; set; }
        public DbSet<Polygon> Polygons { get; set; }
        public DbSet<LineSegment> LineSegments { get; set; }
        public DbSet<Label> Labels { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
         
            foreach (var entry in entries)
            {
                // for entities that inherit from BaseEntity,
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is BaseEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.DateModified = EntityHelpers.GetCurrentDate();

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("DateCreated").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.DateCreated = EntityHelpers.GetCurrentDate();
                            trackable.DateModified = EntityHelpers.GetCurrentDate();
                            break;
                    }
                }
            }
        }
    }
}

