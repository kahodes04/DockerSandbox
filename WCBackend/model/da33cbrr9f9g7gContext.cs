using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WCBackend.model
{
    public partial class da33cbrr9f9g7gContext : DbContext
    {
        public da33cbrr9f9g7gContext()
        {
        }

        public da33cbrr9f9g7gContext(DbContextOptions<da33cbrr9f9g7gContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entry> Entries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=ec2-63-32-248-14.eu-west-1.compute.amazonaws.com;Database=da33cbrr9f9g7g;Username=uvrmwdzujsjqup;Password=44d80ab1b562f8b747cefb2c8b10b85a47980d68428f92e9769fe720c79874f1", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
