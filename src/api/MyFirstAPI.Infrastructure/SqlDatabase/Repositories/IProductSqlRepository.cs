using MyFirstAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstAPI.Infrastructure.SqlDatabase.Repositories
{
    public interface IProductSqlRepository
    {
        ProductSqlContext Context { get; }
        Product Insert(Product product);
        Task<Product> SelectAsync(string id);
        Task<IEnumerable<Product>> GetAll();
        void Update(Product product);
    }
}
