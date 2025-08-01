namespace Presentacion
{
    partial class frmProveedores
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
            this.lblProveedor = new System.Windows.Forms.Label();
            this.txtNProveedor = new System.Windows.Forms.TextBox();
            this.lblTProveedor = new System.Windows.Forms.Label();
            this.txtTProveedor = new System.Windows.Forms.TextBox();
            this.lblDProveedor = new System.Windows.Forms.Label();
            this.txtDProveedor = new System.Windows.Forms.TextBox();
            this.lblCProveedor = new System.Windows.Forms.Label();
            this.txtCProveedor = new System.Windows.Forms.TextBox();
            this.cbProveedor = new System.Windows.Forms.CheckBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvProveedor = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(26, 31);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(63, 22);
            this.lblProveedor.TabIndex = 0;
            this.lblProveedor.Text = "Nombre";
            // 
            // txtNProveedor
            // 
            this.txtNProveedor.Enabled = false;
            this.txtNProveedor.Location = new System.Drawing.Point(102, 28);
            this.txtNProveedor.Name = "txtNProveedor";
            this.txtNProveedor.Size = new System.Drawing.Size(414, 28);
            this.txtNProveedor.TabIndex = 1;
            // 
            // lblTProveedor
            // 
            this.lblTProveedor.AutoSize = true;
            this.lblTProveedor.Location = new System.Drawing.Point(538, 31);
            this.lblTProveedor.Name = "lblTProveedor";
            this.lblTProveedor.Size = new System.Drawing.Size(65, 22);
            this.lblTProveedor.TabIndex = 2;
            this.lblTProveedor.Text = "Telefono";
            // 
            // txtTProveedor
            // 
            this.txtTProveedor.Enabled = false;
            this.txtTProveedor.Location = new System.Drawing.Point(609, 28);
            this.txtTProveedor.Name = "txtTProveedor";
            this.txtTProveedor.Size = new System.Drawing.Size(339, 28);
            this.txtTProveedor.TabIndex = 3;
            // 
            // lblDProveedor
            // 
            this.lblDProveedor.AutoSize = true;
            this.lblDProveedor.Location = new System.Drawing.Point(26, 77);
            this.lblDProveedor.Name = "lblDProveedor";
            this.lblDProveedor.Size = new System.Drawing.Size(70, 22);
            this.lblDProveedor.TabIndex = 4;
            this.lblDProveedor.Text = "Direccion";
            // 
            // txtDProveedor
            // 
            this.txtDProveedor.Enabled = false;
            this.txtDProveedor.Location = new System.Drawing.Point(102, 74);
            this.txtDProveedor.Name = "txtDProveedor";
            this.txtDProveedor.Size = new System.Drawing.Size(846, 28);
            this.txtDProveedor.TabIndex = 5;
            // 
            // lblCProveedor
            // 
            this.lblCProveedor.AutoSize = true;
            this.lblCProveedor.Location = new System.Drawing.Point(26, 124);
            this.lblCProveedor.Name = "lblCProveedor";
            this.lblCProveedor.Size = new System.Drawing.Size(55, 22);
            this.lblCProveedor.TabIndex = 6;
            this.lblCProveedor.Text = "Correo";
            // 
            // txtCProveedor
            // 
            this.txtCProveedor.Enabled = false;
            this.txtCProveedor.Location = new System.Drawing.Point(102, 121);
            this.txtCProveedor.Name = "txtCProveedor";
            this.txtCProveedor.Size = new System.Drawing.Size(501, 28);
            this.txtCProveedor.TabIndex = 7;
            // 
            // cbProveedor
            // 
            this.cbProveedor.AutoSize = true;
            this.cbProveedor.Enabled = false;
            this.cbProveedor.Location = new System.Drawing.Point(655, 128);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(76, 26);
            this.cbProveedor.TabIndex = 8;
            this.cbProveedor.Text = "Estado";
            this.cbProveedor.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.FlatAppearance.BorderSize = 2;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(234, 172);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 44);
            this.btnNuevo.TabIndex = 9;
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
            this.btnGuardar.Location = new System.Drawing.Point(380, 172);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 44);
            this.btnGuardar.TabIndex = 10;
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
            this.btnModificar.Location = new System.Drawing.Point(531, 172);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 44);
            this.btnModificar.TabIndex = 11;
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
            this.btnCancelar.Location = new System.Drawing.Point(685, 172);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 44);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvProveedor
            // 
            this.dgvProveedor.AllowUserToAddRows = false;
            this.dgvProveedor.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProveedor.Location = new System.Drawing.Point(0, 266);
            this.dgvProveedor.Name = "dgvProveedor";
            this.dgvProveedor.ReadOnly = true;
            this.dgvProveedor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProveedor.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProveedor.RowHeadersWidth = 51;
            this.dgvProveedor.RowTemplate.Height = 24;
            this.dgvProveedor.Size = new System.Drawing.Size(1119, 353);
            this.dgvProveedor.TabIndex = 13;
            this.dgvProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedor_CellDoubleClick);
            // 
            // frmProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 619);
            this.Controls.Add(this.dgvProveedor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.cbProveedor);
            this.Controls.Add(this.txtCProveedor);
            this.Controls.Add(this.lblCProveedor);
            this.Controls.Add(this.txtDProveedor);
            this.Controls.Add(this.lblDProveedor);
            this.Controls.Add(this.txtTProveedor);
            this.Controls.Add(this.lblTProveedor);
            this.Controls.Add(this.txtNProveedor);
            this.Controls.Add(this.lblProveedor);
            this.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmProveedores";
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.frmProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.TextBox txtNProveedor;
        private System.Windows.Forms.Label lblTProveedor;
        private System.Windows.Forms.TextBox txtTProveedor;
        private System.Windows.Forms.Label lblDProveedor;
        private System.Windows.Forms.TextBox txtDProveedor;
        private System.Windows.Forms.Label lblCProveedor;
        private System.Windows.Forms.TextBox txtCProveedor;
        private System.Windows.Forms.CheckBox cbProveedor;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvProveedor;
    }
}