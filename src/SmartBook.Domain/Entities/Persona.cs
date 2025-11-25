using SmartBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Entities
{
    public class Persona : BaseAuditable
    {
        public uint Id { get; set; }
        public TipoPersona Tipo { get; set; }
        public string Identificacion { get; set; } = default!;
        public string Nombres { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? Celular { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public RolUsuario? Rol { get; set; }
        public string? PasswordHash { get; set; }
        public bool Activo { get; set; } = true;
        public bool EmailVerificado { get; set; } = false;
    }
}
