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
    public class CD_Categoria
    {
        //metodo consultar categoria
        public List<Categoria> listar() {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    String sql = "select * from CATEGORIA";
                    SqlCommand cmd = new SqlCommand(sql,oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            lista.Add(new Categoria() { 
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex) {
                    lista = new List<Categoria>();
                }
            }
            return lista;
        }
        //fin metodo de consulta categoria

        
        //metodo para registrar categoria
        public int registrar(Categoria obj, out string Mensaje)
        {
            int idCategoriaGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) {
                    SqlCommand cmd = new SqlCommand("sp_categoria_registrar", oconexion);
                    cmd.Parameters.AddWithValue("Descripcion",obj.Descripcion);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idCategoriaGenerado = Convert.ToInt32(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex) {
                idCategoriaGenerado = 0;
                Mensaje = ex.Message;
            }
            return idCategoriaGenerado;
        }
        //fin metodo de registro


        //metodo modificar categoria
        public bool modificar(Categoria obj, out string Mensaje) {
            Mensaje = string.Empty;
            bool respuesta = false;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) {
                    SqlCommand cmd = new SqlCommand("sp_categoria_modificar", oconexion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex) {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
        //fin metodo de modificar

        //metodo para eliminar
        public bool eliminar(Categoria obj, out string Mensaje) {
            Mensaje = string.Empty;
            bool Respuesta = false;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) {
                    SqlCommand cmd = new SqlCommand("sp_categoria_eliminar", oconexion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex) {
                Respuesta = false;
                Mensaje = ex.Message;
            }
            return Respuesta;
        }
        //fin metodo de eliminar
    }
}
