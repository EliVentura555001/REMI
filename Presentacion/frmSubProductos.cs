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
    public partial class frmSubProductos : Form
    {
        bool banderaModificar = false;
        string mensajeError = string.Empty;
        public frmSubProductos()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            txtNSubProducto.Enabled = false;
            txtDSubProducto.Enabled = false;
            txtISubProductos.Enabled = false;
            txtCSuministro.Enabled = false;
            cbxSDetalleSP.Enabled = false;
            cbSubProducto.Enabled = false;
            btnNuevo.Enabled = true;
            btnSuministro.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            txtNSubProducto.Clear();
            txtDSubProducto.Clear();
            txtCSubProducto.Clear();
            txtISubProductos.Clear();
            txtPSubProducto.Clear();
            txtCSuministro.Clear();
            txtSUnidadMedida.Clear();
            cbxSDetalleSP.SelectedIndex = -1;
            cbSubProducto.Checked = false;
            dgvSuministroSP.Rows.Clear();
            dgvSuministroSP.Enabled = false;

            banderaModificar = false;
        }

        public void CargarComboBox()
        {
            try
            {
                List<Suministros_E> suministrosactivos = new List<Suministros_E>();
                suministrosactivos = new Suministros_L().ListarSuministrosActivos();
                cbxSDetalleSP.DataSource = suministrosactivos;
                cbxSDetalleSP.DisplayMember = "NombreSuministro";
                cbxSDetalleSP.ValueMember = "IdSuministro";
                cbxSDetalleSP.SelectedIndex = -1;
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
                List<SubProductos_E> subProductos = new List<SubProductos_E>();
                subProductos = new SubProductos_L().ListarSubProductos();
                dgvSubProducto.DataSource = subProductos;
                dgvSubProducto.Columns["IdSubProducto"].Visible = false;
                dgvSubProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Personaliza los títulos de las columnas
                dgvSubProducto.Columns["NombreSubProducto"].HeaderText = "Nombre";
                dgvSubProducto.Columns["DescripcionSubProducto"].HeaderText = "Descripcion";
                dgvSubProducto.Columns["Instrucciones"].HeaderText = "Instrucciones";
                dgvSubProducto.Columns["CostoSubProducto"].HeaderText = "Costo";
                // Agrega columna para los suministros
                if (!dgvSubProducto.Columns.Contains("Suministros"))
                {
                    DataGridViewTextBoxColumn colSuministros = new DataGridViewTextBoxColumn();
                    colSuministros.HeaderText = "Suministros";
                    colSuministros.Name = "Suministros";
                    colSuministros.ReadOnly = true;
                    dgvSubProducto.Columns.Add(colSuministros);
                }

                dgvSubProducto.Columns["EstadoSubProducto"].HeaderText = "Estado";
                // Llena la columna con los nombres concatenados
                foreach (DataGridViewRow row in dgvSubProducto.Rows)
                {
                    var subProd = row.DataBoundItem as SubProductos_E;
                    if (subProd != null)
                    {
                        string nombres = string.Join(", ",
                        subProd.DetalleSubProducto
                        .Select(d => d.NombreSuministros)
                        .Where(n => !string.IsNullOrEmpty(n.ToString()))
                        );
                        row.Cells["Suministros"].Value = nombres;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarGridSuministros()
        {
            try
            {
                dgvSuministroSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (!dgvSuministroSP.Columns.Contains("IdSuministro"))
                {
                    DataGridViewTextBoxColumn colIdSuministros = new DataGridViewTextBoxColumn();
                    colIdSuministros.HeaderText = "IdSuministro";
                    colIdSuministros.Name = "IdSuministro";
                    colIdSuministros.Visible = false;
                    dgvSuministroSP.Columns.Add(colIdSuministros);
                }
                dgvSuministroSP.Columns.Add("Suministros", "Ingredientes");
                dgvSuministroSP.Columns.Add("Cantidades", "Cantidades");
                dgvSuministroSP.Columns.Add("CostoSuministro", "Costo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmSubProductos_Load(object sender, EventArgs e)
        {
            CargarGridSP();
            CargarGridSuministros();
            CargarComboBox(); 
            dgvSuministroSP.CellValueChanged += dgvSuministroSP_CellValueChanged;
            dgvSuministroSP.RowsRemoved += dgvSuministroSP_RowsRemoved;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNSubProducto.Enabled = true;
            txtDSubProducto.Enabled = true;
            txtISubProductos.Enabled = true;
            txtCSuministro.Enabled = true;
            cbxSDetalleSP.Enabled = true; 
            cbSubProducto.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnSuministro.Enabled = true;
            btnCancelar.Enabled = true;
            dgvSuministroSP.Enabled= true;
            banderaModificar = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNSubProducto.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo Nombre es requerido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDSubProducto.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo Descripcion es requerido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // 1. Recopilar los detalles desde el DataGridView
                List<DetalleSubProducto_E> detalles = new List<DetalleSubProducto_E>();
                foreach (DataGridViewRow row in dgvSuministroSP.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var detalle = new DetalleSubProducto_E
                        {
                            IdSuministro = Convert.ToInt32(row.Cells[0].Value),
                            NombreSuministros = row.Cells[1].Value?.ToString(),
                            CantidadSuministro = Convert.ToDecimal(row.Cells[2].Value),
                            CostoSuministro = Convert.ToDecimal(row.Cells[3].Value)
                        };
                        detalles.Add(detalle);
                    }
                }

                // 2. Crear el objeto principal y asignar la lista de detalles
                SubProductos_E datosFormulario = new SubProductos_E()
                {
                    IdSubProducto = Convert.ToInt32(txtNSubProducto.Tag),
                    NombreSubProducto = txtNSubProducto.Text.Trim(),
                    DescripcionSubProducto = txtDSubProducto.Text.Trim(),
                    Instrucciones = txtISubProductos.Text.Trim(),
                    CostoSubProducto = Convert.ToDecimal(txtCSubProducto.Text.Trim()),
                    EstadoSubProducto = cbSubProducto.Checked,
                    DetalleSubProducto = detalles // ← Aquí agregas la lista
                };

                // 3. Guardar el objeto principal con sus detalles
                if (banderaModificar == false)
                {
                    if (new SubProductos_L().Guardar(datosFormulario, ref mensajeError))
                    {
                        MessageBox.Show("Registro guardado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGridSP();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (new SubProductos_L().Actualizar(datosFormulario, ref mensajeError))
                    {
                        MessageBox.Show("Registro actualizado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGridSP();
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
            txtNSubProducto.Enabled = true;
            txtDSubProducto.Enabled = true;
            txtISubProductos.Enabled = true;
            txtCSuministro.Enabled = true;
            cbxSDetalleSP.Enabled = true;
            cbSubProducto.Enabled = true;
            dgvSuministroSP.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnSuministro.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvSubProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Limpiar();

            // 1. Obtén el objeto SubProductos_E seleccionado
            var subProducto = dgvSubProducto.Rows[e.RowIndex].DataBoundItem as SubProductos_E;
            if (subProducto == null) return;

            // 2. Carga los datos principales al formulario
            txtNSubProducto.Tag = subProducto.IdSubProducto;
            txtNSubProducto.Text = subProducto.NombreSubProducto;
            txtDSubProducto.Text = subProducto.DescripcionSubProducto;
            txtISubProductos.Text = subProducto.Instrucciones;
            txtCSubProducto.Text = subProducto.CostoSubProducto.ToString("F2");
            cbSubProducto.Checked = subProducto.EstadoSubProducto;

            // 3. Limpia el DataGridView de detalles
            dgvSuministroSP.Rows.Clear();

            // 4. Carga los detalles al DataGridView
            foreach (var detalle in subProducto.DetalleSubProducto)
            {
                dgvSuministroSP.Rows.Add( // Asume que esta columna es para el IdDetalleSubProducto
                    detalle.IdSuministro,
                    detalle.NombreSuministros,
                    ((double)detalle.CantidadSuministro),
                    detalle.CostoSuministro.ToString("F2")
                );
            }

            // 5. Habilita los botones necesarios
            btnNuevo.Enabled = false;
            btnModificar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnSuministro_Click(object sender, EventArgs e)
        {
            // Validar selección y entrada
            if (cbxSDetalleSP.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un ingrediente.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSUnidadMedida.Text.Trim() == null)
            {
                MessageBox.Show("Seleccione una unidad de medida.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCSuministro.Text))
            {
                MessageBox.Show("Ingrese una cantidad.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener valores
            DetalleSubProducto_E datosFormulario = new DetalleSubProducto_E()
            {
                IdSubProducto = Convert.ToInt32(txtCSuministro.Tag),
                IdSuministro = Convert.ToInt32(cbxSDetalleSP.SelectedValue),
                NombreSuministros = cbxSDetalleSP.Text.Trim(),
                CantidadSuministro = Convert.ToDecimal(txtCSuministro.Text.Trim()),
                CostoSuministro = CalcularCostoSuministro(Convert.ToInt32(cbxSDetalleSP.SelectedValue), Convert.ToDecimal(txtCSuministro.Text.Trim()))
            };
            // Agregar al DataGridView
            dgvSuministroSP.Rows.Add(
                    //datosFormulario.IdSubProducto,
                    datosFormulario.IdSuministro,
                    datosFormulario.NombreSuministros,
                    datosFormulario.CantidadSuministro.ToString("F2"),
                    datosFormulario.CostoSuministro.ToString("F2")
                    );

            // Calcular el total general de suministros
            ActualizarCostoTotal();
            // Limpiar selección y entrada
            cbxSDetalleSP.SelectedIndex = -1;
            txtCSuministro.Clear();
            txtSUnidadMedida.Clear();
        }

        private void cbxSDetalleSP_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Obtén el suministro seleccionado
            var suministro = cbxSDetalleSP.SelectedItem as Suministros_E;
            if (suministro != null)
            {
                // Asigna la unidad de medida al TextBox
                txtSUnidadMedida.Text = suministro.UnidadMedida?.Trim();
            }
            else
            {
                txtSUnidadMedida.Clear();
            }
        }

        // Agrega este método en la clase frmSubProductos
        private decimal CalcularCostoSuministro(int idSuministro, decimal cantidad)
        {
            // Obtener el suministro desde la lógica
            var suministro = new Suministros_L().ListarSuministrosActivos()
                .FirstOrDefault(s => s.IdSuministro == idSuministro);

            if (suministro == null || suministro.PresentacionSuministro == 0)
                return 0;

            // Cálculo: (CostoSuministro / PresentacionSuministro) * cantidad
            decimal costoUnitario = suministro.CostoSuministro / suministro.PresentacionSuministro;
            return costoUnitario * cantidad;
        }

        private void dgvSuministroSP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Solo recalcula si la columna modificada es "Cantidades"  
            if (dgvSuministroSP.Columns[e.ColumnIndex].Name == "Cantidades")
            {
                // Obtener el IdSuministro y la cantidad desde la fila modificada  
                int idSuministro = Convert.ToInt32(dgvSuministroSP.Rows[e.RowIndex].Cells["IdSuministro"].Value);
                decimal cantidad = 0;
                decimal.TryParse(dgvSuministroSP.Rows[e.RowIndex].Cells["Cantidades"].Value?.ToString(), out cantidad);

                // Calcular el costo del suministro y actualizar la celda correspondiente  
                dgvSuministroSP.Rows[e.RowIndex].Cells["CostoSuministro"].Value = CalcularCostoSuministro(idSuministro, cantidad).ToString("F2");

                // Actualizar el costo total  
                ActualizarCostoTotal();
            }
        }

        private void ActualizarCostoTotal()
        {
            decimal totalGeneral = 0;
            foreach (DataGridViewRow row in dgvSuministroSP.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Obtener el IdSuministro y la cantidad
                    int idSuministro = Convert.ToInt32(row.Cells["IdSuministro"].Value);
                    decimal cantidad = 0;
                    decimal.TryParse(row.Cells["Cantidades"].Value?.ToString(), out cantidad);

                    // Calcular el costo del suministro
                    totalGeneral += CalcularCostoSuministro(idSuministro, cantidad);
                }
            }
            txtCSubProducto.Text = totalGeneral.ToString("F2");
            txtPSubProducto.Text = (totalGeneral * 1.2m).ToString("F2"); // Margen del 20%
        }

        private void dgvSuministroSP_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            // Calcular el total general de suministros al eliminar una fila
            ActualizarCostoTotal();
        }
    }
}
