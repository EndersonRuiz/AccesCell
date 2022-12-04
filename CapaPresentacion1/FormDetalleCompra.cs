using CapaEntidad;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion1
{
    public partial class FormDetalleCompra : Form
    {
        public FormDetalleCompra()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNumeroDocumento.Text == "") {
                MessageBox.Show("Ingrese primero el numero del Documento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumeroDocumento.Select();
                return;
            }

            Compra oCompra = new CN_Compra().obtenerCompra(txtNumeroDocumento.Text);

            if (oCompra.IdCompra != 0) {

                txtTipoDocumento.Text = oCompra.TipoDocumento;
                txtUsuario.Text = oCompra.oUsuario.PrimerNombre;
                txtNumeroDocP.Text = oCompra.oProveedor.Dpi;
                txtRazonSocial.Text = oCompra.oProveedor.RazonSocial;
                txtFecha.Text = oCompra.FechaRegistro.ToString();
                txtTotal.Text = oCompra.MontoTotal.ToString();

                dgvData.Rows.Clear();

                foreach (Detalle_Compra dc in oCompra.oDetalleCompra) {
                    dgvData.Rows.Add(new object[] { 
                        dc.oProducto.NombreProducto,
                        dc.PrecioCompra,
                        dc.PrecioVenta,
                        dc.Cantidad,
                        dc.SubTotal
                    });
                }
            }
        }

        public void limpiar() {
            txtTipoDocumento.Text = "";
            txtUsuario.Text = "";
            txtNumeroDocP.Text = "";
            txtRazonSocial.Text = "";
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTotal.Text = "0.00";
            dgvData.Rows.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            if (txtTipoDocumento.Text == "")
            {
                MessageBox.Show("No se encontraron Resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumeroDocumento.Select();
                return;
            }

            string texto_html = Properties.Resources.PlantillaCompra.ToString();
            Negocio oNegocio = new CN_Negocio().obtenerDatos();

            texto_html = texto_html.Replace("@nombrenegocio", oNegocio.Nombre.ToUpper());
            texto_html = texto_html.Replace("@docnegocio", oNegocio.Ruc);
            texto_html = texto_html.Replace("@direcnegocio", oNegocio.Direccion);

            texto_html = texto_html.Replace("@tipodocumento", txtTipoDocumento.Text);
            texto_html = texto_html.Replace("@numerodocumento", txtNumeroDocumento.Text);
            texto_html = texto_html.Replace("@docproveedor", txtNumeroDocP.Text);
            texto_html = texto_html.Replace("@nombreproveedor", txtRazonSocial.Text);
            texto_html = texto_html.Replace("@fecharegistro", txtFecha.Text);
            texto_html = texto_html.Replace("@usuarioregistro", txtUsuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            texto_html = texto_html.Replace("@filas", filas);
            texto_html = texto_html.Replace("@montototal", txtTotal.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("ReporteCompra_{0}.pdf", txtNumeroDocumento.Text);
            savefile.Filter = "Pdf Files |*.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                //escribir un archivo de memoria
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    bool obtenido = true;
                    byte[] byteImage = new CN_Negocio().obtenerLogo(out obtenido);

                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING; //mostrar la imagen sobre algo
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img); //ingresamos todas las configuraciones de la imagen en el pdf
                    }

                    using (StringReader sr = new StringReader(texto_html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento Genearado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
            }
        }
    }
}
