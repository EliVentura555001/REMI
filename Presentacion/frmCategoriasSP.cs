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
    public partial class frmCategoriasSP : Form
    {
        bool banderaModificar = false;
        string mensajeError = string.Empty;
        public frmCategoriasSP()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            txtNCategoriaSP.Enabled = false;
            txtDCategoriaSP.Enabled = false;
            cbCategoriaSP.Enabled = false;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            txtNCategoriaSP.Clear();
            txtDCategoriaSP.Clear();
            cbCategoriaSP.Checked = false;
            banderaModificar = false;
        }
        private void CargarGrid()
        {
            try
            {
                List<CategoriasSubProducto_E> categoriasSP = new List<CategoriasSubProducto_E>();
                categoriasSP = new CategoriasSubProducto_L().ListarCategoriasSP();
                dgvCategoriaSP.DataSource = categoriasSP;
                dgvCategoriaSP.Columns["IdCategoriaSP"].Visible = false;
                dgvCategoriaSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Personaliza los títulos de las columnas
                dgvCategoriaSP.Columns["NombreCategoriaSP"].HeaderText = "Nombre Categoría";
                dgvCategoriaSP.Columns["DescripcionCategoriaSP"].HeaderText = "Descripción";
                dgvCategoriaSP.Columns["EstadoCategoriaSP"].HeaderText = "Estado";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmCategoriasSP_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNCategoriaSP.Enabled = true;
            txtDCategoriaSP.Enabled = true;
            cbCategoriaSP.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            banderaModificar = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNCategoriaSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo nombre es requerido", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDCategoriaSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo descripcion es requerido", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //crear nuevo registro
                CategoriasSubProducto_E datosFormulario = new CategoriasSubProducto_E()
                {
                    IdCategoriaSP = Convert.ToInt32(txtNCategoriaSP.Tag),
                    NombreCategoriaSP = txtNCategoriaSP.Text.Trim(),
                    DescripcionCategoriaSP = txtDCategoriaSP.Text.Trim(),
                    EstadoCategoriaSP = cbCategoriaSP.Checked
                };
                if (banderaModificar == false)
                {

                    if (new CategoriasSubProducto_L().Guardar(datosFormulario, ref mensajeError))
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
                    if (new CategoriasSubProducto_L().Actualizar(datosFormulario, ref mensajeError))
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
            txtNCategoriaSP.Enabled = true;
            txtDCategoriaSP.Enabled = true;
            cbCategoriaSP.Enabled = true;
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

        private void dgvCategoriaSP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //RESETEAR Y LIMPIAR FORMULARIO
                Limpiar();
                //PASAR INFORMACION DEL GRID AL FORMULARIO
                txtNCategoriaSP.Tag = Convert.ToInt32(dgvCategoriaSP.Rows[e.RowIndex].Cells["IdCategoriaSP"].Value);
                txtNCategoriaSP.Text = dgvCategoriaSP.Rows[e.RowIndex].Cells["NombreCategoriaSP"].Value.ToString();
                txtDCategoriaSP.Text = dgvCategoriaSP.Rows[e.RowIndex].Cells["DescripcionCategoriaSP"].Value.ToString();
                cbCategoriaSP.Checked = Convert.ToBoolean(dgvCategoriaSP.Rows[e.RowIndex].Cells["EstadoCategoriaSP"].Value);
                //setear botones.
                btnNuevo.Enabled = false;
                btnModificar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }        
    }
}
