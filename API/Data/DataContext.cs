using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
