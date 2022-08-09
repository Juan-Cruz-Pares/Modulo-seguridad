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
    public partial class FormularioGestionProductos : Form
    {
        public FormularioGestionProductos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(nombreTxt.TextLength == 0 ||descripcionTxt.TextLength == 0 || precioTxt.TextLength == 0 || stockTxt.TextLength == 0)
            {
                MessageBox.Show("Datos incompletos.");
                return;
            }

            if (ControladoraProductos.obtenerInstancia().getProductoForName(nombreTxt.Text) != null )              
            {
                MessageBox.Show("Producto ya ingresado en el sistema.");
                return;
            }

            Producto producto = new Producto();
            producto.Nombre = nombreTxt.Text;
            producto.Stock = descripcionTxt.Text;
            producto.Descripcion = precioTxt.Text;
            producto.Precio = stockTxt.Text;

            ControladoraProductos.obtenerInstancia().AgregarProducto(producto);
            MessageBox.Show("Producto agregado.");
            nombreTxt.Text = "";
            descripcionTxt.Text = "";
            precioTxt.Text = "";
            stockTxt.Text = "";
        }
    }
}