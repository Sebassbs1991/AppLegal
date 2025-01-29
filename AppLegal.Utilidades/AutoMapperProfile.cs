using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using AppLegal.DTO; 
using AppLegal.Modelo;

namespace AppLegal.Utilidades
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario,UsuarioDTO>();
            CreateMap<Usuario, SesionDTO>();
            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<Caso, CasoDTO>();
            CreateMap<CasoDTO, Caso>();

            CreateMap <Documento, DocumentoDTO>();
            CreateMap<DocumentoDTO, Documento>();

            CreateMap<Evento, EventoDTO>();
            CreateMap<EventoDTO, Evento>();

            CreateMap<Tarea, TareaDTO>();
            CreateMap<TareaDTO, Tarea>();



        }
    }
        
            
}
