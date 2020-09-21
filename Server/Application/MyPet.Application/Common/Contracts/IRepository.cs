﻿namespace MyPet.Application.Common.Contracts
{
    using MyPet.Domain.Common.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
        Task Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
