using Microsoft.EntityFrameworkCore;
using STPL.Entity.Model;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace STPL.Entity
{
    public class STPLContext : DbContext
    {
        public STPLContext(DbContextOptions<STPLContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                        .HasKey(o => new { o.ID });

            modelBuilder.Entity<Firmware>()
                       .HasKey(o => new { o.ID });

            modelBuilder.Entity<VersionData>()
                       .HasKey(o => new { o.ID });
        }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Firmware> Firmwares { get; set; }
        public virtual DbSet<VersionData> VersionInfos { get; set; }
    }
}