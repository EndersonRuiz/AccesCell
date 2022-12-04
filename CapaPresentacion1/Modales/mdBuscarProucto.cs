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

namespace CapaPresentacion1.Modales
{
    public partial class mdBuscarProucto : Form
    {

        public Producto _producto { get; set; }
        public mdBuscarProucto()
        {
            InitializeComponent();
        }

        private void mdBuscarProucto_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }


        private void mostrarDatos()
        {
            List<Producto> listaCliente = new CN_Producto().listar();
            foreach (Producto item in listaCliente)
            {
                dgvData.Rows.Add(new object[] {
                    item.IdProducto,
                    item.CodigoBarra,
                    item.NombreProducto,
                    item.PrecioCompra,
                    item.PrecioVenta,
                    item.Stock,
                    item.oCategoria.Descripcion
                });
            }

            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true)
                {
                    cmbBuscar.Items.Add(new OpcionCombo()
                    {
                        valor = columna.Name,
                        texto = columna.HeaderText
                    });
                }
            }
            cmbBuscar.DisplayMember = "texto";
            cmbBuscar.ValueMember = "valor";
            cmbBuscar.SelectedIndex = 0;
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

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum > 0)
            {
                _producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(dgvData.Rows[iRow].Cells["IdProducto"].Value.ToString()),
                    CodigoBarra = dgvData.Rows[iRow].Cells["CodigoBarra"].Value.ToString(),
                    NombreProducto = dgvData.Rows[iRow].Cells["NombreProducto"].Value.ToString(),
                    PrecioCompra = Convert.ToDecimal(dgvData.Rows[iRow].Cells["PrecioCompra"].Value.ToString()),
                    PrecioVenta = Convert.ToDecimal(dgvData.Rows[iRow].Cells["PrecioVenta"].Value.ToString()),
                    Stock = Convert.ToInt32(dgvData.Rows[iRow].Cells["Stock"].Value.ToString())
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
