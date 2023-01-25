using ProyectoDatosEF.Data;
using ProyectoDatosEF.Models;

namespace ProyectoDatosEF.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        //METODO PARA INSERTAR UN NUEVO HOSPITAL
        public void InsertHospital(int idhospital)
        {
            //CREAMOS UN NUEVO OBJETO HOSPITAL
            Hospital hospital = new Hospital();
            hospital.IdHospital = idhospital;
            hospital.Nombre = "NUEVO";
            hospital.Telefono = "NUEVO";
            hospital.Camas = 99;
            hospital.Direccion = "Calle Nueva";
            //INSERTAMOS EL HOSPITAL EN EL CONTEXT Y SU DbSet
            this.context.Hospitales.Add(hospital);
            //GUARDAMOS LOS CAMBIOS EN LA BBDD
            this.context.SaveChanges();
        }

        //METODO PARA ELIMINAR UN HOSPITAL
        public void DeleteHospital(int idhospital)
        {
            //DEBEMOS BUSCAR EL HOSPITAL A ELIMINAR
            Hospital hospital = this.FindHospital(idhospital);
            //ELIMINAMOS DEL CONTEXT Y DbSet EL OBJETO
            this.context.Hospitales.Remove(hospital);
            //GUARDAMOS LOS CAMBIOS EN LA BBDD
            this.context.SaveChanges();
        }

        //METODO PARA MODIFICAR UN HOSPITAL
        public void UpdateHospital(int idhospital)
        {
            //DEBEMOS BUSCAR EL HOSPITAL A MODIFICAR
            Hospital hospital = this.FindHospital(idhospital);
            //MODIFICAMOS SUS PROPIEDADES (NUNCA SE DEBE MODIFICAR EL ID DE UN DATO)
            hospital.Direccion = "Calle Updated";
            hospital.Nombre = "UPDATED";
            hospital.Telefono = "555 18 19";
            hospital.Camas = 14;
            //EN UPDATE SIMPLEMENTE GUARDAMOS LOS DATOS EN BBDD
            this.context.SaveChanges();
        }

        //CREAMOS NUESTROS METODOS PARA RECUPERAR DATOS
        public List<Hospital> GetHospitales()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return consulta.ToList();
        }

        //METODO PARA DEVOLVER UN SOLO HOSPITAL
        public Hospital FindHospital(int id)
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.IdHospital == id
                           select datos;
            //COMO SOLAMENTE DEVUELVE UN HOSPITAL PODEMOS
            //UTILIZAR EL METODO .First() O EL METODO .FirstOrDefault()
            return consulta.FirstOrDefault();
        }
    }
}
