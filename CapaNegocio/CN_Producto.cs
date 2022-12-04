using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Producto
    {

        private CD_Producto objCate = new CD_Producto();

        public List<Producto> listar()
        {
            return objCate.listar();
        }

        public int registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.CodigoBarra == "")
            {
                Mensaje = "El campo de CodigoBarra esta Vacio";
            }
            if (obj.NombreProducto == "")
            {
                Mensaje = "El campo de NombreProducto esta vacio";
            }
            if (obj.Descripcion == "")
            {
                Mensaje = "El campo Descripcion esta vacio";
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

        public bool modificar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.CodigoBarra == "")
            {
                Mensaje = "El campo de CodigoBarra esta Vacio";
            }
            if (obj.NombreProducto == "")
            {
                Mensaje = "El campo de NombreProducto esta vacio";
            }
            if (obj.Descripcion == "")
            {
                Mensaje = "El campo Descripcion esta vacio";
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

        public bool eliminar(Producto obj, out string Mensaje)
        {
            return objCate.eliminar(obj, out Mensaje);
        }

    }
}
