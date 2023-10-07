using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Kioskuback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private string connection = @"Server=localhost; Uid=root; Password=1234; Database=kiosku";

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Kiosku_back.Models.Producto> lst = null;
            using (var db = new MySqlConnection(connection))
            {
                var sql = "select id_producto,nombre,precio,precioVenta,stock,descripcionProd,imagen from producto";

                lst = db.Query<Kiosku_back.Models.Producto>(sql);
            }
            return Ok(lst);

        }


        [HttpPost]
        public IActionResult insert(Kiosku_back.Models.Producto model)
        {
            int result = 0;
            using (var db = new MySqlConnection(connection))
            {
                var sql = "insert into producto (nombre,precio,precioVenta,stock,descripcionProd,imagen)"+
                    " values (@nombre,@precio,@precioVenta,@stock,@descripcionProd,@imagen)";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }

        [HttpPut]
        public IActionResult edit(Kiosku_back.Models.Producto model)
        {
            int result = 0;
            using (var db = new MySqlConnection(connection))
            {
                var sql = "update producto set nombre=@nombre,precio=@precio,precioVenta=@precioVenta,stock=@stock,descripcionProd=@descripcionProd,imagen=@imagen"+
                    " where id_producto =@id_producto";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult delete(Kiosku_back.Models.Producto model)
        {
            int result = 0;
            using (var db = new MySqlConnection(connection))
            {
                var sql = "delete from producto where id_producto =@id_producto";     
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }


    }
}
