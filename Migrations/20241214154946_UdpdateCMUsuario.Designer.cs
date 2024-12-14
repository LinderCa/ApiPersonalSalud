﻿// <auto-generated />
using System;
using ApiPersonalSalud.CAD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiPersonalSalud.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241214154946_UdpdateCMUsuario")]
    partial class UdpdateCMUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENAntecedentesMedicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdGestante")
                        .HasColumnType("int");

                    b.Property<int>("Motivo")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdGestante");

                    b.ToTable("AntecedentesMedicos", null, t =>
                        {
                            t.HasCheckConstraint("CHK_CENAntecedentesMedicos_Tipo", "Tipo BETWEEN 0 AND 2");

                            t.HasCheckConstraint("CHK_CenAntecedentesMedicos_Motivo", "Motivo BETWEEN 0 AND 3");
                        });
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENCita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCita")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("HoraCita")
                        .HasColumnType("time");

                    b.Property<int>("IdGestante")
                        .HasColumnType("int");

                    b.Property<int>("IdPersonalSalud")
                        .HasColumnType("int");

                    b.Property<int>("Motivo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdGestante");

                    b.HasIndex("IdPersonalSalud");

                    b.ToTable("Cita", null, t =>
                        {
                            t.HasCheckConstraint("CHK_CENCita_Estado", "Estado BETWEEN 0 AND 2");

                            t.HasCheckConstraint("CHK_CENCita_FechaCita", "FechaCita >= GETDATE()");

                            t.HasCheckConstraint("CHK_CENCita_HoraCita", "HoraCita >= '08:00:00' AND HoraCita <= '15:00:00'");

                            t.HasCheckConstraint("CHK_CENCita_Motivo", "Motivo BETWEEN 0 AND 2");
                        });
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENConsulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCita")
                        .HasColumnType("int");

                    b.Property<string>("Resultados")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCita")
                        .IsUnique();

                    b.ToTable("Consulta", (string)null);
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENDatosBiometricos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FrecuenciaCardiaca")
                        .HasColumnType("int");

                    b.Property<int>("IdMonitoreo")
                        .HasColumnType("int");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.Property<int>("PresionArterial")
                        .HasColumnType("int");

                    b.Property<short>("Temperatura")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("IdMonitoreo")
                        .IsUnique();

                    b.ToTable("DatosBiometricos", (string)null);
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENDiagnostico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("EstadoFetal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("IdMonitoreo")
                        .HasColumnType("int");

                    b.Property<string>("Recomendacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sintomas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdMonitoreo")
                        .IsUnique();

                    b.ToTable("Diagnostico", null, t =>
                        {
                            t.HasCheckConstraint("CHK_CENDiagnostico_Estado", "Estado IN (0,1)");

                            t.HasCheckConstraint("CHK_CENDiagnostico_EstadoFetal", "EstadoFetal IN (0, 1)");
                        });
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENGestante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EdadGestacional")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("GrupoSanguineo")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("Id");

                    b.ToTable("Gestantes", null, t =>
                        {
                            t.HasCheckConstraint("CHK_CENGestante_Correo", "Correo LIKE '_%@_%._%'");

                            t.HasCheckConstraint("CHK_CENGestante_FechaNacimiento", "FechaNacimiento <= DATEADD(YEAR,-14,GETDATE())");

                            t.HasCheckConstraint("CHK_CENGestante_GrupoSanguineo", "GrupoSanguineo BETWEEN 0 AND 7");

                            t.HasCheckConstraint("CHK_CENGestante_Telefono", "Telefono IS NOT NULL OR (LEN(Telefono) = 9 AND Telefono NOT LIKE '%[^0-9]%')");
                        });
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENMonitoreo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaMonitoreo")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCita")
                        .HasColumnType("int");

                    b.Property<int>("Proceso")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCita")
                        .IsUnique();

                    b.ToTable("Monitoreo", null, t =>
                        {
                            t.HasCheckConstraint("CHK_CENMonitoreo_Proceso", "Proceso IN (0,1)");

                            t.HasCheckConstraint("CHK_CENMonitoreo_Tipo", " Tipo IN (0,1)");
                        });
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENPersonalSalud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PersonalSalud", null, t =>
                        {
                            t.HasCheckConstraint("CHK_CENPersonalSalud_Especialidad", "Especialidad IN ('M','E','O')");
                        });
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdGestante")
                        .HasColumnType("int");

                    b.Property<int>("IdPersonalSalud")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdGestante")
                        .IsUnique();

                    b.HasIndex("IdPersonalSalud")
                        .IsUnique();

                    b.ToTable("Usuario", null, t =>
                        {
                            t.HasCheckConstraint("CHK_CENUsuario_Rol", "Rol BETWEEN 0 AND 3");
                        });
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENAntecedentesMedicos", b =>
                {
                    b.HasOne("ApiPersonalSalud.CEN.CenEntidades.CENGestante", "Gestante")
                        .WithMany("AntecedentesMedicos")
                        .HasForeignKey("IdGestante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gestante");
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENCita", b =>
                {
                    b.HasOne("ApiPersonalSalud.CEN.CenEntidades.CENGestante", "Gestante")
                        .WithMany("Citas")
                        .HasForeignKey("IdGestante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiPersonalSalud.CEN.CenEntidades.CENPersonalSalud", "PersonalSalud")
                        .WithMany("Citas")
                        .HasForeignKey("IdPersonalSalud")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gestante");

                    b.Navigation("PersonalSalud");
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENConsulta", b =>
                {
                    b.HasOne("ApiPersonalSalud.CEN.CenEntidades.CENCita", "Cita")
                        .WithOne("Consulta")
                        .HasForeignKey("ApiPersonalSalud.CEN.CenEntidades.CENConsulta", "IdCita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cita");
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENDatosBiometricos", b =>
                {
                    b.HasOne("ApiPersonalSalud.CEN.CenEntidades.CENMonitoreo", "Monitoreo")
                        .WithOne("DatosBiometricos")
                        .HasForeignKey("ApiPersonalSalud.CEN.CenEntidades.CENDatosBiometricos", "IdMonitoreo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monitoreo");
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENDiagnostico", b =>
                {
                    b.HasOne("ApiPersonalSalud.CEN.CenEntidades.CENMonitoreo", "Monitoreo")
                        .WithOne("Diagnostico")
                        .HasForeignKey("ApiPersonalSalud.CEN.CenEntidades.CENDiagnostico", "IdMonitoreo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monitoreo");
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENMonitoreo", b =>
                {
                    b.HasOne("ApiPersonalSalud.CEN.CenEntidades.CENCita", "Cita")
                        .WithOne("Monitoreo")
                        .HasForeignKey("ApiPersonalSalud.CEN.CenEntidades.CENMonitoreo", "IdCita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cita");
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENUsuario", b =>
                {
                    b.HasOne("ApiPersonalSalud.CEN.CenEntidades.CENGestante", "Gestante")
                        .WithOne("Usuario")
                        .HasForeignKey("ApiPersonalSalud.CEN.CenEntidades.CENUsuario", "IdGestante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiPersonalSalud.CEN.CenEntidades.CENPersonalSalud", "PersonalSalud")
                        .WithOne("Usuario")
                        .HasForeignKey("ApiPersonalSalud.CEN.CenEntidades.CENUsuario", "IdPersonalSalud")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gestante");

                    b.Navigation("PersonalSalud");
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENCita", b =>
                {
                    b.Navigation("Consulta");

                    b.Navigation("Monitoreo");
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENGestante", b =>
                {
                    b.Navigation("AntecedentesMedicos");

                    b.Navigation("Citas");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENMonitoreo", b =>
                {
                    b.Navigation("DatosBiometricos");

                    b.Navigation("Diagnostico");
                });

            modelBuilder.Entity("ApiPersonalSalud.CEN.CenEntidades.CENPersonalSalud", b =>
                {
                    b.Navigation("Citas");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}