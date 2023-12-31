﻿using ApiCognosV1.Modelos;
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
            CreateMap<Tratamiento, TratamientoDto>().ReverseMap();
            CreateMap<Tratamiento, CrearTratamientoDto>().ReverseMap();
            CreateMap<ConsultaM, ConsultaDto>().ReverseMap();
            CreateMap<ConsultaM, CrearConsultaDto>().ReverseMap();
            CreateMap<ProbObj, ProObjDto>().ReverseMap();
            CreateMap<ProbObj, CrearProObjDto>().ReverseMap();
            CreateMap<LineaVida, LineaVidaDto>().ReverseMap();
            CreateMap<LineaVida, CrearLineaVidaDto>().ReverseMap();
            CreateMap<Sesion, SesionDto>().ReverseMap();
            CreateMap<Sesion, CrearSesionDto>().ReverseMap();

            CreateMap<Usuarios, UsuariosDto>().ReverseMap();

            CreateMap<FormCaso, FormCasoDto>().ReverseMap();
            CreateMap<FormCaso, CrearFormCasoDto>().ReverseMap();

            CreateMap<Comentarios, ComentariosDto>().ReverseMap();
            CreateMap<Comentarios, CrearComentariosDto>().ReverseMap();

            CreateMap<Informe, InformeDto>().ReverseMap();
            CreateMap<Informe, CrearInformeDto>().ReverseMap();

            CreateMap<cat_terapeutas, cat_terapeutasDto>().ReverseMap();
            CreateMap<cat_terapeutas, CrearCat_terapeutasDto>().ReverseMap();

            CreateMap<Genero, GeneroDto>().ReverseMap();
            CreateMap<Genero, CrearGeneroDto>().ReverseMap();

            CreateMap<Escolaridad, EscolaridadDto>().ReverseMap();
            CreateMap<Escolaridad, CrearEscolaridadDto>().ReverseMap();

            CreateMap<Edocivil, EdocivilDto>().ReverseMap();
            CreateMap<Edocivil, CrearEdocivilDto>().ReverseMap();

            CreateMap<Creencias, CreenciasDto>().ReverseMap();
            CreateMap<Creencias, CrearCreenciaDto>().ReverseMap();





        }
    }
}
