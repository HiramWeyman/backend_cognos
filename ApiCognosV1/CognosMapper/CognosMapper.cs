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
        }
    }
}
