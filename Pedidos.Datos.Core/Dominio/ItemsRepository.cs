using Microsoft.Extensions.Configuration;
using Pedidos.Datos.Core.Base;
using Pedidos.Datos.Core.Dto;
using Pedidos.Datos.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Pedidos.Datos.Core.Domain
{
    public class ItemsRepository : BaseRepository, IItemsRepository
    {
        public ItemsRepository(IConfiguration configuration) : base(configuration)
        {
            
        }
        public async Task<int> Guardar(List<SearchFilters> filters)
        {
            int totalRegistrosGuardados = 0;

            foreach (var filter in filters)
            {
                
                var parametros = new
                {
                    NumPedido = filter.NumPedido.ToString(),
                    Producto = filter.Producto,
                    Precio = filter.Precio,
                    Cantidad = filter.Cantidad
                };

                int respuesta = await ExecuteAsync("dbo.SP_ITEMS_INSERTAR", parametros);

                if (respuesta > 0)
                {
                    totalRegistrosGuardados++;
                }
            }

            return totalRegistrosGuardados;
        }

    }
}
