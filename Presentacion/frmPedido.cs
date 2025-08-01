using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmPedido : Form
    {
        bool banderaModificar = false;
        string mensajeError = string.Empty;
        public frmPedido()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            txtDPedido.Enabled = false;
            cbxProducto.Enabled = false;
            nudCProducto.Enabled = false;
            dtpPedido.Enabled = false;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnProcesar.Enabled = false;
            btnCancelar.Enabled = false;
            txtDPedido.Clear();
            nudCProducto.Value = 0;
            cbxProducto.SelectedIndex = -1;
            dgvPedido.Rows.Clear();
            banderaModificar = false;
        }
        private void CargarGrid()
        {
            try
            {
                //Llenar los espacios del DataGridView
                dgvPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgvPedido.Columns.Count == 0)
                {
                    DataGridViewTextBoxColumn colIdProduc = new DataGridViewTextBoxColumn();
                    colIdProduc.HeaderText = "IdProducto";
                    colIdProduc.Name = "IdProducto";
                    colIdProduc.Visible = false;
                    dgvPedido.Columns.Add(colIdProduc);

                    dgvPedido.Columns.Add("NombreProducto", "Platillo");
                    dgvPedido.Columns.Add("CantidadPorciones", "Porciones");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CargarComboBox()
        {
            try
            {
                List<Productos_E> productosactivos = new List<Productos_E>();
                productosactivos = new Productos_L().ListarProductosActivos();
                cbxProducto.DataSource = productosactivos;
                cbxProducto.DisplayMember = "NombreProducto";
                cbxProducto.ValueMember = "IdProducto";
                cbxProducto.SelectedIndex = -1; // Para que no haya selección inicial

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmPedido_Load(object sender, EventArgs e)
        {
            CargarComboBox();
            CargarGrid();
        }
        private void btnProducto_Click(object sender, EventArgs e)
        {
            // Validar selección y entrada
            if (cbxProducto.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener valores
            DetalleProducto_E datosFormulario = new DetalleProducto_E()
            {
                IdProducto = Convert.ToInt32(cbxProducto.SelectedValue),
                NombreProducto = cbxProducto.Text.Trim(),
                CantidadPorciones = (int)nudCProducto.Value
            };
            // Agregar al DataGridView
            dgvPedido.Rows.Add(
                    datosFormulario.IdProducto,
                    datosFormulario.NombreProducto,
                    datosFormulario.CantidadPorciones);

            // Limpiar selección y entrada
            cbxProducto.SelectedIndex = -1;
            nudCProducto.Value = 0;
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDPedido.Enabled = true;
            cbxProducto.Enabled = true;
            nudCProducto.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnProcesar.Enabled = true;
            btnCancelar.Enabled = true;
            btnProducto.Enabled = true;
            banderaModificar = false;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {

            List<DetalleProducto_E> listaDetalles = new List<DetalleProducto_E>();
            foreach (DataGridViewRow row in dgvPedido.Rows)
            {
                if (row.Cells["IdProducto"].Value != null)
                {
                    listaDetalles.Add(new DetalleProducto_E
                    {
                        IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value),
                        NombreProducto = row.Cells["NombreProducto"].Value.ToString(),
                        CantidadPorciones = Convert.ToInt32(row.Cells["CantidadPorciones"].Value)
                    });
                }
            }
            Pedidos_E pedido = new Pedidos_E
            {
                DescripcionPedido = txtDPedido.Text.Trim()
                // Agrega otras propiedades si es necesario
            };
            var frmDetalle = new frmDetallePedido(listaDetalles, pedido);
            frmDetalle.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

    }
}
