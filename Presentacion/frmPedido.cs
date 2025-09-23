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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
                    dgvPedido.Columns.Add("IdPedido", "IdPedido");
                    dgvPedido.Columns.Add("IdProducto", "IdProducto");
                    dgvPedido.Columns.Add("NombreProducto", "Platillo");
                    dgvPedido.Columns.Add("CantidadPorciones", "Porciones");

                    //Ocultar los ID
                    dgvPedido.Columns["IdPedido"].Visible = false;
                    dgvPedido.Columns["IdProducto"].Visible = false;
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
                // Agregar columna de acciones si no existe
                DataGridViewButtonColumn opcionesCol = new DataGridViewButtonColumn();
                opcionesCol.Name = "Opciones";
                opcionesCol.HeaderText = "Opciones";
                opcionesCol.Text = "Detalles";
                opcionesCol.UseColumnTextForButtonValue = true;
                dgvPedidoCreado.Columns.Add(opcionesCol);
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
                    pedido.FechaPedido.ToString("dd/MM/yyyy")
                    //pedido.FechaModPedido
                    );
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
        private void LlenarDetalleOrden(Pedidos_E pedido)
        {
            dgvDetallesSubP.Rows.Clear();
            dgvDetallesSubP.Columns.Clear();
            dgvDetallesSubP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configura las columnas solo una vez
            if (dgvDetallesSubP.Columns.Count == 0)
            {
                dgvDetallesSubP.Columns.Add("NombreProducto", "Platillo");
                dgvDetallesSubP.Columns.Add("NombreSubProducto", "Elemento");
                dgvDetallesSubP.Columns.Add("CantidadPorciones", "Porciones");
                dgvDetallesSubP.Columns.Add("NombreSuministro", "Suministro");
                dgvDetallesSubP.Columns.Add("CantidadSuministro", "Cantidad Suministro");
            }

            // Relaciona cada subproducto con sus suministros
            bool productoMostrado = false;
            foreach (var detalleProd in pedido.DetallePedido)
            {
                // Busca los suministros asociados a este subproducto
                var suministros = pedido.DetallePedidoSP
                    .Where(sp => sp.IdSubProducto == detalleProd.IdSubProducto)
                    .ToList();

                // Si hay suministros, muestra cada uno en una fila
                if (suministros.Count > 0)
                {
                    bool primersubproducto = true;
                    bool Cantidad = true;
                    foreach (var suministro in suministros)
                    {
                        string productoMostrar = !productoMostrado ? detalleProd.NombreProducto : "";
                        productoMostrado = true;
                        string SubProductoMostrar = primersubproducto ? detalleProd.NombreSubProducto : "";
                        primersubproducto = false;
                        decimal CantidadMostrar = Cantidad ? detalleProd.CantidadPorcionesP : 0;
                        Cantidad = false;

                        // Si CantidadMostrar es 0, mostrar cadena vacía
                        string cantidadMostrarStr = CantidadMostrar == 0 ? "" : CantidadMostrar.ToString();

                        dgvDetallesSubP.Rows.Add(
                            productoMostrar,
                            SubProductoMostrar,
                            cantidadMostrarStr,
                            suministro.NombreSuministros,
                            suministro.CantidadSuministro
                        );
                    }
                }
                else
                {
                    // Si no hay suministros, muestra solo el producto y subproducto
                    dgvDetallesSubP.Rows.Add(
                        detalleProd.NombreProducto,
                        detalleProd.NombreSubProducto,
                        detalleProd.CantidadPorcionesP,
                        "", // Sin suministro
                        ""  // Sin cantidad
                    );
                }
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
            DetallePedidoP_E datosFormulario = new DetallePedidoP_E()
            {
                IdPedido = Convert.ToInt32(txtDPedido.Tag),
                IdProducto = Convert.ToInt32(cbxProducto.SelectedValue),
                NombreProducto = cbxProducto.Text.Trim(),
                CantidadPorciones = (int)nudCProducto.Value
            };
            // Agregar al DataGridView
            dgvPedido.Rows.Add(
                    datosFormulario.IdPedido,      
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
                        CantidadPorcionesP = Convert.ToInt32(row.Cells["CantidadPorciones"].Value)
                    });
                }
            }
            Pedidos_E pedido;
            if (banderaModificar && pedidoSeleccionado != null)
            {
                // Editando: usa el pedido seleccionado, actualiza la descripción si cambió
                pedido = pedidoSeleccionado;
                pedido.DescripcionPedido = txtDPedido.Text.Trim();
                // Si quieres actualizar los detalles, asigna listaDetalles
                pedido.DetallePedido = listaDetalles;
            }
            else
            {
                // Nuevo pedido
                pedido = new Pedidos_E
                {
                    DescripcionPedido = txtDPedido.Text.Trim(),
                    DetallePedido = listaDetalles
                };
            }

            var frmDetalle = new frmDetallePedido(listaDetalles, pedido, banderaModificar);
            frmDetalle.ShowDialog();
            CargarPedidoCreado();
            Limpiar();
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
            var productos = new List<DetallePedidoP_E>();
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
                        productos.Add(new DetallePedidoP_E()
                        {
                            IdPedido = pedidoSeleccionado.IdPedido,
                            IdProducto = detalle.IdProducto,
                            NombreProducto = detalle.NombreProducto,
                            //CantidadPorciones = detalle.CantidadPorciones
                        });
                    }
                }
            }
            // Agrupa por IdSubProducto y NombreSuministros
            var productosAgrupados = productos
                .GroupBy(i => new { i.IdProducto, i.NombreProducto })
                .Select(g => new
                {
                    IdPedido = g.Key,
                    IdProducto = g.First().IdProducto,
                    NombreProducto = g.Key.NombreProducto,
                    //CantidadPorciones = g.First().CantidadPorciones
                });

            // Agrega al grid
            foreach (var ing in productosAgrupados)
            {
                dgvPedido.Rows.Add(
                    pedidoSeleccionado.IdPedido,
                    ing.IdProducto,
                    ing.NombreProducto
                    //ing.CantidadPorciones
                );
            }

            // Habilita el botón Modificar
            btnModificar.Enabled = true;
           btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
        }

        private void dgvPedidoCreado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < dgvPedidoCreado.Columns.Count && dgvPedidoCreado.Columns[e.ColumnIndex].Name == "Opciones")
            {
                gbDetalles.Enabled = true;
                btnCerrar.Enabled = true;
                // OBTENER EL ID DE LA FILA SELECCIONADA
                var row = dgvPedidoCreado.Rows[e.RowIndex];
                int idPedido = Convert.ToInt32(row.Cells["IdPedido"].Value);

                // OBTENER LOS DETALLES DE LA ORDEN
                var detalles = new Pedidos_L().ListarPedidos().FirstOrDefault(p => p.IdPedido == idPedido);

                if (detalles != null)
                {
                    // Llenar el DataGridView de detalles
                    LlenarDetalleOrden(detalles);

                    // Mostrar el GroupBox
                    gbDetalles.Visible = true;
                    gbDetalles.BringToFront();
                }
                else
                {
                    MessageBox.Show("No hay detalles disponibles para esta orden", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            gbDetalles.Visible = false;
        }
    }
}
