namespace Presentacion
{
    partial class frmOrden
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnProducto = new System.Windows.Forms.Button();
            this.nudCProducto = new System.Windows.Forms.NumericUpDown();
            this.cbxProducto = new System.Windows.Forms.ComboBox();
            this.dgvOrden = new System.Windows.Forms.DataGridView();
            this.lblCProducto = new System.Windows.Forms.Label();
            this.txtDOrden = new System.Windows.Forms.TextBox();
            this.lblDOrden = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPedidoCreado = new System.Windows.Forms.DataGridView();
            this.dtpPedido = new System.Windows.Forms.DateTimePicker();
            this.btnModificar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoCreado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNuevo);
            this.groupBox2.Controls.Add(this.btnProcesar);
            this.groupBox2.Controls.Add(this.lblProducto);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnProducto);
            this.groupBox2.Controls.Add(this.nudCProducto);
            this.groupBox2.Controls.Add(this.cbxProducto);
            this.groupBox2.Controls.Add(this.dgvOrden);
            this.groupBox2.Controls.Add(this.lblCProducto);
            this.groupBox2.Controls.Add(this.txtDOrden);
            this.groupBox2.Controls.Add(this.lblDOrden);
            this.groupBox2.Location = new System.Drawing.Point(11, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 635);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar Nueva Orden";
            // 
            // btnNuevo
            // 
            this.btnNuevo.FlatAppearance.BorderSize = 2;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(119, 158);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 31);
            this.btnNuevo.TabIndex = 84;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Enabled = false;
            this.btnProcesar.FlatAppearance.BorderSize = 2;
            this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProcesar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesar.Location = new System.Drawing.Point(276, 158);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(128, 31);
            this.btnProcesar.TabIndex = 85;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(6, 100);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(67, 23);
            this.lblProducto.TabIndex = 69;
            this.lblProducto.Text = "Platillo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(485, 158);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 31);
            this.btnCancelar.TabIndex = 86;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnProducto
            // 
            this.btnProducto.Enabled = false;
            this.btnProducto.FlatAppearance.BorderSize = 2;
            this.btnProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProducto.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducto.Location = new System.Drawing.Point(488, 100);
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(84, 31);
            this.btnProducto.TabIndex = 83;
            this.btnProducto.Text = "Agregar";
            this.btnProducto.UseVisualStyleBackColor = true;
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // nudCProducto
            // 
            this.nudCProducto.DecimalPlaces = 2;
            this.nudCProducto.Enabled = false;
            this.nudCProducto.Location = new System.Drawing.Point(397, 98);
            this.nudCProducto.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCProducto.Name = "nudCProducto";
            this.nudCProducto.Size = new System.Drawing.Size(68, 30);
            this.nudCProducto.TabIndex = 82;
            // 
            // cbxProducto
            // 
            this.cbxProducto.Enabled = false;
            this.cbxProducto.FormattingEnabled = true;
            this.cbxProducto.Location = new System.Drawing.Point(119, 98);
            this.cbxProducto.Name = "cbxProducto";
            this.cbxProducto.Size = new System.Drawing.Size(175, 31);
            this.cbxProducto.TabIndex = 81;
            // 
            // dgvOrden
            // 
            this.dgvOrden.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrden.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrden.Enabled = false;
            this.dgvOrden.Location = new System.Drawing.Point(6, 209);
            this.dgvOrden.Name = "dgvOrden";
            this.dgvOrden.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrden.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrden.RowHeadersWidth = 51;
            this.dgvOrden.RowTemplate.Height = 24;
            this.dgvOrden.Size = new System.Drawing.Size(566, 414);
            this.dgvOrden.TabIndex = 80;
            this.dgvOrden.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrden_CellClick);
            // 
            // lblCProducto
            // 
            this.lblCProducto.AutoSize = true;
            this.lblCProducto.Location = new System.Drawing.Point(303, 100);
            this.lblCProducto.Name = "lblCProducto";
            this.lblCProducto.Size = new System.Drawing.Size(88, 23);
            this.lblCProducto.TabIndex = 79;
            this.lblCProducto.Text = "Cantidad";
            // 
            // txtDOrden
            // 
            this.txtDOrden.Enabled = false;
            this.txtDOrden.Location = new System.Drawing.Point(119, 41);
            this.txtDOrden.Name = "txtDOrden";
            this.txtDOrden.Size = new System.Drawing.Size(453, 30);
            this.txtDOrden.TabIndex = 78;
            // 
            // lblDOrden
            // 
            this.lblDOrden.AutoSize = true;
            this.lblDOrden.Location = new System.Drawing.Point(6, 44);
            this.lblDOrden.Name = "lblDOrden";
            this.lblDOrden.Size = new System.Drawing.Size(112, 23);
            this.lblDOrden.TabIndex = 77;
            this.lblDOrden.Text = "Descripcion";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPedidoCreado);
            this.groupBox1.Controls.Add(this.dtpPedido);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Location = new System.Drawing.Point(595, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 635);
            this.groupBox1.TabIndex = 81;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenes Creadas";
            // 
            // dgvPedidoCreado
            // 
            this.dgvPedidoCreado.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPedidoCreado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPedidoCreado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoCreado.Location = new System.Drawing.Point(0, 209);
            this.dgvPedidoCreado.Name = "dgvPedidoCreado";
            this.dgvPedidoCreado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPedidoCreado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPedidoCreado.RowHeadersWidth = 51;
            this.dgvPedidoCreado.RowTemplate.Height = 24;
            this.dgvPedidoCreado.Size = new System.Drawing.Size(495, 414);
            this.dgvPedidoCreado.TabIndex = 78;
            // 
            // dtpPedido
            // 
            this.dtpPedido.Location = new System.Drawing.Point(143, 41);
            this.dtpPedido.Name = "dtpPedido";
            this.dtpPedido.Size = new System.Drawing.Size(328, 30);
            this.dtpPedido.TabIndex = 77;
            // 
            // btnModificar
            // 
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(6, 158);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 31);
            this.btnModificar.TabIndex = 75;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // frmOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 647);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmOrden";
            this.Text = "Ordenes";
            this.Load += new System.EventHandler(this.frmOrden_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoCreado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnProducto;
        private System.Windows.Forms.NumericUpDown nudCProducto;
        private System.Windows.Forms.ComboBox cbxProducto;
        private System.Windows.Forms.DataGridView dgvOrden;
        private System.Windows.Forms.Label lblCProducto;
        private System.Windows.Forms.TextBox txtDOrden;
        private System.Windows.Forms.Label lblDOrden;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPedidoCreado;
        private System.Windows.Forms.DateTimePicker dtpPedido;
        private System.Windows.Forms.Button btnModificar;
    }
}