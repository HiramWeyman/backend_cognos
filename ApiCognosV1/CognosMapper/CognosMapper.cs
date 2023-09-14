using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using AutoMapper;

namespace ApiCognosV1.CognosMapper
{
    public class CognosMapper: Profile
    {
        public CognosMapper()
        {
            CreateMap<Perfiles, PerfilesDto>().ReverseMap();
            CreateMap<Perfiles, CrearPerfilesDto>().ReverseMap();
            CreateMap<Pacientes, PacientesDto>().ReverseMap();
            CreateMap<Pacientes, CrearPacientesDto>().ReverseMap();
            CreateMap<SaludFM, SaludFM_Dto>().ReverseMap();
            CreateMap<SaludFM, CrearSaludFM_Dto>().ReverseMap();
            CreateMap<AnalisisFU, AnalisisFU_Dto>().ReverseMap();
            CreateMap<AnalisisFU, CrearAnalisisFU_Dto>().ReverseMap();
            CreateMap<EvolucionPR, EvolucionPR_Dto>().ReverseMap();
            CreateMap<EvolucionPR, CrearEvolucionPR_Dto>().ReverseMap();
            CreateMap<OtrasAR, OtrasAR_Dto>().ReverseMap();
            CreateMap<OtrasAR, CrearOtrasAR_Dto>().ReverseMap();
            CreateMap<DiagnosticoDS, DiagnosticoDS_Dto>().ReverseMap();
            CreateMap<DiagnosticoDS, CrearDiagnosticoDS_Dto>().ReverseMap();
            CreateMap<ProblemasMed, ProblemasMedDto>().ReverseMap();
            CreateMap<ProblemasMed, CrearProblemasMedDto>().ReverseMap();
            CreateMap<PrevioSalud, PrevioSaludDto>().ReverseMap();
            CreateMap<PrevioSalud, CrearPrevioSaludDto>().ReverseMap();
            CreateMap<ConsumoSust, ConsumoSustDto>().ReverseMap();
            CreateMap<ConsumoSust, CrearConsumoSustDto>().ReverseMap();
        }
    }
}
