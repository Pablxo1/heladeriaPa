using CadHeladeria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnHeladeria
{
    public class VentaCln
    {
        public static List<Venta> GetAll()
        {
            using (var context = new HeladeriaEntities())
            {
                return context.Venta.ToList();  //Venta.Where(x => x.idCliente == idCliente && x.estado != -1).ToList();
            }
        }

        public static List<Venta> GetByid(int id)
        {
            using (var context = new HeladeriaEntities())
            {
                return context.Venta.Where(x => x.id == id && x.estado != -1).ToList();
            }
        }

        public static int insertar(Venta venta)
        {
            using (var context = new HeladeriaEntities())
            {
                context.Venta.Add(venta);
                context.SaveChanges();
                return venta.id;
            }
        }

        public static int actualizar(Venta venta)
        {
            using (var context = new HeladeriaEntities())
            {
                var existente = context.Venta.Find(venta.id);
                existente.idUsuario = venta.idUsuario;
                existente.idCliente = venta.idCliente;
                existente.tipoPago = venta.tipoPago;
                existente.montoPago = venta.montoPago;
                existente.montoCambio = venta.montoCambio;
                existente.montoTotal = venta.montoTotal;
                existente.usuarioRegistro = venta.usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new HeladeriaEntities())
            {
                var venta = context.Venta.Find(id);
                venta.estado = -1;
                venta.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Venta obtenerUno(int id)
        {
            using (var context = new HeladeriaEntities())
            {
                return context.Venta.Find(id);
            }
        }

        public static List<Venta> listar()
        {
            //using (var context = new HeladeriaEntities())
            //{
            //    // Aquí puedes incluir las propiedades de navegación si es necesario
            //    return context.Venta.Where(x => x.estado != -1).ToList();
            //}
            using (var context = new HeladeriaEntities())
            {
                return context.Venta
                    .Include("Cliente") // Carga la propiedad de navegación Cliente
                    .Include("Usuario") // Carga la propiedad de navegación Usuario
                    .Where(x => x.estado != -1)
                    .ToList();
            }
        }

        public static List<paVentaListar_Result> listarPa(string parametro)
        {
            using (var context = new HeladeriaEntities())
            {
                return context.paVentaListar(parametro).ToList();
            }
        }
    }
}
