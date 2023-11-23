using System;
using System.Collections.Generic;
using System.Linq;
using Kiosku_back.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Patpass.PatpassByWebpay.Responses;
using Transbank.Webpay.Common;
using Transbank.Webpay.TransaccionCompleta;
using Transbank.Webpay.TransaccionCompletaMall;
using Transbank.Webpay.TransaccionCompletaMall.Common;
using Transbank.Webpay.WebpayPlus;


namespace Kiosku_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbkController : Controller
    {
        [HttpPost]
        [Route("llamadaWebpay")]
        public IActionResult llamadaWebpay()
        {
            var random = new Random();
            var buyOrder = random.Next(999999999).ToString();
            var sessionId = random.Next(999999999).ToString();
            //var amount = random.Next(1000, 999999);
            var result = (new Transaction()).Create(buyOrder, sessionId, 3600, "http://localhost:4200/login");

            string token = Convert.ToString(result.Token);
            string url = Convert.ToString(result.Url);

            var response = new WebpayResponse
            {
                Token = token,
                Url = url
            };

            return Ok(response);

        } 

        protected String GetRandomNumber()
        {
            var random = new Random();
            return random.Next(999999999).ToString();
        }

        protected String ToJson(Object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }




    }
}
