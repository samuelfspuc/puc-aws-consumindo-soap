using Microsoft.AspNetCore.Mvc;
using Puc.Aws.Samuel.Web.Models;
using ServiceReferenceDemo;
using System.Diagnostics;

namespace Puc.Aws.Samuel.Web.Controllers
{
    public class AddIntegerController : Controller
    {
        private readonly ILogger<AddIntegerController> _logger;

        public AddIntegerController(ILogger<AddIntegerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AddIntegerViewModel addIntegerViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var soapCliente = new SOAPDemoSoapClient();
                    var resultado = soapCliente.AddIntegerAsync(addIntegerViewModel.Arg1, addIntegerViewModel.Arg2).Result;

                    ViewBag.Resultado = resultado;
                }
                catch (Exception ex)
                {
                    ViewBag.MsgErro = ex.Message;
                }
                
                return View(addIntegerViewModel);
            }

            return View(addIntegerViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}