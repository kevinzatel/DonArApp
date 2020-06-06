﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Domain.Especialidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("Domain.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Detalle")
                        .HasColumnType("TEXT");

                    b.Property<bool>("DiagnosticoPresuntivo")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EspecialidadId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("PacienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sintomas")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TratamientoFarmacologico")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VoluntarioBasicoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VoluntarioMedicoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VoluntarioBasicoId");

                    b.HasIndex("VoluntarioMedicoId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Domain.Nacionalidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Nacionalidades");
                });

            modelBuilder.Entity("Domain.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .HasColumnType("TEXT");

                    b.Property<int>("Dni")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Edad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("Genero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HistorialClinico")
                        .HasColumnType("TEXT");

                    b.Property<int>("NacionalidadId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TerminosyCondiciones")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoUsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Domain.Provincia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("Domain.TipoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TiposUsuarios");
                });

            modelBuilder.Entity("Domain.VoluntarioBasico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .HasColumnType("TEXT");

                    b.Property<int>("Dni")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Edad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("Genero")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NacionalidadId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TerminosyCondiciones")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoUsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("VoluntariosBasicos");
                });

            modelBuilder.Entity("Domain.VoluntarioMedico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .HasColumnType("TEXT");

                    b.Property<int>("Dni")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Edad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("EspecialidadId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FinJornada")
                        .HasColumnType("TEXT");

                    b.Property<int>("Genero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InicioJornada")
                        .HasColumnType("TEXT");

                    b.Property<string>("Matricula")
                        .HasColumnType("TEXT");

                    b.Property<int>("NacionalidadId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Seguro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TerminosyCondiciones")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoUsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("VoluntariosMedicos");
                });

            modelBuilder.Entity("Domain.Evento", b =>
                {
                    b.HasOne("Domain.VoluntarioBasico", null)
                        .WithMany("Eventos")
                        .HasForeignKey("VoluntarioBasicoId");

                    b.HasOne("Domain.VoluntarioMedico", null)
                        .WithMany("Eventos")
                        .HasForeignKey("VoluntarioMedicoId");
                });
#pragma warning restore 612, 618
        }
    }
}
