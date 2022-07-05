﻿using Controladora;
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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            Usuario usuario = ControladoraUsuarios.obtenerInstancia().usuarioActual;
            List<Formulario> formularios = usuario.Perfil.Formulario.ToList();
        }

        private void gestionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioGestionarUsuarios form = new FormularioGestionarUsuarios();
            form.Show();
        }

        private void listarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioListadoClientes form = new FormularioListadoClientes();
            form.Show();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioUsuario form = new FormularioUsuario();
            form.Show();
        }
    }
}
