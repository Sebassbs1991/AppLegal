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
    public class DocumentoServicio : IDocumentoServicio
    {

        private readonly IGenericoRepositorio<Documento> _modeloRepositorio;
        private readonly IMapper _mapper;
        public DocumentoServicio(IGenericoRepositorio<Documento> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }
        public async Task<DocumentoDTO> Crear(DocumentoDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Documento>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.DocumentoId != 0)
                    return _mapper.Map<DocumentoDTO>(rspModelo);
                else
                    throw new TaskCanceledException("Error al crear el documento");
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async Task<bool> Editar(DocumentoDTO modelo)
        {
            try
            {

                var consulta = _modeloRepositorio.Consultar(x => x. DocumentoId== modelo.DocumentoId);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.TipoDocumento = modelo.TipoDocumento;
                    fromDbModelo.Ruta = modelo.Ruta;

                    var respuesta = await _modeloRepositorio.Editar(fromDbModelo);

                    if (!respuesta)
                        throw new TaskCanceledException("Error al editar el Documento");
                    return respuesta;

                }
                else
                {
                    throw new TaskCanceledException("Documento no encontrado");
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
                var consulta = _modeloRepositorio.Consultar(x => x.DocumentoId == id);
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

        public async Task<List<DocumentoDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(x =>
                string.Concat(x.Nombre.ToLower(),x.TipoDocumento.ToLower()).Contains(buscar.ToLower())
                );

                List<DocumentoDTO> lista = _mapper.Map<List<DocumentoDTO>>(await consulta.ToListAsync());
                return lista;
            }


            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async Task<DocumentoDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(x => x.DocumentoId == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<DocumentoDTO>(fromDbModelo);
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
