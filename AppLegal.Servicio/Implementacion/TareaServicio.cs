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
    public class TareaServicio : ITareaServicio
    {

        private readonly IGenericoRepositorio<Tarea> _modeloRepositorio;
        private readonly IMapper _mapper;
        public TareaServicio(IGenericoRepositorio<Tarea> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<TareaDTO> Crear(TareaDTO modelo)
        {
            
           try
            {
                var dbModelo = _mapper.Map<Tarea>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.TareaId != 0)
                    return _mapper.Map<TareaDTO>(rspModelo);
                else
                    throw new TaskCanceledException("Error al crear la Tarea");
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
        public async Task<bool> Editar(TareaDTO modelo)
        {
            try
            {

                var consulta = _modeloRepositorio.Consultar(x => x.TareaId == modelo.TareaId);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Titulo = modelo.Titulo;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.FechaVencimiento = modelo.FechaVencimiento;
                    fromDbModelo.Prioridad = modelo.Prioridad;
                    fromDbModelo.Estado = modelo.Estado;
                    var respuesta = await _modeloRepositorio.Editar(fromDbModelo);

                    if (!respuesta)
                        throw new TaskCanceledException("Error al editar la Tarea");
                    return respuesta;

                }
                else
                {
                    throw new TaskCanceledException("Tarea no encontrado");
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
                var consulta = _modeloRepositorio.Consultar(x => x.TareaId == id);
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
    
       public async Task<List<TareaDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(x =>
                string.Concat(x.Titulo.ToLower(), x.Descripcion.ToLower(),x.Prioridad.ToLower(), x.Estado.ToLower()).Contains(buscar.ToLower())
                );

                List<TareaDTO> lista = _mapper.Map<List<TareaDTO>>(await consulta.ToListAsync());
                return lista;
            }


            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async Task<TareaDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(x => x.TareaId == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<TareaDTO>(fromDbModelo);
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
