using System;
using System.Collections.Generic;
using System.Linq;
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
    public class TbkController : Controller
    {
        //private readonly IActionContextAccessor _actionContextAccessor;
        //private readonly IUrlHelperFactory _urlHelperFactory;

        //public TbkController(IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor)
        //{
        //    _actionContextAccessor = actionContextAccessor;
        //    _urlHelperFactory = urlHelperFactory;
        //}

        public string llamadaWebpay()
        {
            var random = new Random();
            var buyOrder = random.Next(999999999).ToString();
            var sessionId = random.Next(999999999).ToString();
            var amount = random.Next(1000, 999999);
            //var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
            //var returnUrl = urlHelper.Action("NormalReturn", "WebpayPlus", null, Request.Scheme);
            var result = (new Transaction()).Create(buyOrder, sessionId, amount, "https://www.google.com");

            //ViewBag.BuyOrder = buyOrder;
            //ViewBag.SessionId = sessionId;
            //ViewBag.Amount = amount;
            ////ViewBag.ReturnUrl = returnUrl;
            //ViewBag.Result = result;
            //ViewBag.Action = result.Url;
            //ViewBag.Token = result.Token;

            string token = Convert.ToString(result.Token);


            return token;

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
