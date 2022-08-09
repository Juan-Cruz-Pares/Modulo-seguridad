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
        public Usuario usuarioActual = null;
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

        public void agregarUsuarioActual(Usuario u)
        {
            usuarioActual = u;
        }

        public Usuario getListUserForName(string name)
        {
            return SingletonContexto.obtener_instancia().Contexto.Usuarios.FirstOrDefault(usuario => usuario.Nombre == name);
        }
        public Usuario getListUserForDNI(string dni)
        {
            return SingletonContexto.obtener_instancia().Contexto.Usuarios.FirstOrDefault(usuario => usuario.Dni == dni);
        }
        
        public void deletUser(Usuario usuario)
        {
            SingletonContexto.obtener_instancia().Contexto.Usuarios.Remove(usuario);
            SingletonContexto.obtener_instancia().Contexto.SaveChanges();
        }
    }
}
