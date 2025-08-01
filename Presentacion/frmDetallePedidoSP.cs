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
    public partial class frmDetallePedidoSP : Form
    {
        private List<DetalleProducto_E> productosSeleccionados;

        public frmDetallePedidoSP(List<DetalleProducto_E> productos)
        {
            InitializeComponent();
            productosSeleccionados = productos;
        }

        public frmDetallePedidoSP()
        {
            InitializeComponent();
        }
        public void CargarComboBox()
        {
            try
            {
                cbxProducto.DataSource = productosSeleccionados;
                cbxProducto.DisplayMember = "NombreProducto";
                cbxProducto.ValueMember = "IdProducto";
                cbxProducto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarGridConSubProductos()
        {
            try
            {
                // Configura las columnas solo si no existen
                dgvDetallePedidoSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgvDetallePedidoSP.Columns.Count == 0)
                {
                    DataGridViewTextBoxColumn colIdDSP = new DataGridViewTextBoxColumn();
                    colIdDSP.HeaderText = "IdSubProducto";
                    colIdDSP.Name = "IdSubProducto";
                    colIdDSP.Visible = false;
                    dgvDetallePedidoSP.Columns.Add(colIdDSP);

                    dgvDetallePedidoSP.Columns.Add("NombreSuministro", "Ingredientes");
                    dgvDetallePedidoSP.Columns.Add("CantidadPorciones", "Cantidades");
                    dgvDetallePedidoSP.Columns.Add("unidadMedidaPSP", "Unidad de Medida");
                    dgvDetallePedidoSP.Columns.Add("CostoParcial", "Costo");
                }

                // Limpia las filas existentes
                dgvDetallePedidoSP.Rows.Clear();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmDetallePedidoSP_Load(object sender, EventArgs e)
        {
            CargarGridConSubProductos();
            CargarComboBox();
            cbxProducto.SelectedIndexChanged += cbxProducto_SelectedIndexChanged;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void cbxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProducto.SelectedItem is DetalleProducto_E producto)
            {
                try
                {
                    // Obtener los subproductos del producto seleccionado
                    var subproductos = new SubProductos_L().ListarSubProductosPorProducto(producto.IdProducto);

                    cbxSupProducto.DataSource = subproductos;
                    cbxSupProducto.DisplayMember = "NombreSubProducto";
                    cbxSupProducto.ValueMember = "IdSubProducto";
                    cbxSupProducto.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                cbxSupProducto.DataSource = null;
            }
        }

        private void cbxSupProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSupProducto.SelectedItem != null && cbxSupProducto.SelectedValue is int idSubProducto)
            {
                try
                {
                    // Obtener los detalles del subproducto seleccionado
                    var detalles = new SubProductos_L().ObtenerDetallesDeSubProducto(idSubProducto);

                    // Limpiar el grid antes de llenarlo
                    dgvDetallePedidoSP.Rows.Clear();

                    // Llenar el DataGridView con los detalles
                    foreach (var detalle in detalles)
                    {
                        dgvDetallePedidoSP.Rows.Add(
                            detalle.IdSubProducto,
                            detalle.NombreSuministros,
                            detalle.CantidadSuministro,
                            detalle.UnidadMedidaSP
                            //detalle.CostoParcial // Si tienes esta propiedad, si no, puedes omitirla
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dgvDetallePedidoSP.Rows.Clear();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }
    }
}
