using Microsoft.AspNetCore.Mvc;
using Puc.Aws.Samuel.Web.Models;
using ServiceReferenceDemo;
using System.Diagnostics;

namespace Puc.Aws.Samuel.Web.Controllers
{
    public class DivideIntegerController : Controller
    {
        private readonly ILogger<DivideIntegerController> _logger;

        public DivideIntegerController(ILogger<DivideIntegerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DivideIntegerViewModel divideIntegerViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var soapCliente = new SOAPDemoSoapClient();
                    var resultado = soapCliente.DivideIntegerAsync(divideIntegerViewModel.Arg1, divideIntegerViewModel.Arg2).Result;

                    ViewBag.Resultado = resultado;
                }
                catch (Exception ex)
                {
                    ViewBag.MsgErro = ex.Message;
                }

                return View(divideIntegerViewModel);
            }

            return View(divideIntegerViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}