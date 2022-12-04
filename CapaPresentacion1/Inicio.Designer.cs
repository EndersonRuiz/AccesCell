namespace CapaPresentacion1
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            this.menuMantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.menuItemCategoria = new FontAwesome.Sharp.IconMenuItem();
            this.menuItemProducto = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuUbicacion = new FontAwesome.Sharp.IconMenuItem();
            this.submenuNegocio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVentas = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuVentaReg = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuVentaDet = new FontAwesome.Sharp.IconMenuItem();
            this.menuCompras = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuCompraReg = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuCompraDet = new FontAwesome.Sharp.IconMenuItem();
            this.menuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuProveedores = new FontAwesome.Sharp.IconMenuItem();
            this.menuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.menuAcercaDe = new FontAwesome.Sharp.IconMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.labelNombreUsuario = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuMantenedor,
            this.menuVentas,
            this.menuCompras,
            this.menuClientes,
            this.menuProveedores,
            this.menuReportes,
            this.menuAcercaDe});
            this.menuStrip1.Location = new System.Drawing.Point(0, 68);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1148, 83);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menu";
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.AutoSize = false;
            this.menuUsuarios.IconChar = FontAwesome.Sharp.IconChar.UserAstronaut;
            this.menuUsuarios.IconColor = System.Drawing.Color.Black;
            this.menuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuUsuarios.IconSize = 60;
            this.menuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(122, 79);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);
            // 
            // menuMantenedor
            // 
            this.menuMantenedor.AutoSize = false;
            this.menuMantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCategoria,
            this.menuItemProducto,
            this.subMenuUbicacion,
            this.submenuNegocio});
            this.menuMantenedor.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.menuMantenedor.IconColor = System.Drawing.Color.Black;
            this.menuMantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuMantenedor.IconSize = 60;
            this.menuMantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuMantenedor.Name = "menuMantenedor";
            this.menuMantenedor.Size = new System.Drawing.Size(80, 79);
            this.menuMantenedor.Text = "Mantenedor";
            this.menuMantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuItemCategoria
            // 
            this.menuItemCategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuItemCategoria.IconColor = System.Drawing.Color.Black;
            this.menuItemCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuItemCategoria.Name = "menuItemCategoria";
            this.menuItemCategoria.Size = new System.Drawing.Size(180, 22);
            this.menuItemCategoria.Text = "Categoria";
            this.menuItemCategoria.Click += new System.EventHandler(this.menuItemCategoria_Click);
            // 
            // menuItemProducto
            // 
            this.menuItemProducto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.menuItemProducto.IconColor = System.Drawing.Color.Black;
            this.menuItemProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuItemProducto.Name = "menuItemProducto";
            this.menuItemProducto.Size = new System.Drawing.Size(180, 22);
            this.menuItemProducto.Text = "Producto";
            this.menuItemProducto.Click += new System.EventHandler(this.menuItemProducto_Click);
            // 
            // subMenuUbicacion
            // 
            this.subMenuUbicacion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuUbicacion.IconColor = System.Drawing.Color.Black;
            this.subMenuUbicacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuUbicacion.Name = "subMenuUbicacion";
            this.subMenuUbicacion.Size = new System.Drawing.Size(180, 22);
            this.subMenuUbicacion.Text = "Ubicaciones";
            this.subMenuUbicacion.Click += new System.EventHandler(this.subMenuUbicacion_Click);
            // 
            // submenuNegocio
            // 
            this.submenuNegocio.Name = "submenuNegocio";
            this.submenuNegocio.Size = new System.Drawing.Size(180, 22);
            this.submenuNegocio.Text = "Negocio";
            this.submenuNegocio.Click += new System.EventHandler(this.submenuNegocio_Click);
            // 
            // menuVentas
            // 
            this.menuVentas.AutoSize = false;
            this.menuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuVentaReg,
            this.subMenuVentaDet});
            this.menuVentas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuVentas.IconColor = System.Drawing.Color.Black;
            this.menuVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuVentas.IconSize = 60;
            this.menuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVentas.Name = "menuVentas";
            this.menuVentas.Size = new System.Drawing.Size(80, 79);
            this.menuVentas.Text = "Ventas";
            this.menuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // subMenuVentaReg
            // 
            this.subMenuVentaReg.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuVentaReg.IconColor = System.Drawing.Color.Black;
            this.subMenuVentaReg.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuVentaReg.Name = "subMenuVentaReg";
            this.subMenuVentaReg.Size = new System.Drawing.Size(129, 22);
            this.subMenuVentaReg.Text = "Registrar";
            this.subMenuVentaReg.Click += new System.EventHandler(this.subMenuVentaReg_Click);
            // 
            // subMenuVentaDet
            // 
            this.subMenuVentaDet.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuVentaDet.IconColor = System.Drawing.Color.Black;
            this.subMenuVentaDet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuVentaDet.Name = "subMenuVentaDet";
            this.subMenuVentaDet.Size = new System.Drawing.Size(129, 22);
            this.subMenuVentaDet.Text = "Ver Detalle";
            this.subMenuVentaDet.Click += new System.EventHandler(this.subMenuVentaDet_Click);
            // 
            // menuCompras
            // 
            this.menuCompras.AutoSize = false;
            this.menuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuCompraReg,
            this.subMenuCompraDet});
            this.menuCompras.IconChar = FontAwesome.Sharp.IconChar.TruckFast;
            this.menuCompras.IconColor = System.Drawing.Color.Black;
            this.menuCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCompras.IconSize = 60;
            this.menuCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCompras.Name = "menuCompras";
            this.menuCompras.Size = new System.Drawing.Size(80, 79);
            this.menuCompras.Text = "Compras";
            this.menuCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // subMenuCompraReg
            // 
            this.subMenuCompraReg.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuCompraReg.IconColor = System.Drawing.Color.Black;
            this.subMenuCompraReg.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuCompraReg.Name = "subMenuCompraReg";
            this.subMenuCompraReg.Size = new System.Drawing.Size(129, 22);
            this.subMenuCompraReg.Text = "Registrar";
            this.subMenuCompraReg.Click += new System.EventHandler(this.subMenuCompraReg_Click);
            // 
            // subMenuCompraDet
            // 
            this.subMenuCompraDet.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuCompraDet.IconColor = System.Drawing.Color.Black;
            this.subMenuCompraDet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuCompraDet.Name = "subMenuCompraDet";
            this.subMenuCompraDet.Size = new System.Drawing.Size(129, 22);
            this.subMenuCompraDet.Text = "Ver Detalle";
            this.subMenuCompraDet.Click += new System.EventHandler(this.subMenuCompraDet_Click);
            // 
            // menuClientes
            // 
            this.menuClientes.AutoSize = false;
            this.menuClientes.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            this.menuClientes.IconColor = System.Drawing.Color.Black;
            this.menuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuClientes.IconSize = 60;
            this.menuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(80, 79);
            this.menuClientes.Text = "Clientes";
            this.menuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuClientes.Click += new System.EventHandler(this.menuClientes_Click);
            // 
            // menuProveedores
            // 
            this.menuProveedores.AutoSize = false;
            this.menuProveedores.IconChar = FontAwesome.Sharp.IconChar.Vcard;
            this.menuProveedores.IconColor = System.Drawing.Color.Black;
            this.menuProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuProveedores.IconSize = 60;
            this.menuProveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProveedores.Name = "menuProveedores";
            this.menuProveedores.Size = new System.Drawing.Size(80, 79);
            this.menuProveedores.Text = "Proveedores";
            this.menuProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuProveedores.Click += new System.EventHandler(this.menuProveedores_Click);
            // 
            // menuReportes
            // 
            this.menuReportes.AutoSize = false;
            this.menuReportes.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            this.menuReportes.IconColor = System.Drawing.Color.Black;
            this.menuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuReportes.IconSize = 60;
            this.menuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(122, 79);
            this.menuReportes.Text = "Reportes";
            this.menuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuReportes.Click += new System.EventHandler(this.menuReportes_Click);
            // 
            // menuAcercaDe
            // 
            this.menuAcercaDe.AutoSize = false;
            this.menuAcercaDe.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuAcercaDe.IconColor = System.Drawing.Color.Black;
            this.menuAcercaDe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuAcercaDe.IconSize = 60;
            this.menuAcercaDe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuAcercaDe.Name = "menuAcercaDe";
            this.menuAcercaDe.Size = new System.Drawing.Size(80, 79);
            this.menuAcercaDe.Text = "Acerca de";
            this.menuAcercaDe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.Color.DarkCyan;
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip2.Size = new System.Drawing.Size(1148, 68);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuTitulo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema de Ventas";
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 151);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(1148, 591);
            this.Contenedor.TabIndex = 3;
            // 
            // labelNombreUsuario
            // 
            this.labelNombreUsuario.AutoSize = true;
            this.labelNombreUsuario.BackColor = System.Drawing.Color.DarkCyan;
            this.labelNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreUsuario.Location = new System.Drawing.Point(913, 40);
            this.labelNombreUsuario.Name = "labelNombreUsuario";
            this.labelNombreUsuario.Size = new System.Drawing.Size(112, 15);
            this.labelNombreUsuario.TabIndex = 5;
            this.labelNombreUsuario.Tag = "";
            this.labelNombreUsuario.Text = "Nombre Usuario";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.BackColor = System.Drawing.Color.DarkCyan;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(913, 16);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(61, 15);
            this.labelUser.TabIndex = 6;
            this.labelUser.Tag = "";
            this.labelUser.Text = "Usuario:";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1148, 742);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelNombreUsuario);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccesCell";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem menuUsuarios;
        private FontAwesome.Sharp.IconMenuItem menuMantenedor;
        private FontAwesome.Sharp.IconMenuItem menuVentas;
        private FontAwesome.Sharp.IconMenuItem menuCompras;
        private FontAwesome.Sharp.IconMenuItem menuClientes;
        private FontAwesome.Sharp.IconMenuItem menuProveedores;
        private FontAwesome.Sharp.IconMenuItem menuReportes;
        private FontAwesome.Sharp.IconMenuItem menuAcercaDe;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Contenedor;
        private System.Windows.Forms.Label labelNombreUsuario;
        private System.Windows.Forms.Label labelUser;
        private FontAwesome.Sharp.IconMenuItem menuItemCategoria;
        private FontAwesome.Sharp.IconMenuItem menuItemProducto;
        private FontAwesome.Sharp.IconMenuItem subMenuVentaReg;
        private FontAwesome.Sharp.IconMenuItem subMenuVentaDet;
        private FontAwesome.Sharp.IconMenuItem subMenuCompraReg;
        private FontAwesome.Sharp.IconMenuItem subMenuCompraDet;
        private FontAwesome.Sharp.IconMenuItem subMenuUbicacion;
        private System.Windows.Forms.ToolStripMenuItem submenuNegocio;
    }
}

