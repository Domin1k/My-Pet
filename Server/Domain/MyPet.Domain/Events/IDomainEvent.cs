﻿namespace MyPet.Domain.Events
{

    using System;

    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
