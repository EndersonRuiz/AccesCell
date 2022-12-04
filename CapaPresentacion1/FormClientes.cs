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
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private void mostrarDatos()
        {
            List<Cliente> listaCliente = new CN_Cliente().listar();
            foreach (Cliente item in listaCliente)
            {
                dgvData.Rows.Add(new object[] {
                    "",
                    item.IdCliente,
                    item.Dpi,
                    item.NombreCompleto,
                    item.Correo,
                    item.Telefono,
                    item.Direccion,
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

        private void FormClientes_Load(object sender, EventArgs e)
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
            txtNombreCompleto.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            cmbEstado.SelectedIndex = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            if (Convert.ToInt16(txtId.Text) != 0)
            {
                Cliente objto = new Cliente()
                {
                    IdCliente = Convert.ToInt32(txtId.Text)
                };

                var dialogo = MessageBox.Show("¿Desea Eliminar el Cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    bool respuesta = new CN_Cliente().eliminar(objto, out Mensaje);

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
                MessageBox.Show("Selecione Primero un Cliente para Eliminar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            Cliente objCliente = new Cliente()
            {
                IdCliente = Convert.ToInt32(txtId.Text),
                Dpi = txtDpi.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                Estado = Convert.ToBoolean(((OpcionCombo)cmbEstado.SelectedItem).valor)
            };

            if (objCliente.IdCliente == 0)
            {
                int idClienteObtenido = new CN_Cliente().registrar(objCliente, out Mensaje);

                if (idClienteObtenido != 0)
                {
                    MessageBox.Show("Registro Exitoso");
                    dgvData.Rows.Add(new object[] {
                    "",
                    idClienteObtenido,
                    txtDpi.Text,
                    txtNombreCompleto.Text,
                    txtCorreo.Text,
                    txtTelefono.Text,
                    txtDireccion.Text,
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
                var dialogo = MessageBox.Show("¿Desea Modificar el Cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    bool resultado = new CN_Cliente().modificar(objCliente, out Mensaje);

                    if (resultado != false)
                    {
                        MessageBox.Show("Registro Modificado");
                        DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIdTabla.Text)];
                        row.Cells["IdCliente"].Value = txtId.Text;
                        row.Cells["Dpi"].Value = txtDpi.Text;
                        row.Cells["NombreCompleto"].Value = txtNombreCompleto.Text;
                        row.Cells["Correo"].Value = txtCorreo.Text;
                        row.Cells["Telefono"].Value = txtTelefono.Text;
                        row.Cells["Direccion"].Value = txtDireccion.Text;
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
                    int dato = Convert.ToInt32(dgvData.Rows[indice].Cells["IdCliente"].Value);
                    Cliente oCliente = new CN_Cliente().listar().Where(x => x.IdCliente == dato).FirstOrDefault();
                    if (oCliente != null)
                    {
                        txtIdTabla.Text = indice.ToString();
                        txtId.Text = oCliente.IdCliente.ToString();
                        txtDpi.Text = oCliente.Dpi.ToString();
                        txtNombreCompleto.Text = oCliente.NombreCompleto.ToString();
                        txtCorreo.Text = oCliente.Correo.ToString();
                        txtTelefono.Text = oCliente.Telefono.ToString();
                        txtDireccion.Text = oCliente.Direccion.ToString();

                        foreach (OpcionCombo cmb in cmbEstado.Items)
                        {
                            if (Convert.ToInt32(cmb.valor) == (oCliente.Estado == true ? 1 : 0))
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
    }
}
