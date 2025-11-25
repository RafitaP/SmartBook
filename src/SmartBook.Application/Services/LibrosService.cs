using SmartBook.Application.Dtos.Requests;
using SmartBook.Application.Dtos.Responses;
using SmartBook.Application.Interfaces;
using SmartBook.Domain.Entities;
using SmartBook.Domain.Exceptions;
using SmartBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBook.Application.Services
{
    public class LibrosService : ILibrosService
    {
        private readonly ILibroRepository _repo;
        private readonly IUnitOfWork _uow;

        public LibrosService(ILibroRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<uint> CrearAsync(CrearLibroDto dto)
        {
            if (await _repo.ExistsAsync(dto.Nombre, dto.Nivel, dto.Tipo, dto.Editorial, dto.Edicion))
                throw new BusinessRuleException("Ya existe un libro con los mismos atributos");

            var l = new Libro {
                Nombre = dto.Nombre,
                Nivel = dto.Nivel,
                Tipo = dto.Tipo,
                Editorial = dto.Editorial,
                Edicion = dto.Edicion,
                CreadoEn = DateTime.UtcNow
            };
            await _repo.AddAsync(l);
            await _uow.CommitAsync();
            return l.Id;
        }

        public async Task<LibroResponse?> ObtenerAsync(uint id)
        {
            var l = await _repo.GetByIdAsync(id);
            return l is null ? null : new LibroResponse(l.Id, l.Nombre, l.Nivel, l.Tipo, l.Editorial, l.Edicion);
        }

        public async Task<IEnumerable<LibroResponse>> BuscarAsync(string? nombre, string? nivel, string? tipo, string? editorial, string? edicion)
        {
            var list = await _repo.SearchAsync(nombre, nivel, tipo, editorial, edicion);
            return list.Select(l => new LibroResponse(l.Id, l.Nombre, l.Nivel, l.Tipo, l.Editorial, l.Edicion));
        }

        public async Task ActualizarAsync(uint id, CrearLibroDto dto)
        {
            var l = await _repo.GetByIdAsync(id) ?? throw new BusinessRuleException("Libro no existe");
            l.Nombre = dto.Nombre; l.Nivel = dto.Nivel; l.Tipo = dto.Tipo; l.Editorial = dto.Editorial; l.Edicion = dto.Edicion;
            l.ActualizadoEn = DateTime.UtcNow;
            _repo.Update(l);
            await _uow.CommitAsync();
        }
    }
}