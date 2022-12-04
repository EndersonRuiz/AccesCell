using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        private CD_Categoria objCate = new CD_Categoria();

        public List<Categoria> listar() {
            return objCate.listar();
        }

        public int registrar(Categoria obj, out string Mensaje) {
            Mensaje = string.Empty;
            if (obj.Descripcion == "") {
                Mensaje = "El campo de Descripion es Vacio";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else {
                return objCate.registrar(obj,out Mensaje);
            }
        }

        public bool modificar(Categoria obj, out string Mensaje) {
            Mensaje = string.Empty;
            if (obj.Descripcion == "") {
                Mensaje = "El campo de Descripcion es Vacio";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else {
                return objCate.modificar(obj,out Mensaje);
            }
        }

        public bool eliminar(Categoria obj, out string Mensaje) {
            return objCate.eliminar(obj,out Mensaje);
        }
    }
}
