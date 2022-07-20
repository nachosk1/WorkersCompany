﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkersCompany.Context;

namespace WorkersCompany.Migrations
{
    [DbContext(typeof(YuriDBContext))]
    [Migration("20220720211637_Trabajador")]
    partial class Trabajador
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorkersCompany.Models.CargaFamiliar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parentesco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CargaFamiliar");
                });

            modelBuilder.Entity("WorkersCompany.Models.ContactosEmerg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Relacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactosEmerg");
                });

            modelBuilder.Entity("WorkersCompany.Models.DatosLaborales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AreaDepartamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DatosLaborales");
                });

            modelBuilder.Entity("WorkersCompany.Models.Trabajador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CargaFamiliarId")
                        .HasColumnType("int");

                    b.Property<int?>("ContactosEmergId")
                        .HasColumnType("int");

                    b.Property<int?>("DatosLaboralesId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CargaFamiliarId");

                    b.HasIndex("ContactosEmergId");

                    b.HasIndex("DatosLaboralesId");

                    b.ToTable("Trabajador");
                });

            modelBuilder.Entity("WorkersCompany.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("TrabajadorId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("TrabajadorId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("WorkersCompany.Models.Trabajador", b =>
                {
                    b.HasOne("WorkersCompany.Models.CargaFamiliar", "CargaFamiliar")
                        .WithMany()
                        .HasForeignKey("CargaFamiliarId");

                    b.HasOne("WorkersCompany.Models.ContactosEmerg", "ContactosEmerg")
                        .WithMany()
                        .HasForeignKey("ContactosEmergId");

                    b.HasOne("WorkersCompany.Models.DatosLaborales", "DatosLaborales")
                        .WithMany()
                        .HasForeignKey("DatosLaboralesId");

                    b.Navigation("CargaFamiliar");

                    b.Navigation("ContactosEmerg");

                    b.Navigation("DatosLaborales");
                });

            modelBuilder.Entity("WorkersCompany.Models.Usuario", b =>
                {
                    b.HasOne("WorkersCompany.Models.Trabajador", "Trabajador")
                        .WithMany()
                        .HasForeignKey("TrabajadorId");

                    b.Navigation("Trabajador");
                });
#pragma warning restore 612, 618
        }
    }
}