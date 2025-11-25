namespace SmartBook.Application.Dtos.Responses
{
    public class UsuarioResponse
    {
        public uint Id { get; set; }
        public string Identificacion { get; set; } = default!;
        public string Nombres { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Celular { get; set; } = default!;
        public DateTime FechaNacimiento { get; set; }
        public string Rol { get; set; } = default!;
        public bool Activo { get; set; }
        public bool EmailVerificado { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }
    }
}
