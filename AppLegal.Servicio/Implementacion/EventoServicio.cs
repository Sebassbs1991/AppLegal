using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppLegal.Modelo;
using AppLegal.DTO;
using AppLegal.Repositorio.Contrato;
using AppLegal.Servicio.Contrato;
using AutoMapper;


namespace AppLegal.Servicio.Implementacion
{
    public class EventoServicio : IEventoServicio
    {
        private readonly IGenericoRepositorio<Evento> _modeloRepositorio;
        private readonly IMapper _mapper;
        public EventoServicio(IGenericoRepositorio<Evento> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }
        public async Task<EventoDTO> Crear(EventoDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Evento>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.EventoId != 0)
                    return _mapper.Map<EventoDTO>(rspModelo);
                else
                    throw new TaskCanceledException("Error al crear el evento");
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async Task<bool> Editar(EventoDTO modelo)
        {
            try
            {

                var consulta = _modeloRepositorio.Consultar(x => x.EventoId == modelo.EventoId);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Titulo = modelo.Titulo;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.FechaInicio = modelo.FechaFin;
                    fromDbModelo.FechaFin= modelo.FechaFin;
                    fromDbModelo.TipoEvento= modelo.TipoEvento;
                    var respuesta = await _modeloRepositorio.Editar(fromDbModelo);

                    if (!respuesta)
                        throw new TaskCanceledException("Error al editar el Evento");
                    return respuesta;

                }
                else
                {
                    throw new TaskCanceledException("Evento no encontrado");
                }
            }

            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(x => x.EventoId== id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {

                    var respuesta = await _modeloRepositorio.Eliminar(fromDbModelo);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo eliminar");
                    return respuesta;
                }

                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async Task<List<EventoDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(x =>
                string.Concat(x.Titulo.ToLower(), x.Descripcion.ToLower()).Contains(buscar, StringComparison.CurrentCultureIgnoreCase)
                );

                List<EventoDTO> lista = _mapper.Map<List<EventoDTO>>(await consulta.ToListAsync());
                return lista;
            }


            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async Task<EventoDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(x => x.EventoId == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<EventoDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");

            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
}
