using Microsoft.Extensions.Configuration;
using Pedidos.Datos.Core.Base;
using Pedidos.Datos.Core.Dto;
using Pedidos.Datos.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Pedidos.Datos.Core.Domain
{
    public class PedidosRepository : BaseRepository, IPedidosRepository
    {
        public PedidosRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<int> Guardar(SearchFilters filters) {
            var parametros = new
            {
                Cliente = filters.Cliente,
                Vendedor = filters.Vendedor
            };
            int respuesta = await ExecuteAsync("dbo.SP_PEDIDOS_INSERTAR", parametros);

            return respuesta;
        }

        public async Task<List<GetPedidosDTO>> GetPedidos()
        {
            return await QueryAsync<GetPedidosDTO>("dbo.SP_PEDIDOS_CONSULTAR");
        }

    }
}
