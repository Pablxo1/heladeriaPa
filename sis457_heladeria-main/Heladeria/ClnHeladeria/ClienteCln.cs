using CadHeladeria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ClnHeladeria
{
    public class ClienteCln
    {
        public static int insertar(Cliente cliente)
        {
            using (var context = new HeladeriaEntities())
            {
                context.Cliente.Add(cliente);
                context.SaveChanges();
                return cliente.id;
            }
        }

        public static int actualizar(Cliente cliente)
        {
            using (var context = new HeladeriaEntities())
            {
                var existente = context.Cliente.Find(cliente.id);
                existente.nombre = cliente.nombre;
                existente.nit = cliente.nit;
                existente.celular = cliente.celular;
                existente.usuarioRegistro = cliente.usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new HeladeriaEntities())
            {
                var cliente = context.Cliente.Find(id);
                cliente.estado = -1;
                cliente.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Cliente obtenerUno(int id)
        {
            using (var context = new HeladeriaEntities())
            {
                return context.Cliente.Find(id);
            }
        }

        public static List<Cliente> listar()
        {
            using (var context = new HeladeriaEntities())
            {
                //return context.Cliente.Where(x => x.estado != -1).ToList();
                return context.Cliente
                .Include("Venta") // Esto carga la propiedad de navegación
                .Where(x => x.estado != -1)
                .ToList();
            }
        }

        public static List<paClienteListar_Result> listar(string parametro)
        {
            using (var context = new HeladeriaEntities())
            {
                return context.paClienteListar(parametro).ToList();
            }
        }
    }
}
