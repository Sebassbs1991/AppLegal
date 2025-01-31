using System;
using System.Collections.Generic;
using AppLegal.Modelo;
using Microsoft.EntityFrameworkCore;

namespace AppLegal.Repositorio.DBContext;

public partial class DbLegalProContext : DbContext
{
    public DbLegalProContext()
    {
    }

    public DbLegalProContext(DbContextOptions<DbLegalProContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Caso> Casos { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Caso>(entity =>
        {
            entity.HasKey(e => e.CasoId).HasName("PK__Casos__692E75535D7900D7");

            entity.HasIndex(e => e.NumeroCaso, "UQ__Casos__B64DBD6DF0C9F544").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.NumeroCaso).HasMaxLength(20);
            entity.Property(e => e.TipoCaso).HasMaxLength(50);

            entity.HasOne(d => d.Abogado).WithMany(p => p.CasoAbogados)
                .HasForeignKey(d => d.AbogadoId)
                .HasConstraintName("FK__Casos__AbogadoId__5070F446");

            entity.HasOne(d => d.Cliente).WithMany(p => p.CasoClientes)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Casos__ClienteId__4F7CD00D");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.DocumentoId).HasName("PK__Document__5DDBFC76A1497C84");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaSubida).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Ruta).HasMaxLength(500);
            entity.Property(e => e.TipoDocumento).HasMaxLength(50);

            entity.HasOne(d => d.Caso).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.CasoId)
                .HasConstraintName("FK__Documento__CasoI__5AEE82B9");

            entity.HasOne(d => d.SubidoPorNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.SubidoPor)
                .HasConstraintName("FK__Documento__Subid__5BE2A6F2");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Eventos__1EEB592168122901");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.RecordatorioEnviado).HasDefaultValue(false);
            entity.Property(e => e.TipoEvento).HasMaxLength(50);
            entity.Property(e => e.Titulo).HasMaxLength(200);

            entity.HasOne(d => d.Caso).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.CasoId)
                .HasConstraintName("FK__Eventos__CasoId__60A75C0F");

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.CreadoPor)
                .HasConstraintName("FK__Eventos__CreadoP__6383C8BA");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.TareaId).HasName("PK__Tareas__5CD8399131C05197");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Prioridad).HasMaxLength(20);
            entity.Property(e => e.Titulo).HasMaxLength(200);

            entity.HasOne(d => d.Caso).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.CasoId)
                .HasConstraintName("FK__Tareas__CasoId__5535A963");

            entity.HasOne(d => d.Responsable).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.ResponsableId)
                .HasConstraintName("FK__Tareas__Responsa__5629CD9C");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B810043F7B");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A19FB34D950").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Correo).HasMaxLength(256);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.NombreUsuario).HasMaxLength(100);
            entity.Property(e => e.Rol).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
