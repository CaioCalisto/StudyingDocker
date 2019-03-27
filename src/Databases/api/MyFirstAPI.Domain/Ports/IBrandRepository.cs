using MyFirstAPI.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstAPI.Domain.Ports
{
    public interface IBrandRepository: IRepository<Brand>
    {
        Brand Add(Brand brand);
        void Update(Brand brand);
        Task<Brand> GetAsync(string id);
    }
}
