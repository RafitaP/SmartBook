namespace SmartBook.Application.Dtos.Requests
{
    public class CrearUsuarioDto
    {
        public string Identificacion { get; set; } = default!;
        public string Nombres { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Celular { get; set; } = default!;
        public DateTime FechaNacimiento { get; set; }
        public string Rol { get; set; } = default!; 
        public string Password { get; set; } = default!;
    }
}
