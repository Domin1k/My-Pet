namespace MyPet.Domain.Common.Events
{

    using System;

    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
