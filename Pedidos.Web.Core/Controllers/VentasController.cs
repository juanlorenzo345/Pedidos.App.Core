using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pedidos.Web.Core.Models;
using Pedidos.Web.Core.Models.Dto;
using System.Diagnostics;
using System.Text;

namespace Pedidos.Web.Core.Controllers
{
    public class VentasController : Controller
    {
        private readonly ILogger<VentasController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public VentasController(ILogger<VentasController> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _clientFactory = httpClientFactory;
            _configuration = configuration;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Comisiones()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult?> GetVentas([FromForm] GetVentasRequestDTO filters)
        {
            try
            {
                var json = JsonConvert.SerializeObject(filters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var model = new List<VentasAcumuladasDTO>();
                var url = $"GetVentasAcumuladasByPeriodo";

                using (var client = _clientFactory.CreateClient("ApiPedidos"))
                {
                    var response = await client.PostAsync(url, data);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<List<VentasAcumuladasDTO>>(content);
                        return View("Index",model);
                    }
                }
            }
            catch (System.Exception)
            {

            }
            return null;
        }

        [HttpPost]
        public async Task<IActionResult?> GetComisiones([FromForm] GetComisionesRequestDTO filters)
        {
            try
            {
                var json = JsonConvert.SerializeObject(filters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var model = new List<ComisionVendedorDTO>();
                var url = $"GetComisionVendedorByPeriodo";

                using (var client = _clientFactory.CreateClient("ApiPedidos"))
                {
                    var response = await client.PostAsync(url, data);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<List<ComisionVendedorDTO>>(content);
                        return View("Comisiones", model);
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