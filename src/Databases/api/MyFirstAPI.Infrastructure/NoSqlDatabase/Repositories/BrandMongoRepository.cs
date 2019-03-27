using MongoDB.Driver;
using MyFirstAPI.Domain;

namespace MyFirstAPI.Infrastructure.NoSqlDatabase.Repositories
{
    public class BrandMongoRepository : IBrandMongoRepository
    {
        public IMyMongoContext Context { get; }

        public BrandMongoRepository(IMyMongoContext context)
        {
            this.Context = context;
        }
        
        public Brand Insert(Brand brand)
        {
            this.Context.Brands.InsertOne(brand);
            return null;
        }

        public Brand Select(string id)
        {
            FilterDefinition<Brand> filter = Builders<Brand>.Filter.Eq("_id", id);
            return this.Context.Brands.Find(filter).First();
        }

        public void Update(Brand brand)
        {
            FilterDefinition<Brand> filter = Builders<Brand>.Filter.Eq("_id", brand.Id);
            UpdateDefinition<Brand> update = Builders<Brand>.Update
                .Set("Name", brand.Name)
                .Set("Country", brand.Country);

            this.Context.Brands.UpdateOne(filter, update);
        }
    }
}
