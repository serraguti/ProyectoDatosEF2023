using Microsoft.AspNetCore.Mvc;
using ProyectoDatosEF.Models;
using ProyectoDatosEF.Repositories;

namespace ProyectoDatosEF.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        public IActionResult IncrementoSalarial()
        {
            List<Empleado> empleados = this.repo.GetEmpleados();
            List<string> oficios = this.repo.GetOficios();
            ViewData["OFICIOS"] = oficios;
            return View(empleados);
        }

        [HttpPost]
        public IActionResult IncrementoSalarial(string oficio, int incremento)
        {
            this.repo.IncrementarSalarios(oficio, incremento);
            List<Empleado> empleados = this.repo.GetEmpleadosOficio(oficio);
            List<string> oficios = this.repo.GetOficios();
            ViewData["OFICIOS"] = oficios;
            return View(empleados);
        }
    }
}
