using ProyectoDatosEF.Data;
using ProyectoDatosEF.Models;

namespace ProyectoDatosEF.Repositories
{
    public class RepositoryPlantilla
    {
        private HospitalContext context;

        public RepositoryPlantilla(HospitalContext context)
        {
            this.context = context;
        }

        public List<Plantilla> GetPlantilla()
        {
            var consulta = from datos in this.context.Plantillas
                           select datos;
            return consulta.ToList();
        }

        public List<Plantilla> GetPlantillaHospital(int idhospital)
        {
            var consulta = from datos in this.context.Plantillas
                           where datos.IdHospital == idhospital
                           select datos;
            return consulta.ToList();
        }

        public Plantilla FindPlantilla(int id)
        {
            var consulta = from datos in this.context.Plantillas
                           where datos.IdPlantilla == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        public List<Plantilla> GetPlantillaFuncion(string funcion)
        {
            var consulta = from datos in this.context.Plantillas
                           where datos.Funcion == funcion
                           select datos;
            return consulta.ToList();
        }

        public List<string> GetFunciones()
        {
            var consulta = (from datos in this.context.Plantillas
                           select datos.Funcion).Distinct();
            return consulta.ToList();
        }
    }
}
