using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Datos.Core.Entities
{
    public class Items
    {
        public string? NumPedido { get; set; }
        public string? Producto { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
