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
    public class CD_Compra
    {

        //metodo para obtenerCorrelativo
        public int obtenerCorrelativo() {
            int idCorrelativo = 0;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string sql = "select COUNT(*) + 1 from COMPRA";
                    SqlCommand cmd = new SqlCommand(sql, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    idCorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    idCorrelativo = 0;
                }
            }
            return idCorrelativo;
        }
        //fin metodo obtener correlativo


        //metodo registrar compra
        public bool registrar(Compra obj, DataTable detalleCompra, out string Mensaje) {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_compra_registrar", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.oProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleCompra",detalleCompra);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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
        //fin metodo registrar compra


        //Metodo para buscar por parametro
        public Compra obtenerCompra(string numero) {
            Compra obj = new Compra();
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    oConexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select c.IdCompra,");
                    query.AppendLine("CONCAT(u.PrimerNombre, ' ', u.SegundoNombre, ' ', u.PrimerApellido, ' ', u.SegundoApellido) as NombreCompleto,");
                    query.AppendLine("c.NumeroDocumento,CONVERT(CHAR(10), c.FechaRegistro, 103)[FechaRegistro],");
                    query.AppendLine("c.TipoDocumento,c.MontoTotal,");
                    query.AppendLine("pr.Dpi,pr.RazonSocial");
                    query.AppendLine("from COMPRA c");
                    query.AppendLine("inner join USUARIO u on u.IdUsuario = c.IdUsuario");
                    query.AppendLine("inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor");
                    query.AppendLine("where c.NumeroDocumento = @numero");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@numero",numero);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Compra()
                            {
                                IdCompra = Convert.ToInt32(dr["IdCompra"]),
                                oUsuario = new Usuario() {
                                    PrimerNombre = dr["NombreCompleto"].ToString()
                                },
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                MontoTotal =Convert.ToDecimal(dr["Montototal"].ToString()),
                                oProveedor = new Proveedor() { 
                                    Dpi = dr["Dpi"].ToString(),
                                    RazonSocial = dr["RazonSocial"].ToString()
                                }
                            };
                        }
                    }
                }
            }
            catch
            {
                return obj = new Compra();
            }
            return obj;
        }
        //fin metodo porparametro


        //metodo consultar 
        public List<Detalle_Compra> listarDetalleCompra(int IdCompra)
        {
            List<Detalle_Compra> lista = new List<Detalle_Compra>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.NombreProducto,");
                    query.AppendLine("dc.PrecioCompra,dc.PrecioVenta,dc.Cantidad,dc.SubTotal");
                    query.AppendLine("from PRODUCTO p");
                    query.AppendLine("inner join DETALLE_COMPRA dc on dc.IdProducto = p.IdProducto");
                    query.AppendLine("where dc.IdCompra = @IdCompra");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@IdCompra", IdCompra);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Detalle_Compra()
                            {
                                oProducto = new Producto() { 
                                    NombreProducto = dr["NombreProducto"].ToString()
                                },
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"].ToString())
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Detalle_Compra>();
                }
            }
            return lista;
        }
        //fin metodo de consulta 
    }
}
