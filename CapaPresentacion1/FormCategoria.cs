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
    public partial class FormCategoria : Form
    {
        public FormCategoria()
        {
            InitializeComponent();
        }



        private void FormCategoria_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }


        private void mostrarDatos()
        {
            List<Categoria> listaUsuario = new CN_Categoria().listar();
            dgvTabla.AutoGenerateColumns = false;
            foreach (Categoria item in listaUsuario)
            {
                dgvTabla.Rows.Add(new object[] {
                    "",
                    item.IdCategoria,
                    item.Descripcion
                });
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            Categoria objCategoria = new Categoria()
            {
                IdCategoria = Convert.ToInt32(txtId.Text),
                Descripcion = txtDescripcion.Text
            };

            if (objCategoria.IdCategoria == 0)
            {

                int idObtenido = new CN_Categoria().registrar(objCategoria, out Mensaje);
                if (idObtenido != 0)
                {
                    MessageBox.Show("Registro Existoso");
                    dgvTabla.Rows.Add(new object[] {
                        "",
                        idObtenido,
                        txtDescripcion.Text
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
                var dialogo = MessageBox.Show("¿Desea Modificar la Categoria?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    bool resultado = new CN_Categoria().modificar(objCategoria, out Mensaje);

                    if (resultado != false)
                    {
                        MessageBox.Show("Registro Modificado");
                        DataGridViewRow row = dgvTabla.Rows[Convert.ToInt32(txtIdTabla.Text)];
                        row.Cells["IdCategoria"].Value = txtId.Text;
                        row.Cells["Descripcion"].Value = txtDescripcion.Text;

                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje);
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar() {
            txtDescripcion.Text = "";
            txtId.Text = "0";
            txtIdTabla.Text = "-1";
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

        private void dgvTabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTabla.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    int dato = Convert.ToInt32(dgvTabla.Rows[indice].Cells["IdCategoria"].Value);

                    Categoria oCategoria = new CN_Categoria().listar().Where(x => x.IdCategoria == dato).FirstOrDefault();
                    if (oCategoria != null)
                    {
                        txtIdTabla.Text = indice.ToString();
                        txtId.Text = oCategoria.IdCategoria.ToString();
                        txtDescripcion.Text = oCategoria.Descripcion.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Se Producjo un Error");
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            if (Convert.ToInt16(txtId.Text) != 0)
            {
                Categoria objto = new Categoria()
                {
                    IdCategoria = Convert.ToInt32(txtId.Text)
                };

                var dialogo = MessageBox.Show("¿Desea Eliminar la Categoria?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    bool respuesta = new CN_Categoria().eliminar(objto, out Mensaje);

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
                MessageBox.Show("Selecione Primero una Categoria para Eliminar");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dgvTabla.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvTabla.Rows)
                {
                    if (row.Cells["Descripcion"].Value.ToString().Trim().ToUpper().Contains(txtBuscar.Text.Trim().ToUpper()))
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

            foreach (DataGridViewRow row in dgvTabla.Rows) {
                row.Visible = true;
            }
        }
    }
}
