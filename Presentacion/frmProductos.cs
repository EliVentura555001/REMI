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
    public partial class frmProductos : Form
    {
        bool banderaModificar = false;
        string mensajeError = string.Empty;
        public frmProductos()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            txtNProducto.Enabled = false;
            txtDProducto.Enabled = false;
            cbxCategoria.Enabled = false;
            cbxDetalleSP.Enabled = false;
            cbProducto.Enabled = false;
            btnNuevo.Enabled = true;
            btnSubProducto.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            txtNProducto.Clear();
            txtDProducto.Clear();
            txtCProducto.Clear();
            txtPProducto.Clear();
            cbxCategoria.SelectedIndex = -1;
            cbxDetalleSP.SelectedIndex = -1;
            cbProducto.Checked = false;
            dgvSubProductos.Rows.Clear();
            dgvSubProductos.Enabled = false;

            banderaModificar = false;
        }
        public void CargarComboBox()
        {
            try
            {
                //CARGAR SUBPRODUCTOS ACTIVOS
                List<SubProductos_E> subProductosactivos = new List<SubProductos_E>();
                subProductosactivos = new SubProductos_L().ListarSubProductosActivos();
                cbxDetalleSP.DataSource = subProductosactivos;
                cbxDetalleSP.DisplayMember = "NombreSubProducto";
                cbxDetalleSP.ValueMember = "IdSubProducto";

                //CARGAR CATEGORIAS ACTIVAS
                List<Categorias_E> categorias = new List<Categorias_E>();
                categorias = new Categorias_L().ListarCategoriasActivas();
                cbxCategoria.DataSource = categorias;
                cbxCategoria.DisplayMember = "NombreCategoria";
                cbxCategoria.ValueMember = "IdCategoria";
                cbxCategoria.SelectedIndex = -1;
                cbxDetalleSP.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CargarGridProd()
        {
            try
            {
                List<Productos_E> productos = new List<Productos_E>();
                productos = new Productos_L().ListarProductos();
                dgvProducto.DataSource = productos;
                dgvProducto.Columns["IdProducto"].Visible = false;
                dgvProducto.Columns["IdCategoria"].Visible = false;
                dgvProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Personaliza los títulos de las columnas
                dgvProducto.Columns["NombreProducto"].HeaderText = "Nombre";
                dgvProducto.Columns["DescripcionProducto"].HeaderText = "Descripcion";
                dgvProducto.Columns["CostoProducto"].HeaderText = "Costo";
                dgvProducto.Columns["PrecioProducto"].HeaderText = "Precio";
                dgvProducto.Columns["NombreCategoria"].HeaderText = "Categoria";
                // Agrega columna para los subproductos
                if (!dgvProducto.Columns.Contains("SubProductos"))
                {
                    DataGridViewTextBoxColumn colSubProductos = new DataGridViewTextBoxColumn();
                    colSubProductos.HeaderText = "SubProductos";
                    colSubProductos.Name = "SubProductos";
                    colSubProductos.ReadOnly = true;
                    dgvProducto.Columns.Add(colSubProductos);
                }

                dgvProducto.Columns["EstadoProducto"].HeaderText = "Estado";
                // Llena la columna con los nombres concatenados
                foreach (DataGridViewRow row in dgvProducto.Rows)
                {
                    var Product = row.DataBoundItem as Productos_E;
                    if (Product != null)
                    {
                        string nombres = string.Join(", ",
                        Product.DetalleProducto
                        .Select(d => d.NombreSubProducto)
                        .Where(n => !string.IsNullOrEmpty(n.ToString()))
                        );
                        row.Cells["SubProductos"].Value = nombres;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarGridSP()
        {
            try
            {
                dgvSubProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (!dgvSubProductos.Columns.Contains("IdDetalleProducto"))
                {
                    DataGridViewTextBoxColumn colIdDetalleP = new DataGridViewTextBoxColumn();
                    colIdDetalleP.HeaderText = "IdDetalleProducto";
                    colIdDetalleP.Name = "IdDetalleProducto";
                    colIdDetalleP.Visible = false;
                    dgvSubProductos.Columns.Add(colIdDetalleP);
                }
                if (!dgvSubProductos.Columns.Contains("IdSubProducto"))
                {
                    DataGridViewTextBoxColumn colIdSP = new DataGridViewTextBoxColumn();
                    colIdSP.HeaderText = "IdSubProducto";
                    colIdSP.Name = "IdSubProducto";
                    colIdSP.Visible = false;
                    dgvSubProductos.Columns.Add(colIdSP);
                }
                dgvSubProductos.Columns.Add("SubProductos", "Contenido");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmProductos_Load(object sender, EventArgs e)
        {
            CargarComboBox();
            CargarGridProd();
            CargarGridSP();
            dgvSubProductos.RowsRemoved += dgvSubProductos_RowsRemoved;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNProducto.Enabled = true;
            txtDProducto.Enabled = true;
            cbxDetalleSP.Enabled = true;
            cbxCategoria.Enabled = true;
            cbProducto.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnSubProducto.Enabled = true;
            btnCancelar.Enabled = true;
            dgvSubProductos.Enabled = true;
            banderaModificar = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNProducto.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo Nombre es requerido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDProducto.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo Descripcion es requerido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // 1. Recopilar los detalles desde el DataGridView
                List<DetalleProducto_E> detalles = new List<DetalleProducto_E>();
                foreach (DataGridViewRow row in dgvSubProductos.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var detalle = new DetalleProducto_E()
                        {
                            IdDetalleProducto = Convert.ToInt32(row.Cells["IdDetalleProducto"].Value),
                            IdSubProducto = Convert.ToInt32(row.Cells[1].Value),
                            NombreSubProducto = row.Cells[2].Value?.ToString(),
                        };
                        detalles.Add(detalle);
                    }
                }

                // 2. Crear el objeto principal y asignar la lista de detalles
                Productos_E datosFormulario = new Productos_E()
                {
                    IdProducto = Convert.ToInt32(txtNProducto.Tag),
                    NombreProducto = txtNProducto.Text.Trim(),
                    DescripcionProducto = txtDProducto.Text.Trim(),
                    CostoProducto = Convert.ToDecimal(txtCProducto.Text.Trim()),
                    PrecioProducto = Convert.ToDecimal(txtPProducto.Text.Trim()),
                    IdCategoria = Convert.ToInt32(cbxCategoria.SelectedValue),
                    EstadoProducto = cbProducto.Checked,
                    DetalleProducto = detalles // ← Aquí agregas la lista
                };

                // 3. Guardar el objeto principal con sus detalles
                if (banderaModificar == false)
                {
                    if (new Productos_L().Guardar(datosFormulario, ref mensajeError))
                    {
                        MessageBox.Show("Registro guardado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGridProd();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (new Productos_L().Actualizar(datosFormulario, ref mensajeError))
                    {
                        MessageBox.Show("Registro actualizado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGridProd();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //HABILITAR BANDERA MODIFICAR
            banderaModificar = true;
            //ACTIVAR CONTROLES
            txtNProducto.Enabled = true;
            txtDProducto.Enabled = true;
            cbxCategoria.Enabled = true;
            cbxDetalleSP.Enabled = true;
            dgvSubProductos.Enabled = true;
            cbProducto.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnSubProducto.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnSubProducto_Click(object sender, EventArgs e)
        {
            // Validar selección y entrada
            if (cbxDetalleSP.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un subproducto.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener valores
            DetalleProducto_E datosFormulario = new DetalleProducto_E()
            {
                IdDetalleProducto = Convert.ToInt32(cbxDetalleSP.Tag),
                IdSubProducto = Convert.ToInt32(cbxDetalleSP.SelectedValue),
                NombreSubProducto = cbxDetalleSP.Text.Trim(),
            };
            // Agregar al DataGridView
            dgvSubProductos.Rows.Add(
                    datosFormulario.IdDetalleProducto,
                    datosFormulario.IdSubProducto,
                    datosFormulario.NombreSubProducto);

            // Calcular el total general de suministros
            ActualizarCostoTotal();
            // Limpiar selección y entrada
            cbxDetalleSP.SelectedIndex = -1;
        }

        private void dgvProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Limpiar();

            // 1. Obtén el objeto Productos_E seleccionado
            var Producto = dgvProducto.Rows[e.RowIndex].DataBoundItem as Productos_E;
            if (Producto == null) return;

            // 2. Carga los datos principales al formulario
            txtNProducto.Tag = Producto.IdProducto;
            txtNProducto.Text = Producto.NombreProducto;
            txtDProducto.Text = Producto.DescripcionProducto;
            txtCProducto.Text = Producto.CostoProducto.ToString();
            txtPProducto.Text = Producto.PrecioProducto.ToString();
            cbxCategoria.SelectedValue = Producto.IdCategoria;
            cbProducto.Checked = Producto.EstadoProducto;

            // 3. Limpia el DataGridView de detalles
            dgvSubProductos.Rows.Clear();

            // 4. Carga los detalles al DataGridView
            foreach (var detalle in Producto.DetalleProducto)
            {
                dgvSubProductos.Rows.Add(
                    detalle.IdDetalleProducto, // Asume que esta columna es para el IdDetalleSubProducto
                    detalle.IdSubProducto,
                    detalle.NombreSubProducto
                );
            }

            // 5. Habilita los botones necesarios
            btnNuevo.Enabled = false;
            btnModificar.Enabled = true;
            btnCancelar.Enabled = true;
        }   

        private void ActualizarCostoTotal()
        {
            decimal totalCosto = 0;
            decimal totalPrecio = 0;

            foreach (DataGridViewRow row in dgvSubProductos.Rows)
            {
                if (!row.IsNewRow)
                {
                    int idSubProducto = Convert.ToInt32(row.Cells["IdSubProducto"].Value);

                    var subproducto = new SubProductos_L().ListarSubProductosActivos()
                        .FirstOrDefault(s => s.IdSubProducto == idSubProducto);

                    if (subproducto != null)
                    {
                        totalCosto += subproducto.CostoSubProducto;
                        totalPrecio += subproducto.PrecioSubProducto;
                    }
                }
            }

            txtCProducto.Text = totalCosto.ToString("F2");
            txtPProducto.Text = totalPrecio.ToString("F2");
        }

        private void dgvSubProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Calcular el total general de suministros al eliminar una fila
            ActualizarCostoTotal();
        }
    }
}
