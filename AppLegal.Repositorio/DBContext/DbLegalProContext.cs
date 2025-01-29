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

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Caso>(entity =>
        {
            entity.HasKey(e => e.CasoId).HasName("PK__Casos__692E7553AE98D7DB");

            entity.HasIndex(e => e.NumeroCaso, "UQ__Casos__B64DBD6D81E4DC90").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.NumeroCaso).HasMaxLength(20);
            entity.Property(e => e.TipoCaso).HasMaxLength(50);

            entity.HasOne(d => d.Abogado).WithMany(p => p.CasoAbogados)
                .HasForeignKey(d => d.AbogadoId)
                .HasConstraintName("FK__Casos__AbogadoId__59FA5E80");

            entity.HasOne(d => d.Cliente).WithMany(p => p.CasoClientes)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Casos__ClienteId__59063A47");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.DocumentoId).HasName("PK__Document__5DDBFC760A632F47");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaSubida).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Ruta).HasMaxLength(500);
            entity.Property(e => e.TipoDocumento).HasMaxLength(50);

            entity.HasOne(d => d.Caso).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.CasoId)
                .HasConstraintName("FK__Documento__CasoI__6477ECF3");

            entity.HasOne(d => d.SubidoPorNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.SubidoPor)
                .HasConstraintName("FK__Documento__Subid__656C112C");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Eventos__1EEB5921B3420144");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.RecordatorioEnviado).HasDefaultValue(false);
            entity.Property(e => e.TipoEvento).HasMaxLength(50);
            entity.Property(e => e.Titulo).HasMaxLength(200);

            entity.HasOne(d => d.Caso).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.CasoId)
                .HasConstraintName("FK__Eventos__CasoId__6A30C649");

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.CreadoPor)
                .HasConstraintName("FK__Eventos__CreadoP__6D0D32F4");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302F14068602B");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.TareaId).HasName("PK__Tareas__5CD83991A1E47369");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Prioridad).HasMaxLength(20);
            entity.Property(e => e.Titulo).HasMaxLength(200);

            entity.HasOne(d => d.Caso).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.CasoId)
                .HasConstraintName("FK__Tareas__CasoId__5EBF139D");

            entity.HasOne(d => d.Responsable).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.ResponsableId)
                .HasConstraintName("FK__Tareas__Responsa__5FB337D6");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B8536FB46E");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A1996F24683").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Correo).HasMaxLength(256);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.NombreUsuario).HasMaxLength(100);
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.UsuarioRolId).HasName("PK__UsuarioR__C869CDCAF54C49B5");

            entity.ToTable("UsuarioRol");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaAsignacion).HasDefaultValueSql("(getutcdate())");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__UsuarioRo__RolId__534D60F1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__UsuarioRo__Usuar__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
