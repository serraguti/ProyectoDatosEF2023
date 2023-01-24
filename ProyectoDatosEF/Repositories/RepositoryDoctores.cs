using ProyectoDatosEF.Data;
using ProyectoDatosEF.Models;

namespace ProyectoDatosEF.Repositories
{
    public class RepositoryDoctores
    {
        private HospitalContext context;

        public RepositoryDoctores(HospitalContext context)
        {
            this.context = context;
        }

        //CONSULTA PARA MOSTRAR TODOS LOS DOCTORES
        public List<Doctor> GetDoctores()
        {
            var consulta = from datos in this.context.Doctores
                           select datos;
            return consulta.ToList();
        }

        //CONSULTA PARA BUSCAR DOCTORES POR HOSPITAL
        public List<Doctor> GetDoctoresHospital(int idhospital)
        {
            var consulta = from datos in this.context.Doctores
                           where datos.IdHospital == idhospital
                           select datos;
            return consulta.ToList();
        }
    }
}
