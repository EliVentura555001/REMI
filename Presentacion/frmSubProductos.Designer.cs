namespace Presentacion
{
    partial class frmSubProductos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.cbSubProducto = new System.Windows.Forms.CheckBox();
            this.lblCSubProducto = new System.Windows.Forms.Label();
            this.txtDSubProducto = new System.Windows.Forms.TextBox();
            this.lblDSubProducto = new System.Windows.Forms.Label();
            this.txtNSubProducto = new System.Windows.Forms.TextBox();
            this.lblNSubProducto = new System.Windows.Forms.Label();
            this.dgvSubProducto = new System.Windows.Forms.DataGridView();
            this.txtCSubProducto = new System.Windows.Forms.TextBox();
            this.lblInstruc = new System.Windows.Forms.Label();
            this.txtISubProductos = new System.Windows.Forms.TextBox();
            this.btnSuministro = new System.Windows.Forms.Button();
            this.dgvSuministroSP = new System.Windows.Forms.DataGridView();
            this.lblTituloSP = new System.Windows.Forms.Label();
            this.lblSUnidadMedida = new System.Windows.Forms.Label();
            this.txtCSuministro = new System.Windows.Forms.TextBox();
            this.lblCantidadS = new System.Windows.Forms.Label();
            this.lblSDetalleSP = new System.Windows.Forms.Label();
            this.cbxSDetalleSP = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSUnidadMedida = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPSubProducto = new System.Windows.Forms.TextBox();
            this.lblPSubProducto = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cbxCategoriaSP = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuministroSP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(0, 188);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 31);
            this.btnCancelar.TabIndex = 29;
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
            this.btnModificar.Location = new System.Drawing.Point(0, 132);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 31);
            this.btnModificar.TabIndex = 28;
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
            this.btnGuardar.Location = new System.Drawing.Point(0, 74);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 31);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.FlatAppearance.BorderSize = 2;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(0, 29);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 31);
            this.btnNuevo.TabIndex = 26;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cbSubProducto
            // 
            this.cbSubProducto.AutoSize = true;
            this.cbSubProducto.Enabled = false;
            this.cbSubProducto.Location = new System.Drawing.Point(1291, 73);
            this.cbSubProducto.Name = "cbSubProducto";
            this.cbSubProducto.Size = new System.Drawing.Size(83, 28);
            this.cbSubProducto.TabIndex = 25;
            this.cbSubProducto.Text = "Estado";
            this.cbSubProducto.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbSubProducto.UseVisualStyleBackColor = true;
            // 
            // lblCSubProducto
            // 
            this.lblCSubProducto.AutoSize = true;
            this.lblCSubProducto.Location = new System.Drawing.Point(992, 74);
            this.lblCSubProducto.Name = "lblCSubProducto";
            this.lblCSubProducto.Size = new System.Drawing.Size(94, 24);
            this.lblCSubProducto.TabIndex = 21;
            this.lblCSubProducto.Text = "Costo Total";
            // 
            // txtDSubProducto
            // 
            this.txtDSubProducto.Enabled = false;
            this.txtDSubProducto.Location = new System.Drawing.Point(529, 8);
            this.txtDSubProducto.Name = "txtDSubProducto";
            this.txtDSubProducto.Size = new System.Drawing.Size(448, 30);
            this.txtDSubProducto.TabIndex = 20;
            // 
            // lblDSubProducto
            // 
            this.lblDSubProducto.AutoSize = true;
            this.lblDSubProducto.Location = new System.Drawing.Point(416, 11);
            this.lblDSubProducto.Name = "lblDSubProducto";
            this.lblDSubProducto.Size = new System.Drawing.Size(93, 24);
            this.lblDSubProducto.TabIndex = 19;
            this.lblDSubProducto.Text = "Descripcion";
            // 
            // txtNSubProducto
            // 
            this.txtNSubProducto.Enabled = false;
            this.txtNSubProducto.Location = new System.Drawing.Point(117, 5);
            this.txtNSubProducto.Name = "txtNSubProducto";
            this.txtNSubProducto.Size = new System.Drawing.Size(275, 30);
            this.txtNSubProducto.TabIndex = 18;
            // 
            // lblNSubProducto
            // 
            this.lblNSubProducto.AutoSize = true;
            this.lblNSubProducto.Location = new System.Drawing.Point(17, 11);
            this.lblNSubProducto.Name = "lblNSubProducto";
            this.lblNSubProducto.Size = new System.Drawing.Size(69, 24);
            this.lblNSubProducto.TabIndex = 17;
            this.lblNSubProducto.Text = "Nombre";
            // 
            // dgvSubProducto
            // 
            this.dgvSubProducto.AllowUserToAddRows = false;
            this.dgvSubProducto.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSubProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubProducto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSubProducto.Location = new System.Drawing.Point(0, 433);
            this.dgvSubProducto.Name = "dgvSubProducto";
            this.dgvSubProducto.ReadOnly = true;
            this.dgvSubProducto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSubProducto.RowHeadersWidth = 51;
            this.dgvSubProducto.RowTemplate.Height = 24;
            this.dgvSubProducto.Size = new System.Drawing.Size(1386, 318);
            this.dgvSubProducto.TabIndex = 34;
            this.dgvSubProducto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubProducto_CellDoubleClick);
            // 
            // txtCSubProducto
            // 
            this.txtCSubProducto.Enabled = false;
            this.txtCSubProducto.Location = new System.Drawing.Point(1092, 71);
            this.txtCSubProducto.Name = "txtCSubProducto";
            this.txtCSubProducto.Size = new System.Drawing.Size(48, 30);
            this.txtCSubProducto.TabIndex = 32;
            // 
            // lblInstruc
            // 
            this.lblInstruc.AutoSize = true;
            this.lblInstruc.Location = new System.Drawing.Point(6, 64);
            this.lblInstruc.Name = "lblInstruc";
            this.lblInstruc.Size = new System.Drawing.Size(105, 24);
            this.lblInstruc.TabIndex = 33;
            this.lblInstruc.Text = "Instrucciones";
            // 
            // txtISubProductos
            // 
            this.txtISubProductos.Enabled = false;
            this.txtISubProductos.Location = new System.Drawing.Point(117, 44);
            this.txtISubProductos.Multiline = true;
            this.txtISubProductos.Name = "txtISubProductos";
            this.txtISubProductos.Size = new System.Drawing.Size(860, 65);
            this.txtISubProductos.TabIndex = 30;
            // 
            // btnSuministro
            // 
            this.btnSuministro.Enabled = false;
            this.btnSuministro.FlatAppearance.BorderSize = 2;
            this.btnSuministro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSuministro.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuministro.Location = new System.Drawing.Point(18, 156);
            this.btnSuministro.Name = "btnSuministro";
            this.btnSuministro.Size = new System.Drawing.Size(129, 31);
            this.btnSuministro.TabIndex = 35;
            this.btnSuministro.Text = "Agregar";
            this.btnSuministro.UseVisualStyleBackColor = true;
            this.btnSuministro.Click += new System.EventHandler(this.btnSuministro_Click);
            // 
            // dgvSuministroSP
            // 
            this.dgvSuministroSP.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSuministroSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSuministroSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuministroSP.Enabled = false;
            this.dgvSuministroSP.Location = new System.Drawing.Point(431, 5);
            this.dgvSuministroSP.Name = "dgvSuministroSP";
            this.dgvSuministroSP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSuministroSP.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSuministroSP.RowHeadersWidth = 51;
            this.dgvSuministroSP.RowTemplate.Height = 24;
            this.dgvSuministroSP.Size = new System.Drawing.Size(738, 237);
            this.dgvSuministroSP.TabIndex = 36;
            this.dgvSuministroSP.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuministroSP_CellValueChanged);
            this.dgvSuministroSP.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvSuministroSP_RowsRemoved);
            // 
            // lblTituloSP
            // 
            this.lblTituloSP.AutoSize = true;
            this.lblTituloSP.Location = new System.Drawing.Point(619, 393);
            this.lblTituloSP.Name = "lblTituloSP";
            this.lblTituloSP.Size = new System.Drawing.Size(176, 24);
            this.lblTituloSP.TabIndex = 37;
            this.lblTituloSP.Text = "Subproductos Creados";
            // 
            // lblSUnidadMedida
            // 
            this.lblSUnidadMedida.AutoSize = true;
            this.lblSUnidadMedida.Location = new System.Drawing.Point(193, 104);
            this.lblSUnidadMedida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSUnidadMedida.Name = "lblSUnidadMedida";
            this.lblSUnidadMedida.Size = new System.Drawing.Size(143, 24);
            this.lblSUnidadMedida.TabIndex = 43;
            this.lblSUnidadMedida.Text = "Unidad de Medida";
            // 
            // txtCSuministro
            // 
            this.txtCSuministro.Enabled = false;
            this.txtCSuministro.Location = new System.Drawing.Point(95, 101);
            this.txtCSuministro.Name = "txtCSuministro";
            this.txtCSuministro.Size = new System.Drawing.Size(82, 30);
            this.txtCSuministro.TabIndex = 41;
            // 
            // lblCantidadS
            // 
            this.lblCantidadS.AutoSize = true;
            this.lblCantidadS.Location = new System.Drawing.Point(14, 104);
            this.lblCantidadS.Name = "lblCantidadS";
            this.lblCantidadS.Size = new System.Drawing.Size(75, 24);
            this.lblCantidadS.TabIndex = 40;
            this.lblCantidadS.Text = "Cantidad";
            // 
            // lblSDetalleSP
            // 
            this.lblSDetalleSP.AutoSize = true;
            this.lblSDetalleSP.Location = new System.Drawing.Point(11, 65);
            this.lblSDetalleSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSDetalleSP.Name = "lblSDetalleSP";
            this.lblSDetalleSP.Size = new System.Drawing.Size(99, 24);
            this.lblSDetalleSP.TabIndex = 39;
            this.lblSDetalleSP.Text = "Ingredientes";
            // 
            // cbxSDetalleSP
            // 
            this.cbxSDetalleSP.Enabled = false;
            this.cbxSDetalleSP.FormattingEnabled = true;
            this.cbxSDetalleSP.Location = new System.Drawing.Point(118, 62);
            this.cbxSDetalleSP.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSDetalleSP.Name = "cbxSDetalleSP";
            this.cbxSDetalleSP.Size = new System.Drawing.Size(307, 32);
            this.cbxSDetalleSP.TabIndex = 38;
            this.cbxSDetalleSP.SelectionChangeCommitted += new System.EventHandler(this.cbxSDetalleSP_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSUnidadMedida);
            this.groupBox1.Controls.Add(this.txtCSuministro);
            this.groupBox1.Controls.Add(this.dgvSuministroSP);
            this.groupBox1.Controls.Add(this.lblSUnidadMedida);
            this.groupBox1.Controls.Add(this.btnSuministro);
            this.groupBox1.Controls.Add(this.cbxSDetalleSP);
            this.groupBox1.Controls.Add(this.lblCantidadS);
            this.groupBox1.Controls.Add(this.lblSDetalleSP);
            this.groupBox1.Location = new System.Drawing.Point(205, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1187, 244);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Ingredientes";
            // 
            // txtSUnidadMedida
            // 
            this.txtSUnidadMedida.Enabled = false;
            this.txtSUnidadMedida.Location = new System.Drawing.Point(343, 105);
            this.txtSUnidadMedida.Name = "txtSUnidadMedida";
            this.txtSUnidadMedida.Size = new System.Drawing.Size(82, 30);
            this.txtSUnidadMedida.TabIndex = 44;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnNuevo);
            this.groupBox3.Controls.Add(this.btnGuardar);
            this.groupBox3.Controls.Add(this.btnModificar);
            this.groupBox3.Controls.Add(this.btnCancelar);
            this.groupBox3.Location = new System.Drawing.Point(12, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 237);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            // 
            // txtPSubProducto
            // 
            this.txtPSubProducto.Enabled = false;
            this.txtPSubProducto.Location = new System.Drawing.Point(1219, 71);
            this.txtPSubProducto.Name = "txtPSubProducto";
            this.txtPSubProducto.Size = new System.Drawing.Size(56, 30);
            this.txtPSubProducto.TabIndex = 47;
            // 
            // lblPSubProducto
            // 
            this.lblPSubProducto.AutoSize = true;
            this.lblPSubProducto.Location = new System.Drawing.Point(1158, 74);
            this.lblPSubProducto.Name = "lblPSubProducto";
            this.lblPSubProducto.Size = new System.Drawing.Size(55, 24);
            this.lblPSubProducto.TabIndex = 46;
            this.lblPSubProducto.Text = "Precio";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(992, 11);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(80, 24);
            this.lblCategoria.TabIndex = 48;
            this.lblCategoria.Text = "Categoria";
            // 
            // cbxCategoriaSP
            // 
            this.cbxCategoriaSP.Enabled = false;
            this.cbxCategoriaSP.FormattingEnabled = true;
            this.cbxCategoriaSP.Location = new System.Drawing.Point(1079, 5);
            this.cbxCategoriaSP.Margin = new System.Windows.Forms.Padding(4);
            this.cbxCategoriaSP.Name = "cbxCategoriaSP";
            this.cbxCategoriaSP.Size = new System.Drawing.Size(289, 32);
            this.cbxCategoriaSP.TabIndex = 45;
            // 
            // frmSubProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 751);
            this.Controls.Add(this.cbxCategoriaSP);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtPSubProducto);
            this.Controls.Add(this.lblPSubProducto);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtISubProductos);
            this.Controls.Add(this.lblInstruc);
            this.Controls.Add(this.lblTituloSP);
            this.Controls.Add(this.txtCSubProducto);
            this.Controls.Add(this.dgvSubProducto);
            this.Controls.Add(this.cbSubProducto);
            this.Controls.Add(this.lblCSubProducto);
            this.Controls.Add(this.txtDSubProducto);
            this.Controls.Add(this.lblDSubProducto);
            this.Controls.Add(this.txtNSubProducto);
            this.Controls.Add(this.lblNSubProducto);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmSubProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubProductos";
            this.Load += new System.EventHandler(this.frmSubProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuministroSP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.CheckBox cbSubProducto;
        private System.Windows.Forms.Label lblCSubProducto;
        private System.Windows.Forms.TextBox txtDSubProducto;
        private System.Windows.Forms.Label lblDSubProducto;
        private System.Windows.Forms.TextBox txtNSubProducto;
        private System.Windows.Forms.Label lblNSubProducto;
        private System.Windows.Forms.TextBox txtCSubProducto;
        private System.Windows.Forms.DataGridView dgvSubProducto;
        private System.Windows.Forms.Label lblInstruc;
        private System.Windows.Forms.TextBox txtISubProductos;
        private System.Windows.Forms.Button btnSuministro;
        private System.Windows.Forms.DataGridView dgvSuministroSP;
        private System.Windows.Forms.Label lblTituloSP;
        private System.Windows.Forms.Label lblSUnidadMedida;
        private System.Windows.Forms.TextBox txtCSuministro;
        private System.Windows.Forms.Label lblCantidadS;
        private System.Windows.Forms.Label lblSDetalleSP;
        private System.Windows.Forms.ComboBox cbxSDetalleSP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSUnidadMedida;
        private System.Windows.Forms.TextBox txtPSubProducto;
        private System.Windows.Forms.Label lblPSubProducto;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cbxCategoriaSP;
    }
}