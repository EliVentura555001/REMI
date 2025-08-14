namespace Presentacion
{
    partial class frmProductos
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
            this.lblTituloP = new System.Windows.Forms.Label();
            this.dgvSubProductos = new System.Windows.Forms.DataGridView();
            this.btnSubProducto = new System.Windows.Forms.Button();
            this.cbxDetalleSP = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCantidadSP = new System.Windows.Forms.TextBox();
            this.lblCantidadSP = new System.Windows.Forms.Label();
            this.lblDetalleSP = new System.Windows.Forms.Label();
            this.dgvProducto = new System.Windows.Forms.DataGridView();
            this.cbProducto = new System.Windows.Forms.CheckBox();
            this.txtCProducto = new System.Windows.Forms.TextBox();
            this.lblCProducto = new System.Windows.Forms.Label();
            this.txtDProducto = new System.Windows.Forms.TextBox();
            this.lblDProducto = new System.Windows.Forms.Label();
            this.txtNProducto = new System.Windows.Forms.TextBox();
            this.lblNProducto = new System.Windows.Forms.Label();
            this.lblCatProducto = new System.Windows.Forms.Label();
            this.cbxCategoria = new System.Windows.Forms.ComboBox();
            this.txtPProducto = new System.Windows.Forms.TextBox();
            this.lblPProducto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubProductos)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloP
            // 
            this.lblTituloP.AutoSize = true;
            this.lblTituloP.Location = new System.Drawing.Point(616, 375);
            this.lblTituloP.Name = "lblTituloP";
            this.lblTituloP.Size = new System.Drawing.Size(180, 23);
            this.lblTituloP.TabIndex = 56;
            this.lblTituloP.Text = "Productos Creados";
            // 
            // dgvSubProductos
            // 
            this.dgvSubProductos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSubProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubProductos.Enabled = false;
            this.dgvSubProductos.Location = new System.Drawing.Point(434, 5);
            this.dgvSubProductos.Name = "dgvSubProductos";
            this.dgvSubProductos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSubProductos.RowHeadersWidth = 51;
            this.dgvSubProductos.RowTemplate.Height = 24;
            this.dgvSubProductos.Size = new System.Drawing.Size(738, 231);
            this.dgvSubProductos.TabIndex = 36;
            this.dgvSubProductos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubProductos_CellValueChanged);
            this.dgvSubProductos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvSubProductos_RowsRemoved);
            // 
            // btnSubProducto
            // 
            this.btnSubProducto.Enabled = false;
            this.btnSubProducto.FlatAppearance.BorderSize = 2;
            this.btnSubProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubProducto.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubProducto.Location = new System.Drawing.Point(15, 165);
            this.btnSubProducto.Name = "btnSubProducto";
            this.btnSubProducto.Size = new System.Drawing.Size(129, 31);
            this.btnSubProducto.TabIndex = 35;
            this.btnSubProducto.Text = "Agregar";
            this.btnSubProducto.UseVisualStyleBackColor = true;
            this.btnSubProducto.Click += new System.EventHandler(this.btnSubProducto_Click);
            // 
            // cbxDetalleSP
            // 
            this.cbxDetalleSP.Enabled = false;
            this.cbxDetalleSP.FormattingEnabled = true;
            this.cbxDetalleSP.Location = new System.Drawing.Point(150, 62);
            this.cbxDetalleSP.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDetalleSP.Name = "cbxDetalleSP";
            this.cbxDetalleSP.Size = new System.Drawing.Size(275, 31);
            this.cbxDetalleSP.TabIndex = 38;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnNuevo);
            this.groupBox3.Controls.Add(this.btnGuardar);
            this.groupBox3.Controls.Add(this.btnModificar);
            this.groupBox3.Controls.Add(this.btnCancelar);
            this.groupBox3.Location = new System.Drawing.Point(9, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 237);
            this.groupBox3.TabIndex = 58;
            this.groupBox3.TabStop = false;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCantidadSP);
            this.groupBox1.Controls.Add(this.lblCantidadSP);
            this.groupBox1.Controls.Add(this.dgvSubProductos);
            this.groupBox1.Controls.Add(this.btnSubProducto);
            this.groupBox1.Controls.Add(this.cbxDetalleSP);
            this.groupBox1.Controls.Add(this.lblDetalleSP);
            this.groupBox1.Location = new System.Drawing.Point(202, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1187, 242);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Contenido";
            // 
            // txtCantidadSP
            // 
            this.txtCantidadSP.Enabled = false;
            this.txtCantidadSP.Location = new System.Drawing.Point(148, 113);
            this.txtCantidadSP.Name = "txtCantidadSP";
            this.txtCantidadSP.Size = new System.Drawing.Size(82, 30);
            this.txtCantidadSP.TabIndex = 45;
            // 
            // lblCantidadSP
            // 
            this.lblCantidadSP.AutoSize = true;
            this.lblCantidadSP.Location = new System.Drawing.Point(54, 116);
            this.lblCantidadSP.Name = "lblCantidadSP";
            this.lblCantidadSP.Size = new System.Drawing.Size(88, 23);
            this.lblCantidadSP.TabIndex = 44;
            this.lblCantidadSP.Text = "Cantidad";
            // 
            // lblDetalleSP
            // 
            this.lblDetalleSP.AutoSize = true;
            this.lblDetalleSP.Location = new System.Drawing.Point(11, 65);
            this.lblDetalleSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetalleSP.Name = "lblDetalleSP";
            this.lblDetalleSP.Size = new System.Drawing.Size(131, 23);
            this.lblDetalleSP.TabIndex = 39;
            this.lblDetalleSP.Text = "Subproductos";
            // 
            // dgvProducto
            // 
            this.dgvProducto.AllowUserToAddRows = false;
            this.dgvProducto.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProducto.Location = new System.Drawing.Point(0, 413);
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.ReadOnly = true;
            this.dgvProducto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProducto.RowHeadersWidth = 51;
            this.dgvProducto.RowTemplate.Height = 24;
            this.dgvProducto.Size = new System.Drawing.Size(1386, 323);
            this.dgvProducto.TabIndex = 55;
            this.dgvProducto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducto_CellDoubleClick);
            // 
            // cbProducto
            // 
            this.cbProducto.AutoSize = true;
            this.cbProducto.Enabled = false;
            this.cbProducto.Location = new System.Drawing.Point(1000, 65);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(94, 27);
            this.cbProducto.TabIndex = 53;
            this.cbProducto.Text = "Estado";
            this.cbProducto.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbProducto.UseVisualStyleBackColor = true;
            // 
            // txtCProducto
            // 
            this.txtCProducto.Enabled = false;
            this.txtCProducto.Location = new System.Drawing.Point(529, 60);
            this.txtCProducto.Name = "txtCProducto";
            this.txtCProducto.Size = new System.Drawing.Size(82, 30);
            this.txtCProducto.TabIndex = 54;
            // 
            // lblCProducto
            // 
            this.lblCProducto.AutoSize = true;
            this.lblCProducto.Location = new System.Drawing.Point(413, 60);
            this.lblCProducto.Name = "lblCProducto";
            this.lblCProducto.Size = new System.Drawing.Size(110, 23);
            this.lblCProducto.TabIndex = 52;
            this.lblCProducto.Text = "Costo Total";
            // 
            // txtDProducto
            // 
            this.txtDProducto.Enabled = false;
            this.txtDProducto.Location = new System.Drawing.Point(526, 6);
            this.txtDProducto.Name = "txtDProducto";
            this.txtDProducto.Size = new System.Drawing.Size(568, 30);
            this.txtDProducto.TabIndex = 51;
            // 
            // lblDProducto
            // 
            this.lblDProducto.AutoSize = true;
            this.lblDProducto.Location = new System.Drawing.Point(413, 9);
            this.lblDProducto.Name = "lblDProducto";
            this.lblDProducto.Size = new System.Drawing.Size(112, 23);
            this.lblDProducto.TabIndex = 50;
            this.lblDProducto.Text = "Descripcion";
            // 
            // txtNProducto
            // 
            this.txtNProducto.Enabled = false;
            this.txtNProducto.Location = new System.Drawing.Point(114, 3);
            this.txtNProducto.Name = "txtNProducto";
            this.txtNProducto.Size = new System.Drawing.Size(275, 30);
            this.txtNProducto.TabIndex = 49;
            // 
            // lblNProducto
            // 
            this.lblNProducto.AutoSize = true;
            this.lblNProducto.Location = new System.Drawing.Point(14, 9);
            this.lblNProducto.Name = "lblNProducto";
            this.lblNProducto.Size = new System.Drawing.Size(79, 23);
            this.lblNProducto.TabIndex = 48;
            this.lblNProducto.Text = "Nombre";
            // 
            // lblCatProducto
            // 
            this.lblCatProducto.AutoSize = true;
            this.lblCatProducto.Location = new System.Drawing.Point(12, 62);
            this.lblCatProducto.Name = "lblCatProducto";
            this.lblCatProducto.Size = new System.Drawing.Size(96, 23);
            this.lblCatProducto.TabIndex = 61;
            this.lblCatProducto.Text = "Categoria";
            // 
            // cbxCategoria
            // 
            this.cbxCategoria.Enabled = false;
            this.cbxCategoria.FormattingEnabled = true;
            this.cbxCategoria.Location = new System.Drawing.Point(114, 57);
            this.cbxCategoria.Name = "cbxCategoria";
            this.cbxCategoria.Size = new System.Drawing.Size(186, 31);
            this.cbxCategoria.TabIndex = 62;
            // 
            // txtPProducto
            // 
            this.txtPProducto.Enabled = false;
            this.txtPProducto.Location = new System.Drawing.Point(764, 57);
            this.txtPProducto.Name = "txtPProducto";
            this.txtPProducto.Size = new System.Drawing.Size(75, 30);
            this.txtPProducto.TabIndex = 60;
            // 
            // lblPProducto
            // 
            this.lblPProducto.AutoSize = true;
            this.lblPProducto.Location = new System.Drawing.Point(696, 62);
            this.lblPProducto.Name = "lblPProducto";
            this.lblPProducto.Size = new System.Drawing.Size(66, 23);
            this.lblPProducto.TabIndex = 59;
            this.lblPProducto.Text = "Precio";
            // 
            // frmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 736);
            this.Controls.Add(this.cbxCategoria);
            this.Controls.Add(this.lblCatProducto);
            this.Controls.Add(this.lblTituloP);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvProducto);
            this.Controls.Add(this.cbProducto);
            this.Controls.Add(this.lblPProducto);
            this.Controls.Add(this.txtPProducto);
            this.Controls.Add(this.txtCProducto);
            this.Controls.Add(this.lblCProducto);
            this.Controls.Add(this.txtDProducto);
            this.Controls.Add(this.lblDProducto);
            this.Controls.Add(this.txtNProducto);
            this.Controls.Add(this.lblNProducto);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProductos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.frmProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubProductos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloP;
        private System.Windows.Forms.DataGridView dgvSubProductos;
        private System.Windows.Forms.Button btnSubProducto;
        private System.Windows.Forms.ComboBox cbxDetalleSP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDetalleSP;
        private System.Windows.Forms.DataGridView dgvProducto;
        private System.Windows.Forms.CheckBox cbProducto;
        private System.Windows.Forms.TextBox txtCProducto;
        private System.Windows.Forms.Label lblCProducto;
        private System.Windows.Forms.TextBox txtDProducto;
        private System.Windows.Forms.Label lblDProducto;
        private System.Windows.Forms.TextBox txtNProducto;
        private System.Windows.Forms.Label lblNProducto;
        private System.Windows.Forms.Label lblCatProducto;
        private System.Windows.Forms.ComboBox cbxCategoria;
        private System.Windows.Forms.TextBox txtPProducto;
        private System.Windows.Forms.Label lblPProducto;
        private System.Windows.Forms.TextBox txtCantidadSP;
        private System.Windows.Forms.Label lblCantidadSP;
    }
}