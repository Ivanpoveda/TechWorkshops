using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inscripciones.Models
{
    public class Inscripcion : IValidatableObject
    {
        public int Id { get; set; } // Opcional para identificar los registros en la memoria

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MinLength(2, ErrorMessage = "El nomnre debe tener al menos 2 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        [MinLength(2, ErrorMessage = "Los apellidos deben tener al menos 2 caracteres.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo electronico valido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [RegularExpression(@"^\d{8,}$", ErrorMessage = "El teléfono debe contener sólo dígitos y al menos 8 números.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Seleccione un taller.")]
        public string Taller { get; set; }  // C#, Pyton, Web, Base de datos, Otro

        [Required(ErrorMessage = "Seleccione el nivel de experiencia.")]
        public string NivelExperiencia { get; set; } // Principiante, Intermedio, Avanzado

        [Required(ErrorMessage = "La fecha del taller es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime? FechaTaller { get; set; }

        [Display(Name = "Acepta terminos y condiciones")]
        public bool AceptaTerminos { get; set; }

        // Validacion a nivel modelo (fecha no pasada, acepta terminos)
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FechaTaller.HasValue)
            {
                // Compara solo fecha (sin horas)
                var fechaHoy = DateTime.Today;
                if (FechaTaller.Value.Date < fechaHoy)
                {
                    yield return new ValidationResult(
                        "La fecha del taller no puede ser una fecha pasada.",
                        new[] { nameof(FechaTaller) });
                }
            }

            if (!AceptaTerminos)
            {
                yield return new ValidationResult(
                    "Debe aceptar los términos y condiciones para completar la inscripción",
                    new[] { nameof(AceptaTerminos) });
            }
        }
    }
} 