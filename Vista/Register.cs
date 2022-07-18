﻿using Controladora;
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
            if (!ValidateEmail(email.Text)) {//Validamos formato de email

                MessageBox.Show("Formato de email no valido");
                return;
            }

            if (name.Text != "" && dni.Text != "" && password.Text != "") { //Validamos campos incompletos

                List<Perfil> perfiles = ControladoraPerfiles.obtenerInstancia().getListPerfil();// buscamos lista de perfiles
                Perfil p = perfiles.Find(x => x.Nombre == "Cliente");

                Usuario u = new Usuario();

                u.Nombre = name.Text;
                u.Email = email.Text;
                u.Dni = dni.Text;
                u.Contraseña = password.Text;
                u.Perfil = p;//Seteamos que sea cliente

                ControladoraUsuarios.obtenerInstancia().addUser(u);//agregamos cliente

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