using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objCate = new CD_Cliente();

        public List<Cliente> listar()
        {
            return objCate.listar();
        }

        public int registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Dpi == "")
            {
                Mensaje = "El campo de DPI esta Vacio";
            }
            if (obj.NombreCompleto == "")
            {
                Mensaje = "El campo de Nombre Cliente esta vacio";
            }
            if (obj.Direccion == "")
            {
                Mensaje = "El campo Direccion esta vacio";
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

        public bool modificar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Dpi == "")
            {
                Mensaje = "El campo de DPI esta Vacio";
            }
            if (obj.NombreCompleto == "")
            {
                Mensaje = "El campo de Nombre Cliente esta vacio";
            }
            if (obj.Direccion == "")
            {
                Mensaje = "El campo Direccion esta vacio";
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

        public bool eliminar(Cliente obj, out string Mensaje)
        {
            return objCate.eliminar(obj, out Mensaje);
        }
    }
}
