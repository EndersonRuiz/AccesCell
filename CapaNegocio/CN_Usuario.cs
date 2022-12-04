using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();

        public List<Usuario> Listar() {
            return objcd_usuario.Listar();
        }

        public List<Usuario> ListarUsuario() {
            return objcd_usuario.ListarUsuario();
        }

        public int registrar(Usuario obj, out string Mensaje) {
            Mensaje = string.Empty;

            if (obj.Dpi == "") {
                Mensaje = "Es necesario el numero de documento del Usuario\n";
            }
            if (obj.PrimerNombre == "") {
                Mensaje = "Es necesario el primer nombre del Usuario\n";
            }
            if (obj.SegundoNombre == "") {
                Mensaje = "Es necesario el segundo nombre del Usuario\n";
            }
            if (obj.PrimerApellido == "") {
                Mensaje = "Es necesario el primer apellido del Usuario\n";
            }
            if (obj.SegundoApellido == "") {
                Mensaje = "Es necesario el segundo nombre del Usuario\n";
            }
            if (obj.Correo == "") {
                Mensaje = "Es necesario el correo del Usuario\n";
            }
            if (obj.Telefono == "") {
                Mensaje = "Es necesario el nemero de telefono del Usuario\n";
            }
            if (obj.User == "")
            {
                Mensaje = "Es necesario el Usuario del Usuario\n";
            }
            if (obj.Clave == ""){
                Mensaje = "Es necesario la clave del Usuario\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else {
                return objcd_usuario.registrar(obj, out Mensaje);
            }
        }

        public bool editar(Usuario obj, out string Mensaje) {
            Mensaje = string.Empty;

            if (obj.Dpi == "")
            {
                Mensaje = "Es necesario el numero de documento del Usuario\n";
            }
            if (obj.PrimerNombre == "")
            {
                Mensaje = "Es necesario el primer nombre del Usuario\n";
            }
            if (obj.SegundoNombre == "")
            {
                Mensaje = "Es necesario el segundo nombre del Usuario\n";
            }
            if (obj.PrimerApellido == "")
            {
                Mensaje = "Es necesario el primer apellido del Usuario\n";
            }
            if (obj.SegundoApellido == "")
            {
                Mensaje = "Es necesario el segundo nombre del Usuario\n";
            }
            if (obj.Correo == "")
            {
                Mensaje = "Es necesario el correo del Usuario\n";
            }
            if (obj.Telefono == "")
            {
                Mensaje = "Es necesario el nemero de telefono del Usuario\n";
            }
            if (obj.User == "")
            {
                Mensaje = "Es necesario el Usuario del Usuario\n";
            }
            if (obj.Clave == "")
            {
                Mensaje = "Es necesario la clave del Usuario\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.editar(obj, out Mensaje);
            }
        }

        public bool eliminar(Usuario obj, out string Mensaje) {
           
            return objcd_usuario.eliminar(obj, out Mensaje);
        }
    }
}
