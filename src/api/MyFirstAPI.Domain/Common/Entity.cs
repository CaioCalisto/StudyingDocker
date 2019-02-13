using MediatR;
using System.Collections.Generic;

namespace MyFirstAPI.Domain.Common
{
    public abstract class Entity
    {
        private List<INotification> domainEvents;

        public IEnumerable<INotification> DomainEvents
        {
            get { return this.domainEvents.AsReadOnly(); }
        }

        public Entity()
        {
            this.domainEvents = new List<INotification>();
        }

        public void AddDomainEvent(INotification eventItem)
        {
            domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            domainEvents?.Clear();
        }

    }
}
