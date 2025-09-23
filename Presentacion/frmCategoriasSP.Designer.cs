namespace Presentacion
{
    partial class frmCategoriasSP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvCategoriaSP = new System.Windows.Forms.DataGridView();
            this.cbCategoriaSP = new System.Windows.Forms.CheckBox();
            this.txtDCategoriaSP = new System.Windows.Forms.TextBox();
            this.txtNCategoriaSP = new System.Windows.Forms.TextBox();
            this.lblDCategoriaSP = new System.Windows.Forms.Label();
            this.lblNCategoriaSP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoriaSP)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(780, 178);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 63);
            this.btnCancelar.TabIndex = 19;
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
            this.btnModificar.Location = new System.Drawing.Point(569, 178);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(124, 63);
            this.btnModificar.TabIndex = 18;
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
            this.btnGuardar.Location = new System.Drawing.Point(364, 178);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(111, 63);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.FlatAppearance.BorderSize = 2;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(162, 178);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(103, 63);
            this.btnNuevo.TabIndex = 16;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvCategoriaSP
            // 
            this.dgvCategoriaSP.AllowUserToAddRows = false;
            this.dgvCategoriaSP.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategoriaSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCategoriaSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoriaSP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCategoriaSP.Location = new System.Drawing.Point(0, 256);
            this.dgvCategoriaSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvCategoriaSP.Name = "dgvCategoriaSP";
            this.dgvCategoriaSP.ReadOnly = true;
            this.dgvCategoriaSP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategoriaSP.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCategoriaSP.RowHeadersWidth = 51;
            this.dgvCategoriaSP.RowTemplate.Height = 24;
            this.dgvCategoriaSP.Size = new System.Drawing.Size(1077, 507);
            this.dgvCategoriaSP.TabIndex = 15;
            this.dgvCategoriaSP.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategoriaSP_CellDoubleClick);
            // 
            // cbCategoriaSP
            // 
            this.cbCategoriaSP.AutoSize = true;
            this.cbCategoriaSP.Enabled = false;
            this.cbCategoriaSP.Location = new System.Drawing.Point(22, 129);
            this.cbCategoriaSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCategoriaSP.Name = "cbCategoriaSP";
            this.cbCategoriaSP.Size = new System.Drawing.Size(94, 27);
            this.cbCategoriaSP.TabIndex = 14;
            this.cbCategoriaSP.Text = "Estado";
            this.cbCategoriaSP.UseVisualStyleBackColor = true;
            // 
            // txtDCategoriaSP
            // 
            this.txtDCategoriaSP.Enabled = false;
            this.txtDCategoriaSP.Location = new System.Drawing.Point(278, 66);
            this.txtDCategoriaSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDCategoriaSP.Name = "txtDCategoriaSP";
            this.txtDCategoriaSP.Size = new System.Drawing.Size(792, 30);
            this.txtDCategoriaSP.TabIndex = 13;
            // 
            // txtNCategoriaSP
            // 
            this.txtNCategoriaSP.Enabled = false;
            this.txtNCategoriaSP.Location = new System.Drawing.Point(278, 12);
            this.txtNCategoriaSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNCategoriaSP.Name = "txtNCategoriaSP";
            this.txtNCategoriaSP.Size = new System.Drawing.Size(502, 30);
            this.txtNCategoriaSP.TabIndex = 12;
            // 
            // lblDCategoriaSP
            // 
            this.lblDCategoriaSP.AutoSize = true;
            this.lblDCategoriaSP.Location = new System.Drawing.Point(16, 75);
            this.lblDCategoriaSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDCategoriaSP.Name = "lblDCategoriaSP";
            this.lblDCategoriaSP.Size = new System.Drawing.Size(204, 23);
            this.lblDCategoriaSP.TabIndex = 11;
            this.lblDCategoriaSP.Text = "Descripcion Categoria";
            // 
            // lblNCategoriaSP
            // 
            this.lblNCategoriaSP.AutoSize = true;
            this.lblNCategoriaSP.Location = new System.Drawing.Point(16, 20);
            this.lblNCategoriaSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNCategoriaSP.Name = "lblNCategoriaSP";
            this.lblNCategoriaSP.Size = new System.Drawing.Size(171, 23);
            this.lblNCategoriaSP.TabIndex = 10;
            this.lblNCategoriaSP.Text = "Nombre Categoria";
            // 
            // frmCategoriasSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 763);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvCategoriaSP);
            this.Controls.Add(this.cbCategoriaSP);
            this.Controls.Add(this.txtDCategoriaSP);
            this.Controls.Add(this.txtNCategoriaSP);
            this.Controls.Add(this.lblDCategoriaSP);
            this.Controls.Add(this.lblNCategoriaSP);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmCategoriasSP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categoria SubProductos";
            this.Load += new System.EventHandler(this.frmCategoriasSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoriaSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvCategoriaSP;
        private System.Windows.Forms.CheckBox cbCategoriaSP;
        private System.Windows.Forms.TextBox txtDCategoriaSP;
        private System.Windows.Forms.TextBox txtNCategoriaSP;
        private System.Windows.Forms.Label lblDCategoriaSP;
        private System.Windows.Forms.Label lblNCategoriaSP;
    }
}