using Microsoft.EntityFrameworkCore;
using Smz.Practice.Employee.Models;

namespace Smz.Practice.Employee.Context;

public partial class SmzTestContext : DbContext
{
    public SmzTestContext()
    {
    }

    public SmzTestContext(DbContextOptions<SmzTestContext> options) : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DBDevp");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Empleados_Id");

            entity.HasIndex(e => e.Clave, "UQ_Empleados_Clave").IsUnique();

            entity.Property(e => e.Ingreso).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Materno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Paterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sueldo).HasColumnType("decimal(8, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
