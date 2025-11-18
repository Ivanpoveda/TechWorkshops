using System.ComponentModel.DataAnnotations;

namespace TechWorkshops.Models
{
    public enum Categoria
    {
        Seleccione = 0,
        Programacion,
        Redes,
        BasesDeDatos,
        IA,
        Otro
    }

    public class Libro
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Autor { get; set; } = string.Empty;

        [Required(ErrorMessage = "Seleccione una categoría")]
        public Categoria Categoria { get; set; } = Categoria.Seleccione;

        [Required]
        [Range(1900, 9999)]
        public int AnioPublicacion { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int NumeroPaginas { get; set; }

        [Required]
        [RegularExpression(@"^LIB-\d{3}$")]
        public string CodigoInterno { get; set; } = string.Empty;

        [Required]
        public bool Disponible { get; set; }
    }
}
