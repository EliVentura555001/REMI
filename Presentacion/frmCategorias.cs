using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Logica;

namespace Presentacion
{
    public partial class frmCategorias : Form
    {
        bool banderaModificar = false;
        string mensajeError = string.Empty;
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNCategoria.Enabled = true;
            txtDCategoria.Enabled = true;
            cbCategoria.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            banderaModificar = false;
        }
        private void Limpiar()
        {
            txtNCategoria.Enabled = false;
            txtDCategoria.Enabled = false;
            cbCategoria.Enabled = false;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            txtNCategoria.Clear();
            txtDCategoria.Clear();
            cbCategoria.Checked = false;
            banderaModificar = false;
        }
        private void CargarGrid()
        {
            try
            {
                List<Categorias_E> categorias = new List<Categorias_E>();
                categorias = new Categorias_L().ListarCategorias();
                dgvCategoria.DataSource = categorias;
                dgvCategoria.Columns["IdCategoria"].Visible = false;
                dgvCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Personaliza los títulos de las columnas
                dgvCategoria.Columns["NombreCategoria"].HeaderText = "Nombre Categoría";
                dgvCategoria.Columns["DescripcionCategoria"].HeaderText = "Descripción";
                dgvCategoria.Columns["EstadoCategoria"].HeaderText = "Estado";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNCategoria.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo nombre es requerido", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDCategoria.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo descripcion es requerido", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //crear nuevo registro
                Categorias_E datosFormulario = new Categorias_E()
                {
                    IdCategoria = Convert.ToInt32(txtNCategoria.Tag),
                    NombreCategoria = txtNCategoria.Text.Trim(),
                    DescripcionCategoria = txtDCategoria.Text.Trim(),
                    EstadoCategoria = cbCategoria.Checked
                };
                if (banderaModificar == false)
                {

                    if (new Categorias_L().Guardar(datosFormulario, ref mensajeError))
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
                    if (new Categorias_L().Actualizar(datosFormulario, ref mensajeError))
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
            txtNCategoria.Enabled = true;
            txtDCategoria.Enabled = true;
            cbCategoria.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            //HABILITAR BOTONES
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
        }

        private void dgvCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //RESETEAR Y LIMPIAR FORMULARIO
                Limpiar();
                //PASAR INFORMACION DEL GRID AL FORMULARIO
                txtNCategoria.Tag = Convert.ToInt32(dgvCategoria.Rows[e.RowIndex].Cells["IdCategoria"].Value);
                txtNCategoria.Text = dgvCategoria.Rows[e.RowIndex].Cells["NombreCategoria"].Value.ToString();
                txtDCategoria.Text = dgvCategoria.Rows[e.RowIndex].Cells["DescripcionCategoria"].Value.ToString();
                cbCategoria.Checked = Convert.ToBoolean(dgvCategoria.Rows[e.RowIndex].Cells["EstadoCategoria"].Value);
                //setear botones.
                btnNuevo.Enabled = false;
                btnModificar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }
    }
}
