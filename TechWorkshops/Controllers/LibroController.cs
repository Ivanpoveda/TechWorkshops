using Microsoft.AspNetCore.Mvc;
using TechWorkshops.Models;
using TechWorkshops.Data;

namespace TechWorkshops.Controllers
{
    public class LibroController : Controller
    {
        private readonly LibroRepository _repo = new();

        public IActionResult Index()
        {
            return View(_repo.ObtenerLibros());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View(new Libro { AnioPublicacion = DateTime.Now.Year });
        }

        [HttpPost]
        public IActionResult Crear(Libro libro)
        {
            if (libro.AnioPublicacion > DateTime.Now.Year)
                ModelState.AddModelError("AnioPublicacion", "El año no puede ser futuro");

            if (!ModelState.IsValid)
                return View(libro);

            var result = _repo.AgregarLibro(libro);

            if (!result.ok)
            {
                ModelState.AddModelError("CodigoInterno", result.error);
                return View(libro);
            }

            TempData["msg"] = "Libro registrado correctamente";
            return RedirectToAction("Index");
        }
    }
}
