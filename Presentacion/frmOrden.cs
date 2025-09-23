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
    public partial class frmOrden : Form
    {
        bool banderaModificar = false;
        string mensajeError = string.Empty;
        private Pedidos_E pedidoSeleccionado; // Variable para almacenar el pedido actual
        private List<DetalleProducto_E> detallesOrden = new List<DetalleProducto_E>();

        public frmOrden()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            txtDOrden.Enabled = false;
            cbxProducto.Enabled = false;
            nudCProducto.Enabled = false;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnProcesar.Enabled = false;
            btnCancelar.Enabled = false;
            btnProducto.Enabled = false;
            dgvOrden.Enabled = false;
            txtDOrden.Clear();
            nudCProducto.Value = 0;
            cbxProducto.SelectedIndex = -1;
            dgvOrden.Rows.Clear();
            banderaModificar = false;
        }
        private void CargarGrid()
        {
            try
            {
                //Llenar los espacios del DataGridView
                dgvOrden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgvOrden.Columns.Count == 0)
                {
                    dgvOrden.Columns.Add("IdOrden", "IdOrden");
                    dgvOrden.Columns.Add("IdPedido", "IdPedido");
                    dgvOrden.Columns.Add("IdProducto", "IdProducto");
                    dgvOrden.Columns.Add("NombreProducto", "Platillo");
                    dgvOrden.Columns.Add("CantidadPorciones", "Porciones");
                    dgvOrden.Columns.Add("PrecioOrden", "Precio");

                    // Agregar columna de acciones si no existe
                    if (!dgvOrden.Columns.Contains("Acciones"))
                    {
                        DataGridViewButtonColumn accionesCol = new DataGridViewButtonColumn();
                        accionesCol.Name = "Acciones";
                        accionesCol.HeaderText = "Acciones";
                        accionesCol.Text = "Detalles";
                        accionesCol.UseColumnTextForButtonValue = true;
                        dgvOrden.Columns.Add(accionesCol);
                    }
                    //Ocultar los ID

                    dgvOrden.Columns["IdOrden"].Visible = false;
                    dgvOrden.Columns["IdPedido"].Visible = false;
                    dgvOrden.Columns["IdProducto"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarComboBox()
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
        private void CargaGridOrdenes()
        {
            try
            {
                //Llenar los espacios del DataGridView
                dgvOrdenCreada.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgvOrdenCreada.Columns.Count == 0)
                {

                    dgvOrdenCreada.Columns.Add("IdOrden", "IdOrden");
                    dgvOrdenCreada.Columns.Add("Descripcion", "Descripción");
                    dgvOrdenCreada.Columns.Add("Fecha", "Fecha de Creación");

                    //dgvPedidoCreado.Columns.Add("FechaModPedido", "Fecha de Modificación");
                    // Agregar columna de acciones si no existe
                    DataGridViewButtonColumn opcionesCol = new DataGridViewButtonColumn();
                    opcionesCol.Name = "Opciones";
                    opcionesCol.HeaderText = "Opciones";
                    opcionesCol.Text = "Detalles";
                    opcionesCol.UseColumnTextForButtonValue = true;
                    dgvOrdenCreada.Columns.Add(opcionesCol);

                   dgvOrdenCreada.Columns["IdOrden"].Visible = false; 
                }
                dgvOrdenCreada.Rows.Clear();

                DateTime fechaSeleccionada = dtpOrden.Value.Date;
                List<Ordenes_E> ordenes = new Ordenes_L().ListaOrdenes()
                    .Where(p => p.FechaCreacionOrden.Date == fechaSeleccionada)
                    .ToList();

                foreach (var orden in ordenes)
                {
                    dgvOrdenCreada.Rows.Add(
                        orden.IdOrden,
                        orden.DescripcionOrden,
                        orden.FechaCreacionOrden.ToString("dd/MM/yyyy")
                        //pedido.FechaModPedido
                        );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LlenarDetalleOrden(List<DetalleOrden_E> detalles)
        {
            dgvDetallesProd.Rows.Clear();
            dgvDetallesProd.Columns.Clear();
            dgvDetallesProd.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.Fill;
            // Agrega las columnas si es necesario
            if (dgvDetallesProd.Columns.Count == 0)
            {
                dgvDetallesProd.Columns.Add("NombreProducto", "Platillo");
                dgvDetallesProd.Columns.Add("NombreSubProducto", "Elementos");
                dgvDetallesProd.Columns.Add("CantidadPorciones", "Porciones");
                dgvDetallesProd.Columns.Add("PrecioOrden", "Precio");
            }
            bool primerproducto = true;
            // Llena las filas
            foreach (var detalle in detalles)
            {
                string nombreProductoMostrar = primerproducto ? detalle.NombreProducto : "";
                primerproducto = false;
                dgvDetallesProd.Rows.Add(
                    nombreProductoMostrar,
                    detalle.NombreSubProducto,
                    detalle.CantidadPorciones,
                    detalle.PrecioOrden
                );
            }
        }
        private void frmOrden_Load(object sender, EventArgs e)
        {
            CargarGrid();
            CargarComboBox();
            CargaGridOrdenes();
            dtpOrden.ValueChanged += dtpOrden_ValueChanged;
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            if (cbxProducto.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProductoSeleccionado = Convert.ToInt32(cbxProducto.SelectedValue);
            int cantidad = (int)nudCProducto.Value;

            // Obtén el producto y sus subproductos predeterminados
            var producto = (new Productos_L().ListarProductosActivos())
                .FirstOrDefault(p => p.IdProducto == idProductoSeleccionado);

            if (producto == null)
            {
                MessageBox.Show("No se encontró el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Agrega la fila visual al DataGridView
            dgvOrden.Rows.Add(
                0,
                0, // IdOrden y IdPedido se pueden ajustar según tu lógica
                producto.IdProducto,
                producto.NombreProducto,
                cantidad,
                producto.CostoProducto * cantidad * 1.5m
            );

            cbxProducto.SelectedIndex = -1;
            nudCProducto.Value = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDOrden.Enabled = true;
            cbxProducto.Enabled = true;
            nudCProducto.Enabled = true;
            dgvOrden.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnProcesar.Enabled = true;
            btnCancelar.Enabled = true;
            btnProducto.Enabled = true;
            banderaModificar = false;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada
            if (dgvOrden.CurrentRow != null)
            {
                object valorCelda = dgvOrden.CurrentRow.Cells["IdOrden"].Value;
                int idOrden = (valorCelda != null && valorCelda != DBNull.Value) ? Convert.ToInt32(valorCelda) : 0;

                Ordenes_E datosFormulario = new Ordenes_E()
                {
                    IdOrden = idOrden,
                    DescripcionOrden = txtDOrden.Text.Trim(),
                    DetalleOrden = detallesOrden.Select(dp => new DetalleOrden_E
                    {
                        IdPedido = pedidoSeleccionado?.IdPedido ?? 0,
                        IdProducto = dp.IdProducto,
                        IdSubProducto = dp.IdSubProducto,
                        CantidadPorciones = dp.CantidadPorcionesP,
                        PrecioOrden = dp.PrecioSubProducto
                    }).ToList()
                };

                // 4. Guardar el objeto principal con sus detalles
                if (banderaModificar == false)
                {
                    if (new Ordenes_L().Guardar(datosFormulario, ref mensajeError))
                    {
                        MessageBox.Show("Registro guardado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (new Ordenes_L().Actualizar(datosFormulario, ref mensajeError))
                    {
                        MessageBox.Show("Registro actualizado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Si no hay fila seleccionada, puedes decidir si asignar 0 o mostrar un mensaje
                Ordenes_E datosFormulario = new Ordenes_E()
                {
                    IdOrden = 0,
                    DescripcionOrden = txtDOrden.Text.Trim(),
                    DetalleOrden = detallesOrden.Select(dp => new DetalleOrden_E
                    {
                        IdPedido = pedidoSeleccionado?.IdPedido ?? 0,
                        IdProducto = dp.IdProducto,
                        IdSubProducto = dp.IdSubProducto,
                        CantidadPorciones = dp.CantidadPorcionesP,
                        PrecioOrden = dp.PrecioSubProducto
                    }).ToList()
                };

                // ... (el resto del código para guardar o actualizar)
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            //HABILITAR BANDERA MODIFICAR
            banderaModificar = true;
            //ACTIVAR CONTROLES
            txtDOrden.Enabled = true;
            nudCProducto.Enabled = true;
            cbxProducto.Enabled = true;
            dgvOrden.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnProcesar.Enabled = true;
            btnProducto.Enabled = true;
            btnCancelar.Enabled = true;
        }
        private void dgvOrden_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrden.Columns[e.ColumnIndex].Name == "Acciones")
            {
                // Obtén la fila seleccionada
                var row = dgvOrden.Rows[e.RowIndex];

                // Crea el objeto con los datos necesarios
                DetalleProducto_E detalle = new DetalleProducto_E
                {
                    IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value),
                    CantidadPorcionesP = Convert.ToInt32(row.Cells["CantidadPorciones"].Value)
                };

                // Envía el objeto al formulario de detalles
                frmDetalleOrden detalleForm = new frmDetalleOrden(detalle);
                if (detalleForm.ShowDialog() == DialogResult.OK)
                {
                    // Agrega o actualiza los detalles en la lista principal
                    // Por ejemplo, puedes tener una lista List<DetalleOrden_E> detallesOrden
                    detallesOrden.AddRange(detalleForm.DetallesSeleccionados);
                }
            }
        }

        private void dtpOrden_ValueChanged(object sender, EventArgs e)
        {
            CargaGridOrdenes();
        }

        private void dgvOrdenCreada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < dgvOrdenCreada.Columns.Count && dgvOrdenCreada.Columns[e.ColumnIndex].Name == "Opciones")
            {
                gbDetalles.Enabled= true;
                btnCerrar.Enabled= true;
                // OBTENER EL ID DE LA FILA SELECCIONADA
                var row = dgvOrdenCreada.Rows[e.RowIndex];
                int idOrden = Convert.ToInt32(row.Cells["IdOrden"].Value);

                // OBTENER LOS DETALLES DE LA ORDEN
                var detalles = new Ordenes_L().ObtenerDetallesOrdenporID(idOrden);

                if (detalles != null && detalles.Count > 0)
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

        private void dgvOrdenCreada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 1. Obtener el Id de la orden seleccionada
                int idOrden = Convert.ToInt32(dgvOrdenCreada.Rows[e.RowIndex].Cells["IdOrden"].Value);

                // 2. Obtener la orden y sus detalles
                var orden = new Ordenes_L().ListaOrdenes().FirstOrDefault(p => p.IdOrden == idOrden);

                if (orden != null)
                {
                    // 3. Cargar la descripción en el textbox
                    txtDOrden.Text = orden.DescripcionOrden;

                    // 4. Limpiar y cargar los productos en el DataGridView
                    dgvOrden.Rows.Clear();

                    // Agrupar los detalles por IdOrden, IdProducto, NombreProducto
                    var detallesAgrupados = orden.DetalleOrden
                        .GroupBy(d => new { d.IdOrden,d.IdPedido, d.IdProducto, d.NombreProducto })
                        .Select(g => new
                        {
                            IdOrden = g.Key.IdOrden,
                            IdProducto = g.Key.IdProducto,
                            IdPedido = g.Key.IdPedido,
                            NombreProducto = g.Key.NombreProducto,
                            CantidadPorciones = g.Min(x => x.CantidadPorciones),
                            PrecioOrden = g.Sum(x => x.PrecioOrden)
                        });

                    foreach (var detalle in detallesAgrupados)
                    {
                        dgvOrden.Rows.Add(
                            idOrden,
                            detalle.IdPedido,
                            detalle.IdProducto,
                            detalle.NombreProducto,
                            detalle.CantidadPorciones,
                            detalle.PrecioOrden
                        );
                    }

                    // 5. Habilitar botones de edición
                    btnModificar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnNuevo.Enabled = false;

                    // Si necesitas habilitar otros controles, hazlo aquí
                }
                else
                {
                    MessageBox.Show("No se pudo cargar la orden seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
