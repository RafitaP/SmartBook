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
    public class ClientesService : IClientesService
    {
        private readonly IClienteRepository _repo;
        private readonly IUnitOfWork _uow;

        public ClientesService(IClienteRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<uint> CrearAsync(CrearClienteDto dto)
        {
            if (!dto.FechaNacimiento.HasValue)
                throw new BusinessRuleException("La fecha de nacimiento es obligatoria.");

            AgeValidator.ValidarEdadMinima(dto.FechaNacimiento.Value);

            var identificacion = dto.Identificacion.Trim();
            var nombres = dto.Nombres.RemoveAccents().ToUpper().Trim();
            var email = dto.Email.Trim().ToLowerInvariant();
            var celular = dto.Celular.Trim();

            var p = new Persona
            {
                Tipo = TipoPersona.Cliente,
                Identificacion = identificacion,
                Nombres = nombres,
                Email = email,
                Celular = celular,
                FechaNacimiento = dto.FechaNacimiento,
                CreadoEn = DateTime.UtcNow
            };

            await _repo.AddAsync(p);
            await _uow.CommitAsync();

            return p.Id;
        }

        public async Task<ClienteResponse?> ObtenerPorIdentificacionAsync(string identificacion)
        {
            var p = await _repo.GetByIdentificacionAsync(identificacion);

            return p is null
                ? null
                : new ClienteResponse(
                    p.Id,
                    p.Identificacion,
                    p.Nombres,
                    p.Email,
                    p.Celular,
                    p.FechaNacimiento,
                    p.CreadoEn,
                    p.ActualizadoEn);
        }

        public async Task<IEnumerable<ClienteResponse>> BuscarAsync(string? nombres)
        {
            string? filtro = nombres?.RemoveAccents().ToUpper().Trim();

            var list = await _repo.FindAsync(
                x => x.Tipo == TipoPersona.Cliente &&
                (string.IsNullOrWhiteSpace(filtro) ||
                 x.Nombres.Contains(filtro))
            );

            return list.Select(p => new ClienteResponse(
                p.Id,
                p.Identificacion,
                p.Nombres,
                p.Email,
                p.Celular,
                p.FechaNacimiento,
                p.CreadoEn,
                p.ActualizadoEn
            ));
        }

        public async Task ActualizarAsync(string identificacion, CrearClienteDto dto)
        {
            var p = await _repo.GetByIdentificacionAsync(identificacion)
                ?? throw new BusinessRuleException("Cliente no existe.");

            if (dto.FechaNacimiento.HasValue)
            {
                AgeValidator.ValidarEdadMinima(dto.FechaNacimiento.Value);
                p.FechaNacimiento = dto.FechaNacimiento.Value;
            }

            if (!string.IsNullOrWhiteSpace(dto.Nombres))
                p.Nombres = dto.Nombres.RemoveAccents().ToUpper().Trim();

            if (!string.IsNullOrWhiteSpace(dto.Email))
                p.Email = dto.Email.Trim().ToLowerInvariant();

            if (!string.IsNullOrWhiteSpace(dto.Celular))
                p.Celular = dto.Celular.Trim();

            p.ActualizadoEn = DateTime.UtcNow;

            _repo.Update(p);
            await _uow.CommitAsync();
        }
    }
}
