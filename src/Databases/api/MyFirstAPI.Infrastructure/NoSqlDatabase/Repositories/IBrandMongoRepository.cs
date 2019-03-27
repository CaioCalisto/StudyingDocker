using MyFirstAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstAPI.Infrastructure.NoSqlDatabase.Repositories
{
    public interface IBrandMongoRepository
    {
        IMyMongoContext Context { get; }
        Brand Insert(Brand brand);
        Brand Select(string id);
        void Update(Brand brand);
    }
}
