using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;
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
    public partial class Inicio : Form
    {
        private static Usuario userActual;
        private static IconMenuItem menuActivo = null;
        private static Form formularioActivo = null;
        public Inicio(Usuario objUsuario)
        {
            userActual = objUsuario;
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            //extraer los permisos
            List<Permiso> ListaPermisos = new CN_Permiso().Listar(userActual.IdUsuario);

            //para cargar los menus o timens de acuerdo a sus permisos
            foreach (IconMenuItem IconMenu in menuStrip1.Items) {
                bool encontrado = ListaPermisos.Any(x => x.NombreMenu == IconMenu.Name);
                if (encontrado == false) {
                    IconMenu.Visible = false;
                }
            }

            this.labelNombreUsuario.Text = userActual.PrimerNombre + " " + userActual.PrimerApellido + " " + userActual.SegundoApellido;
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario) {
            if (menuActivo != null) {
                menuActivo.BackColor = Color.White;
            }

            menu.BackColor = Color.Silver;
            menuActivo = menu;

            if (formularioActivo != null) {
                formularioActivo.Close();
            }

            formularioActivo = formulario;
            //formulario no sea superior
            formulario.TopLevel = false;
            //no contenga ningun borde
            formulario.FormBorderStyle = FormBorderStyle.None;
            //que tome todo el espacio del contenedor
            formulario.Dock = DockStyle.Fill;
            //color del contenedor
            formulario.BackColor = Color.SteelBlue;
            //al contenedor se pueda agregar este formulario
            Contenedor.Controls.Add(formulario);
            //mostrar el formulario
            formulario.Show();
        }
        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuUsuarios, new FormUsuario());
        }

        private void menuItemCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenedor,new FormCategoria());
        }

        private void menuItemProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenedor, new FormProducto());
        }

        private void subMenuVentaReg_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuVentas, new FormVentas());
        }

        private void subMenuVentaDet_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuVentas, new FormDetalleVenta());
        }

        private void subMenuCompraReg_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuCompras, new FormCompras(userActual));
        }

        private void subMenuCompraDet_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuCompras, new FormDetalleCompra());
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuClientes, new FormClientes());
        }


        private void menuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuProveedores, new FormProveedores());
        }

        private void menuReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuReportes, new FormReportes());
        }

        private void subMenuUbicacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenedor, new FormUbicaciones());
        }

        private void submenuNegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenedor, new FormNegocio());
        }
    }
}
