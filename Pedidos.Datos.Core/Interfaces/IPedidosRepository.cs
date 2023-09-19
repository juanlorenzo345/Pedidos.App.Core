using Pedidos.Datos.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Datos.Core.Interfaces
{
    public interface IPedidosRepository
    {
        Task<int> Guardar(SearchFilters filters);

        Task<List<GetPedidosDTO>> GetPedidos();
    }
}
