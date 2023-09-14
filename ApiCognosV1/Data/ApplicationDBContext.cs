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

    }
}
