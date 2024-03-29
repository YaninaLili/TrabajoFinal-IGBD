using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrabajoFinal_IGBD.Models;
namespace TrabajoFinal_IGBD.Controllers
{
    public class CuentaController : Controller
    {
        
        private HotelContext _context;
        private SignInManager<IdentityUser> _sim;
        private UserManager<IdentityUser> _um;
        private RoleManager<IdentityRole> _rm;

        public CuentaController(
            HotelContext c,  
            SignInManager<IdentityUser> s,
            UserManager<IdentityUser> um,
            RoleManager<IdentityRole> rm) {

            _context = c;
            _sim = s;
            _um = um;
            _rm = rm;
        }

        public IActionResult AsociarRol(){
            ViewBag.Usuarios = _um.Users.ToList();
            ViewBag.Roles = _rm.Roles.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AsociarRol(string usuario,string rol){
            var user = _um.FindByIdAsync(usuario).Result;

            var resultado = _um.AddToRoleAsync(user,rol).Result;

            return RedirectToAction("index","home");
        }

        public IActionResult CrearRol(){
            return View();
        }

        [HttpPost]
        public IActionResult CrearRol(string nombre){
            var rol = new IdentityRole();
            rol.Name = nombre;

            var resultado = _rm.CreateAsync(rol).Result;
            
            return RedirectToAction("index","home");
        }

        public IActionResult Crear() {
            return View();
        }

        public IActionResult AccesoDenegado(){
            return View();
        }

        [HttpPost]
        public IActionResult Crear(CrearCuentaViewModel model) {
            if (ModelState.IsValid) {
                // Guardar datos del modelo en la tabla usuarios
                var usuario = new IdentityUser();
                usuario.UserName = model.Correo;
                usuario.Email = model.Correo;

                IdentityResult resultado = _um.CreateAsync(usuario, model.Password1).Result;
                if (resultado.Succeeded) {
                    return RedirectToAction("index", "home");
                }
                else {
                    foreach (var item in resultado.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }                
            }

            return View(model);
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model) {

            if (ModelState.IsValid) {

             
                var resultado = _sim.PasswordSignInAsync(model.Correo, model.Password, true, false).Result;

                if (resultado.Succeeded) {

                    return RedirectToAction("index", "home");
                }
                else {
                    
                    ModelState.AddModelError("", "Datos incorrectos");
                }
            }        

            return View(model);
        }

        public IActionResult Logout() {
            _sim.SignOutAsync();

            return RedirectToAction("index", "home");
        }

    }
}