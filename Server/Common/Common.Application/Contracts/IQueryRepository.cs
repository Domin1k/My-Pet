namespace MyPet.Application.Common.Contracts
{
    using Domain.Models;

    public interface IQueryRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
    }
}
