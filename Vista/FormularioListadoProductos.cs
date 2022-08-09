using Controladora;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormularioListadoProductos : Form
    {
        public FormularioListadoProductos()
        {
            InitializeComponent();
        }

        private void FormularioListadoProductos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ControladoraProductos.obtenerInstancia().getListProductos();
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Producto;

            DialogResult respuesta = MessageBox.Show("Seguro de querer borrar el producto? Esta accion es permanente.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                ControladoraProductos.obtenerInstancia().DeleteProducto(seleccionado);

                dataGridView1.DataSource = ControladoraProductos.obtenerInstancia().getListProductos();
                dataGridView1.Columns["Id"].Visible = false;
            }
            if (respuesta == DialogResult.No)
            {
                return;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormularioGestionProductos form = new FormularioGestionProductos();
            form.Show();
            this.Close();
        }
    }
}
