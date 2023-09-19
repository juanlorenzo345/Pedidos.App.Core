using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Datos.Core.Entities
{
    public class Producto
    {
        public string CodProd { get; set; }
        public string CodDesc { get; set;}
        public string Nombre { get; set;}
        public string Familia { get; set;}
        public decimal Precio { get;set;}
    }
}
