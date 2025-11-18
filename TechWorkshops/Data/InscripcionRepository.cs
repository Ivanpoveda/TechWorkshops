using TechWorkshops.Models;
using System.Collections.Generic;

namespace TechWorkshops.Data
{
    public class InscripcionRepository
    {
        private static readonly List<Inscripcion> _inscripciones = new();

        public IEnumerable<Inscripcion> ObtenerInscripciones() => _inscripciones;

        public void Agregar(Inscripcion inscripcion)
        {
            _inscripciones.Add(inscripcion);
        }
    }
}
