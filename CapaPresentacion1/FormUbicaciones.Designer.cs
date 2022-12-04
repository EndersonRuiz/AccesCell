namespace CapaPresentacion1
{
    partial class FormUbicaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLimpiarBuscar = new FontAwesome.Sharp.IconButton();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.txtIdTabla = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvTabla = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.txtEstante = new System.Windows.Forms.TextBox();
            this.txt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeccion = new System.Windows.Forms.TextBox();
            this.btnSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IdUbicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreEstante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbBuscar = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion1.Properties.Resources.cel;
            this.pictureBox1.Location = new System.Drawing.Point(38, 398);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 98;
            this.pictureBox1.TabStop = false;
            // 
            // btnLimpiarBuscar
            // 
            this.btnLimpiarBuscar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiarBuscar.IconColor = System.Drawing.Color.Black;
            this.btnLimpiarBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiarBuscar.IconSize = 18;
            this.btnLimpiarBuscar.Location = new System.Drawing.Point(774, 104);
            this.btnLimpiarBuscar.Name = "btnLimpiarBuscar";
            this.btnLimpiarBuscar.Size = new System.Drawing.Size(31, 23);
            this.btnLimpiarBuscar.TabIndex = 97;
            this.btnLimpiarBuscar.UseVisualStyleBackColor = true;
            this.btnLimpiarBuscar.Click += new System.EventHandler(this.btnLimpiarBuscar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 18;
            this.btnBuscar.Location = new System.Drawing.Point(735, 104);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(33, 23);
            this.btnBuscar.TabIndex = 96;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtIdTabla
            // 
            this.txtIdTabla.Location = new System.Drawing.Point(257, 31);
            this.txtIdTabla.Name = "txtIdTabla";
            this.txtIdTabla.Size = new System.Drawing.Size(26, 20);
            this.txtIdTabla.TabIndex = 95;
            this.txtIdTabla.Text = "-1";
            this.txtIdTabla.Visible = false;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(301, 31);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(26, 20);
            this.txtId.TabIndex = 94;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(564, 85);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(119, 15);
            this.label16.TabIndex = 93;
            this.label16.Text = "Buscar Ubicacion";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(567, 104);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(150, 20);
            this.txtBuscar.TabIndex = 92;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(385, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(740, 31);
            this.label15.TabIndex = 91;
            this.label15.Text = "Lista de Ubicaciones";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvTabla
            // 
            this.dgvTabla.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSeleccionar,
            this.IdUbicacion,
            this.NombreEstante,
            this.Seccion});
            this.dgvTabla.Location = new System.Drawing.Point(385, 140);
            this.dgvTabla.MultiSelect = false;
            this.dgvTabla.Name = "dgvTabla";
            this.dgvTabla.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvTabla.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTabla.Size = new System.Drawing.Size(740, 436);
            this.dgvTabla.TabIndex = 90;
            this.dgvTabla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTabla_CellContentClick);
            this.dgvTabla.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvTabla_CellPainting);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.SteelBlue;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(68, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(238, 24);
            this.label14.TabIndex = 89;
            this.label14.Text = "Registro de Ubicaciones";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Maroon;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 35;
            this.btnEliminar.Location = new System.Drawing.Point(38, 319);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(1);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(292, 38);
            this.btnEliminar.TabIndex = 88;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Navy;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLimpiar.FlatAppearance.BorderSize = 2;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiar.IconColor = System.Drawing.Color.White;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 35;
            this.btnLimpiar.Location = new System.Drawing.Point(38, 259);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(292, 39);
            this.btnLimpiar.TabIndex = 87;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 35;
            this.btnGuardar.Location = new System.Drawing.Point(38, 200);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(292, 42);
            this.btnGuardar.TabIndex = 86;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtEstante
            // 
            this.txtEstante.Location = new System.Drawing.Point(38, 87);
            this.txtEstante.Name = "txtEstante";
            this.txtEstante.Size = new System.Drawing.Size(292, 20);
            this.txtEstante.TabIndex = 85;
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.BackColor = System.Drawing.Color.SteelBlue;
            this.txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt.Location = new System.Drawing.Point(35, 71);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(114, 15);
            this.txt.TabIndex = 84;
            this.txt.Text = "Nombre Estante:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(359, 588);
            this.label2.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(35, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 99;
            this.label1.Text = "Nombre Seccion";
            // 
            // txtSeccion
            // 
            this.txtSeccion.Location = new System.Drawing.Point(38, 146);
            this.txtSeccion.Name = "txtSeccion";
            this.txtSeccion.Size = new System.Drawing.Size(292, 20);
            this.txtSeccion.TabIndex = 100;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.DataPropertyName = "btnSeleccionar";
            this.btnSeleccionar.HeaderText = "";
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.ReadOnly = true;
            this.btnSeleccionar.Width = 50;
            // 
            // IdUbicacion
            // 
            this.IdUbicacion.DataPropertyName = "IdUbicacion";
            this.IdUbicacion.HeaderText = "Id";
            this.IdUbicacion.Name = "IdUbicacion";
            this.IdUbicacion.ReadOnly = true;
            // 
            // NombreEstante
            // 
            this.NombreEstante.HeaderText = "Nombre Estante";
            this.NombreEstante.Name = "NombreEstante";
            this.NombreEstante.ReadOnly = true;
            this.NombreEstante.Width = 295;
            // 
            // Seccion
            // 
            this.Seccion.HeaderText = "Nombre Seccion";
            this.Seccion.Name = "Seccion";
            this.Seccion.ReadOnly = true;
            this.Seccion.Width = 250;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(385, 85);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(103, 15);
            this.label17.TabIndex = 102;
            this.label17.Text = "Tipo Busqueda";
            // 
            // cmbBuscar
            // 
            this.cmbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBuscar.FormattingEnabled = true;
            this.cmbBuscar.Location = new System.Drawing.Point(388, 103);
            this.cmbBuscar.Name = "cmbBuscar";
            this.cmbBuscar.Size = new System.Drawing.Size(148, 23);
            this.cmbBuscar.TabIndex = 101;
            // 
            // FormUbicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 588);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbBuscar);
            this.Controls.Add(this.txtSeccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLimpiarBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtIdTabla);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dgvTabla);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtEstante);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "FormUbicaciones";
            this.Text = "FormUbicaciones";
            this.Load += new System.EventHandler(this.FormUbicaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnLimpiarBuscar;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.TextBox txtIdTabla;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgvTabla;
        private System.Windows.Forms.Label label14;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.TextBox txtEstante;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSeccion;
        private System.Windows.Forms.DataGridViewButtonColumn btnSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUbicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreEstante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seccion;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbBuscar;
    }
}