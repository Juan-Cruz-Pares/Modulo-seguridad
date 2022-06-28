using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraPerfiles
    {
        private static ControladoraPerfiles _instance;

        public ControladoraPerfiles() { }

        public static ControladoraPerfiles obtenerInstancia()
        {
            if (_instance == null)
            {
                _instance = new ControladoraPerfiles();
            }
            return _instance;
        }

        public List<Perfil> getListPerfil()
        {
            return SingletonContexto.obtener_instancia().Contexto.Perfiles.ToList();
        }
    }
}
