using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor objCate = new CD_Proveedor();

        public List<Proveedor> listar()
        {
            return objCate.listar();
        }

        public int registrar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Dpi == "")
            {
                Mensaje = "El campo de DPI esta Vacio";
            }
            if (obj.RazonSocial == "")
            {
                Mensaje = "El campo de Razon Social esta vacio";
            }
            if (obj.Telefono == "")
            {
                Mensaje = "El campo Telefono esta vacio";
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

        public bool modificar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Dpi == "")
            {
                Mensaje = "El campo de DPI esta Vacio";
            }
            if (obj.RazonSocial == "")
            {
                Mensaje = "El campo de Razon Social esta vacio";
            }
            if (obj.Telefono == "")
            {
                Mensaje = "El campo Telefono esta vacio";
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

        public bool eliminar(Proveedor obj, out string Mensaje)
        {
            return objCate.eliminar(obj, out Mensaje);
        }
    }
}
