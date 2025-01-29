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
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IGenericoRepositorio<Usuario> _modeloRepositorio;
        private readonly IMapper _mapper;
        public UsuarioServicio(IGenericoRepositorio<Usuario> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<SesionDTO> Autorizacion(LoginDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(x => x.Correo == modelo.Correo && x.Clave == modelo.Clave);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();
                if (fromDbModelo == null)
                    return _mapper.Map<SesionDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("Usuario o clave incorrecta");


            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(UsuarioDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UsuarioDTO>> Lista(string rol, string buscar)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDTO> Obtener(string id)
        {
            throw new NotImplementedException();
        }
    }
}
