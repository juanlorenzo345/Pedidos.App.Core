using Microsoft.AspNetCore.Mvc;
using Pedidos.Datos;
using Pedidos.Datos.Core.Domain;
using Pedidos.Datos.Core.Dto;
using Pedidos.Datos.Core.Interfaces;
using Pedidos.Negocio.Core.Dto;

namespace Pedidos.Api.Core.Controllers
{
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IPedidosRepository _pedidosRepository;
        private readonly IItemsRepository _itemsRepository;

        public PedidosController(ILogger<PedidosController> logger, IConfiguration configuration, IPedidosRepository pedidosRepository, IItemsRepository itemsRepository)
        {
            _logger = logger;
            _configuration = configuration;
            _pedidosRepository = pedidosRepository;
            _itemsRepository = itemsRepository;
        }

        [HttpPost("GuardarPedido")]
        public async Task<ActionResult<int>> GuardarPedido([FromBody] SearchFilters filters)
        {
            try
            {
                int result = await _pedidosRepository.Guardar(filters);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var emex = new ErrorDetails
                {
                    StatusCode = 400,
                    Message = "Error: " + ex.Message
                };
                return BadRequest(emex);
            }
        }

        [HttpPost("GuardarItems")]
        public async Task<ActionResult<int>> GuardarItems([FromBody] List<SearchFilters> filters)
        {
            try
            {

                int result = await _itemsRepository.Guardar(filters);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var emex = new ErrorDetails
                {
                    StatusCode = 400,
                    Message = "Error: " + ex.Message
                };
                return BadRequest(emex);
            }
        }

        [HttpGet("GetPedidos")]
        public async Task<ActionResult<int>> GetPedidos()
        {
            try
            {

                List<GetPedidosDTO> result = await _pedidosRepository.GetPedidos();

                return Ok(result);
            }
            catch (Exception ex)
            {
                var emex = new ErrorDetails
                {
                    StatusCode = 400,
                    Message = "Error: " + ex.Message
                };
                return BadRequest(emex);
            }
        }

    }
}