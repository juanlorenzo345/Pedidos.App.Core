using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Datos.Core.Entities
{
    public class Cliente
    {
        public string CodCli { get; set; }
        public string Nombre { get;set; }
        public string Direccion { get;set; }
        public string Telefono { get;set; }
        public int Cupo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Canal { get; set; }
        public string Vendedor { get; set; }
        public string Ciudad { get; set; }
        public string Padre { get; set; }
        
    }
}
