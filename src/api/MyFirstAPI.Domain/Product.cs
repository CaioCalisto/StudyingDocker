using MyFirstAPI.Domain.Common;

namespace MyFirstAPI.Domain
{
    public class Product: Entity, IAggregateRoot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
    }
}
