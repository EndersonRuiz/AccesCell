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
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new OpcionCombo() { valor = 1, texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { valor = 0, texto = "No Activo" });
            cmbEstado.DisplayMember = "texto";
            cmbEstado.ValueMember = "valor";
            cmbEstado.SelectedIndex = 0;

            List<Rol> lista = new CN_Rol().Listar();
            foreach (Rol item in lista)
            {
                cmbRol.Items.Add(new OpcionCombo() { valor = item.IdRol, texto = item.Descripcion });
            }
            cmbRol.DisplayMember = "texto";
            cmbRol.ValueMember = "valor";
            cmbRol.SelectedIndex = 0;

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

            mostrarDatos();

        }

        private void mostrarDatos()
        {
            List<Usuario> listaUsuario = new CN_Usuario().ListarUsuario();
            foreach (Usuario item in listaUsuario)
            {
                dgvData.Rows.Add(new object[] {
                    "",
                    item.IdUsuario,
                    item.Dpi,
                    item.PrimerNombre+" "+item.SegundoNombre+" "+item.PrimerApellido+" "+item.SegundoApellido,
                    item.Correo,
                    item.User,
                    item.oRol.Descripcion,
                    item.oRol.IdRol,
                    item.Clave ,
                    item.Estado == true ? "Activo" : "No Activo",
                    item.Estado == true ? 1 : 0
                });
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            string Mensaje = string.Empty;

            Usuario objUsuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtId.Text),
                Dpi = txtDpi.Text,
                PrimerNombre = txtPrimerNombre.Text,
                SegundoNombre = txtSegundoNombre.Text,
                PrimerApellido = txtPrimerApellido.Text,
                SegundoApellido = txtSegundoApellido.Text,
                User = txtUsuario.Text,
                Clave = txtClave.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                oRol = new Rol()
                {
                    IdRol = Convert.ToInt32(((OpcionCombo)cmbRol.SelectedItem).valor)
                },
                Estado = Convert.ToBoolean(((OpcionCombo)cmbEstado.SelectedItem).valor)
            };

            if (objUsuario.IdUsuario == 0)
            {
                int idUsuarioObtenido = new CN_Usuario().registrar(objUsuario, out Mensaje);

                if (idUsuarioObtenido != 0)
                {
                    MessageBox.Show("Registro Exitoso");
                    dgvData.Rows.Add(new object[] {
                    "",
                    idUsuarioObtenido,
                    txtDpi.Text,
                    txtPrimerNombre.Text+" "+txtSegundoNombre.Text+" "+txtPrimerApellido.Text+" "+txtSegundoApellido.Text,
                    txtCorreo.Text,
                    txtUsuario.Text,
                    ((OpcionCombo)cmbRol.SelectedItem).texto.ToString(),
                    ((OpcionCombo)cmbRol.SelectedItem).valor.ToString(),
                    txtClave.Text,
                    ((OpcionCombo)cmbEstado.SelectedItem).texto.ToString(),
                    ((OpcionCombo)cmbEstado.SelectedItem).valor.ToString()
                });
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
            else
            {
                 var dialogo = MessageBox.Show("¿Desea Modificar el Usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    bool resultado = new CN_Usuario().editar(objUsuario, out Mensaje);

                    if (resultado != false)
                    {
                        MessageBox.Show("Registro Modificado");
                        DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIdTabla.Text)];
                        row.Cells["IdUsuario"].Value = txtId.Text;
                        row.Cells["Dpi"].Value = txtDpi.Text;
                        row.Cells["NombreCompleto"].Value = txtPrimerNombre.Text + " " + txtSegundoNombre.Text + " " + txtPrimerApellido.Text + " " + txtSegundoApellido.Text;
                        row.Cells["correo"].Value = txtCorreo.Text;
                        row.Cells["Usuario"].Value = txtUsuario.Text;
                        row.Cells["Rol"].Value = ((OpcionCombo)cmbRol.SelectedItem).texto.ToString();
                        row.Cells["IdRol"].Value = ((OpcionCombo)cmbRol.SelectedItem).valor.ToString();
                        row.Cells["Contraseña"].Value = txtClave.Text;
                        row.Cells["Estado"].Value = ((OpcionCombo)cmbEstado.SelectedItem).texto.ToString();
                        row.Cells["EstadoValor"].Value = ((OpcionCombo)cmbEstado.SelectedItem).valor.ToString();

                        limpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje);
                    }
                }
            }
        }

        private void limpiarCampos()
        {
            txtIdTabla.Text = "-1";
            txtId.Text = "0";
            txtDpi.Text = "";
            txtPrimerNombre.Text = "";
            txtSegundoNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = "";
            txtClave.Text = "";
            txtConfimarClave.Text = "";
            cmbEstado.SelectedIndex = 0;
            cmbRol.SelectedIndex = 0;
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
                    int dato = Convert.ToInt32(dgvData.Rows[indice].Cells["IdUsuario"].Value);
                    Usuario oUsaurio = new CN_Usuario().ListarUsuario().Where(x => x.IdUsuario == dato).FirstOrDefault();
                    if (oUsaurio != null)
                    {
                        txtIdTabla.Text = indice.ToString();
                        txtId.Text = oUsaurio.IdUsuario.ToString();
                        txtDpi.Text = oUsaurio.Dpi.ToString();
                        txtPrimerNombre.Text = oUsaurio.PrimerNombre.ToString();
                        txtSegundoNombre.Text = oUsaurio.SegundoNombre.ToString();
                        txtPrimerApellido.Text = oUsaurio.PrimerApellido.ToString();
                        txtSegundoApellido.Text = oUsaurio.SegundoApellido.ToString();
                        txtCorreo.Text = oUsaurio.Correo.ToString();
                        txtTelefono.Text = oUsaurio.Telefono.ToString();
                        txtUsuario.Text = oUsaurio.User.ToString();
                        txtClave.Text = oUsaurio.Clave.ToString();
                        txtConfimarClave.Text = oUsaurio.Clave.ToString();
                        //cmbRol.Items.Add(dgvData.Rows[indice].Cells["Rol"].Value);

                        foreach (OpcionCombo cmb in cmbRol.Items)
                        {
                            if (Convert.ToInt32(cmb.valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["IdRol"].Value))
                            {
                                int indice_combo = cmbRol.Items.IndexOf(cmb);
                                cmbRol.SelectedIndex = indice_combo;
                                break;
                            }
                        }

                        foreach (OpcionCombo cmb in cmbEstado.Items)
                        {
                            if (Convert.ToInt32(cmb.valor) == (oUsaurio.Estado == true ? 1 : 0))
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            if (Convert.ToInt16(txtId.Text) != 0)
            {
                Usuario objto = new Usuario()
                {
                    IdUsuario = Convert.ToInt32(txtId.Text)
                };

                var dialogo = MessageBox.Show("¿Desea Eliminar el Usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes) {
                    bool respuesta = new CN_Usuario().eliminar(objto, out Mensaje);

                    if (respuesta)
                    {
                        MessageBox.Show("Registro Eliminado Correctamente");
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIdTabla.Text));
                        limpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje);
                    }
                }
            }
            else {
                MessageBox.Show("Selecione Primero un Usuario para Eliminar");
            }
       
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cmbBuscar.SelectedItem).valor.ToString();

            if (dgvData.Rows.Count > 0) {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscar.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else {
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnLimpiarBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";

            foreach (DataGridViewRow row in dgvData.Rows) {
                row.Visible = true;
            }
        }
    }
}
