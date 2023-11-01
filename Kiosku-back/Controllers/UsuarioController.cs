using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Kiosku_back.Models;

namespace Kiosku_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private string connection = @"Server=localhost; Uid=root; Password=1234; Database=kiosku";

        [HttpGet]
        [Route("listarUsuario")]
        public IActionResult Get()
        {
            IEnumerable<Kiosku_back.Models.Usuario> lst = null;
            using (var db = new MySqlConnection(connection))
            {
                var sql = "select id_usuario,nombre,email,contraseña,telefono from usuario";

                lst = db.Query<Kiosku_back.Models.Usuario>(sql);
            }
            return Ok(lst);
        }

        [HttpPost]
        [Route("agregarUsuario")]
        public IActionResult insert(Kiosku_back.Models.Usuario model)
        {
            int result = 0;
            using (var db = new MySqlConnection(connection))
            {
                var sql = "insert into usuario (nombre,email,contraseña,telefono)" +
                    " values (@nombre,@email,@contraseña,@telefono)";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }

    }
}
