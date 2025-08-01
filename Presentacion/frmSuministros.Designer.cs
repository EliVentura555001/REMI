namespace Presentacion
{
    partial class frmSuministros
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNSuministro = new System.Windows.Forms.Label();
            this.txtNSuministro = new System.Windows.Forms.TextBox();
            this.lblDSuministro = new System.Windows.Forms.Label();
            this.txtDSuministro = new System.Windows.Forms.TextBox();
            this.lblPSuministro = new System.Windows.Forms.Label();
            this.nudCSuministro = new System.Windows.Forms.NumericUpDown();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cbxPSuministro = new System.Windows.Forms.ComboBox();
            this.cbSuministro = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvSuministro = new System.Windows.Forms.DataGridView();
            this.cbxUnidadMedida = new System.Windows.Forms.ComboBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblUnidadMedida = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblExistencias = new System.Windows.Forms.Label();
            this.lblPresentacion = new System.Windows.Forms.Label();
            this.nudPresentacionSuministro = new System.Windows.Forms.NumericUpDown();
            this.txtESuministro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudCSuministro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuministro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPresentacionSuministro)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNSuministro
            // 
            this.lblNSuministro.AutoSize = true;
            this.lblNSuministro.Location = new System.Drawing.Point(24, 20);
            this.lblNSuministro.Name = "lblNSuministro";
            this.lblNSuministro.Size = new System.Drawing.Size(69, 24);
            this.lblNSuministro.TabIndex = 0;
            this.lblNSuministro.Text = "Nombre";
            // 
            // txtNSuministro
            // 
            this.txtNSuministro.Enabled = false;
            this.txtNSuministro.Location = new System.Drawing.Point(99, 14);
            this.txtNSuministro.Name = "txtNSuministro";
            this.txtNSuministro.Size = new System.Drawing.Size(275, 30);
            this.txtNSuministro.TabIndex = 1;
            // 
            // lblDSuministro
            // 
            this.lblDSuministro.AutoSize = true;
            this.lblDSuministro.Location = new System.Drawing.Point(409, 20);
            this.lblDSuministro.Name = "lblDSuministro";
            this.lblDSuministro.Size = new System.Drawing.Size(93, 24);
            this.lblDSuministro.TabIndex = 2;
            this.lblDSuministro.Text = "Descripcion";
            // 
            // txtDSuministro
            // 
            this.txtDSuministro.Enabled = false;
            this.txtDSuministro.Location = new System.Drawing.Point(508, 20);
            this.txtDSuministro.Name = "txtDSuministro";
            this.txtDSuministro.Size = new System.Drawing.Size(586, 30);
            this.txtDSuministro.TabIndex = 3;
            // 
            // lblPSuministro
            // 
            this.lblPSuministro.AutoSize = true;
            this.lblPSuministro.Location = new System.Drawing.Point(929, 72);
            this.lblPSuministro.Name = "lblPSuministro";
            this.lblPSuministro.Size = new System.Drawing.Size(55, 24);
            this.lblPSuministro.TabIndex = 4;
            this.lblPSuministro.Text = "Precio";
            // 
            // nudCSuministro
            // 
            this.nudCSuministro.DecimalPlaces = 2;
            this.nudCSuministro.Enabled = false;
            this.nudCSuministro.Location = new System.Drawing.Point(1004, 73);
            this.nudCSuministro.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.nudCSuministro.Name = "nudCSuministro";
            this.nudCSuministro.Size = new System.Drawing.Size(74, 30);
            this.nudCSuministro.TabIndex = 5;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(12, 126);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(85, 24);
            this.lblProveedor.TabIndex = 6;
            this.lblProveedor.Text = "Proveedor";
            // 
            // cbxPSuministro
            // 
            this.cbxPSuministro.Enabled = false;
            this.cbxPSuministro.FormattingEnabled = true;
            this.cbxPSuministro.Location = new System.Drawing.Point(103, 121);
            this.cbxPSuministro.Name = "cbxPSuministro";
            this.cbxPSuministro.Size = new System.Drawing.Size(191, 32);
            this.cbxPSuministro.TabIndex = 7;
            // 
            // cbSuministro
            // 
            this.cbSuministro.AutoSize = true;
            this.cbSuministro.Enabled = false;
            this.cbSuministro.Location = new System.Drawing.Point(322, 126);
            this.cbSuministro.Name = "cbSuministro";
            this.cbSuministro.Size = new System.Drawing.Size(83, 28);
            this.cbSuministro.TabIndex = 8;
            this.cbSuministro.Text = "Estado";
            this.cbSuministro.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbSuministro.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(726, 199);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 44);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(572, 199);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 44);
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(421, 199);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 44);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.FlatAppearance.BorderSize = 2;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(275, 199);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 44);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvSuministro
            // 
            this.dgvSuministro.AllowUserToAddRows = false;
            this.dgvSuministro.AllowUserToDeleteRows = false;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSuministro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvSuministro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuministro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSuministro.Location = new System.Drawing.Point(0, 270);
            this.dgvSuministro.Name = "dgvSuministro";
            this.dgvSuministro.ReadOnly = true;
            this.dgvSuministro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSuministro.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.dgvSuministro.RowHeadersWidth = 51;
            this.dgvSuministro.RowTemplate.Height = 24;
            this.dgvSuministro.Size = new System.Drawing.Size(1118, 405);
            this.dgvSuministro.TabIndex = 17;
            this.dgvSuministro.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuministro_CellDoubleClick);
            // 
            // cbxUnidadMedida
            // 
            this.cbxUnidadMedida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnidadMedida.Enabled = false;
            this.cbxUnidadMedida.FormattingEnabled = true;
            this.cbxUnidadMedida.Items.AddRange(new object[] {
            "Galon",
            "Gramo",
            "Kilo",
            "Libra",
            "Litro",
            "ml",
            "Onza"});
            this.cbxUnidadMedida.Location = new System.Drawing.Point(558, 73);
            this.cbxUnidadMedida.Name = "cbxUnidadMedida";
            this.cbxUnidadMedida.Size = new System.Drawing.Size(104, 32);
            this.cbxUnidadMedida.Sorted = true;
            this.cbxUnidadMedida.TabIndex = 18;
            // 
            // nudCantidad
            // 
            this.nudCantidad.DecimalPlaces = 2;
            this.nudCantidad.Enabled = false;
            this.nudCantidad.Location = new System.Drawing.Point(99, 70);
            this.nudCantidad.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(82, 30);
            this.nudCantidad.TabIndex = 19;
            this.nudCantidad.ValueChanged += new System.EventHandler(this.nudCantidad_ValueChanged);
            // 
            // lblUnidadMedida
            // 
            this.lblUnidadMedida.AutoSize = true;
            this.lblUnidadMedida.Location = new System.Drawing.Point(409, 72);
            this.lblUnidadMedida.Name = "lblUnidadMedida";
            this.lblUnidadMedida.Size = new System.Drawing.Size(143, 24);
            this.lblUnidadMedida.TabIndex = 20;
            this.lblUnidadMedida.Text = "Unidad de Medida";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(12, 70);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(75, 24);
            this.lblCantidad.TabIndex = 21;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblExistencias
            // 
            this.lblExistencias.AutoSize = true;
            this.lblExistencias.Location = new System.Drawing.Point(709, 70);
            this.lblExistencias.Name = "lblExistencias";
            this.lblExistencias.Size = new System.Drawing.Size(91, 24);
            this.lblExistencias.TabIndex = 22;
            this.lblExistencias.Text = "Existencias";
            // 
            // lblPresentacion
            // 
            this.lblPresentacion.AutoSize = true;
            this.lblPresentacion.Location = new System.Drawing.Point(200, 70);
            this.lblPresentacion.Name = "lblPresentacion";
            this.lblPresentacion.Size = new System.Drawing.Size(104, 24);
            this.lblPresentacion.TabIndex = 23;
            this.lblPresentacion.Text = "Presentacion";
            // 
            // nudPresentacionSuministro
            // 
            this.nudPresentacionSuministro.DecimalPlaces = 2;
            this.nudPresentacionSuministro.Enabled = false;
            this.nudPresentacionSuministro.Location = new System.Drawing.Point(322, 73);
            this.nudPresentacionSuministro.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.nudPresentacionSuministro.Name = "nudPresentacionSuministro";
            this.nudPresentacionSuministro.Size = new System.Drawing.Size(69, 30);
            this.nudPresentacionSuministro.TabIndex = 24;
            this.nudPresentacionSuministro.ValueChanged += new System.EventHandler(this.nudPresentacionSuministro_ValueChanged);
            // 
            // txtESuministro
            // 
            this.txtESuministro.Enabled = false;
            this.txtESuministro.Location = new System.Drawing.Point(830, 70);
            this.txtESuministro.Name = "txtESuministro";
            this.txtESuministro.Size = new System.Drawing.Size(77, 30);
            this.txtESuministro.TabIndex = 25;
            // 
            // frmSuministros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 675);
            this.Controls.Add(this.txtESuministro);
            this.Controls.Add(this.nudPresentacionSuministro);
            this.Controls.Add(this.lblPresentacion);
            this.Controls.Add(this.lblExistencias);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblUnidadMedida);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.cbxUnidadMedida);
            this.Controls.Add(this.dgvSuministro);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.cbSuministro);
            this.Controls.Add(this.cbxPSuministro);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.nudCSuministro);
            this.Controls.Add(this.lblPSuministro);
            this.Controls.Add(this.txtDSuministro);
            this.Controls.Add(this.lblDSuministro);
            this.Controls.Add(this.txtNSuministro);
            this.Controls.Add(this.lblNSuministro);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmSuministros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suministros";
            this.Load += new System.EventHandler(this.frmSuministros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCSuministro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuministro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPresentacionSuministro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNSuministro;
        private System.Windows.Forms.TextBox txtNSuministro;
        private System.Windows.Forms.Label lblDSuministro;
        private System.Windows.Forms.TextBox txtDSuministro;
        private System.Windows.Forms.Label lblPSuministro;
        private System.Windows.Forms.NumericUpDown nudCSuministro;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cbxPSuministro;
        private System.Windows.Forms.CheckBox cbSuministro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvSuministro;
        private System.Windows.Forms.ComboBox cbxUnidadMedida;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblUnidadMedida;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblExistencias;
        private System.Windows.Forms.Label lblPresentacion;
        private System.Windows.Forms.NumericUpDown nudPresentacionSuministro;
        private System.Windows.Forms.TextBox txtESuministro;
    }
}