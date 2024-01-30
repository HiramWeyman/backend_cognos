using ApiCognosV1.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiCognosV1.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions <ApplicationDBContext> options):base(options)
        { 
        }
        public DbSet<Perfiles> Perfiles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<SaludFM> SaludFM { get; set; }
        public DbSet<AnalisisFU> AnalisisFU { get; set; }
        public DbSet<EvolucionPR> EvolucionPR { get; set; }
        public DbSet<OtrasAR> OtrasAR { get; set; }
        public DbSet<DiagnosticoDS> DiagnosticoDS { get; set; }
        public DbSet<ProblemasMed> ProblemasMed { get; set; }
        public DbSet<PrevioSalud> PrevioSalud { get; set; }
        public DbSet<ConsumoSust> ConsumoSust { get; set; }
        public DbSet<Tratamiento> Tratamiento { get; set; }
        public DbSet<ConsultaM> ConsultaM { get; set; }
        public DbSet<ProbObj> ProbObj { get; set; }
        public DbSet<LineaVida> LineaVida { get; set; }
        public DbSet<Sesion> Sesion { get; set; }
        public DbSet<v_sesion_x> v_sesion { get; set; }

        public DbSet<v_informe_x> v_informe { get; set; }
        public DbSet<FormCaso> FormCaso { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Informe> Informe { get; set; }
        public DbSet<cat_terapeutas> cat_terapeutas { get; set; }

        public DbSet<Genero> Genero { get; set; }

        public DbSet<Escolaridad> Escolaridad { get; set; }

        public DbSet<Edocivil> Edocivil { get; set; }

        public DbSet<Creencias> Creencias { get; set; }

        public DbSet<Files> Files { get; set; }

        public DbSet<TablaPrueba> TablaPrueba { get; set; }

        //Preguntas de los Test
        public DbSet<TestSCL> TestSCL { get; set; }
        public DbSet<TestBAI_Inv_An> TestBAI_Inv_An { get; set; }
        public DbSet<TestBDI_Inv_Dp> TestBDI_Inv_Dp { get; set; }
        public DbSet<TestEllis> TestEllis { get; set; }
        public DbSet<TestSCID> TestSCID { get; set; }
        public DbSet<TestIsraC> TestIsraC { get; set; }
        public DbSet<TestIsraF> TestIsraF { get; set; }
        public DbSet<TestIsraM> TestIsraM { get; set; }
        public DbSet<Maestro_pruebas> Maestro_pruebas { get; set; }

        


        //Respuestas de los Test
        public DbSet<RespSCL> RespSCL { get; set; }
        public DbSet<RespBAIan> RespBAIan { get; set; }
        public DbSet<RespBDIdp> RespBDIdp { get; set; }
        public DbSet<RespEllis> RespEllis { get; set; }
        public DbSet<RespSCID> RespSCID { get; set; }

        public DbSet<RespIsraC> RespIsraC { get; set; }
        public DbSet<RespIsraF> RespIsraF { get; set; }
        public DbSet<RespIsraM> RespIsraM { get; set; }




        //Vistas de los Test
        public DbSet<v_scl_x> v_scl { get; set; }
        public DbSet<v_baian_x> v_baian { get; set; }
        public DbSet<v_bdidp_x> v_bdidp { get; set; }
        public DbSet<v_ellis_x> v_ellis { get; set; }
        public DbSet<v_scid_x> v_scid { get; set; }
        public DbSet<v_israC_x> v_israC { get; set; }
        public DbSet<v_israF_x> v_israF { get; set; }
        public DbSet<v_israM_x> v_israM { get; set; }

        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<v_sesion_x>(c => {

                c.HasNoKey();
                c.ToView("v_sesiones");
            });

            modelBuilder.Entity<v_informe_x>(d => {

                d.HasNoKey();
                d.ToView("Vista_Informe");
            });

            modelBuilder.Entity<v_scl_x>(e => {

                e.HasNoKey();
                e.ToView("Vista_SCL");
            });

            modelBuilder.Entity<v_baian_x>(e => {

                e.HasNoKey();
                e.ToView("Vista_BAIAN");
            });

            modelBuilder.Entity<v_bdidp_x>(f => {

                f.HasNoKey();
                f.ToView("Vista_BDIDP");
            });

            modelBuilder.Entity<v_ellis_x>(g => {

                g.HasNoKey();
                g.ToView("Vista_Ellis");
            });

            modelBuilder.Entity<v_scid_x>(h => {

                h.HasNoKey();
                h.ToView("Vista_SCID");
            });

            modelBuilder.Entity<v_israC_x>(i => {

                i.HasNoKey();
                i.ToView("VistaIsraC");
            });
            modelBuilder.Entity<v_israF_x>(j => {

                j.HasNoKey();
                j.ToView("VistaIsraF");
            });
            modelBuilder.Entity<v_israM_x>(k => {

                k.HasNoKey();
                k.ToView("VistaIsraM");
            });
            //base.OnModelCreating(modelBuilder);
        }
    }
}
