using CapaEntidad;
using CapaNegocio;
using CapaPresentacion1.Modales;
using CapaPresentacion1.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion1
{
    public partial class FormCompras : Form
    {

        private Usuario _usuario;

        public FormCompras(Usuario oUsuario = null)
        {
            _usuario = oUsuario;
            InitializeComponent();
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            llenarCombo();
        }

        public void llenarCombo() {
            cmbDocumento.Items.Add(new OpcionCombo() { valor = "Boleta", texto = "Boleta" });
            cmbDocumento.Items.Add(new OpcionCombo() { valor = "Factura", texto = "Factura" });
            cmbDocumento.DisplayMember = "texto";
            cmbDocumento.ValueMember = "valor";
            cmbDocumento.SelectedIndex = 0;
            //txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProveedor()) {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProveedor.Text = modal._proveedor.IdProveedor.ToString();
                    txtRazonSocial.Text = modal._proveedor.RazonSocial;
                    txtNumeroDocumento.Text = modal._proveedor.Dpi;
                }
                else {
                    txtNumeroDocumento.Select();
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            mdProducto modal = new mdProducto();
            modal.Show();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdBuscarProucto()) {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = modal._producto.IdProducto.ToString();
                    txtCodigoBarra.Text = modal._producto.CodigoBarra;
                    txtNombreProducto.Text = modal._producto.NombreProducto;
                    txtPrecioCompra.Text = modal._producto.PrecioCompra.ToString();
                    txtPrecioVenta.Text = modal._producto.PrecioVenta.ToString();
                }
                else {
                    txtCodigoBarra.Select();
                }
            }
        }

        private void txtCodigoBarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) {
                Producto oProducto = new CN_Producto().listar().Where(x => x.CodigoBarra == txtCodigoBarra.Text && x.Estado == true).FirstOrDefault();
                if (oProducto != null)
                {
                    txtCodigoBarra.BackColor = Color.Honeydew;
                    txtNombreProducto.Text = oProducto.NombreProducto;
                    txtIdProducto.Text = oProducto.IdProducto.ToString();
                    txtPrecioCompra.Text = oProducto.PrecioCompra.ToString();
                    txtPrecioVenta.Text = oProducto.PrecioVenta.ToString();
                    txtPrecioCompra.Select();
                }
                else {
                    txtCodigoBarra.BackColor = Color.MistyRose;
                    txtNombreProducto.Text = "";
                    txtIdProducto.Text = "0";
                    txtPrecioCompra.Text = "";
                    txtPrecioVenta.Text = "";
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal _precioCompra = 0;
            decimal _precioVenta = 0;
            bool productoExistente = false;

            if (int.Parse(txtIdProducto.Text) == 0) {
                MessageBox.Show("Debe de Seleccionar un Producto","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (int.Parse(txtIdProveedor.Text) == 0)
            {
                MessageBox.Show("Debe de Seleccionar un Proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!decimal.TryParse(txtPrecioCompra.Text, out _precioCompra)) {
                MessageBox.Show("Precio Compra - Formato Moneda Incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioCompra.Select();
                return;
            }
            if (!decimal.TryParse(txtPrecioVenta.Text, out _precioVenta))
            {
                MessageBox.Show("Precio Venta - Formato Moneda Incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioVenta.Select();
                return;
            }

            foreach (DataGridViewRow fila in dgvData.Rows) {
                if (fila.Cells["IdProducto"].Value.ToString() == txtIdProducto.Text) {
                    productoExistente = true;
                    break;
                }
            }

            if (!productoExistente) {
                dgvData.Rows.Add(new object[] {
                    txtIdProducto.Text,
                    txtNombreProducto.Text,
                    _precioCompra.ToString("0.00"),
                    _precioVenta.ToString("0.00"),
                    txtCantidad.Value.ToString(),
                    (txtCantidad.Value * _precioCompra).ToString("0.00")
                });
                calcularTotal();
                limpiarProducto();
                txtCodigoBarra.Select();
            }
        }

        private void limpiarProducto() {
            txtIdProducto.Text = "0";
            txtCodigoBarra.Text = "";
            txtCodigoBarra.BackColor = Color.White;
            txtNombreProducto.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtCantidad.Value = 1;
        }

        private void calcularTotal() {
            decimal total = 0;
            if (dgvData.Rows.Count > 0) {
                foreach (DataGridViewRow row in dgvData.Rows) {
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
                }
                txtTotal.Text = total.ToString("0.00");
            }
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.delete.Width;
                var h = Properties.Resources.delete.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.delete, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    dgvData.Rows.RemoveAt(indice);
                    calcularTotal();
                }
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else {
                if (txtPrecioCompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else {
                    if (char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecioVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtIdProveedor.Text) == 0) {
                MessageBox.Show("Seleccione Primero un Proveedor","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("Debe de Ingresar Productos en la Compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //creamos el data table igual a la tabla type de creamos en sql server debe ser igual para que se pueda crear
            DataTable detalle_compra = new DataTable();
            detalle_compra.Columns.Add("IdProducto",typeof(int));
            detalle_compra.Columns.Add("PrecioCompra", typeof(decimal));
            detalle_compra.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_compra.Columns.Add("Cantidad", typeof(int));
            detalle_compra.Columns.Add("SubTotal", typeof(decimal));

            //leer los datos de la tabla datagridview
            foreach (DataGridViewRow row in dgvData.Rows) {
                detalle_compra.Rows.Add(new object[] {
                    Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                    Convert.ToDecimal(row.Cells["PrecioCompra"].Value.ToString()),
                    Convert.ToDecimal(row.Cells["PrecioVenta"].Value.ToString()),
                    Convert.ToInt32(row.Cells["Cantidad"].Value.ToString()),
                    Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString())
                });
            }

            int obtenerCorrelatio = new CN_Compra().obtenerCorrelativo();

            //convertir el correlativo a este tipo de formato ejm. 00001
            string numeroDocumento = string.Format("{0:00000}",obtenerCorrelatio);

            //le mandamos valores al objeto de compra
            Compra obj_Com = new Compra() { 
                oUsuario = new Usuario() { 
                    IdUsuario = _usuario.IdUsuario
                },
                oProveedor = new Proveedor() { 
                    IdProveedor = Convert.ToInt32(txtIdProveedor.Text)
                },
                TipoDocumento = ((OpcionCombo)cmbDocumento.SelectedItem).valor.ToString(),
                NumeroDocumento = numeroDocumento.ToString(),
                MontoTotal = Convert.ToDecimal(txtTotal.Text)
            };

            string Mensaje = string.Empty;
            bool Respuesta = new CN_Compra().registrar(obj_Com,detalle_compra,out Mensaje);

            if (Respuesta)
            {
                var result = MessageBox.Show("Numero de Compra Generada:\n" + numeroDocumento + "\n\n¿Desea copiar al portapapeles?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)

                    Clipboard.SetText(numeroDocumento);

                //limpiar todos los campos al finalizar
                txtIdProveedor.Text = "0";
                txtNumeroDocumento.Text = "0";
                txtRazonSocial.Text = "";
                dgvData.Rows.Clear();
                calcularTotal();

            }
            else {
                MessageBox.Show(Mensaje, "Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
