using SmartBook.Application.Dtos.Requests;
using SmartBook.Application.Dtos.Responses;
using SmartBook.Application.Interfaces;
using SmartBook.Domain.Entities;
using SmartBook.Domain.Enums;
using SmartBook.Domain.Exceptions;
using SmartBook.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBook.Application.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuarioRepository _repo;
        private readonly IUnitOfWork _uow;
        private const string DominioInstitucional = "@cecar.edu.co";

        public UsuariosService(IUsuarioRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<uint> CrearAsync(CrearUsuarioDto dto)
        {
            AgeValidator.ValidarEdadMinima(dto.FechaNacimiento);

            if (!dto.Email.EndsWith(DominioInstitucional, StringComparison.OrdinalIgnoreCase))
                throw new BusinessRuleException("El correo debe ser institucional (@cecar.edu.co).");

            var nombres = dto.Nombres.RemoveAccents().ToUpper().Trim();

            if (!Enum.TryParse<RolUsuario>(dto.Rol, true, out var rolAsignado))
                throw new BusinessRuleException("Rol inválido. Debe ser ADMIN o VENDEDOR.");

            var u = new Persona
            {
                Tipo = TipoPersona.Usuario,
                Identificacion = dto.Identificacion.Trim(),
                Nombres = nombres,
                Email = dto.Email.Trim().ToLowerInvariant(),
                Celular = dto.Celular.Trim(),
                FechaNacimiento = dto.FechaNacimiento,
                Rol = rolAsignado,
                PasswordHash = dto.Password,
                Activo = true,
                EmailVerificado = false,
                CreadoEn = DateTime.UtcNow
            };

            await _repo.AddAsync(u);
            await _uow.CommitAsync();
            return u.Id;
        }

        public async Task<IEnumerable<UsuarioResponse>> BuscarAsync(string? nombres, string? rol)
        {
            string? filtroNombre = nombres?.RemoveAccents().ToUpper().Trim();
            RolUsuario? filtroRol = null;

            if (!string.IsNullOrWhiteSpace(rol) &&
                Enum.TryParse<RolUsuario>(rol, true, out var r))
                filtroRol = r;

            var list = await _repo.FindAsync(x =>
                x.Tipo == TipoPersona.Usuario &&
                (string.IsNullOrWhiteSpace(filtroNombre) || x.Nombres.Contains(filtroNombre)) &&
                (filtroRol == null || x.Rol == filtroRol)
            );

            return list.Select(u => new UsuarioResponse
            {
                Id = u.Id,
                Identificacion = u.Identificacion,
                Nombres = u.Nombres,
                Email = u.Email,
                Celular = u.Celular,
                FechaNacimiento = u.FechaNacimiento,
                Rol = u.Rol.ToString()!,
                Activo = u.Activo,
                EmailVerificado = u.EmailVerificado,
                CreadoEn = u.CreadoEn,
                ActualizadoEn = u.ActualizadoEn
            });
        }
    }
}
