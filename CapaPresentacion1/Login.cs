using CapaEntidad;
using CapaNegocio;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
           // List<Usuario> test = new CN_Usuario().Listar();
            Usuario oUsuario = new CN_Usuario().Listar().Where(x => x.User == txtUsuario.Text && x.Clave == txtContraseña.Text).FirstOrDefault();

            if (oUsuario != null)
            {
                Inicio form = new Inicio(oUsuario);
                form.Show();
                this.Hide();
                form.FormClosing += form_closing;
            }
            else {
                MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTA","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                Limpiar();
            }
        }

        private void form_closing(object sender, FormClosingEventArgs e) {
            Limpiar();
            this.Show();
        }

        private void Limpiar() {
            this.txtContraseña.Text = "";
            this.txtUsuario.Text = "";
        }
    }
}
