using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class N_Choferes
    {
        D_Choferes objDato1 = new D_Choferes();
        D_Choferes objDato2 = new D_Choferes();
        D_Choferes objDato3 = new D_Choferes();
        public List<E_Choferes> ListarChoferes(string buscar)
        {
            return objDato1.ListarChoferes(buscar);

        }
        public List<E_Choferes> ListarAutobuses(string buscar)
        {
            return objDato2.ListarAutobuses(buscar);

        }
        public List<E_Choferes> ListarRuta(string buscar)
        {
            return objDato3.ListarRuta(buscar);

        }
        public void InsertandoChoferes(E_Choferes Choferes)
        {
            objDato1.InsertarChoferes(Choferes);

        }
        public void InsertandoAutobuses(E_Choferes Autobus)
        {
            objDato2.InsertarAutobuses(Autobus);

        }
        public void InsertandoRuta(E_Choferes Ruta)
        {
            objDato3.InsertarRutas(Ruta);

        }
        public void EditandoChoferes(E_Choferes Choferes)
        {
            objDato1.EditarChoferes(Choferes);

        }
        public void EditandoAutobuses(E_Choferes Choferes)
        {
            objDato1.EditarAutobuses(Choferes);

        }
        public void EditandoRutas(E_Choferes Choferes)
        {
            objDato1.EditarRutas(Choferes);

        }
        public void EliminandoChoferes(E_Choferes Choferes)
        {
            objDato1.EliminarChoferes(Choferes);
        }
        public void EliminandoAutobuses(E_Choferes Choferes)
        {
            objDato1.EliminarAutobuses(Choferes);
        }
        public void EliminandoRutas(E_Choferes Choferes)
        {
            objDato1.EliminarRutas(Choferes);
        }
       
    }
}
