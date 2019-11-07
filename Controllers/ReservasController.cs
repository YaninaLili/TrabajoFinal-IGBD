using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TrabajoFinal_IGBD.Models;

namespace TrabajoFinal_IGBD.Controllers
{
    public class ReservasController : Controller
    {
        private HotelContext _context;
        public ReservasController(HotelContext c) {
            _context = c;
        }

        public IActionResult Index()
        {
            var lista = _context.Reservas.ToList();
            return View(lista);
        }
        
        public IActionResult Registro()
        {
            ViewBag.Habitaciones = _context.Habitaciones.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Reserva x)
        {
            if (ModelState.IsValid) {
                _context.Add(x);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Habitaciones = _context.Habitaciones.ToList();

            return View(x);
        }
    }
}