using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraFormularios
    {
        private static ControladoraFormularios _instance;

        public ControladoraFormularios() { }

        public static ControladoraFormularios obtenerInstancia()
        {
            if (_instance == null)
            {
                _instance = new ControladoraFormularios();
            }
            return _instance;
        }

        public List<Formulario> getListFormularios(Usuario usuario)
        {           
            return usuario.Perfil.Formulario.ToList();           
        }
    }
}
