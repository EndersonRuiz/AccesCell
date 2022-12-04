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
    public class CD_Proveedor
    {
        //metodo consultar 
        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string sql = "select * from PROVEEDOR";
                    SqlCommand cmd = new SqlCommand(sql, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proveedor()
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                Dpi = dr["Dpi"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Proveedor>();
                }
            }
            return lista;
        }
        //fin metodo de consulta 


        //metodo para registrar
        public int registrar(Proveedor obj, out string Mensaje)
        {
            int idProveedorGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_proveedor_registrar", oconexion);
                    cmd.Parameters.AddWithValue("Dpi", obj.Dpi);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idProveedorGenerado = Convert.ToInt32(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idProveedorGenerado = 0;
                Mensaje = ex.Message;
            }
            return idProveedorGenerado;
        }
        //fin metodo de registro


        //metodo para modificar 
        public bool modificar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool respuesta = false;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_proveedor_modificar", oconexion);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);
                    cmd.Parameters.AddWithValue("Dpi", obj.Dpi);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
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
        public bool eliminar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool Respuesta = false;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_proveedor_eliminar", oconexion);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);
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
