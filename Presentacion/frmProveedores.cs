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
    public partial class frmProveedores : Form
    {

        bool banderaModificar = false;
        string mensajeError = string.Empty;
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNProveedor.Enabled = true;
            txtTProveedor.Enabled = true;
            txtDProveedor.Enabled = true;
            txtCProveedor.Enabled = true;
            cbProveedor.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            banderaModificar = false;
        }
        private void Limpiar()
        {
            txtNProveedor.Enabled = false;
            txtTProveedor.Enabled = false;
            txtDProveedor.Enabled = false;
            txtCProveedor.Enabled = false;
            cbProveedor.Enabled = false;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            txtNProveedor.Clear();
            txtTProveedor.Clear();
            txtDProveedor.Clear();
            txtCProveedor.Clear();
            cbProveedor.Checked = false;
            banderaModificar = false;
        }
        private void CargarGrid()
        {
            try
            {
                List<Proveedores_E> proveedores = new List<Proveedores_E>();
                proveedores = new Proveedores_L().ListarProveedores();
                dgvProveedor.DataSource = proveedores;
                dgvProveedor.Columns["IdProveedor"].Visible = false;
                dgvProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Personaliza los títulos de las columnas
                dgvProveedor.Columns["NombreProveedor"].HeaderText = "Nombre";
                dgvProveedor.Columns["TelefonoProveedor"].HeaderText = "Telefono";
                dgvProveedor.Columns["DireccionProveedor"].HeaderText = "Direccion";
                dgvProveedor.Columns["CorreoProveedor"].HeaderText = "Correo";
                dgvProveedor.Columns["EstadoProveedor"].HeaderText = "Estado";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNProveedor.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo nombre es requerido", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtTProveedor.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo telefono es requerido", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDProveedor.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo direccion es requerido", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //crear nuevo registro
                Proveedores_E datosFormulario = new Proveedores_E()
                {
                    IdProveedor = Convert.ToInt32(txtNProveedor.Tag),
                    NombreProveedor = txtNProveedor.Text.Trim(),
                    TelefonoProveedor = txtTProveedor.Text.Trim(),
                    DireccionProveedor = txtDProveedor.Text.Trim(),
                    CorreoProveedor = txtCProveedor.Text.Trim(),
                    EstadoProveedor = cbProveedor.Checked
                };
                if (banderaModificar == false)
                {

                    if (new Proveedores_L().Guardar(datosFormulario, ref mensajeError))
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
                    if (new Proveedores_L().Actualizar(datosFormulario, ref mensajeError))
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
            txtNProveedor.Enabled = true;
            txtTProveedor.Enabled = true;
            txtDProveedor.Enabled = true;
            txtCProveedor.Enabled = true;
            cbProveedor.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void dgvProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //RESETEAR Y LIMPIAR FORMULARIO
            Limpiar();
            //PASAR INFORMACION DEL GRID AL FORMULARIO
            txtNProveedor.Tag = Convert.ToInt32(dgvProveedor.Rows[e.RowIndex].Cells["IdProveedor"].Value);
            txtNProveedor.Text = dgvProveedor.Rows[e.RowIndex].Cells["NombreProveedor"].Value.ToString();
            txtTProveedor.Text = dgvProveedor.Rows[e.RowIndex].Cells["TelefonoProveedor"].Value.ToString();
            txtDProveedor.Text = dgvProveedor.Rows[e.RowIndex].Cells["DireccionProveedor"].Value.ToString();
            txtCProveedor.Text = dgvProveedor.Rows[e.RowIndex].Cells["CorreoProveedor"].Value.ToString();
            cbProveedor.Checked = Convert.ToBoolean(dgvProveedor.Rows[e.RowIndex].Cells["EstadoProveedor"].Value);
            //setear botones.
            btnNuevo.Enabled = false;
            btnModificar.Enabled = true;
            btnCancelar.Enabled = true;
        }
    }
}
