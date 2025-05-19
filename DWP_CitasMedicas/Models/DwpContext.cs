using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DWP_CitasMedicas.Models;

public partial class DwpContext : DbContext
{
    public DwpContext()
    {
    }

    public DwpContext(DbContextOptions<DwpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agendum> Agenda { get; set; }

    public virtual DbSet<Citum> Cita { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Medicacion> Medicacions { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ALEXIS;Database=DWP;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendum>(entity =>
        {
            entity.HasKey(e => e.IdAgenda).HasName("PK__agenda__F7F3D96B4BA10727");

            entity.ToTable("agenda");

            entity.Property(e => e.IdAgenda).HasColumnName("idAgenda");
            entity.Property(e => e.DiaSemana).HasMaxLength(20);
            entity.Property(e => e.IdDoctor).HasColumnName("idDoctor");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Agenda)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__agenda__idDoctor__49C3F6B7");
        });

        modelBuilder.Entity<Citum>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__cita__814F31260EA0F1E8");

            entity.ToTable("cita");

            entity.Property(e => e.IdCita).HasColumnName("idCita");
            entity.Property(e => e.EstadoCita)
                .HasMaxLength(20)
                .HasDefaultValueSql("('pendiente')");
            entity.Property(e => e.FechaCita).HasColumnType("datetime");
            entity.Property(e => e.IdDoctor).HasColumnName("idDoctor");
            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.TipoServicio).HasMaxLength(100);

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cita__idDoctor__44FF419A");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cita__idPaciente__440B1D61");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("PK__doctor__418956C35EE1D4B2");

            entity.ToTable("doctor");

            entity.Property(e => e.IdDoctor).HasColumnName("idDoctor");
            entity.Property(e => e.Especialidad).HasMaxLength(100);
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__doctor__idUsuari__403A8C7D");
        });

        modelBuilder.Entity<Medicacion>(entity =>
        {
            entity.HasKey(e => e.IdMedicacion).HasName("PK__medicaci__A538A7F7E6C13EE7");

            entity.ToTable("medicacion");

            entity.Property(e => e.IdMedicacion).HasColumnName("idMedicacion");
            entity.Property(e => e.Dosis).HasMaxLength(50);
            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.Medicamento).HasMaxLength(100);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Medicacions)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__medicacio__idPac__4CA06362");
        });

        modelBuilder.Entity<Notificacione>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK__notifica__AFE1D7E425A9A0F5");

            entity.ToTable("notificaciones");

            entity.Property(e => e.IdNotificacion).HasColumnName("idNotificacion");
            entity.Property(e => e.FechaEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Visto).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__notificac__idUsu__5165187F");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__F48A08F204C06CD4");

            entity.ToTable("Paciente");

            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Estatura).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Genero).HasMaxLength(10);
            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.NumeroTelefono).HasMaxLength(15);
            entity.Property(e => e.Peso).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Paciente__IDUsua__3D5E1FD2");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__rol__3C872F76729B67C1");

            entity.ToTable("rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.NombreRol).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__645723A6E4B2320A");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Correo, "UQ__usuario__60695A196DABF671").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Idrol).HasColumnName("IDRol");

            entity.HasOne(d => d.IdrolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idrol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__IDRol__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
