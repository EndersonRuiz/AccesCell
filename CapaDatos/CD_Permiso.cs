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
    public class CD_Permiso
    {
        public List<Permiso> Listar(int IdUsuario)
        {
            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select p.IdRol,p.NombreMenu from PERMISO p inner join ROL r on r.IdRol = p.IdRol inner join USUARIO u on u.IdRol = r.IdRol where u.IdUsuario = @IdUsuario";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"])},
                                NombreMenu = dr["NombreMenu"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();
                }
            }
            return lista;
        }
    }
}
