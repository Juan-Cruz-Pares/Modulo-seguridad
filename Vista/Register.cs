using Controladora;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!ValidateEmail(email.Text)) {

                MessageBox.Show("Formato de email no valido");
                return;
            }

            if (name.Text != "" && dni.Text != "" && password.Text != "") {

                List<Perfil> perfiles = ControladoraPerfiles.obtenerInstancia().getListPerfil();
                Perfil p = perfiles.Find(x => x.Nombre == "Cliente");

                Usuario u = new Usuario();

                u.Nombre = name.Text;
                u.Email = email.Text;
                u.Dni = dni.Text;
                u.Contraseña = password.Text;
                u.Perfil = p;

                ControladoraUsuarios.obtenerInstancia().addUser(u);

                MessageBox.Show("Registro correcto");
                this.Close();
            }
            else {
                MessageBox.Show("Datos incompletos");
                return;
            }
        }

        private bool ValidateEmail(string email)
        {            
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            
            return match.Success;                
        }
    }
}
