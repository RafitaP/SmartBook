using System.Collections.Generic;
using System.Text;

namespace SmartBook.Domain.Helpers
{
    public static class StringExtensions
    {
        public static string RemoveAccents(this string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            var acentos = new Dictionary<char, char>
            {
                { 'á', 'a' }, { 'é', 'e' }, { 'í', 'i' }, { 'ó', 'o' }, { 'ú', 'u' },
                { 'Á', 'A' }, { 'É', 'E' }, { 'Í', 'I' }, { 'Ó', 'O' }, { 'Ú', 'U' },
                { 'ñ', 'n' }, { 'Ñ', 'N' }   // EXTRA: necesario para nombres como "Peñalosa"
            };

            var sb = new StringBuilder();
            foreach (char c in texto)
            {
                if (acentos.ContainsKey(c))
                    sb.Append(acentos[c]);
                else
                    sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
