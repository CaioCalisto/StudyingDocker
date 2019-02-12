using MediatR;

namespace MyFirstAPI.Application.SQLServer.Commands
{
    public class CreateProductCommand: IRequest<bool>
    {
        public string Name { get; set; }
        public string Brand { get; set; }
    }
}
