using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Kiosku_back.Models;

namespace Kiosku_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuioscoController : Controller
    {
        private string connection = @"Server=localhost; Uid=root; Password=1234; Database=kiosku";

        [HttpGet]
        [Route("listarQuiosco")]
        public IActionResult Get()
        {
            IEnumerable<Kiosku_back.Models.Quiosco> lst = null;
            using (var db = new MySqlConnection(connection))
            {
                var sql = "select id_quiosco,nombre_quiosco,ubicacion,correo,fecha_registro,imagen from quiosco";

                lst = db.Query<Kiosku_back.Models.Quiosco>(sql);
            }
            return Ok(lst);
        }

        [HttpPost]
        [Route("agregarQuiosco")]
        public IActionResult insert(Kiosku_back.Models.Quiosco model)
        {
            int result = 0;
            using (var db = new MySqlConnection(connection))
            {
                var sql = "insert into quiosco (nombre_quiosco,ubicacion,correo,fecha_registro,imagen)" +
                    " values (@nombre_quiosco,@ubicacion,@correo,@fecha_registro,@imagen)";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }


        [HttpPut]
        [Route("editarQuiosco")]
        public IActionResult edit(Kiosku_back.Models.Quiosco model)
        {
            int result = 0;
            using (var db = new MySqlConnection(connection))
            {
                var sql = "update quiosco set nombre_quiosco=@nombre_quiosco,ubicacion=@ubicacion,correo=@correo,fecha_registro=@fecha_registro,imagen=@imagen" +
                    " where id_quiosco =@id_quiosco";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("eliminarQuiosco")]
        public IActionResult delete(Kiosku_back.Models.Quiosco model)
        {
            int result = 0;
            using (var db = new MySqlConnection(connection))
            {
                var sql = "delete from quiosco where id_quiosco =@id_quiosco";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }

    }
}
