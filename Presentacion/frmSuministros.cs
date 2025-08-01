using Logica;
using Entidades;
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
    public partial class frmSuministros : Form
    {

        bool banderaModificar = false;
        string mensajeError = string.Empty;
        public frmSuministros()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            txtNSuministro.Enabled = false;
            txtDSuministro.Enabled = false;
            nudCSuministro.Enabled = false;
            cbxPSuministro.Enabled = false;
            cbxUnidadMedida.Enabled = false;
            nudCantidad.Enabled = false;
            nudPresentacionSuministro.Enabled = false;
            cbSuministro.Enabled = false;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            txtNSuministro.Clear();
            txtDSuministro.Clear();
            txtESuministro.Clear();
            nudCSuministro.Value = 0;
            nudCantidad.Value = 0;  
            nudPresentacionSuministro.Value = 0;  
            cbxPSuministro.SelectedIndex = -1;
            cbxUnidadMedida.SelectedIndex = -1;
            cbSuministro.Checked = false;
            banderaModificar = false;
        }
        public void CargarComboBox()
        {
            try
            {
                List<Proveedores_E> proveedoresactivos = new List<Proveedores_E>();
                proveedoresactivos = new Proveedores_L().ListarProveedoresActivos();
                cbxPSuministro.DataSource = proveedoresactivos;
                cbxPSuministro.DisplayMember = "NombreProveedor";
                cbxPSuministro.ValueMember = "IdProveedor";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarGrid()
        {
            try
            {
                List<Suministros_E> suministros = new List<Suministros_E>();
                suministros = new Suministros_L().ListarSuministros();
                dgvSuministro.DataSource = suministros;
                dgvSuministro.Columns["IdSuministro"].Visible = false;
                dgvSuministro.Columns["IdProveedor"].Visible = false;
                dgvSuministro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Personaliza los títulos de las columnas
                dgvSuministro.Columns["NombreSuministro"].HeaderText = "Nombre";
                dgvSuministro.Columns["DescripcionSuministro"].HeaderText = "Descripcion";
                dgvSuministro.Columns["Cantidad"].HeaderText = "Cantidad";
                dgvSuministro.Columns["PresentacionSuministro"].HeaderText = "Presentacion";
                dgvSuministro.Columns["ExistenciasSuministro"].HeaderText = "Existencias";
                dgvSuministro.Columns["UnidadMedida"].HeaderText = "Unidad Medida";
                dgvSuministro.Columns["NombreProveedor"].HeaderText = "Proveedor";
                dgvSuministro.Columns["CostoSuministro"].HeaderText = "Costo";
                dgvSuministro.Columns["EstadoSuministro"].HeaderText = "Estado";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmSuministros_Load(object sender, EventArgs e)
        {
            CargarComboBox();
            CargarGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNSuministro.Enabled = true;
            txtDSuministro.Enabled = true;
            cbxPSuministro.Enabled = true;
            cbxUnidadMedida.Enabled = true;
            nudCSuministro.Enabled = true;
            nudCantidad.Enabled = true;
            nudPresentacionSuministro.Enabled = true;
            cbSuministro.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            banderaModificar = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNSuministro.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo nombre es requerido", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbxPSuministro.SelectedValue == null)
            {
                MessageBox.Show("El campo proveedor es requerido", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nudCSuministro.Value == 0)
            {
                MessageBox.Show("El campo precio es requerido", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //crear nuevo registro
                Suministros_E datosFormulario = new Suministros_E()
                {
                    IdSuministro = Convert.ToInt32(txtNSuministro.Tag),
                    NombreSuministro = txtNSuministro.Text.Trim(),
                    DescripcionSuministro = txtDSuministro.Text.Trim(),
                    UnidadMedida = cbxUnidadMedida.SelectedItem.ToString().Trim(),
                    Cantidad = Convert.ToDecimal(nudCantidad.Text.Trim()),
                    PresentacionSuministro = Convert.ToDecimal(nudPresentacionSuministro.Text.Trim()),
                    ExistenciasSuministro = Convert.ToDecimal(txtESuministro.Text.Trim()),
                    IdProveedor = Convert.ToInt32(cbxPSuministro.SelectedValue),
                    CostoSuministro = Convert.ToDecimal(nudCSuministro.Text.Trim()),    
                    EstadoSuministro = cbSuministro.Checked
                };
                if (banderaModificar == false)
                {

                    if (new Suministros_L().Guardar(datosFormulario, ref mensajeError))
                    {
                        MessageBox.Show("Registro guardado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrid();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //Actualizar registro
                    if (new Suministros_L().Actualizar(datosFormulario, ref mensajeError))
                    {
                        MessageBox.Show("Registro actualizado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrid();
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
            txtNSuministro.Enabled = true;
            txtDSuministro.Enabled = true;
            cbxPSuministro.Enabled = true;
            cbxUnidadMedida.Enabled = true;
            nudCSuministro.Enabled = true;
            nudCantidad.Enabled = true;
            nudPresentacionSuministro.Enabled = true;
            cbSuministro.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            //HABILITAR BOTONES
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvSuministro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //RESETEAR Y LIMPIAR FORMULARIO
                Limpiar();
                //PASAR INFORMACION DEL GRID AL FORMULARIO
                txtNSuministro.Tag = Convert.ToInt32(dgvSuministro.Rows[e.RowIndex].Cells["IdSuministro"].Value);
                txtNSuministro.Text = dgvSuministro.Rows[e.RowIndex].Cells["NombreSuministro"].Value.ToString();
                txtDSuministro.Text = dgvSuministro.Rows[e.RowIndex].Cells["DescripcionSuministro"].Value.ToString();
                cbxPSuministro.SelectedValue = Convert.ToInt32(dgvSuministro.Rows[e.RowIndex].Cells["IdProveedor"].Value);
                cbxUnidadMedida.SelectedItem = dgvSuministro.Rows[e.RowIndex].Cells["UnidadMedida"].Value.ToString().Trim();
                nudCSuministro.Text = dgvSuministro.Rows[e.RowIndex].Cells["CostoSuministro"].Value.ToString();
                nudCantidad.Text = dgvSuministro.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString();
                nudPresentacionSuministro.Text = dgvSuministro.Rows[e.RowIndex].Cells["PresentacionSuministro"].Value.ToString();
                cbSuministro.Checked = Convert.ToBoolean(dgvSuministro.Rows[e.RowIndex].Cells["EstadoSuministro"].Value);
                //setear botones.
                btnNuevo.Enabled = false;
                btnModificar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        private void CalcularExistencias()
        {
            decimal cantidad = nudCantidad.Value;
            decimal presentacion = nudPresentacionSuministro.Value;
            decimal existencias = cantidad * presentacion;
            txtESuministro.Text = existencias.ToString("N2");
        }

        // Asocia este método a los eventos ValueChanged de los NumericUpDown
        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularExistencias();
        }

        private void nudPresentacionSuministro_ValueChanged(object sender, EventArgs e)
        {
            CalcularExistencias();
        }
    }
}
