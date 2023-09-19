using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pedidos.Datos.Core.Base
{
    public class BaseRepository : BaseCls
    {

        public BaseRepository(IConfiguration configuration) : base(configuration)
        {

        }

        protected T QueryFirstOrDefault<T>(string sql, object? parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return connection.QueryFirstOrDefault<T>(sql, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        protected List<T> Query<T>(string sql, object? parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<T>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        protected async Task<List<T>> QueryAsync<T>(string sql, object? parameters = null)
        {
            using (var connection = CreateConnection())
            {
                var result = await connection.QueryAsync<T>(sql, parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }


        protected int Execute(string sql, object? parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return connection.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        protected async Task<int> ExecuteAsync(string sql, object? parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        protected T ExecuteScalar<T>(string sql, object? parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return connection.ExecuteScalar<T>(sql, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        private IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_strConnection);
            return connection;
        }
    }
}
