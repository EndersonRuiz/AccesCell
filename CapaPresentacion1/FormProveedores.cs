using CapaEntidad;
using CapaNegocio;
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
    public partial class FormProveedores : Form
    {
        public FormProveedores()
        {
            InitializeComponent();
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        public void limpiar()
        {
            txtId.Text = "0";
            txtIdTabla.Text = "-1";
            txtDpi.Text = "";
            txtRazonSocial.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            cmbEstado.SelectedIndex = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            if (Convert.ToInt16(txtId.Text) != 0)
            {
                Proveedor objto = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(txtId.Text)
                };

                var dialogo = MessageBox.Show("¿Desea Eliminar el Proveedor?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    bool respuesta = new CN_Proveedor().eliminar(objto, out Mensaje);

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
                MessageBox.Show("Selecione Primero un Proveedor para Eliminar");
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

        private void btnLimpiarBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            Proveedor obj = new Proveedor()
            {
                IdProveedor = Convert.ToInt32(txtId.Text),
                Dpi = txtDpi.Text,
                RazonSocial = txtRazonSocial.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                Estado = Convert.ToBoolean(((OpcionCombo)cmbEstado.SelectedItem).valor)
            };

            if (obj.IdProveedor == 0)
            {
                int idProveedorObtenido = new CN_Proveedor().registrar(obj, out Mensaje);

                if (idProveedorObtenido != 0)
                {
                    MessageBox.Show("Registro Exitoso");
                    dgvData.Rows.Add(new object[] {
                    "",
                    idProveedorObtenido,
                    txtDpi.Text,
                    txtRazonSocial.Text,
                    txtCorreo.Text,
                    txtTelefono.Text,
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
                var dialogo = MessageBox.Show("¿Desea Modificar el Proveedor?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    bool resultado = new CN_Proveedor().modificar(obj, out Mensaje);

                    if (resultado != false)
                    {
                        MessageBox.Show("Registro Modificado");
                        DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIdTabla.Text)];
                        row.Cells["IdProveedor"].Value = txtId.Text;
                        row.Cells["Dpi"].Value = txtDpi.Text;
                        row.Cells["RazonSocial"].Value = txtRazonSocial.Text;
                        row.Cells["Correo"].Value = txtCorreo.Text;
                        row.Cells["Telefono"].Value = txtTelefono.Text;
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

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    int dato = Convert.ToInt32(dgvData.Rows[indice].Cells["IdProveedor"].Value);
                    Proveedor oProveedor = new CN_Proveedor().listar().Where(x => x.IdProveedor == dato).FirstOrDefault();
                    if (oProveedor != null)
                    {
                        txtIdTabla.Text = indice.ToString();
                        txtId.Text = oProveedor.IdProveedor.ToString();
                        txtDpi.Text = oProveedor.Dpi.ToString();
                        txtRazonSocial.Text = oProveedor.RazonSocial.ToString();
                        txtCorreo.Text = oProveedor.Correo.ToString();
                        txtTelefono.Text = oProveedor.Telefono.ToString();

                        foreach (OpcionCombo cmb in cmbEstado.Items)
                        {
                            if (Convert.ToInt32(cmb.valor) == (oProveedor.Estado == true ? 1 : 0))
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

        private void mostrarDatos()
        {
            List<Proveedor> listaCliente = new CN_Proveedor().listar();
            foreach (Proveedor item in listaCliente)
            {
                dgvData.Rows.Add(new object[] {
                    "",
                    item.IdProveedor,
                    item.Dpi,
                    item.RazonSocial,
                    item.Correo,
                    item.Telefono,
                    item.Estado == true ? "Activo" : "No Activo"
                });
            }

            cmbEstado.Items.Add(new OpcionCombo() { valor = 1, texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { valor = 0, texto = "No Activo" });
            cmbEstado.DisplayMember = "texto";
            cmbEstado.ValueMember = "valor";
            cmbEstado.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cmbBuscar.Items.Add(new OpcionCombo() { valor = columna.Name, texto = columna.HeaderText });
                }
            }
            cmbBuscar.DisplayMember = "texto";
            cmbBuscar.ValueMember = "valor";
            cmbBuscar.SelectedIndex = 0;
        }
    }
}
