using TechWorkshops.Models;
using System.Collections.Generic;
using System.Linq;

namespace TechWorkshops.Data
{
    public class LibroRepository
    {
        private static readonly List<Libro> _libros = new();

        public IEnumerable<Libro> ObtenerLibros() => _libros;

        public (bool ok, string? error) AgregarLibro(Libro libro)
        {
            if (_libros.Any(x => x.CodigoInterno == libro.CodigoInterno))
                return (false, "El código interno ya existe");

            _libros.Add(libro);
            return (true, null);
        }
    }
}