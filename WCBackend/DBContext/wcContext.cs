using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WCBackend.DBContext
{
    public partial class wcContext : DbContext
    {
        public wcContext()
        {
        }

        public wcContext(DbContextOptions<wcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Config> Configs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=dpg-cd4t4o1gp3jqpbpgfad0-a.frankfurt-postgres.render.com;Database=wc;Username=wc_user;Password=OuefQHd7QLpYk19A0bPuY9FfiD9v14fu", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Config>(entity =>
            {
                entity.ToTable("config");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Results)
                    .HasMaxLength(200)
                    .HasColumnName("results");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
