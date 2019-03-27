using System.Collections.Generic;
using MongoDB.Driver;
using MyFirstAPI.Domain;

namespace MyFirstAPI.Application.MongoDB.Queries
{
    public class BrandQueries : IBrandQueries
    {
        private IMongoDatabase db;

        public BrandQueries(string connectionString, string database)
        {
            IMongoClient client = new MongoClient(connectionString);
            db = client.GetDatabase(database);
        }

        public IEnumerable<Brand> GetAll()
        {
            return db.GetCollection<Brand>("Brands")
                .Find(Builders<Brand>.Filter.Empty)
                .ToList();
        }
    }
}
