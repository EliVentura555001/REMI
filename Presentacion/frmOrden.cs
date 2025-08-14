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
        private void frmOrden_Load(object sender, EventArgs e)
        {
            CargarGrid();
            CargarComboBox();
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

            // Inicializa el detalle con los subproductos predeterminados
            //var detalleProducto = new DetalleProducto_E
            //{
            //    IdProducto = producto.IdProducto,
            //    NombreProducto = producto.NombreProducto,
            //    CantidadPorcionesP = cantidad,
            //    DetallePedidoProducto = producto.DetalleProducto != null
            //        ? producto.DetalleProducto.Select(dp => new DetallePedidoP_E
            //            {
            //                IdPedido = pedidoSeleccionado?.IdPedido ?? 0, // Asigna el IdPedido del pedido actual
            //                IdProducto = dp.IdProducto,
            //                IdSubProducto = dp.IdSubProducto,
            //            CantidadPorciones = cantidad, // O el valor predeterminado
            //                CostoSubProducto = dp.CostoSubProducto
            //            }).ToList()
            //        : new List<DetallePedidoP_E>()
            //};

            //// Agrega el detalle a la lista de la orden
            //detallesOrden.Add(detalleProducto);

            // Agrega la fila visual al DataGridView
            dgvOrden.Rows.Add(
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
            // 3. Crear el objeto principal y asignar la lista de detalles
            Ordenes_E datosFormulario = new Ordenes_E()
            {
                IdOrden = Convert.ToInt32(txtDOrden.Tag),
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
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
    }
}
