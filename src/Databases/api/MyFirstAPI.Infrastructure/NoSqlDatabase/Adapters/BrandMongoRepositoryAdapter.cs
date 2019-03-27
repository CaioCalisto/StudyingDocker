using MyFirstAPI.Domain;
using MyFirstAPI.Domain.Common;
using MyFirstAPI.Domain.Ports;
using MyFirstAPI.Infrastructure.NoSqlDatabase.Repositories;
using System.Threading.Tasks;

namespace MyFirstAPI.Infrastructure.NoSqlDatabase.Adapters
{
    public class BrandMongoRepositoryAdapter : IBrandRepository
    {
        private IBrandMongoRepository brandMongoRepository;
        public IUnitOfWork UnitOfWork
        {
            get { return this.brandMongoRepository.Context; }
        }

        public BrandMongoRepositoryAdapter(IBrandMongoRepository brandMongoRepository)
        {
            this.brandMongoRepository = brandMongoRepository;
        }

        public Brand Add(Brand brand)
        {
            this.brandMongoRepository.Insert(brand);
            return null;
        }
        
        public Task<Brand> GetAsync(string id)
        {
            return Task.FromResult(this.brandMongoRepository.Select(id));
        }

        public void Update(Brand brand)
        {
            this.brandMongoRepository.Update(brand);
        }
    }
}
