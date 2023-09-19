using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Datos.Core.Entities
{
    public class Pedido
    {
        public string? NumPedido { get; set; }
        public string? Cliente { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Vendedor { get; set; }
    }
}
