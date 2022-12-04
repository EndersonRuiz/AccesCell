using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Compra
    {
        private CD_Compra obj_compra = new CD_Compra();

        public int obtenerCorrelativo()
        {
            return obj_compra.obtenerCorrelativo();
        }

        public bool registrar(Compra obj, DataTable detalleCompra, out string Mensaje)
        {
            Mensaje = String.Empty;
            return obj_compra.registrar(obj, detalleCompra, out Mensaje);
        }

        public Compra obtenerCompra(string numero) {

            Compra oCompra = obj_compra.obtenerCompra(numero);
            if (oCompra.IdCompra != 0) {
                List<Detalle_Compra> oDetalle_Compra = obj_compra.listarDetalleCompra(oCompra.IdCompra);

                oCompra.oDetalleCompra = oDetalle_Compra;
            }
            return oCompra;
        }
    }
}
