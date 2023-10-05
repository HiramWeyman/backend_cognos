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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<v_sesion_x>(c => {

                c.HasNoKey();
                c.ToView("v_sesiones");
            });
            //base.OnModelCreating(modelBuilder);
        }
    }
}
