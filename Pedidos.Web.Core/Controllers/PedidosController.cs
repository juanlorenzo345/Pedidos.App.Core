using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pedidos.Web.Core.Models;
using Pedidos.Web.Core.Models.Dto;
using System.Diagnostics;
using System.Text;
using X.PagedList;
using static NuGet.Packaging.PackagingConstants;

namespace Pedidos.Web.Core.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public PedidosController(ILogger<PedidosController> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _clientFactory = httpClientFactory;
            _configuration = configuration;

        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10; 

            List<GetPedidosDTO>? model = await GetPedidos();

            IPagedList<GetPedidosDTO> pagedList = model.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        [HttpGet]
        public async Task<List<GetPedidosDTO>?> GetPedidos()
        {
            try
            {
                var model = new List<GetPedidosDTO>();
                var url = $"GetPedidos";

                using (var client = _clientFactory.CreateClient("ApiPedidos"))
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<List<GetPedidosDTO>>(content);
                        return model;
                    }
                }
            }
            catch (System.Exception)
            {

            }
            return null;
        }

        [HttpPost]
        public async Task<IActionResult?> PostPedidos([FromForm] PedidoDTO filters)
        {
            try
            {
                var json = JsonConvert.SerializeObject(filters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var model = new List<PedidoDTO>();
                var url = $"GuardarPedido";

                using (var client = _clientFactory.CreateClient("ApiPedidos"))
                {
                    var response = await client.PostAsync(url, data);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<List<PedidoDTO>>(content);
                        return View("Index",model);
                    }
                }
            }
            catch (System.Exception)
            {

            }
            return null;
        }

        [HttpGet]
        public IActionResult AgregarRegistro()
        {
            return PartialView("_AgregarRegistro"); 
        }

        [HttpPost]
        public async Task<IActionResult?> AgregarRegistro(PedidoDTO filters)
        {
            try
            {
                var json = JsonConvert.SerializeObject(filters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var model = new List<PedidoDTO>();
                var url = $"GuardarPedido";

                using (var client = _clientFactory.CreateClient("ApiPedidos"))
                {
                    var response = await client.PostAsync(url, data);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<List<PedidoDTO>>(content);
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (System.Exception)
            {

            }
            return null;

            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}