namespace Presentacion
{
    partial class frmDetallePedidoSP
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
            this.dgvDetallePedidoSP = new System.Windows.Forms.DataGridView();
            this.cbxSupProducto = new System.Windows.Forms.ComboBox();
            this.lblDetalleSP = new System.Windows.Forms.Label();
            this.txtCostParSP = new System.Windows.Forms.TextBox();
            this.lblCPSP = new System.Windows.Forms.Label();
            this.lblCPP = new System.Windows.Forms.Label();
            this.txtCostTPrd = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCostTPedido = new System.Windows.Forms.TextBox();
            this.lblCTP = new System.Windows.Forms.Label();
            this.cbxProducto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCPProd = new System.Windows.Forms.Label();
            this.lblCPSProd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedidoSP)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetallePedidoSP
            // 
            this.dgvDetallePedidoSP.AllowUserToAddRows = false;
            this.dgvDetallePedidoSP.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallePedidoSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetallePedidoSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallePedidoSP.Enabled = false;
            this.dgvDetallePedidoSP.Location = new System.Drawing.Point(-1, 139);
            this.dgvDetallePedidoSP.Name = "dgvDetallePedidoSP";
            this.dgvDetallePedidoSP.ReadOnly = true;
            this.dgvDetallePedidoSP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallePedidoSP.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetallePedidoSP.RowHeadersWidth = 51;
            this.dgvDetallePedidoSP.RowTemplate.Height = 24;
            this.dgvDetallePedidoSP.Size = new System.Drawing.Size(1100, 434);
            this.dgvDetallePedidoSP.TabIndex = 68;
            // 
            // cbxSupProducto
            // 
            this.cbxSupProducto.FormattingEnabled = true;
            this.cbxSupProducto.Location = new System.Drawing.Point(363, 79);
            this.cbxSupProducto.Name = "cbxSupProducto";
            this.cbxSupProducto.Size = new System.Drawing.Size(186, 31);
            this.cbxSupProducto.TabIndex = 74;
            this.cbxSupProducto.SelectedIndexChanged += new System.EventHandler(this.cbxSupProducto_SelectedIndexChanged);
            // 
            // lblDetalleSP
            // 
            this.lblDetalleSP.AutoSize = true;
            this.lblDetalleSP.Location = new System.Drawing.Point(226, 82);
            this.lblDetalleSP.Name = "lblDetalleSP";
            this.lblDetalleSP.Size = new System.Drawing.Size(121, 23);
            this.lblDetalleSP.TabIndex = 73;
            this.lblDetalleSP.Text = "Subproducto";
            // 
            // txtCostParSP
            // 
            this.txtCostParSP.Enabled = false;
            this.txtCostParSP.Location = new System.Drawing.Point(782, 55);
            this.txtCostParSP.Name = "txtCostParSP";
            this.txtCostParSP.Size = new System.Drawing.Size(93, 30);
            this.txtCostParSP.TabIndex = 72;
            // 
            // lblCPSP
            // 
            this.lblCPSP.AutoSize = true;
            this.lblCPSP.Location = new System.Drawing.Point(587, 58);
            this.lblCPSP.Name = "lblCPSP";
            this.lblCPSP.Size = new System.Drawing.Size(189, 23);
            this.lblCPSP.TabIndex = 71;
            this.lblCPSP.Text = "Costo Subproductos";
            // 
            // lblCPP
            // 
            this.lblCPP.AutoSize = true;
            this.lblCPP.Location = new System.Drawing.Point(587, 14);
            this.lblCPP.Name = "lblCPP";
            this.lblCPP.Size = new System.Drawing.Size(125, 23);
            this.lblCPP.TabIndex = 75;
            this.lblCPP.Text = "Costo Platillo";
            // 
            // txtCostTPrd
            // 
            this.txtCostTPrd.Enabled = false;
            this.txtCostTPrd.Location = new System.Drawing.Point(782, 14);
            this.txtCostTPrd.Name = "txtCostTPrd";
            this.txtCostTPrd.Size = new System.Drawing.Size(93, 30);
            this.txtCostTPrd.TabIndex = 76;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.FlatAppearance.BorderSize = 2;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Location = new System.Drawing.Point(450, 604);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(165, 31);
            this.btnConfirmar.TabIndex = 78;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.FlatAppearance.BorderSize = 2;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtras.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Location = new System.Drawing.Point(12, 11);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(90, 31);
            this.btnAtras.TabIndex = 79;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderSize = 2;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(1001, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 31);
            this.btnCancelar.TabIndex = 80;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCostTPedido
            // 
            this.txtCostTPedido.Enabled = false;
            this.txtCostTPedido.Location = new System.Drawing.Point(782, 94);
            this.txtCostTPedido.Name = "txtCostTPedido";
            this.txtCostTPedido.Size = new System.Drawing.Size(93, 30);
            this.txtCostTPedido.TabIndex = 82;
            // 
            // lblCTP
            // 
            this.lblCTP.AutoSize = true;
            this.lblCTP.Location = new System.Drawing.Point(587, 97);
            this.lblCTP.Name = "lblCTP";
            this.lblCTP.Size = new System.Drawing.Size(110, 23);
            this.lblCTP.TabIndex = 81;
            this.lblCTP.Text = "Costo Total";
            // 
            // cbxProducto
            // 
            this.cbxProducto.FormattingEnabled = true;
            this.cbxProducto.Location = new System.Drawing.Point(363, 11);
            this.cbxProducto.Name = "cbxProducto";
            this.cbxProducto.Size = new System.Drawing.Size(186, 31);
            this.cbxProducto.TabIndex = 84;
            this.cbxProducto.SelectedIndexChanged += new System.EventHandler(this.cbxProducto_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 23);
            this.label2.TabIndex = 83;
            this.label2.Text = "Platillo";
            // 
            // lblCPProd
            // 
            this.lblCPProd.AutoSize = true;
            this.lblCPProd.Location = new System.Drawing.Point(359, 45);
            this.lblCPProd.Name = "lblCPProd";
            this.lblCPProd.Size = new System.Drawing.Size(28, 23);
            this.lblCPProd.TabIndex = 85;
            this.lblCPProd.Text = "...";
            // 
            // lblCPSProd
            // 
            this.lblCPSProd.AutoSize = true;
            this.lblCPSProd.Location = new System.Drawing.Point(359, 113);
            this.lblCPSProd.Name = "lblCPSProd";
            this.lblCPSProd.Size = new System.Drawing.Size(28, 23);
            this.lblCPSProd.TabIndex = 86;
            this.lblCPSProd.Text = "...";
            // 
            // frmDetallePedidoSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 647);
            this.Controls.Add(this.lblCPSProd);
            this.Controls.Add(this.lblCPProd);
            this.Controls.Add(this.cbxProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCostTPedido);
            this.Controls.Add(this.lblCTP);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtCostTPrd);
            this.Controls.Add(this.lblCPP);
            this.Controls.Add(this.cbxSupProducto);
            this.Controls.Add(this.lblDetalleSP);
            this.Controls.Add(this.txtCostParSP);
            this.Controls.Add(this.lblCPSP);
            this.Controls.Add(this.dgvDetallePedidoSP);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetallePedidoSP";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle Pedido Subproductos";
            this.Load += new System.EventHandler(this.frmDetallePedidoSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedidoSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetallePedidoSP;
        private System.Windows.Forms.ComboBox cbxSupProducto;
        private System.Windows.Forms.Label lblDetalleSP;
        private System.Windows.Forms.TextBox txtCostParSP;
        private System.Windows.Forms.Label lblCPSP;
        private System.Windows.Forms.Label lblCPP;
        private System.Windows.Forms.TextBox txtCostTPrd;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtCostTPedido;
        private System.Windows.Forms.Label lblCTP;
        private System.Windows.Forms.ComboBox cbxProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCPProd;
        private System.Windows.Forms.Label lblCPSProd;
    }
}