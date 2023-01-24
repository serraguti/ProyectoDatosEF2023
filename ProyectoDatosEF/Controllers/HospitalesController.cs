using Microsoft.AspNetCore.Mvc;
using ProyectoDatosEF.Models;
using ProyectoDatosEF.Repositories;

namespace ProyectoDatosEF.Controllers
{
    public class HospitalesController : Controller
    {
        private RepositoryHospital repo;

        public HospitalesController(RepositoryHospital repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            //DEVOLVEMOS TODOS LOS HOSPITALES
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }

        public IActionResult Details(int id)
        {
            Hospital hospital = this.repo.FindHospital(id);
            return View(hospital);
        }
    }
}
