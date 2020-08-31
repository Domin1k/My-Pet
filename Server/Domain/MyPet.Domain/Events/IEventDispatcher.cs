﻿namespace MyPet.Domain.Events
{
    using System.Threading.Tasks;

    public interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
