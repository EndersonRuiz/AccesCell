using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Ubicacion
    {
        private CD_Ubicacion objCate = new CD_Ubicacion();

        public List<Ubicacion> listar()
        {
            return objCate.listar();
        }

        public int registrar(Ubicacion obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreEstante == "")
            {
                Mensaje = "El campo de Estante esta Vacio";
            }
            if (obj.Seccion == "") {
                Mensaje = "El campo de Seccion esta vacio";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCate.registrar(obj, out Mensaje);
            }
        }

        public bool modificar(Ubicacion obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreEstante == "")
            {
                Mensaje = "El campo de Estante esta Vacio";
            }
            if (obj.Seccion == "") {
                Mensaje = "el campo Seccion esta vacio";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCate.modificar(obj, out Mensaje);
            }
        }

        public bool eliminar(Ubicacion obj, out string Mensaje)
        {
            return objCate.eliminar(obj, out Mensaje);
        }
    }
}
