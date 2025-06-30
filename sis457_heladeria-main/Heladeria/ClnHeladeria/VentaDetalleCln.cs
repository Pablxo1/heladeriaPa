using CadHeladeria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnHeladeria
{
    public class VentaDetalleCln
    {
        // Método para obtener todos los detalles de venta
        public static List<VentaDetalle> GetAll()
        {
            using (var context = new HeladeriaEntities())
            {
                return context.VentaDetalle.ToList();
            }
        }

        // Método para obtener detalles de venta por ID de la venta
        public static List<VentaDetalle> GetByVentaId(int idVenta)
        {
            using (var context = new HeladeriaEntities())
            {
                return context.VentaDetalle.Where(d => d.idVenta == idVenta).ToList();
            }
        }

        // Método para obtener un detalle de venta por su ID
        public static VentaDetalle GetById(int id)
        {
            using (var context = new HeladeriaEntities())
            {
                return context.VentaDetalle.FirstOrDefault(d => d.id == id);
            }
        }

        // Método para insertar un nuevo detalle de venta
        public static void Insert(VentaDetalle VentaDetalle)
        {
            using (var context = new HeladeriaEntities())
            {
                context.VentaDetalle.Add(VentaDetalle);
                context.SaveChanges();
            }
        }

        // Método para actualizar un detalle de venta existente
        public static void Update(VentaDetalle VentaDetalle)
        {
            using (var context = new HeladeriaEntities())
            {
                var existingDetalle = context.VentaDetalle.FirstOrDefault(d => d.id == VentaDetalle.id);
                if (existingDetalle != null)
                {
                    existingDetalle.idVenta = VentaDetalle.idVenta;
                    existingDetalle.idProducto = VentaDetalle.idProducto;
                    existingDetalle.cantidad = VentaDetalle.cantidad;
                    existingDetalle.precioUnitario = VentaDetalle.precioUnitario;
                    existingDetalle.total = VentaDetalle.total;
                    existingDetalle.fechaRegistro = VentaDetalle.fechaRegistro;
                    existingDetalle.estado = VentaDetalle.estado;

                    context.SaveChanges();
                }
            }
        }

        // Método para eliminar un detalle de venta (cambia el estado a inactivo)
        public static void Delete(int id)
        {
            using (var context = new HeladeriaEntities())
            {
                var VentaDetalle = context.VentaDetalle.FirstOrDefault(d => d.id == id);
                if (VentaDetalle != null)
                {
                    VentaDetalle.estado = 0; // 0 representa estado inactivo
                    context.SaveChanges();
                }
            }
        }
    }
}
