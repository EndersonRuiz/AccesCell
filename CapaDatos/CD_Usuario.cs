using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Usuario
    {
        //Inicio metodo de consulta para listar Usuarios
        public List<Usuario> Listar() {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select * from USUARIO";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Dpi = dr["Dpi"].ToString(),
                                PrimerNombre = dr["PrimerNombre"].ToString(),
                                SegundoNombre = dr["SegundoNombre"].ToString(),
                                PrimerApellido = dr["PrimerApellido"].ToString(),
                                SegundoApellido = dr["SegundoApellido"].ToString(),
                                User = dr["Usuario"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            }); 
                        }
                    }
                }
                catch (Exception ex) {
                    lista = new List<Usuario>(); 
                }
            }
            return lista;
        }
        //Fin del metodo Listar


        //Metodo para Listar Todos los Usuarios
        public List<Usuario> ListarUsuario() {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena)) {
                try {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("select a.IdUsuario,a.IdRol,b.Descripcion,a.Dpi,a.PrimerNombre,a.SegundoNombre,a.PrimerApellido,");
                    sql.AppendLine("a.SegundoApellido, a.Usuario,a.Clave,a.Correo,a.Telefono,a.Estado,a.FechaRegistro");
                    sql.AppendLine("from USUARIO a");
                    sql.AppendLine("inner join ROL b on b.IdRol = a.IdRol");
                    SqlCommand cmd = new SqlCommand(sql.ToString(),oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            lista.Add(new Usuario() { 
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                oRol = new Rol() { 
                                    IdRol = Convert.ToInt32(dr["IdRol"]),
                                    Descripcion = dr["Descripcion"].ToString()
                                },
                                Dpi = dr["Dpi"].ToString(),
                                PrimerNombre = dr["PrimerNombre"].ToString(),
                                SegundoNombre = dr["SegundoNombre"].ToString(),
                                PrimerApellido = dr["PrimerApellido"].ToString(),
                                SegundoApellido = dr["SegundoApellido"].ToString(),
                                User = dr["Usuario"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            });
                        }
                    }
                } catch (Exception ex) {
                    lista = new List<Usuario>();
                }
            }
                return lista;  
        }
        //fin el metodo listar Usuarios


        //Metodo para registrar usuarios
        public int registrar(Usuario obj, out string Mensaje) {
            int idUsuarioGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) {
                    SqlCommand cmd = new SqlCommand("sp_Registrar_Usuarios", oconexion);
                    cmd.Parameters.AddWithValue("IdRol",obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Dpi",obj.Dpi);
                    cmd.Parameters.AddWithValue("PrimerNombre", obj.PrimerNombre);
                    cmd.Parameters.AddWithValue("SegundoNombre", obj.SegundoNombre);
                    cmd.Parameters.AddWithValue("PrimerApellido", obj.PrimerApellido);
                    cmd.Parameters.AddWithValue("SegundoApellido", obj.SegundoApellido);
                    cmd.Parameters.AddWithValue("Usuario", obj.User);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("IdEstadoResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idUsuarioGenerado = Convert.ToInt32(cmd.Parameters["IdEstadoResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex) {
                idUsuarioGenerado = 0;
                Mensaje = ex.Message;
            }
            return idUsuarioGenerado;
        }
        //fin del metodo Registrar Usuario


        //Metodo para Modificar Usuario
        public bool editar(Usuario obj, out string Mensaje) {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena)) {
                    SqlCommand cmd = new SqlCommand("sp_Modificar_Usuarios", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Dpi", obj.Dpi);
                    cmd.Parameters.AddWithValue("PrimerNombre", obj.PrimerNombre);
                    cmd.Parameters.AddWithValue("SegundoNombre", obj.SegundoNombre);
                    cmd.Parameters.AddWithValue("PrimerApellido", obj.PrimerApellido);
                    cmd.Parameters.AddWithValue("SegundoApellido", obj.SegundoApellido);
                    cmd.Parameters.AddWithValue("Usuario", obj.User);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex) {
                Mensaje = ex.Message;
                Respuesta = false;
            }
            return Respuesta;
        }
        //Fin del Metodo Modificar Usuario


        //Metodo para Eliminar Usuarios
        public bool eliminar(Usuario obj, out string Mensaje) {
            bool Respusta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena)) {
                    SqlCommand cmd = new  SqlCommand("sp_Eliminar_Usuario", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario",obj.IdUsuario);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    Respusta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex) {
                Mensaje = ex.Message;
                Respusta = false;
            }
            return Respusta;
        }
        //Fin del Metodo eliminar


    }
}
