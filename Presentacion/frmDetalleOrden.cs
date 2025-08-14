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
    public partial class frmDetalleOrden : Form
    {
        private DetalleProducto_E productoSeleccionado;
        public List<DetallePedidoP_E> SubproductosSeleccionados { get; private set; }
        public IEnumerable<DetalleProducto_E> DetallesSeleccionados { get; internal set; }

        public frmDetalleOrden(DetalleProducto_E detalles)
        {
            InitializeComponent();
            this.productoSeleccionado = detalles;
        }

        private void CargarSubproductos()
        {
            try
            {
                dgvDetalleOrden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgvDetalleOrden.Columns.Count == 0)
                {
                    dgvDetalleOrden.Columns.Add("IdProducto", "IdProducto");
                    dgvDetalleOrden.Columns.Add("IdSubProducto", "IdSubProducto");
                    dgvDetalleOrden.Columns.Add("NombreProducto", "Producto");
                    dgvDetalleOrden.Columns.Add("NombreSubProducto", "SubProducto");
                    dgvDetalleOrden.Columns.Add("CantidadPorciones", "Porciones");
                    dgvDetalleOrden.Columns.Add("CostoParcial", "Costo");
                    dgvDetalleOrden.Columns.Add("PrecioSubProducto", "Precio");

                    // Oculta las columnas de Ids
                    dgvDetalleOrden.Columns["IdProducto"].Visible = false;
                    dgvDetalleOrden.Columns["IdSubProducto"].Visible = false;
                    dgvDetalleOrden.Columns["CostoParcial"].Visible = false;
                }
                dgvDetalleOrden.Rows.Clear();

                var subproductosAgrupados = new Dictionary<(int IdProducto, int IdSubProducto), (string NombreProducto, string NombreSubProducto, int CantidadPorciones, decimal CostoUnitario, decimal PrecioSubProducto)>();

                bool primerproducto = true;
                var subproductos = new Productos_L().ObtenerSubProductosPorProducto(productoSeleccionado.IdProducto);

                foreach (var sub in subproductos)
                {
                    if (sub.DetalleProducto != null)
                    {
                        foreach (var detalle in sub.DetalleProducto)
                        {
                            var clave = (detalle.IdProducto, detalle.IdSubProducto);

                            // Lógica para decidir la cantidad de porciones
                            int cantidadPorciones = detalle.CantidadPorcionesP;

                            string nombreProductoMostrar = primerproducto ? detalle.NombreProducto : "";
                            primerproducto = false;
                            if (subproductosAgrupados.ContainsKey(clave))
                            {
                                var actual = subproductosAgrupados[clave];
                                subproductosAgrupados[clave] = (
                                    nombreProductoMostrar,
                                    actual.NombreSubProducto,
                                    productoSeleccionado.CantidadPorcionesP,
                                    actual.CostoUnitario,
                                    actual.PrecioSubProducto = actual.CostoUnitario * 1.5m
                                );
                            }
                            else
                            {
                                subproductosAgrupados[clave] = (
                                    nombreProductoMostrar,
                                    detalle.NombreSubProducto,
                                    productoSeleccionado.CantidadPorcionesP,
                                    detalle.CostoSubProducto,
                                    detalle.PrecioSubProducto = detalle.CostoSubProducto * 1.5m
                                );
                            }
                        }
                    }
                }

                // Agrega los subproductos agrupados al DataGridView
                foreach (var kvp in subproductosAgrupados)
                {
                    var key = kvp.Key;
                    var item = kvp.Value;
                    var nuevaFila = dgvDetalleOrden.Rows[dgvDetalleOrden.Rows.Add(
                        key.IdProducto,
                        key.IdSubProducto,
                        item.NombreProducto,
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
        private void CargarListBox()
        {
            try
            {
                clbSubProducto.Items.Clear();
                var subproductosactivos = new SubProductos_L().ListarSubProductosActivos();
                foreach (var sub in subproductosactivos)
                {
                    clbSubProducto.Items.Add(sub, false); // Agrega el objeto completo, puedes mostrar el nombre con DisplayMember
                }
                clbSubProducto.DisplayMember = "NombreSubProducto";
                clbSubProducto.ValueMember = "IdSubProducto";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmDetalleOrden_Load(object sender, EventArgs e)
        {
            CargarSubproductos();
            CargarListBox();
            MarcarSubproductosEnListBox();
            clbSubProducto.ItemCheck += clbSubProducto_ItemCheck;
        }

        private void clbSubProducto_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((Action)(() =>
            {
                var subproducto = clbSubProducto.Items[e.Index] as SubProductos_E;
                if (e.NewValue == CheckState.Checked)
                {
                    // Si se marca, agregar al DataGridView (evita duplicados)
                    bool existe = false;
                    foreach (DataGridViewRow row in dgvDetalleOrden.Rows)
                    {
                        if (row.Cells["IdSubProducto"].Value != null &&
                            Convert.ToInt32(row.Cells["IdSubProducto"].Value) == subproducto.IdSubProducto)
                        {
                            existe = true;
                            break;
                        }
                    }
                    if (!existe)
                    {
                        int rowIndex = dgvDetalleOrden.Rows.Add(
                            productoSeleccionado.IdProducto,
                            subproducto.IdSubProducto,
                            "",
                            subproducto.NombreSubProducto,
                            productoSeleccionado.CantidadPorcionesP,
                            productoSeleccionado.CostoSubProducto
                        );

                        // Supón que tienes el costo unitario en subproducto.CostoSubProducto
                        decimal precioUnitario = subproducto.CostoSubProducto * 1.5m;
                        int cantidad = productoSeleccionado.CantidadPorcionesP;

                        dgvDetalleOrden.Rows[rowIndex].Cells["PrecioSubProducto"].Value = precioUnitario * cantidad;
                    }
                }
                else
                {
                    // Si se desmarca, eliminar del DataGridView
                    foreach (DataGridViewRow row in dgvDetalleOrden.Rows)
                    {
                        if (row.Cells["IdSubProducto"].Value != null &&
                            Convert.ToInt32(row.Cells["IdSubProducto"].Value) == subproducto.IdSubProducto)
                        {
                            dgvDetalleOrden.Rows.Remove(row);
                            break;
                        }
                    }
                }
            }));
        }

        private void MarcarSubproductosEnListBox()
        {
            // Obtén los IdSubProducto que están en el DataGridView
            var idsMarcados = new HashSet<int>();
            foreach (DataGridViewRow row in dgvDetalleOrden.Rows)
            {
                if (row.Cells["IdSubProducto"].Value != null)
                {
                    idsMarcados.Add(Convert.ToInt32(row.Cells["IdSubProducto"].Value));
                }
            }

            // Recorre los items del CheckedListBox y márcalos si están en el DataGridView
            for (int i = 0; i < clbSubProducto.Items.Count; i++)
            {
                var subproducto = clbSubProducto.Items[i] as SubProductos_E;
                if (subproducto != null && idsMarcados.Contains(subproducto.IdSubProducto))
                {
                    clbSubProducto.SetItemChecked(i, true);
                }
                else
                {
                    clbSubProducto.SetItemChecked(i, false);
                }
            }
        }

        private void dgvDetalleOrden_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que la columna modificada sea la de cantidad
            if (dgvDetalleOrden.Columns[e.ColumnIndex].Name == "CantidadPorciones")
            {
                var row = dgvDetalleOrden.Rows[e.RowIndex];
                int cantidad = 0;
                decimal precioUnitario = 0;

                // Obtén la cantidad nueva
                if (row.Cells["CantidadPorciones"].Value != null)
                    int.TryParse(row.Cells["CantidadPorciones"].Value.ToString(), out cantidad);

                // Obtén el costo unitario (puedes guardarlo en Tag o buscarlo en tu lista de subproductos)
                if (row.Tag is ValueTuple<decimal, decimal> tag)
                {
                    precioUnitario = tag.Item2; // Precio unitario (ya multiplicado por 1.5)
                }
                else
                {
                    // Si no está en Tag, obtén el IdSubProducto y busca el costo en tu lista
                    int idSubProducto = Convert.ToInt32(row.Cells["IdSubProducto"].Value);
                    var subproducto = clbSubProducto.Items
                        .OfType<SubProductos_E>()
                        .FirstOrDefault(s => s.IdSubProducto == idSubProducto);
                    if (subproducto != null)
                        precioUnitario = subproducto.CostoSubProducto * 1.5m;
                }

                // Actualiza el precio
                row.Cells["PrecioSubProducto"].Value = precioUnitario * cantidad;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var seleccionados = new List<DetallePedidoP_E>();

            foreach (DataGridViewRow row in dgvDetalleOrden.Rows)
            {
                if (row.IsNewRow) continue;

                var detalle = new DetallePedidoP_E
                {
                    IdProducto = productoSeleccionado.IdProducto,
                    IdSubProducto = row.Cells["IdSubProducto"].Value != null ? Convert.ToInt32(row.Cells["IdSubProducto"].Value) : 0,
                    NombreProducto = productoSeleccionado.NombreProducto,
                    NombreSubProducto = row.Cells["NombreSubProducto"].Value?.ToString(),
                    CantidadPorciones = row.Cells["CantidadPorciones"].Value != null ? Convert.ToInt32(row.Cells["CantidadPorciones"].Value) : 0,
                    CostoSubProducto = row.Cells["CostoParcial"].Value != null ? Convert.ToDecimal(row.Cells["CostoParcial"].Value) : 0
                };

                seleccionados.Add(detalle);
            }

            SubproductosSeleccionados = seleccionados;
            DetallesSeleccionados = SubproductosSeleccionados.Select(s => new DetalleProducto_E
            {
                IdProducto = s.IdProducto,
                IdSubProducto = s.IdSubProducto,
                NombreProducto = s.NombreProducto,
                NombreSubProducto = s.NombreSubProducto,
                CantidadPorcionesP = s.CantidadPorciones,
                CostoSubProducto = s.CostoSubProducto,
                PrecioSubProducto = s.CostoSubProducto * 1.5m
            }).ToList();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
