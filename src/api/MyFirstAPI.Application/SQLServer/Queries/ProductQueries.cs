using System.Collections.Generic;
using System.Threading.Tasks;
using MyFirstAPI.Domain;
using System.Data.SqlClient;
using Dapper;

namespace MyFirstAPI.Application.SQLServer.Queries
{
    public class ProductQueries : IProductQueries
    {
        private string connectionString;

        public ProductQueries(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Product>> GetAll()
        { 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<Product>(@"SELECT * FROM Product");
            } 
        }
    }
}
