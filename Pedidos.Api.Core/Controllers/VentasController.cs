using Microsoft.AspNetCore.Mvc;
using Pedidos.Datos;
using Pedidos.Datos.Core.Domain;
using Pedidos.Datos.Core.Dto;
using Pedidos.Datos.Core.Interfaces;
using Pedidos.Negocio.Core.Dto;

namespace Pedidos.Api.Core.Controllers
{
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly ILogger<VentasController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IVentasRepository _ventasRepository;
     
        public VentasController(ILogger<VentasController> logger, IConfiguration configuration, IVentasRepository ventasRepository)
        {
            _logger = logger;
            _configuration = configuration;
            _ventasRepository = ventasRepository;
            
        }

        [HttpPost("GetVentasAcumuladasByPeriodo")]
        public async Task<ActionResult<List<VentasAcumuladasDTO>>> GetVentasAcumuladasByPeriodo([FromBody] GetVentasRequestDTO filters)
        {
            try
            {
                List<VentasAcumuladasDTO> result = await _ventasRepository.GetVentasAcumuladasByPeriodo(filters);

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

        [HttpPost("GetComisionVendedorByPeriodo")]
        public async Task<ActionResult<List<ComisionVendedorDTO>>> GetComisionVendedorByPeriodo([FromBody] GetComisionesRequestDTO filters)
        {
            try
            {
                List<ComisionVendedorDTO> result = await _ventasRepository.GetComisionVendedorByPeriodo(filters);

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