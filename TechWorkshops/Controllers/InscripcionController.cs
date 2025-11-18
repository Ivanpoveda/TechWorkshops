using Microsoft.AspNetCore.Mvc;
using TechWorkshops.Data;
using TechWorkshops.Models;

namespace TechWorkshops.Controllers
{
    public class InscripcionController : Controller
    {
        private readonly InscripcionRepository _repo = new();

        public IActionResult Index()
        {
            return View(_repo.ObtenerInscripciones());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View(new Inscripcion { FechaTaller = DateTime.Today });
        }

        [HttpPost]
        public IActionResult Crear(Inscripcion inscripcion)
        {
            if (inscripcion.FechaTaller < DateTime.Today)
                ModelState.AddModelError("FechaTaller", "La fecha no puede ser pasada");

            if (!ModelState.IsValid)
                return View(inscripcion);

            _repo.Agregar(inscripcion);
            TempData["msg"] = "Inscripción realizada correctamente";
            return RedirectToAction("Index");
        }
    }
}