using MyFirstAPI.Domain;
using MyFirstAPI.Domain.Common;
using MyFirstAPI.Domain.Ports;
using MyFirstAPI.Infrastructure.SqlDatabase.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstAPI.Infrastructure.SqlDatabase.Adapter
{
    public class ProductSqlRepositoryAdapter : IProductRepository
    {
        private IProductSqlRepository productSqlRepository;

        public IUnitOfWork UnitOfWork
        {
            get { return this.productSqlRepository.Context; }
        }

        public ProductSqlRepositoryAdapter(IProductSqlRepository productSqlRepository)
        {
            this.productSqlRepository = productSqlRepository;
        }

        public Product Add(Product product)
        {
            return this.productSqlRepository.Insert(product);
        }

        public async Task<Product> GetAsync(string id)
        {
            Product product = await this.productSqlRepository.SelectAsync(id);
            return product;
        }

        public void Update(Product product)
        {
            this.productSqlRepository.Update(product);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await this.productSqlRepository.GetAll();
        }
    }
}
