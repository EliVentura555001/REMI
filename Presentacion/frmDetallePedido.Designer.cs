namespace Presentacion
{
    partial class frmDetallePedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDetallePedido = new System.Windows.Forms.Label();
            this.dgvDetallePedido = new System.Windows.Forms.DataGridView();
            this.btnCompletar = new System.Windows.Forms.Button();
            this.dgvDetallePedidoSP = new System.Windows.Forms.DataGridView();
            this.lblLisIngre = new System.Windows.Forms.Label();
            this.lblGananciaB = new System.Windows.Forms.Label();
            this.lblCostoT = new System.Windows.Forms.Label();
            this.lblPrecioT = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedidoSP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDetallePedido
            // 
            this.lblDetallePedido.AutoSize = true;
            this.lblDetallePedido.Location = new System.Drawing.Point(122, 9);
            this.lblDetallePedido.Name = "lblDetallePedido";
            this.lblDetallePedido.Size = new System.Drawing.Size(202, 23);
            this.lblDetallePedido.TabIndex = 71;
            this.lblDetallePedido.Text = "Lista de Subroductos ";
            // 
            // dgvDetallePedido
            // 
            this.dgvDetallePedido.AllowUserToAddRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallePedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetallePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallePedido.Location = new System.Drawing.Point(12, 37);
            this.dgvDetallePedido.Name = "dgvDetallePedido";
            this.dgvDetallePedido.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallePedido.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetallePedido.RowHeadersWidth = 51;
            this.dgvDetallePedido.RowTemplate.Height = 24;
            this.dgvDetallePedido.Size = new System.Drawing.Size(667, 217);
            this.dgvDetallePedido.TabIndex = 70;
            this.dgvDetallePedido.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetallePedido_CellValueChanged);
            // 
            // btnCompletar
            // 
            this.btnCompletar.FlatAppearance.BorderSize = 2;
            this.btnCompletar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCompletar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompletar.Location = new System.Drawing.Point(6, 166);
            this.btnCompletar.Name = "btnCompletar";
            this.btnCompletar.Size = new System.Drawing.Size(134, 31);
            this.btnCompletar.TabIndex = 75;
            this.btnCompletar.Text = "Completado";
            this.btnCompletar.UseVisualStyleBackColor = true;
            this.btnCompletar.Click += new System.EventHandler(this.btnCompletar_Click);
            // 
            // dgvDetallePedidoSP
            // 
            this.dgvDetallePedidoSP.AllowUserToAddRows = false;
            this.dgvDetallePedidoSP.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallePedidoSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDetallePedidoSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallePedidoSP.Enabled = false;
            this.dgvDetallePedidoSP.Location = new System.Drawing.Point(12, 299);
            this.dgvDetallePedidoSP.Name = "dgvDetallePedidoSP";
            this.dgvDetallePedidoSP.ReadOnly = true;
            this.dgvDetallePedidoSP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallePedidoSP.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetallePedidoSP.RowHeadersWidth = 51;
            this.dgvDetallePedidoSP.RowTemplate.Height = 24;
            this.dgvDetallePedidoSP.Size = new System.Drawing.Size(984, 439);
            this.dgvDetallePedidoSP.TabIndex = 76;
            // 
            // lblLisIngre
            // 
            this.lblLisIngre.AutoSize = true;
            this.lblLisIngre.Location = new System.Drawing.Point(122, 273);
            this.lblLisIngre.Name = "lblLisIngre";
            this.lblLisIngre.Size = new System.Drawing.Size(194, 23);
            this.lblLisIngre.TabIndex = 77;
            this.lblLisIngre.Text = "Lista de Ingredientes";
            // 
            // lblGananciaB
            // 
            this.lblGananciaB.AutoSize = true;
            this.lblGananciaB.Location = new System.Drawing.Point(6, 121);
            this.lblGananciaB.Name = "lblGananciaB";
            this.lblGananciaB.Size = new System.Drawing.Size(28, 23);
            this.lblGananciaB.TabIndex = 88;
            this.lblGananciaB.Text = "...";
            // 
            // lblCostoT
            // 
            this.lblCostoT.AutoSize = true;
            this.lblCostoT.Location = new System.Drawing.Point(6, 37);
            this.lblCostoT.Name = "lblCostoT";
            this.lblCostoT.Size = new System.Drawing.Size(28, 23);
            this.lblCostoT.TabIndex = 85;
            this.lblCostoT.Text = "...";
            // 
            // lblPrecioT
            // 
            this.lblPrecioT.AutoSize = true;
            this.lblPrecioT.Location = new System.Drawing.Point(6, 78);
            this.lblPrecioT.Name = "lblPrecioT";
            this.lblPrecioT.Size = new System.Drawing.Size(28, 23);
            this.lblPrecioT.TabIndex = 83;
            this.lblPrecioT.Text = "...";
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(156, 166);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 31);
            this.btnCancelar.TabIndex = 89;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPrecioT);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.lblCostoT);
            this.groupBox1.Controls.Add(this.lblGananciaB);
            this.groupBox1.Controls.Add(this.btnCompletar);
            this.groupBox1.Location = new System.Drawing.Point(709, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 217);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            // 
            // frmDetallePedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 743);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblLisIngre);
            this.Controls.Add(this.dgvDetallePedidoSP);
            this.Controls.Add(this.lblDetallePedido);
            this.Controls.Add(this.dgvDetallePedido);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetallePedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles del Pedido";
            this.Load += new System.EventHandler(this.frmDetallePedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedidoSP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDetallePedido;
        private System.Windows.Forms.DataGridView dgvDetallePedido;
        private System.Windows.Forms.Button btnCompletar;
        private System.Windows.Forms.DataGridView dgvDetallePedidoSP;
        private System.Windows.Forms.Label lblLisIngre;
        private System.Windows.Forms.Label lblGananciaB;
        private System.Windows.Forms.Label lblCostoT;
        private System.Windows.Forms.Label lblPrecioT;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}