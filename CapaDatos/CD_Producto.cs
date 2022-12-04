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
    public class CD_Producto
    {
        //metodo consultar 
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine(" select a.IdProducto,a.IdCategoria,b.Descripcion,a.IdUbicacion,c.NombreEstante,c.Seccion,a.CodigoBarra,");
                    sql.AppendLine("a.NombreProducto,a.Stock,a.PrecioCompra,a.PrecioVenta,a.Estado,a.Descripcion as DescripcionProducto,a.FechaRegistro");
                    sql.AppendLine("from PRODUCTO a");
                    sql.AppendLine("inner join CATEGORIA b on b.IdCategoria = a.IdCategoria");
                    sql.AppendLine("inner join UBICACION c on c.IdUbicacion = a.IdUbicacion");
                    SqlCommand cmd = new SqlCommand(sql.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                oCategoria = new Categoria()
                                {
                                    IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                    Descripcion = dr["Descripcion"].ToString()
                                },
                                oUbicacion = new Ubicacion()
                                {
                                    IdUbicacion = Convert.ToInt32(dr["IdUbicacion"]),
                                    NombreEstante = dr["NombreEstante"].ToString(),
                                    Seccion = dr["Seccion"].ToString()
                                },
                                CodigoBarra = dr["CodigoBarra"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Stock = Convert.ToInt32(dr["Stock"]),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                Descripcion = dr["DescripcionProducto"].ToString(),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            }); 
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Producto>();
                }
            }
            return lista;
        }
        //fin metodo de consulta 


        //metodo para registrar
        public int registrar(Producto obj, out string Mensaje)
        {
            int idProductoGenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_producto_registrar", oconexion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("IdUbicacion", obj.oUbicacion.IdUbicacion);
                    cmd.Parameters.AddWithValue("CodigoBarra", obj.CodigoBarra);
                    cmd.Parameters.AddWithValue("NombreProducto", obj.NombreProducto);
                    cmd.Parameters.AddWithValue("Stock",obj.Stock);
                    cmd.Parameters.AddWithValue("PrecioCompra",obj.PrecioCompra);
                    cmd.Parameters.AddWithValue("PrecioVenta", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("Estado",obj.Estado);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idProductoGenerado = Convert.ToInt32(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idProductoGenerado = 0;
                Mensaje = ex.Message;
            }
            return idProductoGenerado;
        }
        //fin metodo de registro


        //metodo para modificar 
        public bool modificar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool respuesta = false;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_producto_modificar", oconexion);
                    cmd.Parameters.AddWithValue("IdProducto",obj.IdProducto);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("IdUbicacion", obj.oUbicacion.IdUbicacion);
                    cmd.Parameters.AddWithValue("CodigoBarra", obj.CodigoBarra);
                    cmd.Parameters.AddWithValue("NombreProducto", obj.NombreProducto);
                    cmd.Parameters.AddWithValue("Stock", obj.Stock);
                    cmd.Parameters.AddWithValue("PrecioCompra", obj.PrecioCompra);
                    cmd.Parameters.AddWithValue("PrecioVenta", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
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
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
        //fin metodo de modificar

        //metodo para eliminar
        public bool eliminar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool Respuesta = false;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_producto_eliminar", oconexion);
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);
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
