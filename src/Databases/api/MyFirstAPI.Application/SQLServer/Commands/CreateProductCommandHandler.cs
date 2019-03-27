using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyFirstAPI.Domain;
using MyFirstAPI.Domain.Ports;

namespace MyFirstAPI.Application.SQLServer.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private IProductRepository productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product()
            {
                Brand = request.Brand,
                Name = request.Name
            };
            this.productRepository.Add(product);
            await this.productRepository.UnitOfWork.SaveEntitiesAsync();
            return true;
        }
    }
}
