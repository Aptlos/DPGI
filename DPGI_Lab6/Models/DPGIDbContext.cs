using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DPGI_Lab6.Models;

public partial class DPGIDbContext : DbContext
{
    public DPGIDbContext()
    {
    }

    public DPGIDbContext(DbContextOptions<DPGIDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Value> Values { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Programming\\DPGI\\DPGI_Lab6\\Data\\ExchangeRates");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Value>(entity =>
        {
            entity.HasKey(e => e.ValId);

            entity.Property(e => e.ValCode).HasDefaultValueSql("'-'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
