namespace MyPet.Domain.Common.Models
{
    using MyPet.Domain.Common.Events;
    using System.Collections.Generic;
    using System.Linq;

    public class Entity<T> : IEntity
    {
        private readonly ICollection<IDomainEvent> events;

        protected Entity()
        {
            events = new List<IDomainEvent>();
        }

        public IReadOnlyCollection<IDomainEvent> Events => events.ToList();

        public void ClearEvents() => events.Clear();

        protected void AdddEvent(IDomainEvent @event) => events.Add(@event);
    }
}
