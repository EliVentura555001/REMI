using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }


        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frmclientes = new frmClientes();
            frmclientes.ShowDialog();
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductos frmproductos = new frmProductos();
            frmproductos.ShowDialog();
        }

        private void subproductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSubProductos frmsubproductos = new frmSubProductos();
            frmsubproductos.ShowDialog();
        }

        private void ingredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSuministros frmsuministros = new frmSuministros();
            frmsuministros.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores frmproveedores = new frmProveedores();
            frmproveedores.ShowDialog();
        }

        private void ordenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrden frmorden = new frmOrden();
            frmorden.ShowDialog();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPedido frmpedido = new frmPedido();
            frmpedido.ShowDialog();
        }

        private void categoriasProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategorias frmcategorias = new frmCategorias();
            frmcategorias.ShowDialog();
        }

        private void categoriasSubproductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoriasSP frmcategoriassp = new frmCategoriasSP();
            frmcategoriassp.ShowDialog();
        }
    }
}
