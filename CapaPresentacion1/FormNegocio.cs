using CapaEntidad;
using CapaNegocio;
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
    public partial class FormNegocio : Form
    {
        public FormNegocio()
        {
            InitializeComponent();
        }

        private void FormNegocio_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        //convertir imagen en byte
        public Image ByteToImagen(byte[] imageBytes) {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image imagen = new Bitmap(ms);

            return imagen;
        }
        private void mostrarDatos() {

            //obtener imagen
            bool obtenido = true;
            byte[] byteImagen = new CN_Negocio().obtenerLogo(out obtenido);

            if (obtenido) {
                picLogo.Image = ByteToImagen(byteImagen);
            }

            //obtener datos negocio
            Negocio datos = new CN_Negocio().obtenerDatos();
            txtNombre.Text = datos.Nombre;
            txtRuc.Text = datos.Ruc;
            txtDireccion.Text = datos.Direccion;
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            OpenFileDialog oOpenFile = new OpenFileDialog();
            oOpenFile.FileName = "Files|*.jpg;*.jpeg;*.png;";
            if (oOpenFile.ShowDialog() == DialogResult.OK) {
                byte[] imagen = File.ReadAllBytes(oOpenFile.FileName);
                bool respuesta = new CN_Negocio().ActualizarLogo(imagen,out Mensaje);

                if (respuesta)
                    picLogo.Image = ByteToImagen(imagen);
                else
                    MessageBox.Show(Mensaje, "Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Negocio obj = new Negocio()
            {
                Nombre = txtNombre.Text,
                Ruc = txtRuc.Text,
                Direccion = txtDireccion.Text
            };

            bool respuesta = new CN_Negocio().registrar(obj,out Mensaje);
            if(respuesta)
                MessageBox.Show("Los cambios fueron Guardados existosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error al realizar los Cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
