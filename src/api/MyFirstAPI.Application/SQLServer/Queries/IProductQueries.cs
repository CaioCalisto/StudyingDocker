using MyFirstAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstAPI.Application.SQLServer.Queries
{
    public interface IProductQueries
    {
        Task<IEnumerable<Product>> GetAll();
    }
}
