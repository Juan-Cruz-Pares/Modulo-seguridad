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
    public partial class FormularioListadoClientes : Form
    {
        public FormularioListadoClientes()
        {
            InitializeComponent();
        }

        private void FormularioClientes(object sender, EventArgs e)//Funcion cuando carga el formulario
        {
            List<Usuario> listaUsuarios = ControladoraUsuarios.obtenerInstancia().getListUser();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = listaUsuarios.Select(u => new
            {//objeto personalizado para mostrar en la grilla
                Nombre = u.Nombre,
                Email = u.Email,
                DNI = u.Dni,
                Perfil = u.Perfil.Nombre
            }).ToList();
        }
    }
}
