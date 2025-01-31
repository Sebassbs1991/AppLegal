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
    public class CasoServicio : ICasoServicio
    {
        private readonly IGenericoRepositorio<Caso> _modeloRepositorio;
        private readonly IMapper _mapper;
        public CasoServicio(IGenericoRepositorio<Caso> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }
        public async Task<CasoDTO> Crear(CasoDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Caso>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.CasoId != 0)
                    return _mapper.Map<CasoDTO>(rspModelo);
                else
                    throw new TaskCanceledException("Error al crear el caso");
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
        public async Task<bool> Editar(CasoDTO modelo)
        {
            try
            {

                var consulta = _modeloRepositorio.Consultar(x => x.CasoId == modelo.CasoId);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.TipoCaso = modelo.TipoCaso;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    var respuesta = await _modeloRepositorio.Editar(fromDbModelo);

                    if (!respuesta)
                        throw new TaskCanceledException("Error al editar el Caso");
                    return respuesta;

                }
                else
                {
                    throw new TaskCanceledException("Caso no encontrado");
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
                var consulta = _modeloRepositorio.Consultar(x => x.CasoId == id);
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
        public async Task<CasoDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(x => x.CasoId == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<CasoDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");

            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
        public async Task<List<CasoDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(x =>
                x.NumeroCaso!.ToLower().Contains(buscar.ToLower())
                );

                List<CasoDTO> lista = _mapper.Map<List<CasoDTO>>(await consulta.ToListAsync());
                return lista;
            }


            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
    
}
