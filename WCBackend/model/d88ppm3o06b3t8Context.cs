using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WCBackend.model
{
    public partial class d88ppm3o06b3t8Context : DbContext
    {
        public d88ppm3o06b3t8Context()
        {
        }

        public d88ppm3o06b3t8Context(DbContextOptions<d88ppm3o06b3t8Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Config> Configs { get; set; } = null!;
        public virtual DbSet<Entry> Entries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=ec2-34-249-161-200.eu-west-1.compute.amazonaws.com;Database=d88ppm3o06b3t8;Username=kempbthugvslhv;Password=96f643d9f55c1740541991d49fe88548581a62749a397b08c52f02a98051bb4a", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Config>(entity =>
            {
                entity.ToTable("config");

                entity.HasIndex(e => e.Apikey, "config_apikey_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apikey)
                    .HasMaxLength(50)
                    .HasColumnName("apikey");
            });

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.ToTable("entries");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Results)
                    .HasMaxLength(500)
                    .HasColumnName("results");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
