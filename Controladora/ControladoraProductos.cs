using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraProductos
    {
        private static ControladoraProductos _instance;

        public ControladoraProductos() { }

        public static ControladoraProductos obtenerInstancia()
        {
            if (_instance == null)
            {
                _instance = new ControladoraProductos();
            }
            return _instance;
        }

        public List<Producto> getListProductos()
        {
            return SingletonContexto.obtener_instancia().Contexto.Productos.ToList();
        }

        public Producto getProductoForName(string name)
        {
            return SingletonContexto.obtener_instancia().Contexto.Productos.FirstOrDefault(p=> p.Nombre == name);
        }

        public void AgregarProducto(Producto producto)
        {
            SingletonContexto.obtener_instancia().Contexto.Productos.Add(producto);
            SingletonContexto.obtener_instancia().Contexto.SaveChanges();
        }
        public void DeleteProducto(Producto producto)
        {
            SingletonContexto.obtener_instancia().Contexto.Productos.Remove(producto);
            SingletonContexto.obtener_instancia().Contexto.SaveChanges();
        }
    }
}
