using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKenel.Abstracts
{
    public abstract class Entity
    {
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        protected Entity(Guid id)
        {
            Id = id;
        }
        protected Entity(){ }
        public Guid Id { get; init; }
        public List<IDomainEvent> DomainEvents => _domainEvents.ToList();
        public void RaiseEvent(IDomainEvent domainEvent)
        { 
           _domainEvents.Add(domainEvent);
        }

    }
}
