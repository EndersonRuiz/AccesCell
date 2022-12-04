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
    public partial class mdProveedor : Form
    {
        //propiedad de este formulario la definimos
        public Proveedor _proveedor { get; set; }

        public mdProveedor()
        {
            InitializeComponent();
        }

        private void mdProveedor_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void mostrarDatos()
        {
            List<Proveedor> listaCliente = new CN_Proveedor().listar();
            foreach (Proveedor item in listaCliente)
            {
                dgvData.Rows.Add(new object[] {
                    item.IdProveedor,
                    item.Dpi,
                    item.RazonSocial
                });
            }

            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "IdProveedor")
                {
                    cmbBuscar.Items.Add(new OpcionCombo() { 
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

            if (iRow >= 0 && iColum > 0) {
                _proveedor = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(dgvData.Rows[iRow].Cells["IdProveedor"].Value.ToString()),
                    Dpi = dgvData.Rows[iRow].Cells["Dpi"].Value.ToString(),
                    RazonSocial = dgvData.Rows[iRow].Cells["RazonSocial"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
