using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DPGI_Lab5.Models;

public partial class DPGIDbContext : DbContext
{
    public DPGIDbContext()
    {
    }

    public DPGIDbContext(DbContextOptions<DPGIDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Comapny> Comapnies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Programming\\DPGI\\DPGI_Lab5\\Data\\DPGI_1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.ClientGains).HasDefaultValueSql("0");
            entity.Property(e => e.ClientPhone).HasDefaultValueSql("'-'");
            entity.Property(e => e.ClientSpends).HasDefaultValueSql("0");
        });

        modelBuilder.Entity<Comapny>(entity =>
        {
            entity.HasKey(e => e.CompanyId);

            entity.Property(e => e.CompanyName).HasDefaultValueSql("'-'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
