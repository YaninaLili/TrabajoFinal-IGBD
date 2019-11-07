using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TrabajoFinal_IGBD.Models;

namespace TrabajoFinal_IGBD.Controllers
{
    public class HabitacionesController : Controller
    {
        private HotelContext _context;
        public HabitacionesController(HotelContext c) {
            _context = c;
        }
        
        public IActionResult Index()
        {
            var lista = _context.Habitaciones.ToList();
            return View(lista);
        }
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Habitacion x)
        {
            if (ModelState.IsValid) {
                _context.Add(x);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(x);
        }
    }
}