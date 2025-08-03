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
        private Pedidos_E pedidoSeleccionado; // Variable para almacenar el pedido actual

        public frmPedido()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            txtDPedido.Enabled = false;
            cbxProducto.Enabled = false;
            nudCProducto.Enabled = false;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnProcesar.Enabled = false;
            btnCancelar.Enabled = false;
            btnProducto.Enabled = false;
            dgvPedido.Enabled = false;
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
        private void CargarPedidoCreado()
        {
            dgvPedidoCreado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvPedidoCreado.Columns.Count == 0)
            {
                DataGridViewTextBoxColumn colIdPedido = new DataGridViewTextBoxColumn();
                colIdPedido.HeaderText = "IdPedido";
                colIdPedido.Name = "IdPedido";
                colIdPedido.Visible = false;
                dgvPedidoCreado.Columns.Add(colIdPedido);
                dgvPedidoCreado.Columns.Add("Descripcion", "Descripción");
                dgvPedidoCreado.Columns.Add("Fecha", "Fecha de Creación");
                if (dgvPedidoCreado.Columns["FechaModPedido"] != null)
                {
                    dgvPedidoCreado.Columns.Add("FechaModPedido", "Fecha de Modificación");
                }
            }
            dgvPedidoCreado.Rows.Clear();

            DateTime fechaSeleccionada = dtpPedido.Value.Date;
            List<Pedidos_E> pedidos = new Pedidos_L().ListarPedidos()
                .Where(p => p.FechaPedido.Date == fechaSeleccionada)
                .ToList();

            foreach (var pedido in pedidos)
            {
                dgvPedidoCreado.Rows.Add(
                    pedido.IdPedido,
                    pedido.DescripcionPedido,
                    pedido.FechaPedido.ToString("dd/MM/yyyy"),
                    pedido.FechaModPedido.HasValue ? pedido.FechaModPedido.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
            dgvPedido.Rows.Clear(); // Limpiar el DataGridView de pedidos al cargar nuevos pedidos
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
            CargarPedidoCreado();
            dtpPedido.ValueChanged += dtpPedido_ValueChanged;
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
            dgvPedido.Enabled = true;
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
            var frmDetalle = new frmDetallePedido(listaDetalles, pedido, banderaModificar);
            frmDetalle.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //HABILITAR BANDERA MODIFICAR
            banderaModificar = true;
            //ACTIVAR CONTROLES
            txtDPedido.Enabled = true;
            nudCProducto.Enabled = true;
            cbxProducto.Enabled = true;
            dgvPedido.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnProcesar.Enabled = true;
            btnProducto.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dtpPedido_ValueChanged(object sender, EventArgs e)
        {
            CargarPedidoCreado();
        }

        private void dgvPedidoCreado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var productos = new List<DetalleProducto_E>();
            if (e.RowIndex >= 0)
            {
                int idPedido = Convert.ToInt32(dgvPedidoCreado.Rows[e.RowIndex].Cells["IdPedido"].Value);
                pedidoSeleccionado = new Pedidos_L().ListarPedidos().FirstOrDefault(p => p.IdPedido == idPedido);

                if (pedidoSeleccionado != null)
                {
                    txtDPedido.Text = pedidoSeleccionado.DescripcionPedido;
                    dtpPedido.Value = pedidoSeleccionado.FechaPedido;
                    // Si tienes otros controles, asígnalos aquí
                    // Puedes cargar los productos en dgvPedido si lo deseas
                    dgvPedido.Rows.Clear();
                    foreach (var detalle in pedidoSeleccionado.DetallePedido)
                    {
                        productos.Add(new DetalleProducto_E()
                        {
                            IdProducto = detalle.IdProducto,
                            NombreProducto = detalle.NombreProducto,
                            CantidadPorciones = detalle.CantidadPorciones
                        });
                    }
                }
            }
            // Agrupa por IdSubProducto y NombreSuministros
            var productosAgrupados = productos
                .GroupBy(i => new { i.IdProducto, i.NombreProducto })
                .Select(g => new
                {
                    IdProducto = g.First().IdProducto,
                    NombreProducto = g.Key.NombreProducto,
                    CantidadPorciones = g.First().CantidadPorciones
                });

            // Agrega al grid
            foreach (var ing in productosAgrupados)
            {
                dgvPedido.Rows.Add(
                    ing.IdProducto,
                    ing.NombreProducto,
                    ing.CantidadPorciones
                );
            }

            // Habilita el botón Modificar
            btnModificar.Enabled = true;
           btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
        }
    }
}
