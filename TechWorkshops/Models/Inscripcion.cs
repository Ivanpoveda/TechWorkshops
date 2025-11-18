using System.ComponentModel.DataAnnotations;

namespace TechWorkshops.Models
{
    public enum Taller
    {
        Seleccione = 0,
        CSharp,
        Python,
        Web,
        BasesDeDatos,
        Otro
    }

    public enum Nivel
    {
        Seleccione = 0,
        Principiante,
        Intermedio,
        Avanzado
    }

    public class Inscripcion
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Apellidos { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\d{8,}$")]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        public Taller TallerSeleccionado { get; set; }

        [Required]
        public Nivel NivelExperiencia { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaTaller { get; set; }

        [Range(typeof(bool), "true", "true",
            ErrorMessage = "Debe aceptar los términos para continuar")]
        public bool AceptaTerminos { get; set; }
    }
}