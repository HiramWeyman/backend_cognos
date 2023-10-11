﻿// <auto-generated />
using System;
using ApiCognosV1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiCognosV1.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20231011063310_evo_problem_division")]
    partial class evo_problem_division
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiCognosV1.Modelos.AnalisisFU", b =>
                {
                    b.Property<int>("analisis_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("analisis_id"));

                    b.Property<string>("analisis_ant")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("analisis_ant_desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("analisis_con")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("analisis_con_desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("analisis_cons")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("analisis_cons_desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("analisis_fecha_captura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("analisis_fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("analisis_paciente_id")
                        .HasColumnType("int");

                    b.HasKey("analisis_id");

                    b.HasIndex("analisis_paciente_id");

                    b.ToTable("AnalisisFU");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.ConsultaM", b =>
                {
                    b.Property<int>("con_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("con_id"));

                    b.Property<DateTime>("con_fecha_captura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("con_fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("con_motivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("con_paciente_id")
                        .HasColumnType("int");

                    b.HasKey("con_id");

                    b.HasIndex("con_paciente_id");

                    b.ToTable("ConsultaM");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.ConsumoSust", b =>
                {
                    b.Property<int>("consumo_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("consumo_id"));

                    b.Property<string>("consumo_cantidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("consumo_edad_inicio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("consumo_fecha_captura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("consumo_fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("consumo_paciente_id")
                        .HasColumnType("int");

                    b.Property<string>("consumo_sino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("consumo_sustancia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("consumo_tiempo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("consumo_id");

                    b.HasIndex("consumo_paciente_id");

                    b.ToTable("ConsumoSust");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.DiagnosticoDS", b =>
                {
                    b.Property<int>("diag_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("diag_id"));

                    b.Property<string>("diag_desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("diag_fecha_captura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("diag_fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("diag_paciente_id")
                        .HasColumnType("int");

                    b.Property<string>("diag_titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("diag_id");

                    b.HasIndex("diag_paciente_id");

                    b.ToTable("DiagnosticoDS");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.EvolucionPR", b =>
                {
                    b.Property<int>("evo_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("evo_id"));

                    b.Property<string>("evo_curso_problema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("evo_desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("evo_factores")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("evo_fecha_captura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("evo_fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("evo_paciente_id")
                        .HasColumnType("int");

                    b.Property<string>("evo_titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("evo_id");

                    b.HasIndex("evo_paciente_id");

                    b.ToTable("EvolucionPR");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.LineaVida", b =>
                {
                    b.Property<int>("lin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("lin_id"));

                    b.Property<string>("lin_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lin_fecha_captura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("lin_fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("lin_paciente_id")
                        .HasColumnType("int");

                    b.Property<string>("lin_titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("lin_id");

                    b.HasIndex("lin_paciente_id");

                    b.ToTable("LineaVida");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.OtrasAR", b =>
                {
                    b.Property<int>("otras_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("otras_id"));

                    b.Property<string>("otras_desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("otras_fecha_captura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("otras_fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("otras_paciente_id")
                        .HasColumnType("int");

                    b.Property<string>("otras_titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("otras_id");

                    b.HasIndex("otras_paciente_id");

                    b.ToTable("OtrasAR");
                });

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

                    b.Property<int?>("pac_tutor")
                        .IsRequired()
                        .HasColumnType("int");

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

            modelBuilder.Entity("ApiCognosV1.Modelos.PrevioSalud", b =>
                {
                    b.Property<int>("previo_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("previo_id"));

                    b.Property<DateTime>("previo_fecha_captura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("previo_fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("previo_medicamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("previo_medico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("previo_paciente_id")
                        .HasColumnType("int");

                    b.Property<string>("previo_problema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("previo_tiempo_psicologico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("previo_tiempo_tratamiento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("previo_id");

                    b.HasIndex("previo_paciente_id");

                    b.ToTable("PrevioSalud");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.ProbObj", b =>
                {
                    b.Property<int>("pro_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pro_id"));

                    b.Property<DateTime>("pro_fecha_captura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("pro_fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("pro_objetivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pro_paciente_id")
                        .HasColumnType("int");

                    b.Property<string>("pro_problema")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pro_tecnica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pro_id");

                    b.HasIndex("pro_paciente_id");

                    b.ToTable("ProbObj");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.ProblemasMed", b =>
                {
                    b.Property<int>("problema_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("problema_id"));

                    b.Property<DateTime>("problema_fecha_captura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("problema_fecha_ini_trata")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("problema_fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("problema_medicamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("problema_medico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("problema_paciente_id")
                        .HasColumnType("int");

                    b.Property<string>("problema_problema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("problema_tiempo_tratamiento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("problema_id");

                    b.HasIndex("problema_paciente_id");

                    b.ToTable("ProblemasMed");
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

            modelBuilder.Entity("ApiCognosV1.Modelos.Sesion", b =>
                {
                    b.Property<int>("sesion_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sesion_id"));

                    b.Property<string>("sesion_caso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sesion_coterapeuta")
                        .HasColumnType("int");

                    b.Property<DateTime>("sesion_fecha_captura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("sesion_fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("sesion_no")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sesion_notas_ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sesion_objetivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sesion_otras_tecnicas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sesion_paciente_id")
                        .HasColumnType("int");

                    b.Property<string>("sesion_recomendacion_sup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sesion_rev_tarea")
                        .HasColumnType("int");

                    b.Property<string>("sesion_tarea_asignada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sesion_tecnica_abc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sesion_terapeuta")
                        .HasColumnType("int");

                    b.HasKey("sesion_id");

                    b.HasIndex("sesion_paciente_id");

                    b.ToTable("Sesion");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.Tratamiento", b =>
                {
                    b.Property<int>("trata_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("trata_id"));

                    b.Property<DateTime>("trata_fecha_captura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("trata_fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("trata_objetivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("trata_paciente_id")
                        .HasColumnType("int");

                    b.Property<string>("trata_tecnica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("trata_id");

                    b.HasIndex("trata_paciente_id");

                    b.ToTable("Tratamiento");
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

            modelBuilder.Entity("ApiCognosV1.Modelos.v_sesion_x", b =>
                {
                    b.Property<string>("coterapeuta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rev_tarea_desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sesion_caso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sesion_coterapeuta")
                        .HasColumnType("int");

                    b.Property<DateTime>("sesion_fecha_captura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("sesion_fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("sesion_id")
                        .HasColumnType("int");

                    b.Property<string>("sesion_no")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sesion_notas_ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sesion_objetivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sesion_otras_tecnicas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sesion_paciente_id")
                        .HasColumnType("int");

                    b.Property<string>("sesion_recomendacion_sup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sesion_rev_tarea")
                        .HasColumnType("int");

                    b.Property<string>("sesion_tarea_asignada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sesion_tecnica_abc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sesion_terapeuta")
                        .HasColumnType("int");

                    b.Property<string>("terapeuta")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("v_sesiones", (string)null);
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.AnalisisFU", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("analisis_paciente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.ConsultaM", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("con_paciente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.ConsumoSust", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("consumo_paciente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.DiagnosticoDS", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("diag_paciente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.EvolucionPR", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("evo_paciente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.LineaVida", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("lin_paciente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.OtrasAR", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("otras_paciente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacientes");
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

            modelBuilder.Entity("ApiCognosV1.Modelos.PrevioSalud", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("previo_paciente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.ProbObj", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("pro_paciente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.ProblemasMed", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("problema_paciente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacientes");
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

            modelBuilder.Entity("ApiCognosV1.Modelos.Sesion", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("sesion_paciente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("ApiCognosV1.Modelos.Tratamiento", b =>
                {
                    b.HasOne("ApiCognosV1.Modelos.Pacientes", "Pacientes")
                        .WithMany()
                        .HasForeignKey("trata_paciente_id")
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
