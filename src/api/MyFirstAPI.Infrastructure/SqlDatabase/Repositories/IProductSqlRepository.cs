using MyFirstAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstAPI.Infrastructure.SqlDatabase.Repositories
{
    public interface IProductSqlRepository
    {
        MySqlContext Context { get; }
        Product Insert(Product product);
        Task<Product> SelectAsync(string id);
        void Update(Product product);
    }
}
