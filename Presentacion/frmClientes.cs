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
    public partial class frmClientes : Form
    {
        bool banderaModificar = false;
        string mensajeError = string.Empty;
        public frmClientes()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            txtNCliente.Enabled = false;
            txtTCliente.Enabled = false;
            txtDCliente.Enabled = false;
            txtCCliente.Enabled = false;
            cbCliente.Enabled = false;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            txtNCliente.Clear();
            txtTCliente.Clear();
            txtDCliente.Clear();
            txtCCliente.Clear();
            cbCliente.Checked = false;
            banderaModificar = false;
        }
        private void CargarGrid()
        {
            try
            {
                List<Clientes_E> clientes = new List<Clientes_E>();
                clientes = new Clientes_L().ListarClientes();
                dgvCliente.DataSource = clientes;
                dgvCliente.Columns["IdCliente"].Visible = false;
                dgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Personaliza los títulos de las columnas
                dgvCliente.Columns["NombreCliente"].HeaderText = "Nombre";
                dgvCliente.Columns["TelefonoCliente"].HeaderText = "Telefono";
                dgvCliente.Columns["DireccionCliente"].HeaderText = "Direccion";
                dgvCliente.Columns["CorreoCliente"].HeaderText = "Correo";
                dgvCliente.Columns["EstadoCliente"].HeaderText = "Estado";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNCliente.Enabled = true;
            txtTCliente.Enabled = true;
            txtDCliente.Enabled = true;
            txtCCliente.Enabled = true;
            cbCliente.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            banderaModificar = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNCliente.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo nombre es requerido", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtTCliente.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo telefono es requerido", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDCliente.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo direccion es requerido", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //crear nuevo registro
                Clientes_E datosFormulario = new Clientes_E()
                {
                    IdCliente = Convert.ToInt32(txtNCliente.Tag),
                    NombreCliente = txtNCliente.Text.Trim(),
                    TelefonoCliente = txtTCliente.Text.Trim(),
                    DireccionCliente = txtDCliente.Text.Trim(),
                    CorreoCliente = txtCCliente.Text.Trim(),
                    EstadoCliente = cbCliente.Checked
                };
                if (banderaModificar == false)
                {

                    if (new Clientes_L().Guardar(datosFormulario, ref mensajeError))
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
                    if (new Clientes_L().Actualizar(datosFormulario, ref mensajeError))
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
            txtNCliente.Enabled = true;
            txtTCliente.Enabled = true;
            txtDCliente.Enabled = true;
            txtCCliente.Enabled = true;
            cbCliente.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //RESETEAR Y LIMPIAR FORMULARIO
            Limpiar();
            //PASAR INFORMACION DEL GRID AL FORMULARIO
            txtNCliente.Tag = Convert.ToInt32(dgvCliente.Rows[e.RowIndex].Cells["IdCliente"].Value);
            txtNCliente.Text = dgvCliente.Rows[e.RowIndex].Cells["NombreCliente"].Value.ToString();
            txtTCliente.Text = dgvCliente.Rows[e.RowIndex].Cells["TelefonoCliente"].Value.ToString();
            txtDCliente.Text = dgvCliente.Rows[e.RowIndex].Cells["DireccionCliente"].Value.ToString();
            txtCCliente.Text = dgvCliente.Rows[e.RowIndex].Cells["CorreoCliente"].Value.ToString();
            cbCliente.Checked = Convert.ToBoolean(dgvCliente.Rows[e.RowIndex].Cells["EstadoCliente"].Value);
            //setear botones.
            btnNuevo.Enabled = false;
            btnModificar.Enabled = true;
            btnCancelar.Enabled = true;
        }
    }
}
