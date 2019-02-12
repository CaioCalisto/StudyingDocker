using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Domain;

namespace MyFirstAPI.Infrastructure.SqlDatabase.Repositories
{
    public class ProductSqlRepository : IProductSqlRepository
    {
        public ProductSqlContext Context { get; }

        public ProductSqlRepository(ProductSqlContext context)
        {
            this.Context = context;
        }
          
        public Product Insert(Product product)
        {
            return this.Context.Products.Add(product).Entity;
        }

        public async Task<Product> SelectAsync(string id)
        {
            Product product = await Context.Products.FindAsync(id);
            return product;
        }

        public void Update(Product product)
        {
            this.Context.Entry(product).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            List<Product> products = await this.Context.Products.ToListAsync();
            return products;
        }
    }
}
