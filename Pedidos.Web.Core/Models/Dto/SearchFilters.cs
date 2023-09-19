using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Web.Core.Models.Dto
{
    public class SearchFilters
    {
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string? NumPedido { get; set; }
        public string? Producto { get; set;}
        public string? Precio { get; set;}
        public string? Cantidad { get; set; }
        public string? Cliente { get; set;}
        public string? Vendedor { get; set;}
        public int Mes { get; set; }
    }
}
