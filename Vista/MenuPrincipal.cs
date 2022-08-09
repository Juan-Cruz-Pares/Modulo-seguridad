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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            Usuario usuario = ControladoraUsuarios.obtenerInstancia().usuarioActual;
            List<Formulario> formularios = usuario.Perfil.Formulario.ToList();//Formularios habilitados para el perfil del usuario
            
            formularios.ForEach((formulario) =>
            {
                foreach (ToolStripMenuItem categoria in menuStrip1.Items)
                {                    
                    foreach (ToolStripMenuItem form in categoria.DropDownItems)
                    {                        
                        if (form.Name == formulario.NombreSistema)
                        {
                            form.Enabled = true;
                        }
                    }
                }
            });
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
    }
}
