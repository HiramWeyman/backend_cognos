﻿// <auto-generated />
using System;
using ApiCognosV1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiCognosV1.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiCognosV1.Modelos.Pacientes", b =>
                {
                    b.Property<int>("pac_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pac_id"));

                    b.Property<string>("pac_domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pac_edad")
                        .HasColumnType("int");

                    b.Property<int>("pac_edocivil")
                        .HasColumnType("int");

                    b.Property<string>("pac_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pac_escolaridad")
                        .HasColumnType("int");

                    b.Property<DateTime>("pac_fecha_ingreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("pac_fecha_nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("pac_genero")
                        .HasColumnType("int");

                    b.Property<string>("pac_materno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pac_nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pac_ocupacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pac_paterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pac_telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pac_usr_id")
                        .HasColumnType("int");

                    b.HasKey("pac_id");

                    b.HasIndex("pac_usr_id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.Perfiles", b =>
                {
                    b.Property<int>("per_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("per_id"));

                    b.Property<string>("per_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("per_id");

                    b.ToTable("Perfiles");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.SaludFM", b =>
                {
                    b.Property<int>("salud_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("salud_id"));

                    b.Property<string>("salud_act_fisica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salud_act_fisica_desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salud_alimentacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salud_alimentacion_desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("salud_fecha_captura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("salud_fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("salud_paciente_id")
                        .HasColumnType("int");

                    b.Property<string>("salud_sueno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("salud_sueno_desc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("salud_id");

                    b.HasIndex("salud_paciente_id");

                    b.ToTable("SaludFM");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.Usuarios", b =>
                {
                    b.Property<int>("usr_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("usr_id"));

                    b.Property<string>("usr_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("usr_fecha_creacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("usr_materno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usr_nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usr_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usr_paterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("usr_per_id")
                        .HasColumnType("int");

                    b.HasKey("usr_id");

                    b.HasIndex("usr_per_id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.Pacientes", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("pac_usr_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.SaludFM", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("salud_paciente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.Usuarios", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Perfiles", "Perfiles")
                        .WithMany()
                        .HasForeignKey("usr_per_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfiles");
                });
#pragma warning restore 612, 618
        }
    }
}
