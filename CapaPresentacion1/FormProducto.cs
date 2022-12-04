using CapaEntidad;
using CapaNegocio;
using CapaPresentacion1.Utilidades;
using ClosedXML.Excel;
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
    public partial class FormProducto : Form
    {
        public FormProducto()
        {
            InitializeComponent();
        }

        private void FormProducto_Load(object sender, EventArgs e)
        {
            cargarTexbox();
            cargarProducto();
        }

        private void cargarTexbox() {

            cmbEstado.Items.Add(new OpcionCombo() { valor = 1, texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { valor = 0, texto = "No Activo" });
            cmbEstado.DisplayMember = "texto";
            cmbEstado.ValueMember = "valor";
            cmbEstado.SelectedIndex = 0;

            List<Ubicacion> lista = new CN_Ubicacion().listar();
            foreach (Ubicacion item in lista)
            {
                cmbUbicacion.Items.Add(new OpcionCombo() { valor = item.IdUbicacion, texto = item.NombreEstante+"("+item.Seccion+")" });
            }
            cmbUbicacion.DisplayMember = "texto";
            cmbUbicacion.ValueMember = "valor";
            cmbUbicacion.SelectedIndex = 0;

            List<Categoria> lista1 = new CN_Categoria().listar();
            foreach (Categoria item1 in lista1) {
                cmbCategoria.Items.Add(new OpcionCombo()
                {
                    valor = item1.IdCategoria,
                    texto = item1.Descripcion,
                });
            }
            cmbCategoria.DisplayMember = "texto";
            cmbCategoria.ValueMember = "Valor";
            cmbCategoria.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar" && columna.Name != "Stock" 
                    && columna.Name != "PrecioCosto" && columna.Name != "PrecioVenta")
                {
                    cmbBuscar.Items.Add(new OpcionCombo() { valor = columna.Name, texto = columna.HeaderText });
                }
            }
            cmbBuscar.DisplayMember = "texto";
            cmbBuscar.ValueMember = "valor";
            cmbBuscar.SelectedIndex = 0;
        }

        private void cargarProducto() {
            List<Producto> cargar = new CN_Producto().listar();
            foreach (Producto lista in cargar) {
                dgvData.Rows.Add(new object[] { 
                    "",
                    lista.IdProducto,
                    lista.CodigoBarra,
                    lista.NombreProducto,
                    lista.Stock,
                    lista.PrecioCompra,
                    lista.PrecioVenta,
                    lista.oUbicacion.NombreEstante+"("+lista.oUbicacion.Seccion+")",
                    lista.oCategoria.Descripcion,
                    lista.Descripcion,
                    lista.Estado == true ? "Activo" : "No Activo"
                });
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            if (txtStock.Text == "")
            {
                MessageBox.Show("El campo de Existecia esta vacio");
            }
            else if (txtPrecioCosto.Text == "")
            {
                MessageBox.Show("El campo de PrecioCosto esta vacio");
            }
            else if (txtPrecioVenta.Text == "")
            {
                MessageBox.Show("El campo de PrecioVenta esta vacio");
            }
            else {
                Producto objProducto = new Producto()
                {
                    IdProducto = Convert.ToInt32(txtId.Text),
                    oCategoria = new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(((OpcionCombo)cmbCategoria.SelectedItem).valor)
                    },
                    oUbicacion = new Ubicacion()
                    {
                        IdUbicacion = Convert.ToInt32(((OpcionCombo)cmbUbicacion.SelectedItem).valor)
                    },
                    CodigoBarra = txtCodigoBarra.Text,
                    NombreProducto = txtNombreProducto.Text,
                    Stock = Convert.ToInt32(txtStock.Text),
                    PrecioCompra = Convert.ToDecimal(txtPrecioCosto.Text),
                    PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text),
                    Estado = Convert.ToBoolean(((OpcionCombo)cmbEstado.SelectedItem).valor),
                    Descripcion = txtDescripcion.Text
                };

                if (objProducto.IdProducto == 0)
                {
                    int idProductoObtenido = new CN_Producto().registrar(objProducto, out Mensaje);

                    if (idProductoObtenido != 0)
                    {
                        MessageBox.Show("Registro Exitoso");
                        dgvData.Rows.Add(new object[] {
                    "",
                    idProductoObtenido,
                    txtCodigoBarra.Text,
                    txtNombreProducto.Text,
                    txtStock.Text,
                    txtPrecioCosto.Text,
                    txtPrecioVenta.Text,
                    ((OpcionCombo)cmbUbicacion.SelectedItem).texto.ToString(),
                    ((OpcionCombo)cmbCategoria.SelectedItem).texto.ToString(),
                    txtDescripcion.Text,
                    ((OpcionCombo)cmbEstado.SelectedItem).texto.ToString()
                });
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje);
                    }
                }
                else
                {
                    var dialogo = MessageBox.Show("¿Desea Modificar el Producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogo == DialogResult.Yes)
                    {
                        bool resultado = new CN_Producto().modificar(objProducto, out Mensaje);

                        if (resultado != false)
                        {
                            MessageBox.Show("Registro Modificado");
                            DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIdTabla.Text)];
                            row.Cells["IdProducto"].Value = txtId.Text;
                            row.Cells["CodigoBarra"].Value = txtCodigoBarra.Text;
                            row.Cells["NombreProducto"].Value = txtNombreProducto.Text;
                            row.Cells["Stock"].Value = txtStock.Text;
                            row.Cells["PrecioCosto"].Value = txtPrecioCosto.Text;
                            row.Cells["PrecioVenta"].Value = txtPrecioVenta.Text;
                            row.Cells["Ubicacion"].Value = ((OpcionCombo)cmbUbicacion.SelectedItem).texto.ToString();
                            row.Cells["Categoria"].Value = ((OpcionCombo)cmbCategoria.SelectedItem).texto.ToString();
                            row.Cells["Descripcion"].Value = txtDescripcion.Text;
                            row.Cells["Estado"].Value = ((OpcionCombo)cmbEstado.SelectedItem).texto.ToString();

                            limpiar();
                        }
                        else
                        {
                            MessageBox.Show(Mensaje);
                        }
                    }
                }
            }
        }

        private void limpiar() {
            txtId.Text = "0";
            txtIdTabla.Text = "-1";
            txtCodigoBarra.Text = "";
            txtNombreProducto.Text = "";
            txtStock.Text = "";
            txtPrecioCosto.Text = "";
            txtPrecioVenta.Text = "";
            txtDescripcion.Text = "";
            cmbCategoria.SelectedIndex = 0;
            cmbUbicacion.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    int dato = Convert.ToInt32(dgvData.Rows[indice].Cells["IdProducto"].Value);
                    Producto oProducto = new CN_Producto().listar().Where(x => x.IdProducto == dato).FirstOrDefault();
                    if (oProducto != null)
                    {
                        txtIdTabla.Text = indice.ToString();
                        txtId.Text = oProducto.IdProducto.ToString();
                        txtCodigoBarra.Text = oProducto.CodigoBarra.ToString();
                        txtNombreProducto.Text = oProducto.NombreProducto.ToString();
                        txtStock.Text = oProducto.Stock.ToString();
                        txtPrecioCosto.Text = oProducto.PrecioCompra.ToString();
                        txtPrecioVenta.Text = oProducto.PrecioVenta.ToString();
                        txtDescripcion.Text = oProducto.Descripcion.ToString();

                        foreach (OpcionCombo cmb in cmbCategoria.Items)
                        {
                            if (Convert.ToInt32(cmb.valor) == oProducto.oCategoria.IdCategoria)
                            {
                                int indice_combo = cmbCategoria.Items.IndexOf(cmb);
                                cmbCategoria.SelectedIndex = indice_combo;
                                break;
                            }
                        }

                        foreach (OpcionCombo cmb in cmbEstado.Items)
                        {
                            if (Convert.ToInt32(cmb.valor) == (oProducto.Estado == true ? 1 : 0))
                            {
                                int indice_comb = cmbEstado.Items.IndexOf(cmb);
                                cmbEstado.SelectedIndex = indice_comb;
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se Producjo un Error");
                    }
                }
            }
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.comprobado.Width;
                var h = Properties.Resources.comprobado.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.comprobado, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void btnLimpiarBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cmbBuscar.SelectedItem).valor.ToString();

            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscar.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            if (Convert.ToInt16(txtId.Text) != 0)
            {
                Producto objto = new Producto()
                {
                    IdProducto = Convert.ToInt32(txtId.Text)
                };

                var dialogo = MessageBox.Show("¿Desea Eliminar el Producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    bool respuesta = new CN_Producto().eliminar(objto, out Mensaje);

                    if (respuesta)
                    {
                        MessageBox.Show("Registro Eliminado Correctamente");
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIdTabla.Text));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione Primero un Producto para Eliminar");
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("no hay datos para Exportar");
            }
            else {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columnas in dgvData.Columns) {
                    if (columnas.HeaderText != "" && columnas.Visible) {
                        dt.Columns.Add(columnas.HeaderText, typeof(string));
                    }
                }

                foreach (DataGridViewRow row in dgvData.Rows) {
                    if (row.Visible) {
                        dt.Rows.Add(new object[] {
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[10].Value.ToString()
                        });
                    }
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteProducto_{0}.xlsx",DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files | *.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte generado","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Error al generar Reporte "+ex);
                    }
                }
            }
        }
    }
}
