namespace WebHeladeria.Models
{
    public class VentaDetalleVM
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal total { get; set; }
    }
}