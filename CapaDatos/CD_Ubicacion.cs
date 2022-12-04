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
    public class CD_Ubicacion
    {
        //metodo consultar 
        public List<Ubicacion> listar()
        {
            List<Ubicacion> lista = new List<Ubicacion>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    String sql = "select * from UBICACION";
                    SqlCommand cmd = new SqlCommand(sql, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Ubicacion()
                            {
                                IdUbicacion = Convert.ToInt32(dr["IdUbicacion"]),
                                NombreEstante = dr["NombreEstante"].ToString(),
                                Seccion = dr["Seccion"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Ubicacion>();
                }
            }
            return lista;
        }
        //fin metodo de consulta 


        //metodo para registrar
        public int registrar(Ubicacion obj, out string Mensaje)
        {
            int idUbicacionGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ubicacion_registrar", oconexion);
                    cmd.Parameters.AddWithValue("NombreEstante", obj.NombreEstante);
                    cmd.Parameters.AddWithValue("Seccion",obj.Seccion);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idUbicacionGenerado = Convert.ToInt32(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idUbicacionGenerado = 0;
                Mensaje = ex.Message;
            }
            return idUbicacionGenerado;
        }
        //fin metodo de registro


        //metodo para modificar 
        public bool modificar(Ubicacion obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool respuesta = false;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ubicacion_modificar", oconexion);
                    cmd.Parameters.AddWithValue("IdUbicacion", obj.IdUbicacion);
                    cmd.Parameters.AddWithValue("NombreEstante", obj.NombreEstante);
                    cmd.Parameters.AddWithValue("Seccion",obj.Seccion);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
        //fin metodo de modificar

        //metodo para eliminar
        public bool eliminar(Ubicacion obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool Respuesta = false;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ubicacion_eliminar", oconexion);
                    cmd.Parameters.AddWithValue("IdUbicacion", obj.IdUbicacion);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }
            return Respuesta;
        }
        //fin metodo de eliminar
    }
}
