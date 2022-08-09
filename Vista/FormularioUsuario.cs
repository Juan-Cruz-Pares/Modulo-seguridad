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
    public partial class FormularioUsuario : Form
    {
        public FormularioUsuario()
        {
            InitializeComponent();
        }

        private void FormularioUsuario_Load(object sender, EventArgs e)
        {
            Usuario usuario = ControladoraUsuarios.obtenerInstancia().usuarioActual;
            nombreTxt.Text = usuario.Nombre;
            emailTxt.Text = usuario.Email;
            nombreTxt.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuarioactual = ControladoraUsuarios.obtenerInstancia().usuarioActual;

            if(usuarioactual.Email == emailTxt.Text)
            {
                MessageBox.Show("No se modifico el email.");
                return;
            }

            usuarioactual.Email = emailTxt.Text;
            SingletonContexto.obtener_instancia().Contexto.SaveChanges();
            MessageBox.Show("Email modificado.");
            this.Close();
        }
    }
}
