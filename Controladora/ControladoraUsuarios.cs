using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraUsuarios
    {
        private static ControladoraUsuarios _instance;

        public ControladoraUsuarios() { }

        public static ControladoraUsuarios obtenerInstancia()
        {
            if(_instance == null)
            {
                _instance = new ControladoraUsuarios();
            }
            return _instance;
        }

        public List<Usuario> getListUser()
        {
            return SingletonContexto.obtener_instancia().Contexto.Usuarios.ToList();  
        }

        public void addUser(Usuario u)
        {
            SingletonContexto.obtener_instancia().Contexto.Usuarios.Add(u);
            SingletonContexto.obtener_instancia().Contexto.SaveChanges();
        }
    }
}
