namespace Kiosku_back.Models
{
    public class Pedido
    {
        public int id_pedido { get; set; }
        public int id_quiosco { get; set; }
        public int id_producto { get; set; }
        public int id_usuario { get; set; }
        public string fecha { get; set; }
        public int cantidadProd { get; set; }
        public int total { get; set; }
    }
}
