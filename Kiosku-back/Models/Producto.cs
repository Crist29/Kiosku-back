namespace Kiosku_back.Models
{
    public class Producto
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public int precioVenta { get; set; }
        public int stock { get; set; }
        public string descripcionProd { get; set; }
        public string imagen { get; set; }

    }
}
