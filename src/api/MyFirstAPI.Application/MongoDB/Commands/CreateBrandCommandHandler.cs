using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyFirstAPI.Domain;
using MyFirstAPI.Domain.Ports;

namespace MyFirstAPI.Application.MongoDB.Commands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, bool>
    {
        private IBrandRepository brandRepository;

        public CreateBrandCommandHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<bool> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = new Brand()
            {
                Name = request.Name,
                Country = request.Country
            };
            this.brandRepository.Add(brand);
            await this.brandRepository.UnitOfWork.SaveEntitiesAsync();
            return true;
        }
    }
}
