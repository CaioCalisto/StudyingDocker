using MyFirstAPI.Domain.Common;

namespace MyFirstAPI.Domain
{
    public class Brand : Entity, IAggregateRoot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
