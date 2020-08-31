namespace MyPet.Domain.Common
{
    using MyPet.Domain.Events;
    using System.Collections.Generic;
    using System.Linq;

    public class Entity<T> : IEntity
    {
        private readonly ICollection<IDomainEvent> events;

        protected Entity()
        {
            this.events = new List<IDomainEvent>();
        }

        public IReadOnlyCollection<IDomainEvent> Events => this.events.ToList();

        public void ClearEvents() => this.events.Clear();

        protected void AdddEvent(IDomainEvent @event) => this.events.Add(@event);
    }
}
