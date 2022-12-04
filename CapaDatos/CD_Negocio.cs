using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Negocio
    {
        //metodo listar
        public Negocio obetenerDatos()
        {
            Negocio obj = new Negocio();
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    oConexion.Open();

                    string query = "select * from NEGOCIO where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Negocio()
                            {
                                IdNegocio = Convert.ToInt32(dr["IdNegocio"]),
                                Nombre = dr["Nombre"].ToString(),
                                Ruc = dr["Ruc"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                            };
                        }
                    }
                }
            }
            catch
            {
                return obj = new Negocio();
            }
            return obj;
        }
        //fin metodo listar

        //metodo guardar
        public bool guardar(Negocio obj, out string mensaje)
        {
            mensaje = string.Empty;
            bool Respuesta = true;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    oConexion.Open();
                    StringBuilder cadena = new StringBuilder();
                    cadena.AppendLine("update NEGOCIO set Nombre = @Nombre,Ruc = @Ruc,");
                    cadena.AppendLine("Direccion=@Direccion");
                    cadena.AppendLine("where IdNegocio = 1");

                    SqlCommand cmd = new SqlCommand(cadena.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Ruc", obj.Ruc);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo guardar los datos";
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
            return Respuesta;
        }
        //fin metodo guardar

        //metodo obtener imagen
        public byte[] obtnerLogo(out bool obtenido)
        {
            obtenido = true;
            byte[] LogoBytes = new byte[0];
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    oConexion.Open();

                    string query = "select Logo from NEGOCIO where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LogoBytes = (byte[])dr["Logo"];
                        }
                    }
                }
            }
            catch
            {
                obtenido = false;
                LogoBytes = new byte[0];
            }
            return LogoBytes;
        }
        //fin metodo lista imagen

        //modificar logo
        public bool ActualizarLogo(byte[] imagen, out string mensaje)
        {
            mensaje = string.Empty;
            bool Respuesta = true;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    oConexion.Open();
                    StringBuilder cadena = new StringBuilder();
                    cadena.AppendLine("update NEGOCIO set Logo = @Logo");
                    cadena.AppendLine("where IdNegocio = 1");

                    SqlCommand cmd = new SqlCommand(cadena.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@Logo", imagen);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo Actualizar el logo";
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
            return Respuesta;
        }
        //fin metodo logo
    }
}
