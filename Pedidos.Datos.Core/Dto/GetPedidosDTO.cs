using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Datos.Core.Dto
{
    public class GetPedidosDTO
    {
        public string? NumPedido { get; set; }
        public string? NomVendedor { get; set; }
        public string? NomCliente { get; set; }
        public string? NomDep { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
