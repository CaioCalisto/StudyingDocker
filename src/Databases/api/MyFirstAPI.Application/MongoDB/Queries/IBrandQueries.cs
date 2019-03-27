using MyFirstAPI.Domain;
using System.Collections.Generic;

namespace MyFirstAPI.Application.MongoDB.Queries
{
    public interface IBrandQueries
    {
        IEnumerable<Brand> GetAll();
    }
}
