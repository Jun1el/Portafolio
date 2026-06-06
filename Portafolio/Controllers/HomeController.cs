using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryProjects _repositoryProjects;
        private readonly IServicioEmail _servicioEmail;

        public HomeController(ILogger<HomeController> logger, IRepositoryProjects repositoryProjects, IServicioEmail servicioEmail)
        {
            _logger = logger;
            _repositoryProjects = repositoryProjects;
            _servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            var proyectos = _repositoryProjects.ObtenerProyecto().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }

        public IActionResult Proyectos()
        {
            var proyectos = _repositoryProjects.ObtenerProyecto();
            return View(proyectos);
        }

        public IActionResult Contacto()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            if (!ModelState.IsValid)
                return View(contactoViewModel);

            try
            {
                await _servicioEmail.Enviar(contactoViewModel);
                return RedirectToAction("Gracias");
            }
            catch
            {
                ModelState.AddModelError("", "Ocurrió un error al enviar el mensaje. Intenta nuevamente.");
                return View(contactoViewModel);
            }
        }


        public IActionResult Gracias()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
