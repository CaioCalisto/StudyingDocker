using MyFirstAPI.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstAPI.Domain.Ports
{
    public interface IProductRepository: IRepository<Product>
    {
        Product Add(Product product);
        void Update(Product product);
        Task<Product> GetAsync(string id);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
