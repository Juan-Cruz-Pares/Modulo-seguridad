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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("Datos incompletos");
            }   
            
            List<Usuario> listUser = ControladoraUsuarios.obtenerInstancia().getListUser();
            Usuario u = listUser.Find(x => (x.Nombre == username.Text || x.Email == username.Text) && x.Contraseña == password.Text);

            if (u != null)
            {
                MenuPrincipal menu = new MenuPrincipal();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos incorrectos");

            };
        }
    }
}