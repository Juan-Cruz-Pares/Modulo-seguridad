using Controladora;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormularioGestionarUsuarios : Form
    {
        public FormularioGestionarUsuarios()
        {
            InitializeComponent();
        }

        private void FormularioGestionarUsuarios_Load(object sender, EventArgs e)
        {
            List<Usuario> listaUsuarios = ControladoraUsuarios.obtenerInstancia().getListUser();

            dataGridView1.DataSource = listaUsuarios;
            dataGridView1.Columns["Contraseña"].Visible = false;
            dataGridView1.Columns["Id"].Visible = false;

            Usuario usuario = ControladoraUsuarios.obtenerInstancia().usuarioActual;
            Formulario formulario = usuario.Perfil.Formulario.ToList().Find(x => x.NombreSistema == "FormularioGestionarUsuarios");
            List<Permiso> permisos = formulario.Permiso.ToList();

            permisos.ForEach(p =>
            {
                if (p.NombreSistema == "btnAgregar") btnAgregar.Enabled = true;
                else if (p.NombreSistema == "btnEliminar") btnEliminar.Enabled = true;
                else if (p.NombreSistema == "btnModificar") btnModificar.Enabled = true;
            });

            comboPerfil.DataSource = ControladoraPerfiles.obtenerInstancia().getListPerfil();
            comboPerfil.DisplayMember = "Nombre";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            user.Nombre = nombreTxt.Text;
            user.Email = emailTxt.Text;
            user.Dni = dniTxt.Text;
            user.Contraseña = Seguridad.Encriptar(passTxt.Text);
            user.Perfil = comboPerfil.SelectedValue as Perfil;

            if (ControladoraUsuarios.obtenerInstancia().getListUserForName(nombreTxt.Text) != null)  //funciones validan que el email y el nombre sean correctos, devuelven un mensaje de error y no permiten la creacion si se ingresan incorrectamente
            {
                MessageBox.Show("Nombre de usuario no valido");
                return;
            }
            if (!Validaciones.ValidateEmail(emailTxt.Text))
            {
                MessageBox.Show("El email ingresado no es valido");
                return;
            }

            ControladoraUsuarios.obtenerInstancia().addUser(user);
            MessageBox.Show("Usuario creado con exito");
            nombreTxt.Clear();
            emailTxt.Clear();
            dniTxt.Clear();
            passTxt.Clear();
            List<Usuario> listaUsuarios = ControladoraUsuarios.obtenerInstancia().getListUser();
            dataGridView1.DataSource = listaUsuarios;
            dataGridView1.Columns["Contraseña"].Visible = false;
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Usuario seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Usuario;
            nombreTxt.Text = seleccionado.Nombre;
            emailTxt.Text = seleccionado.Email;
            dniTxt.Text = seleccionado.Dni;
            comboPerfil.SelectedItem = seleccionado.Perfil;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Usuario seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Usuario;
            if (seleccionado.Nombre == ControladoraUsuarios.obtenerInstancia().usuarioActual.Nombre)
            {
                MessageBox.Show("No es posible borrar el usuario actual.");
                return;
            }

            if (seleccionado.Perfil.Nombre == "Admin" || seleccionado.Perfil.Nombre == "Super Admin")
            {
                MessageBox.Show("Imposible eliminar este usuario por su protección.");
                return;
            }

            DialogResult respuesta = MessageBox.Show("Seguro de querer borrar al usuario? Esta accion es permanente.", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                ControladoraUsuarios.obtenerInstancia().deletUser(seleccionado);

                List<Usuario> listaUsuarios = ControladoraUsuarios.obtenerInstancia().getListUser();
                dataGridView1.DataSource = listaUsuarios; //refresco la lista
                dataGridView1.Columns["Contraseña"].Visible = false;
                dataGridView1.Columns["Id"].Visible = false;
            }
            if (respuesta == DialogResult.No)
            {
                return;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Usuario usuarioactual = ControladoraUsuarios.obtenerInstancia().usuarioActual;
            Usuario seleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Usuario;
            if (usuarioactual == seleccionado ^ seleccionado.Perfil.Nombre == "Admin")
            {
                MessageBox.Show("No es posible editar este usuario.");
                return;
            }
            if (nombreTxt.Text != "" && dniTxt.Text != "" && passTxt.Text != "" && emailTxt.Text != "")
            {
                seleccionado.Dni = dniTxt.Text;
                seleccionado.Nombre = nombreTxt.Text;
                seleccionado.Email = emailTxt.Text;
                seleccionado.Contraseña = Seguridad.Encriptar(passTxt.Text);

                if (ControladoraUsuarios.obtenerInstancia().getListUserForName(nombreTxt.Text) != null)
                {
                    MessageBox.Show("Ya existe este nombre de usuario");
                    return;
                }

                if (ControladoraUsuarios.obtenerInstancia().getListUserForDNI(dniTxt.Text) != null)
                {
                    MessageBox.Show("Ya existe este nombre de usuario");
                    return;
                }

                if (Validaciones.ValidateEmail(emailTxt.Text))
                {
                    MessageBox.Show("Formato incorrecto de email.");
                    return;
                }

                if (usuarioactual.Perfil.Nombre.Contains("Admin"))
                {
                    seleccionado.Perfil = (Perfil)comboPerfil.SelectedValue;
                }
                else
                {
                    MessageBox.Show("No puede modificar el perfil a este usuario");
                    return;
                }

                SingletonContexto.obtener_instancia().Contexto.SaveChanges();

                List<Usuario> listaUsuarios = ControladoraUsuarios.obtenerInstancia().getListUser();
                dataGridView1.DataSource = listaUsuarios;
                dataGridView1.Columns["Contraseña"].Visible = false;
                dataGridView1.Columns["Id"].Visible = false;
                MessageBox.Show("Usuario modificado con exito");
                nombreTxt.Clear();
                dniTxt.Clear();
                emailTxt.Clear();
                passTxt.Clear();
            }
        }
    }
}