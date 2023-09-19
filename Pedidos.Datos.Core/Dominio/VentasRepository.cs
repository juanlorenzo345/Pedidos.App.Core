using Microsoft.Extensions.Configuration;
using Pedidos.Datos.Core.Base;
using Pedidos.Datos.Core.Dto;
using Pedidos.Datos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Datos.Core.Domain
{
    public class VentasRepository : BaseRepository, IVentasRepository
    {
        public VentasRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<List<VentasAcumuladasDTO>> GetVentasAcumuladasByPeriodo(GetVentasRequestDTO Filters)
        {
            DateTime fechaInicial = DateTime.Parse(Filters.FechaInicial.ToString());
            DateTime fechaFinal = DateTime.Parse(Filters.FechaFinal.ToString());
            string fechaInicialF = fechaInicial.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            string fechaFinalF = fechaFinal.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            return await QueryAsync<VentasAcumuladasDTO>("dbo.SP_VENTASACUMULADASDEPARTAMENTOS_CONSULTAR", new { FechaInicial = fechaInicialF, FechaFinal = fechaFinalF });
        }

        public async Task<List<ComisionVendedorDTO>> GetComisionVendedorByPeriodo(GetComisionesRequestDTO Filters) {
            return await QueryAsync<ComisionVendedorDTO>("dbo.SP_COMISIONVENDEDORDEPARTAMENTOS_CONSULTAR", new { FechaInicial = Filters.FechaInicial });
        }
    }
}
