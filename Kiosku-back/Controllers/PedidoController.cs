using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Kiosku_back.Models;

namespace Kiosku_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
        private string connection = @"Server=localhost; Uid=root; Password=1234; Database=kiosku";

        [HttpGet]
        [Route("listarPedido")]
        public IActionResult Get()
        {
            IEnumerable<Kiosku_back.Models.Pedido> lst = null;
            using (var db = new MySqlConnection(connection))
            {
                var sql = "select id_pedido,id_quiosco,id_producto,id_usuario,fecha,cantidadProd,total from pedido";

                lst = db.Query<Kiosku_back.Models.Pedido>(sql);
            }
            return Ok(lst);
        }

        [HttpPost]
        [Route("agregarPedido")]
        public IActionResult insert(Kiosku_back.Models.Pedido model)
        {
            int result = 0;
            using (var db = new MySqlConnection(connection))
            {
                var sql = "insert into pedido (id_quiosco,id_producto,id_usuario,fecha,cantidadProd,total)" +
                    " values (@id_quiosco,@id_producto,@id_usuario,@fecha,@cantidadProd,@total)";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }


        [HttpDelete]
        [Route("eliminarPedido")]
        public IActionResult delete(Kiosku_back.Models.Pedido model)
        {
            int result = 0;
            using (var db = new MySqlConnection(connection))
            {
                var sql = "delete from pedido where id_pedido=@id_pedido";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }

    }
}
