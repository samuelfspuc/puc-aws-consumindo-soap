using Microsoft.AspNetCore.Mvc;
using Puc.Aws.Samuel.Web.Models;
using ServiceReferenceDemo;
using System.Diagnostics;

namespace Puc.Aws.Samuel.Web.Controllers
{
    public class GetListByNameController : Controller
    {
        private readonly ILogger<GetListByNameController> _logger;

        public GetListByNameController(ILogger<GetListByNameController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public ActionResult Index(string nome)
        {
            try
            {
                var soapCliente = new SOAPDemoSoapClient();
                var resultadoWebService = soapCliente.GetListByNameAsync(nome)!.Result;

                if (resultadoWebService == null)
                    return View(new List<GetListByNameViewModel>());

                var resultadoViewModel = resultadoWebService
                                            .Select(x =>
                                            new GetListByNameViewModel(x.ID, x.Name, x.SSN, x.DOB.ToString("dd/MM/yyyy")))
                                            .OrderBy(x => x.Id)
                                            .ToList();

                return View(resultadoViewModel);

            }
            catch (Exception ex)
            {
                ViewBag.MsgErro = ex.Message;

                return View(new List<GetListByNameViewModel>());
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}