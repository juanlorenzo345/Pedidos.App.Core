﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Datos.Core.Dto
{
    public class VentasAcumuladasDTO
    {
        public string? CodDep { get; set; }
        public string? NomDep { get; set;}
        public decimal VentasAcumuladas { get;set;}
    }
}
