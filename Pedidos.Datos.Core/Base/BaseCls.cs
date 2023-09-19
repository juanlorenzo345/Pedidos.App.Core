using Microsoft.Extensions.Configuration;

namespace Pedidos.Datos.Core.Base
{
    public class BaseCls
    {
        public readonly string? _strConnection;
        public string? _qry;

        public BaseCls(IConfiguration configuration)
        {
            _strConnection = configuration.GetConnectionString("DefaultConnection");
        }
    }
}
