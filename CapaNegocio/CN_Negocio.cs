using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Negocio
    {
        private CD_Negocio obj_Negocio = new CD_Negocio();

        public Negocio obtenerDatos()
        {
            return obj_Negocio.obetenerDatos();
        }

        public byte[] obtenerLogo(out bool obtenido)
        {
            return obj_Negocio.obtnerLogo(out obtenido);
        }

        public bool registrar(Negocio obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje = "Es necesario el Nombre del Negocio\n";
            }
            if (obj.Ruc == "")
            {
                Mensaje = "Es necesario el Ruc del Negocio\n";
            }
            if (obj.Direccion == "")
            {
                Mensaje = "Es necesario la Direccion del Negocio\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return obj_Negocio.guardar(obj, out Mensaje);
            }
        }

        public bool ActualizarLogo(byte[] imagen, out string Mensaje)
        {
            return obj_Negocio.ActualizarLogo(imagen, out Mensaje);
        }
    }
}
