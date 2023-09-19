using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Web.Core.Models.Dto
{
    public class ComisionVendedorDTO
    {
        public int Mes { get; set; }
        public string? NomVendedor { get; set;}
        public decimal VentasAcumuladas { get; set; }
        public decimal ComisionAcumulada { get; set; }

    }
}
