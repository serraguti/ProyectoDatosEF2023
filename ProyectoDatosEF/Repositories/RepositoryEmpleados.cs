using ProyectoDatosEF.Data;
using ProyectoDatosEF.Models;

namespace ProyectoDatosEF.Repositories
{
    public class RepositoryEmpleados
    {
        private HospitalContext context;
        public RepositoryEmpleados(HospitalContext context)
        {
            this.context = context;
        }

        public List<Empleado> GetEmpleados()
        {
            var consulta = from datos in this.context.Empleados
                           select datos;
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleadosOficio(string oficio)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.Oficio == oficio
                           select datos;
            return consulta.ToList();
        }

        public List<string> GetOficios()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return consulta.ToList();
        }

        public void IncrementarSalarios(string oficio, int incremento)
        {
            List<Empleado> empleados = this.GetEmpleadosOficio(oficio);
            foreach (Empleado empleado in empleados)
            {
                empleado.Salario = empleado.Salario + incremento;
            }
            this.context.SaveChanges();
        }
    }
}
