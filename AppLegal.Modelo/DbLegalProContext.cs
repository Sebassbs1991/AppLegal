using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppLegal.Modelo;

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

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<RolMenu> RolMenus { get; set; }

    public virtual DbSet<Rol> Roles { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=DB_LegalPro; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Caso>(entity =>
        {
            entity.HasKey(e => e.CasoId).HasName("PK__Casos__692E755393F4808D");

            entity.HasIndex(e => e.NumeroCaso, "UQ__Casos__B64DBD6D5D717B1C").IsUnique();

            entity.Property(e => e.AbogadoId).HasMaxLength(450);
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.ClienteId).HasMaxLength(450);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.NumeroCaso).HasMaxLength(20);
            entity.Property(e => e.TipoCaso).HasMaxLength(50);

            entity.HasOne(d => d.Abogado).WithMany(p => p.CasoAbogados)
                .HasForeignKey(d => d.AbogadoId)
                .HasConstraintName("FK__Casos__AbogadoId__6383C8BA");

            entity.HasOne(d => d.Cliente).WithMany(p => p.CasoClientes)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Casos__ClienteId__628FA481");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.DocumentoId).HasName("PK__Document__5DDBFC768AA67788");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaSubida).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Ruta).HasMaxLength(500);
            entity.Property(e => e.SubidoPor).HasMaxLength(450);
            entity.Property(e => e.TipoDocumento).HasMaxLength(50);

            entity.HasOne(d => d.Caso).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.CasoId)
                .HasConstraintName("FK__Documento__CasoI__6E01572D");

            entity.HasOne(d => d.SubidoPorNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.SubidoPor)
                .HasConstraintName("FK__Documento__Subid__6EF57B66");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Eventos__1EEB5921780BF992");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.RecordatorioEnviado).HasDefaultValue(false);
            entity.Property(e => e.TipoEvento).HasMaxLength(50);
            entity.Property(e => e.Titulo).HasMaxLength(200);

            entity.HasOne(d => d.Caso).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.CasoId)
                .HasConstraintName("FK__Eventos__CasoId__73BA3083");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__Menus__C99ED230FF7DDD9C");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Icono).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Url).HasMaxLength(200);

            entity.HasOne(d => d.MenuPadre).WithMany(p => p.InverseMenuPadre)
                .HasForeignKey(d => d.MenuPadreId)
                .HasConstraintName("FK__Menus__MenuPadre__5812160E");
        });

        modelBuilder.Entity<RolMenu>(entity =>
        {
            entity.HasKey(e => e.RolMenuId).HasName("PK__RolMenu__8339C1FEBAB0B5AD");

            entity.ToTable("RolMenu");

            entity.Property(e => e.FechaAsignacion).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Permitido).HasDefaultValue(true);

            entity.HasOne(d => d.Menu).WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK__RolMenu__MenuId__5CD6CB2B");

            entity.HasOne(d => d.Rol).WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__RolMenu__RolId__5BE2A6F2");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302F15354D21D");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.TareaId).HasName("PK__Tareas__5CD83991022DFD34");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Prioridad).HasMaxLength(20);
            entity.Property(e => e.ResponsableId).HasMaxLength(450);
            entity.Property(e => e.Titulo).HasMaxLength(200);

            entity.HasOne(d => d.Caso).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.CasoId)
                .HasConstraintName("FK__Tareas__CasoId__68487DD7");

            entity.HasOne(d => d.Responsable).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.ResponsableId)
                .HasConstraintName("FK__Tareas__Responsa__693CA210");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B87324F34B");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A19DE273EAB").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Correo).HasMaxLength(256);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.NombreUsuario).HasMaxLength(100);
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.UsuarioRolId).HasName("PK__UsuarioR__C869CDCA87CA5FBA");

            entity.ToTable("UsuarioRol");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaAsignacion).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.UsuarioId).HasMaxLength(450);

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
