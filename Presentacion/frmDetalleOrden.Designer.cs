namespace Presentacion
{
    partial class frmDetalleOrden
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
            this.lblDetallePedido = new System.Windows.Forms.Label();
            this.dgvDetalleOrden = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.clbSubProducto = new System.Windows.Forms.CheckedListBox();
            this.lblComplementos = new System.Windows.Forms.Label();
            this.clbBebidas = new System.Windows.Forms.CheckedListBox();
            this.lblbebidas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOrden)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDetallePedido
            // 
            this.lblDetallePedido.AutoSize = true;
            this.lblDetallePedido.Location = new System.Drawing.Point(396, 23);
            this.lblDetallePedido.Name = "lblDetallePedido";
            this.lblDetallePedido.Size = new System.Drawing.Size(202, 23);
            this.lblDetallePedido.TabIndex = 73;
            this.lblDetallePedido.Text = "Lista de Subroductos ";
            // 
            // dgvDetalleOrden
            // 
            this.dgvDetalleOrden.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleOrden.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalleOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleOrden.Location = new System.Drawing.Point(234, 51);
            this.dgvDetalleOrden.Name = "dgvDetalleOrden";
            this.dgvDetalleOrden.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleOrden.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalleOrden.RowHeadersWidth = 51;
            this.dgvDetalleOrden.RowTemplate.Height = 24;
            this.dgvDetalleOrden.Size = new System.Drawing.Size(520, 226);
            this.dgvDetalleOrden.TabIndex = 72;
            this.dgvDetalleOrden.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleOrden_CellValueChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(400, 320);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 31);
            this.btnCancelar.TabIndex = 91;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderSize = 2;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(248, 320);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(134, 31);
            this.btnAceptar.TabIndex = 90;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // clbSubProducto
            // 
            this.clbSubProducto.FormattingEnabled = true;
            this.clbSubProducto.Location = new System.Drawing.Point(12, 49);
            this.clbSubProducto.Name = "clbSubProducto";
            this.clbSubProducto.Size = new System.Drawing.Size(214, 129);
            this.clbSubProducto.TabIndex = 93;
            this.clbSubProducto.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbSubProducto_ItemCheck);
            // 
            // lblComplementos
            // 
            this.lblComplementos.AutoSize = true;
            this.lblComplementos.Location = new System.Drawing.Point(8, 23);
            this.lblComplementos.Name = "lblComplementos";
            this.lblComplementos.Size = new System.Drawing.Size(141, 23);
            this.lblComplementos.TabIndex = 94;
            this.lblComplementos.Text = "Complementos";
            // 
            // clbBebidas
            // 
            this.clbBebidas.FormattingEnabled = true;
            this.clbBebidas.Location = new System.Drawing.Point(12, 222);
            this.clbBebidas.Name = "clbBebidas";
            this.clbBebidas.Size = new System.Drawing.Size(214, 129);
            this.clbBebidas.TabIndex = 95;
            this.clbBebidas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbBebidas_ItemCheck);
            // 
            // lblbebidas
            // 
            this.lblbebidas.AutoSize = true;
            this.lblbebidas.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblbebidas.Location = new System.Drawing.Point(10, 196);
            this.lblbebidas.Name = "lblbebidas";
            this.lblbebidas.Size = new System.Drawing.Size(81, 23);
            this.lblbebidas.TabIndex = 96;
            this.lblbebidas.Text = "Bebidas";
            // 
            // frmDetalleOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 370);
            this.Controls.Add(this.lblbebidas);
            this.Controls.Add(this.clbBebidas);
            this.Controls.Add(this.lblComplementos);
            this.Controls.Add(this.clbSubProducto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblDetallePedido);
            this.Controls.Add(this.dgvDetalleOrden);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetalleOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles del Platillo";
            this.Load += new System.EventHandler(this.frmDetalleOrden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOrden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDetallePedido;
        private System.Windows.Forms.DataGridView dgvDetalleOrden;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.CheckedListBox clbSubProducto;
        private System.Windows.Forms.Label lblComplementos;
        private System.Windows.Forms.CheckedListBox clbBebidas;
        private System.Windows.Forms.Label lblbebidas;
    }
}