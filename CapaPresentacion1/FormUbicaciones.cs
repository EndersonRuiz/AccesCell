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
    public partial class FormUbicaciones : Form
    {
        public FormUbicaciones()
        {
            InitializeComponent();
        }

        private void mostrarDatos()
        {
            List<Ubicacion> listaUbicacion = new CN_Ubicacion().listar();
            foreach (Ubicacion item in listaUbicacion)
            {
                dgvTabla.Rows.Add(new object[] {
                    "",
                    item.IdUbicacion,
                    item.NombreEstante,
                    item.Seccion
                });
            }
        }

        private void FormUbicaciones_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvTabla.Columns)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            Ubicacion objUbicacion = new Ubicacion()
            {
                IdUbicacion = Convert.ToInt32(txtId.Text),
                NombreEstante = txtEstante.Text,
                Seccion = txtSeccion.Text
            };

            if (objUbicacion.IdUbicacion == 0)
            {

                int idObtenido = new CN_Ubicacion().registrar(objUbicacion, out Mensaje);
                if (idObtenido != 0)
                {
                    MessageBox.Show("Registro Existoso");
                    dgvTabla.Rows.Add(new object[] {
                        "",
                        idObtenido,
                        txtEstante.Text,
                        txtSeccion.Text
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
                var dialogo = MessageBox.Show("¿Desea Modificar la Ubicacion?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    bool resultado = new CN_Ubicacion().modificar(objUbicacion, out Mensaje);

                    if (resultado != false)
                    {
                        MessageBox.Show("Registro Modificado");
                        DataGridViewRow row = dgvTabla.Rows[Convert.ToInt32(txtIdTabla.Text)];
                        row.Cells["IdUbicacion"].Value = txtId.Text;
                        row.Cells["NombreEstante"].Value = txtEstante.Text;
                        row.Cells["Seccion"].Value = txtSeccion.Text;

                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje);
                    }
                }
            }
        }

        private void limpiar() {
            txtId.Text = "0";
            txtIdTabla.Text = "-1";
            txtEstante.Text = "";
            txtSeccion.Text = "";
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
                Ubicacion objto = new Ubicacion()
                {
                    IdUbicacion = Convert.ToInt32(txtId.Text)
                };

                var dialogo = MessageBox.Show("¿Desea Eliminar la Ubicacion?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    bool respuesta = new CN_Ubicacion().eliminar(objto, out Mensaje);

                    if (respuesta)
                    {
                        MessageBox.Show("Registro Eliminado Correctamente");
                        dgvTabla.Rows.RemoveAt(Convert.ToInt32(txtIdTabla.Text));
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
                MessageBox.Show("Selecione Primero una Ubicacion para Eliminar");
            }
        }

        private void dgvTabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTabla.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    int dato = Convert.ToInt32(dgvTabla.Rows[indice].Cells["IdUbicacion"].Value);

                    Ubicacion oUbicacion = new CN_Ubicacion().listar().Where(x => x.IdUbicacion == dato).FirstOrDefault();
                    if (oUbicacion != null)
                    {
                        txtIdTabla.Text = indice.ToString();
                        txtId.Text = oUbicacion.IdUbicacion.ToString();
                        txtEstante.Text = oUbicacion.NombreEstante.ToString();
                        txtSeccion.Text = oUbicacion.Seccion.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Se Producjo un Error");
                    }
                }
            }
        }

        private void dgvTabla_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

            foreach (DataGridViewRow row in dgvTabla.Rows) {
                row.Visible = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cmbBuscar.SelectedItem).valor.ToString();

            if (dgvTabla.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvTabla.Rows)
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

    }
}
