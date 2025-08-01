using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmDetallePedido : Form
    {
        bool banderaModificar = false;
        string mensajeError = string.Empty;

        private List<DetalleProducto_E> productosSeleccionados;
        private Pedidos_E pedidoActual;

        public frmDetallePedido(List<DetalleProducto_E> detalles, Pedidos_E pedidoActual)
        {
            InitializeComponent();
            this.productosSeleccionados = detalles;
            this.pedidoActual = pedidoActual;
        }
        private void CargarGridConSubProductos()
        {
            try
            {
                dgvDetallePedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgvDetallePedido.Columns.Count == 0)
                {
                    dgvDetallePedido.Columns.Add("IdProducto", "IdProducto");
                    dgvDetallePedido.Columns.Add("IdSubProducto", "IdSubProducto");
                    dgvDetallePedido.Columns.Add("NombreSubProducto", "SubProducto");
                    dgvDetallePedido.Columns.Add("CantidadPorciones", "Porciones");
                    dgvDetallePedido.Columns.Add("CostoParcial", "Costo");
                    dgvDetallePedido.Columns.Add("PrecioSubProducto", "Precio");

                    // Oculta las columnas de Ids
                    dgvDetallePedido.Columns["IdProducto"].Visible = false;
                    dgvDetallePedido.Columns["IdSubProducto"].Visible = false;
                    dgvDetallePedido.Columns["PrecioSubProducto"].Visible = false;
                }
                dgvDetallePedido.Rows.Clear();

                // Lista para agrupar subproductos
                var subproductosAgrupados = new Dictionary<string, (int IdProducto, int IdSubProducto, string NombreSubProducto, int CantidadPorciones, decimal CostoUnitario, decimal PrecioSubProducto)>();
                
                foreach (var producto in productosSeleccionados)
                {
                    var subproductos = new Productos_L().ObtenerSubProductosPorProducto(producto.IdProducto);

                    foreach (var sub in subproductos)
                    {
                        if (sub.DetalleProducto != null)
                        {
                            foreach (var detalle in sub.DetalleProducto)
                            {
                                string clave = detalle.NombreSubProducto?.Trim() ?? "";

                                if (subproductosAgrupados.ContainsKey(clave))
                                {
                                    // Suma las porciones
                                    var actual = subproductosAgrupados[clave];
                                    subproductosAgrupados[clave] = (
                                        actual.IdProducto,
                                        actual.IdSubProducto,
                                        actual.NombreSubProducto,
                                        actual.CantidadPorciones + producto.CantidadPorciones,
                                        actual.CostoUnitario,
                                        actual.PrecioSubProducto
                                    );
                                }
                                else
                                {
                                    subproductosAgrupados[clave] = (
                                        detalle.IdProducto,
                                        detalle.IdSubProducto,
                                        detalle.NombreSubProducto,
                                        producto.CantidadPorciones,
                                        detalle.CostoSubProducto,
                                        detalle.PrecioSubProducto
                                    );
                                }
                            }
                        }
                    }
                }

                // Agrega los subproductos agrupados al DataGridView
                foreach (var item in subproductosAgrupados.Values)
                {
                    var nuevaFila = dgvDetallePedido.Rows[dgvDetallePedido.Rows.Add(
                        item.IdProducto,
                        item.IdSubProducto,
                        item.NombreSubProducto,
                        item.CantidadPorciones,
                        item.CostoUnitario * item.CantidadPorciones,
                        item.PrecioSubProducto * item.CantidadPorciones
                    )];
                    // Guarda costo y precio unitario en Tag como una tupla
                    nuevaFila.Tag = (item.CostoUnitario, item.PrecioSubProducto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarGridConIngredientes()
        {
            try
            {
                dgvDetallePedidoSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgvDetallePedidoSP.Columns.Count == 0)
                {
                    dgvDetallePedidoSP.Columns.Add("IdSubProducto", "IdSubProducto");
                    dgvDetallePedidoSP.Columns.Add("IdSuministro", "IdSuministro");
                    dgvDetallePedidoSP.Columns.Add("NombreSuministro", "Ingredientes");
                    dgvDetallePedidoSP.Columns.Add("CantidadSuministroPSP", "Cantidad");
                    dgvDetallePedidoSP.Columns.Add("UnidadMedidaPSP", "Unidad de Medida");
                    dgvDetallePedidoSP.Columns.Add("CostoParcialPSP", "Costo Parcial");

                    dgvDetallePedidoSP.Columns["IdSuministro"].Visible = false;
                    dgvDetallePedidoSP.Columns["IdSubProducto"].Visible = false;
                }
                dgvDetallePedidoSP.Rows.Clear();

                // Lista para almacenar todos los ingredientes con cantidades ajustadas
                var ingredientes = new List<DetalleSubProducto_E>();

                foreach (DataGridViewRow row in dgvDetallePedido.Rows)
                {
                    if (row.Cells["IdSubProducto"].Value != null && row.Cells["CantidadPorciones"].Value != null)
                    {
                        int idSubProducto = Convert.ToInt32(row.Cells["IdSubProducto"].Value);
                        int cantidadPorciones = Convert.ToInt32(row.Cells["CantidadPorciones"].Value);

                        var detalles = new SubProductos_L().ObtenerDetallesDeSubProducto(idSubProducto);

                        foreach (var detalle in detalles)
                        {
                            // Multiplica la cantidad de suministro por la cantidad de porciones
                            ingredientes.Add(new DetalleSubProducto_E
                            {
                                IdSubProducto = detalle.IdSubProducto,
                                IdSuministro = detalle.IdSuministro,
                                NombreSuministros = detalle.NombreSuministros,
                                UnidadMedidaSP = detalle.UnidadMedidaSP,
                                CantidadSuministro = detalle.CantidadSuministro * cantidadPorciones,
                                CostoSuministro = detalle.CostoSuministro * cantidadPorciones
                            });
                        }
                    }
                }

                // Agrupa ingredientes por nombre y suma cantidades
                var ingredientesAgrupados = ingredientes
                    .GroupBy(i => i.NombreSuministros)
                    .Select(g => new
                    {
                        IdSubProducto = g.First().IdSubProducto,
                        IdSuministro = g.First().IdSuministro,
                        NombreSuministro = g.Key,
                        CantidadSuministro = g.Sum(x => x.CantidadSuministro),
                        UnidadMedidaSP = g.First().UnidadMedidaSP,
                        CostoParcialPSP = g.Sum(x => x.CostoSuministro)
                    });

                // Agrega al grid
                foreach (var ing in ingredientesAgrupados)
                {
                    dgvDetallePedidoSP.Rows.Add(
                        ing.IdSubProducto,
                        ing.IdSuministro,
                        ing.NombreSuministro,
                        ing.CantidadSuministro,
                        ing.UnidadMedidaSP,
                        ing.CostoParcialPSP
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmDetallePedido_Load(object sender, EventArgs e)
        {
            CargarGridConSubProductos();
            ActualizarTotales();
            CargarGridConIngredientes();
            dgvDetallePedido.CellValueChanged += dgvDetallePedido_CellValueChanged;
        }

        private void btnCompletar_Click(object sender, EventArgs e)
        {
            // 1. Recopilar los detalles desde el DataGridView dgvDetallePedido
            List<DetalleProducto_E> detallesP = new List<DetalleProducto_E>();
            foreach (DataGridViewRow row in dgvDetallePedido.Rows)
            {
                if (!row.IsNewRow)
                {
                    var detallep = new DetalleProducto_E
                    {
                        IdDetalleProducto = Convert.ToInt32(row.Cells["IdProducto"].Tag), // Se genera en BD si es autoincremental
                        IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value),
                        IdSubProducto = Convert.ToInt32(row.Cells["IdSubProducto"].Value),
                        CantidadPorciones = Convert.ToInt32(row.Cells["CantidadPorciones"].Value),
                        CostoSubProducto = Convert.ToDecimal(row.Cells["CostoParcial"].Value),
                        PrecioSubProducto = Convert.ToDecimal(row.Cells["PrecioSubProducto"].Value),
                    };
                    detallesP.Add(detallep);
                }
            }

            // 2. Recopilar los detalles desde el DataGridView dgvDetallePedidoSP
            List<DetalleSubProducto_E> detallesSP = new List<DetalleSubProducto_E>();
            foreach (DataGridViewRow row in dgvDetallePedidoSP.Rows)
            {
                if (!row.IsNewRow)
                {
                    var detallesp = new DetalleSubProducto_E
                    {
                        IdDetalleSubProducto = Convert.ToInt32(row.Cells["IdSubProducto"].Tag), // Se genera en BD si es autoincremental
                        IdSubProducto = Convert.ToInt32(row.Cells["IdSubProducto"].Value),
                        IdSuministro = Convert.ToInt32(row.Cells["IdSuministro"].Value),
                        CantidadSuministro = Convert.ToDecimal(row.Cells["CantidadSuministroPSP"].Value),
                        UnidadMedidaSP = row.Cells["UnidadMedidaPSP"].Value?.ToString(),
                        CostoSuministro = Convert.ToDecimal(row.Cells["CostoParcialPSP"].Value),
                    };
                    detallesSP.Add(detallesp);
                }
            }

            // 3. Crear el objeto principal y asignar la lista de detalles
            Pedidos_E datosFormulario = new Pedidos_E()
            {
                DescripcionPedido = pedidoActual?.DescripcionPedido ?? "Pedido generado",
                DetallePedido = detallesP,
                DetallePedidoSP = detallesSP
            };

            // 4. Guardar el objeto principal con sus detalles
            if (banderaModificar == false)
            {
                if (new Pedidos_L().Guardar(datosFormulario, ref mensajeError))
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
                if (new Pedidos_L().Actualizar(datosFormulario, ref mensajeError))
                {
                    MessageBox.Show("Registro actualizado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //Cerrar el formulario después de guardar o actualizar
            this.Close();
        }

        private void dgvDetallePedido_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Solo recalcula si la columna modificada es "Porciones"
            if (dgvDetallePedido.Columns[e.ColumnIndex].Name == "CantidadPorciones")
            {
                var fila = dgvDetallePedido.Rows[e.RowIndex];

                // Obtén el nuevo valor de porciones
                int nuevasPorciones = 0;
                int.TryParse(fila.Cells["CantidadPorciones"].Value?.ToString(), out nuevasPorciones);

                // Obtén costo y precio unitario del subproducto desde Tag
                decimal costoUnitario = 0;
                decimal precioUnitario = 0;
                if (fila.Tag != null)
                {
                    var tuple = ((decimal, decimal))fila.Tag;
                    costoUnitario = tuple.Item1;
                    precioUnitario = tuple.Item2;
                }

                // Calcula el nuevo costo parcial
                decimal nuevoCostoParcial = nuevasPorciones * costoUnitario;
                // Calcula el nuevo precio parcial
                decimal nuevoPrecioParcial = nuevasPorciones * precioUnitario;

                // Actualiza la celda de CostoParcial
                fila.Cells["CostoParcial"].Value = nuevoCostoParcial;
                // Actualiza la celda de PrecioSubProducto
                fila.Cells["PrecioSubProducto"].Value = nuevoPrecioParcial;

                // Actualiza el grid de ingredientes
                CargarGridConIngredientes();
                ActualizarTotales();
            }
        }

        private void ActualizarTotales()
        {
            decimal totalCosto = 0;
            decimal totalPrecio = 0;

            foreach (DataGridViewRow row in dgvDetallePedido.Rows)
            {
                if (row.Cells["CostoParcial"].Value != null)
                    totalCosto += Convert.ToDecimal(row.Cells["CostoParcial"].Value);

                if (row.Cells["PrecioSubProducto"].Value != null)
                    totalPrecio += Convert.ToDecimal(row.Cells["PrecioSubProducto"].Value);
            }

            lblCostoT.Text = "Costo Total: " + totalCosto.ToString("N2");
            lblPrecioT.Text = "Precio Total: " + totalPrecio.ToString("N2");
            lblGananciaB.Text = "Margen de Ganancia: " + (totalPrecio - totalCosto).ToString("N2");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
