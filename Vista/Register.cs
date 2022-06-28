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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            CargarCombo();
        }

        private void CargarCombo()
        {
            List<Perfil> perfiles = ControladoraPerfiles.obtenerInstancia().getListPerfil();
            comboPerfil.Items.AddRange(perfiles.Select(x=>x.Nombre).ToArray());
        }
    }
}
