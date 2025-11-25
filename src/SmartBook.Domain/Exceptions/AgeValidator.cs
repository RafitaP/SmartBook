using System;
using SmartBook.Domain.Exceptions;

namespace SmartBook.Domain.Helpers
{
    public static class AgeValidator
    {
        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            var hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;

            if (fechaNacimiento > hoy.AddYears(-edad))
                edad--;

            return edad;
        }

        public static void ValidarEdadMinima(DateTime fechaNacimiento, int edadMinima = 14)
        {
            int edad = CalcularEdad(fechaNacimiento);

            if (edad < edadMinima)
                throw new BusinessRuleException(
                    $"El cliente debe tener mínimo {edadMinima} años de edad."
                );
        }
    }
}
